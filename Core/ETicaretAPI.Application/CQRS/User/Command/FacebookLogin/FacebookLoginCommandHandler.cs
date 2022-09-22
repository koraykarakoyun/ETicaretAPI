using ETicaretAPI.Application.CQRS.User.Command.GoogleLogin;
using ETicaretAPI.Application.DTOs;
using ETicaretAPI.Application.Token;
using ETicaretAPI.Domain.Entities.Identity;
using Google.Apis.Auth.OAuth2;
using MediatR;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.User.Command.FacebookLogin
{
    public class FacebookLoginCommandHandler : IRequestHandler<FacebookLoginCommandRequest, FacebookLoginCommandResponse>
    {

        UserManager<AppUser> _userManager;
        ITokenHandler _tokenHandler;
        HttpClient _httpClient;


        public FacebookLoginCommandHandler(UserManager<AppUser> userManager, ITokenHandler tokenHandler, IHttpClientFactory httpClientFactory)
        {
            _userManager = userManager;
            _tokenHandler = tokenHandler;
            _httpClient = httpClientFactory.CreateClient();
        }
        public async Task<FacebookLoginCommandResponse> Handle(FacebookLoginCommandRequest request, CancellationToken cancellationToken)
        {

            string response = await _httpClient.GetStringAsync("https://graph.facebook.com/oauth/access_token?client_id=630541088591232&client_secret=cc4f81b42f98add5b9b02e3641e71d47&grant_type=client_credentials");

            FacebookAccessTokenResponse facebookAccessTokenResponse = JsonSerializer.Deserialize<FacebookAccessTokenResponse>(response);



            string useraccesstokenValidation = await _httpClient.GetStringAsync($"https://graph.facebook.com/debug_token?input_token={request.AccessToken}&access_token={facebookAccessTokenResponse.AccessToken}");


            FacebookUserInfoValidation facebookUserInfoValidation = JsonSerializer.Deserialize<FacebookUserInfoValidation>(useraccesstokenValidation);

            if (facebookUserInfoValidation.Data.IsValid)
            {
                string userinforesponse = await _httpClient.GetStringAsync($"https://graph.facebook.com/me?fields=email,name&access_token={request.AccessToken}");
                UserInfoResponse userInfoResponse = JsonSerializer.Deserialize<UserInfoResponse>(userinforesponse);

                var info = new UserLoginInfo("Facebook", facebookUserInfoValidation.Data.UserId, "Facebook");

                //login tablosunda google girişi yapan kisinin bilgileri aranır
                AppUser appUser = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);

                bool result = appUser != null;

                //login tablosunda kisi bulunamazsa kisiyi login tablosuna kaydeder.
                if (appUser == null)
                {

                    //kullanıcıyı user tablosunda arar
                    appUser = await _userManager.FindByEmailAsync(userInfoResponse.Email);

                    //kullanıcı user tablosunda yoksa
                    if (appUser == null)
                    {
                        appUser = new AppUser()
                        {
                            Id = Guid.NewGuid().ToString(),
                            Name = userInfoResponse.Name,
                            Surname = userInfoResponse.Name,
                            UserName = userInfoResponse.Name,
                            Email = userInfoResponse.Email
                        };
                        //kullanıcı yoksa user tablosuna kaydeder.
                        var identityResult = await _userManager.CreateAsync(appUser);
                        result = identityResult.Succeeded;
                    }
                    result = true;
                   
                }

                if (result)
                {
                    await _userManager.AddLoginAsync(appUser, info);
                    DTOs.Token token = _tokenHandler.CreateAccessToken(5);

                    return new FacebookLoginCommandResponse()
                    {
                        Token = token
                    };
                }

            }

            throw new Exception();

        }
    }
}
