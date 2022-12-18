using Domain;
using MediatR;

namespace Application.Query
{
    public class UserQuery : IRequest<List<User>> { }
}
