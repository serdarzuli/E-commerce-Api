using MediatR;

namespace ETicaretApi.Application.Features.Commands.AppUsers.GoogleLogin
{
    public class GoogleloginCommandRequest : IRequest<GoogleLoginCommandResponse>
    {
        public string Id { get; set; }
        public string IdToken { get; set; }    
        public string FirstName { get; set; }
        public string Name { get; set; }   
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Provider { get; set; }
    }
}
