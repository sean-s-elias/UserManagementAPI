using Application.Commands;
using Application.Core;
using Application.Query;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace UserManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        //private IMediator _mediator;
        //protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        private IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            return await _mediator.Send(new UserQuery());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteUser(int id)
        {
            return await _mediator.Send(new DeleteUserCommand { UserId = id });
        }

        [HttpPost]
        public async Task<ActionResult<Result<Unit>>> CreateUser(User user)
        {
            return await _mediator.Send(new CreateUserCommand { User = user });
        }

        [HttpPut]
        public async Task<ActionResult<Result<Unit>>> UpdateUser(User user)
        {
            return await _mediator.Send(new UpdateUserCommand { User = user });
        }
    }
}