using Application.Core;
using Domain;
using MediatR;

namespace Application.Commands
{
    public class UpdateUserCommand : IRequest<Result<Unit>>
    {
        public User User { get; set; }
    }
}
