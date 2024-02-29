using ETicaretApi.Application.Exceptions;
using ETicaretApi.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;


namespace ETicaretApi.Application.Features.Commands.AppUsers.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        readonly UserManager<AppUser> _userManager;

        public CreateUserCommandHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            IdentityResult identityResult = await _userManager.CreateAsync(new()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = request.UserName,
                Email = request.Email
            }, request.Password);

            CreateUserCommandResponse response = new CreateUserCommandResponse() { Success = identityResult.Succeeded };

            if (identityResult.Succeeded)
                return new()
                {
                    Success = true,
                    Message = "User Created"
                };

            else
                foreach (var error in identityResult.Errors)
                    response.Message += $"{error.Code} - {error.Description}";

            return response;


            //throw new UserCreateFailedException("Failed create user");


        }


    }
}
