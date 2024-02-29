using MediatR;

namespace ETicaretApi.Application.Features.Commands.AppUsers.CreateUser
{
    public class CreateUserCommandRequest : IRequest<CreateUserCommandResponse>
    {

        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }



    }
}
