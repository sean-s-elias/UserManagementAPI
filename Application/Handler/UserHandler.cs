using Application.Interfaces;
using Application.Query;
using Domain;
using MediatR;

namespace Application.Handler
{
    public class UserHandler : IRequestHandler<UserQuery, List<User>>
    {
        private readonly IUserService _userService;
        public UserHandler(IUserService userAccessor)
        {
            _userService = userAccessor;
        }

        public async Task<List<User>> Handle(UserQuery request, CancellationToken cancellationToken)
        {
            return await _userService.GetUsers();
        }
    }
}
