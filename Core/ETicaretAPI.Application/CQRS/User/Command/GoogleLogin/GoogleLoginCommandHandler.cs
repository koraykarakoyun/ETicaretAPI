using ETicaretAPI.Application.Token;
using ETicaretAPI.Domain.Entities.Identity;
using Google.Apis.Auth;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.User.Command.GoogleLogin
{
    public class GoogleLoginCommandHandler : IRequestHandler<GoogleLoginCommandRequest, GoogleLoginCommandResponse>
    {
        UserManager<AppUser> _userManager;
        ITokenHandler _tokenHandler;

        public GoogleLoginCommandHandler(UserManager<AppUser> userManager, ITokenHandler tokenHandler)
        {
            _userManager = userManager;
            _tokenHandler = tokenHandler;
        }

        public async Task<GoogleLoginCommandResponse> Handle(GoogleLoginCommandRequest request, CancellationToken cancellationToken)
        {
            var settings = new GoogleJsonWebSignature.ValidationSettings()
            {
                Audience = new List<string> { "858096983515-prmmpeohub6v3u5smr2cc02o6u4mkn2v.apps.googleusercontent.com" }
            };

            var payload = await GoogleJsonWebSignature.ValidateAsync(request.IdToken, settings);

            var info = new UserLoginInfo(request.Provider, payload.Subject, request.Provider);

            //login tablosunda google girişi yapan kisinin bilgileri aranır
            AppUser appUser = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);

            bool result = appUser != null;

            //login tablosunda kisi bulunamazsa kisiyi login tablosuna kaydeder.
            if (appUser == null)
            {

                //kullanıcıyı user tablosunda arar
                appUser = await _userManager.FindByEmailAsync(payload.Email);

                //kullanıcı user tablosunda yoksa
                if (appUser == null)
                {
                    appUser = new AppUser()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = payload.GivenName,
                        Surname = payload.FamilyName,
                        UserName = payload.Name,
                        Email = payload.Email,
                    };
                    //kullanıcı yoksa user tablosuna kaydeder.
                    var identityResult = await _userManager.CreateAsync(appUser);
                    result = identityResult.Succeeded;
                }
            }

            if (result)
            {
                await _userManager.AddLoginAsync(appUser, info);
            }

            return new GoogleLoginCommandResponse()
            {
                Token = _tokenHandler.CreateAccessToken(5)
            };

        }
    }
}
