using Application.Core;
using Domain;
using MediatR;

namespace Application.Commands
{
    public class CreateUserCommand : IRequest<Result<Unit>>
    {
        public User User { get; set; }
    }
}
