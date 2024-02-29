using MediatR;

namespace ETicaretApi.Application.Features.Commands.AppUsers.CreateUser
{
    public class CreateUserCommandResponse : IRequest<CreateUserCommandRequest>
    {

        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
