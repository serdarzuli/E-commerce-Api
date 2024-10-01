using ETicaretApi.Application.Abstractions.Services;
using ETicaretApi.Application.Abstractions.Tokens;
using ETicaretApi.Application.DTOs;
using ETicaretApi.Domain.Entities.Identity;
using Google.Apis.Auth;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApi.Application.Features.Commands.AppUsers.GoogleLogin
{
    public class GoogleLoginCommandHandler : IRequestHandler<GoogleloginCommandRequest, GoogleLoginCommandResponse>
    {
        readonly UserManager<AppUser> _userManager;
        readonly ITokenHandler _tokenHandler;

        public GoogleLoginCommandHandler(UserManager<AppUser> userManager, ITokenHandler tokenHandler)
        {
            _userManager = userManager;
            _tokenHandler = tokenHandler;
        }
        public async Task<GoogleLoginCommandResponse> Handle(GoogleloginCommandRequest request, CancellationToken cancellationToken)
        {
            var settings = new GoogleJsonWebSignature.ValidationSettings()
            {
                Audience = new List<string> { "......." }
            };

            var payload = await GoogleJsonWebSignature.ValidateAsync(request.IdToken, settings);

            var userLoginInfo =  new UserLoginInfo(request.Provider, payload.Subject, request.Provider);

            AppUser user = await _userManager.FindByLoginAsync(userLoginInfo.LoginProvider, userLoginInfo.ProviderKey);
            bool result = user != null;
            if (user == null)
            {
                user = await _userManager.FindByEmailAsync(payload.Email); //nolur nolmaz aspnetlogins tablosunda belki kayiti yoktur ama emaili basksa ismle vardir garantiye almak icin boyle bir kosul ekliyoruz
                if (user == null)
                {
                    user = new() 
                    { 
                        Id = Guid.NewGuid().ToString(), 
                        Email = payload.Email, 
                        UserName = payload.Email, 
                        NameSurname = payload.Name 
                    };

                    IdentityResult createResult = await _userManager.CreateAsync(user);
                    result = createResult.Succeeded;
                }
            }

            if (result)
                await _userManager.AddLoginAsync(user, userLoginInfo); //aspnetuserlogin tablosuna ekledik
            else
                throw new Exception("Invalid external authentication.");

            Token token =  _tokenHandler.CreateAccessToken(5);
            return new() { Token = token };

        }
    }
}
