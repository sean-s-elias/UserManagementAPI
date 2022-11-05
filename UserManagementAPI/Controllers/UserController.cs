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
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            return await Mediator.Send(new UserQuery());
        }
    }
}