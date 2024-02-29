using ETicaretApi.Application.Abstractions.Tokens;
using ETicaretApi.Application.DTOs;
using ETicaretApi.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApi.Application.Features.Commands.AppUsers.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
    {
        readonly UserManager<AppUser> _userManager;
        readonly SignInManager<AppUser> _signInManager;
        readonly ITokenHandler _tokenHandler;

        public LoginUserCommandHandler(UserManager<AppUser> userManager,
                                       SignInManager<AppUser> signInManager,
                                       ITokenHandler tokenHandler)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenHandler = tokenHandler;
        }

        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            AppUser user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null)
            {
                user = await _userManager.FindByEmailAsync(request.Email);
            }
            if (user == null)
            {
                throw new Exceptions.NotFoundUserException();
            }

            SignInResult auth = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            if (auth.Succeeded) //auth successed
            {
                Token token = _tokenHandler.CreateAccessToken(5);

                return new LoginUserSuccessCommandResponse()
                {
                    Token = token
                };

            }

            //Singel responsibility 
            return new LoginUserErrorCommandResponse()
            {
                MessageError = "Token failed"
            };

            //throw new Exceptions.AuthenticationErrorException();
        }
    }
}
