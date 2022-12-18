using Application.Interfaces;
using Application.Query;
using Domain;
using MediatR;

namespace Application.Queries
{
    public class UserQueryHandler : IRequestHandler<UserQuery, List<User>>
    {
        private readonly IUserService _userService;
        public UserQueryHandler(IUserService userAccessor)
        {
            _userService = userAccessor;
        }
        public async Task<List<User>> Handle(UserQuery request, CancellationToken cancellationToken)
        {
            var res = await _userService.GetUsers();

            return res;
        }
    }
}
