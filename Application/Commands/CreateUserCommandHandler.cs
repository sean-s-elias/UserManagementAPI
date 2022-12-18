using Application.Core;
using Application.Interfaces;
using MediatR;

namespace Application.Commands
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result<Unit>>
    {
        private readonly IUserService _userService;

        public CreateUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<Result<Unit>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var userRequest = request.User;

            return await _userService.CreateUser(userRequest);
        }
    }
}
