using ETicaretApi.Application.DTOs;
using MediatR;

namespace ETicaretApi.Application.Features.Commands.AppUsers.LoginUser
{
    public class LoginUserCommandResponse 
    {
    }

    public class LoginUserSuccessCommandResponse : LoginUserCommandResponse 
    {
        public Token Token { get; set; }
    }

    public class LoginUserErrorCommandResponse : LoginUserCommandResponse 
    {
        public string MessageError { get; set; }
    }
}
