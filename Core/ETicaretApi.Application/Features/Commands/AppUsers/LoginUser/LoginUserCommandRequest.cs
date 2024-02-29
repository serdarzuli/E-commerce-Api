using MediatR;

namespace ETicaretApi.Application.Features.Commands.AppUsers.LoginUser
{
    public class LoginUserCommandRequest : IRequest<LoginUserCommandResponse>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }   
    }
}
