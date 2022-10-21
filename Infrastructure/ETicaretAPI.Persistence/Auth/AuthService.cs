using ETicaretAPI.Application.Abstraction.Auth;
using ETicaretAPI.Application.Abstraction.User;
using ETicaretAPI.Application.CQRS.User.Command.FacebookLogin;
using ETicaretAPI.Application.CQRS.User.Command.GoogleLogin;
using ETicaretAPI.Application.CQRS.User.Command.Login;
using ETicaretAPI.Application.DTOs;
using ETicaretAPI.Application.Token;
using ETicaretAPI.Domain.Entities.Identity;
using Google.Apis.Auth;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static Google.Apis.Requests.BatchRequest;

namespace ETicaretAPI.Persistence.Auth
{
    public class AuthService : IAuthService
    {
        UserManager<AppUser> _userManager;
        SignInManager<AppUser> _signInManager;
        ITokenHandler _tokenHandler;
        HttpClient _httpClient;
        IConfiguration _configuration;
        IUserService _userService;
        public AuthService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenHandler tokenHandler, IHttpClientFactory httpClientFactory, IConfiguration configuration, IUserService userService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenHandler = tokenHandler;
            _httpClient = httpClientFactory.CreateClient();
            _configuration = configuration;
            _userService = userService;
        }

        private async Task<LoginDto> CreateUserExternalAsync(AppUser appUser, string email, string name, UserLoginInfo info, int TokenLifeTime_Seconds)
        {
            bool result = appUser != null;

            //login tablosunda kisi bulunamazsa kisiyi login tablosuna kaydeder.
            if (appUser == null)
            {

                //kullanıcıyı user tablosunda arar
                appUser = await _userManager.FindByEmailAsync(email);

                //kullanıcı user tablosunda yoksa
                if (appUser == null)
                {
                    appUser = new AppUser()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = name,
                        Surname = name,
                        UserName = name,
                        Email = email
                    };
                    //kullanıcı yoksa user tablosuna kaydeder.
                    var identityResult = await _userManager.CreateAsync(appUser);
                    if (!identityResult.Succeeded)
                    {

                        LoginDto response = new LoginDto()
                        {
                            IsSuccess = false,
                        };

                        foreach (var error in identityResult.Errors)
                        {
                            response.Message += error.Description;
                        }

                        return response;

                    }
                    result = identityResult.Succeeded;
                }
                result = true;

            }

            if (result)
            {
                await _userManager.AddLoginAsync(appUser, info);
                Token token = _tokenHandler.CreateAccessToken(TokenLifeTime_Seconds,appUser);
                await _userService.UpdateRefreshToken(appUser, token.RefreshToken, token.Expiration, 5);


                return new LoginDto()
                {
                    IsSuccess = true,
                    Message = "Basarili giris",
                    Token = token
                };

            }
            return new LoginDto()
            {
                IsSuccess = false,
                Message = "Hatali Giris"
            };

        }


        public async Task<LoginDto> FacbookLogin(string AccessToken, int TokenLifeTime_Seconds)
        {
            string response = await _httpClient.GetStringAsync($"https://graph.facebook.com/oauth/access_token?client_id={_configuration["ExternalService:Facebook:Client_Id"]}&client_secret={_configuration["ExternalService:Facebook:Client_Secret"]}&grant_type=client_credentials");
            FacebookAccessTokenResponse facebookAccessTokenResponse = JsonSerializer.Deserialize<FacebookAccessTokenResponse>(response);
            string useraccesstokenValidation = await _httpClient.GetStringAsync($"https://graph.facebook.com/debug_token?input_token={AccessToken}&access_token={facebookAccessTokenResponse.AccessToken}");
            FacebookUserInfoValidation facebookUserInfoValidation = JsonSerializer.Deserialize<FacebookUserInfoValidation>(useraccesstokenValidation);

            if (facebookUserInfoValidation.Data.IsValid)
            {
                string userinforesponse = await _httpClient.GetStringAsync($"https://graph.facebook.com/me?fields=email,name&access_token={AccessToken}");
                UserInfoResponse userInfoResponse = JsonSerializer.Deserialize<UserInfoResponse>(userinforesponse);

                var info = new UserLoginInfo("FACEBOOK", facebookUserInfoValidation.Data.UserId, "FACEBOOK");

                //login tablosunda google girişi yapan kisinin bilgileri aranır
                AppUser appUser = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);
                return await CreateUserExternalAsync(appUser, userInfoResponse.Email, userInfoResponse.Name, info, TokenLifeTime_Seconds);

            }

            return new LoginDto()
            {
                IsSuccess = false,
                Message = "Hatali Giris"
            };
        }

        public async Task<LoginDto> GoogleLogin(string IdToken, int TokenLifeTime_Seconds)
        {

            var settings = new GoogleJsonWebSignature.ValidationSettings()
            {
                Audience = new List<string> { _configuration["ExternalService:Google:App_Id"] }
            };

            var payload = await GoogleJsonWebSignature.ValidateAsync(IdToken, settings);

            var info = new UserLoginInfo("GOOGLE", payload.Subject, "GOOGLE");

            //login tablosunda google girişi yapan kisinin bilgileri aranır
            AppUser appUser = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);

            return await CreateUserExternalAsync(appUser, payload.Email, payload.Name, info, TokenLifeTime_Seconds);


        }

        public async Task<LoginDto> Login(string Email, string Password, int TokenLifeTime_Seconds)
        {
            AppUser user = await _userManager.FindByEmailAsync(Email);

            if (user == null)
            {
                return new LoginDto()
                {
                    IsSuccess = false,
                    Message = "Email Veya Sifre Yanlis"
                };
            }

            SignInResult signInResult = await _signInManager.CheckPasswordSignInAsync(user, Password, false);

            if (signInResult.Succeeded)
            {
                //kullanıcı login oldu.
                ETicaretAPI.Application.DTOs.Token token = _tokenHandler.CreateAccessToken(TokenLifeTime_Seconds,user);
                await _userService.UpdateRefreshToken(user, token.RefreshToken, token.Expiration, 200);
                return new LoginDto()
                {
                    IsSuccess = true,
                    Message = "Giris yapildi.",
                    Token = token
                };

            }

            return new LoginDto()
            {
                IsSuccess = false,
                Message = "Email Veya Sifre Yanlis"
            };

        }

        public async Task<Token> RefreshTokenLogin(string RefreshToken)
        {

            AppUser appUser = await _userManager.Users.FirstOrDefaultAsync(p => p.RefreshToken == RefreshToken);

            if (appUser != null && appUser.RefreshTokenLifeTime > DateTime.UtcNow)
            {
                Token token = _tokenHandler.CreateAccessToken(300, appUser);
                await _userService.UpdateRefreshToken(appUser, token.RefreshToken, token.Expiration, 200);
                return token;
            }
            else
            {
                throw new Exception("Islemi yapmak için yetkiniz yok");
            }

        }


    }
}
