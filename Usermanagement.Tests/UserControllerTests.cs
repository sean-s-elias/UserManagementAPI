using Application.Commands;
using Application.Core;
using Application.Interfaces;
using Domain;
using MediatR;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Usermanagement.Tests
{
    [TestFixture]
    public class UserControllerTests
    {
        private readonly Mock<IUserService> _userService;

        public UserControllerTests()
        {
            _userService = new Mock<IUserService>();
        }

        [Test]
        public async Task DeleteUser_NotSuccessful_NoIdDeleted()
        {
            //Arrange
            var command = new DeleteUserCommand { UserId = 3 };
            _userService.Setup(x => x.DeleteUser(It.IsAny<int>())).ReturnsAsync(false);

            var handler = new DeleteUserCommandHandler(_userService.Object);

            //Act
            //var result = await handler.Handle(command, default);
            var result = await handler.Handle(command, default);

            //Assert
            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public async Task DeleteUser_Successful_IdDeleted()
        {
            Result<Unit> expected = new Result<Unit>();
            //Arrange
            var command = new DeleteUserCommand { UserId = 1 };
            _userService.Setup(x => x.DeleteUser(It.IsAny<int>())).ReturnsAsync(true);
            var handler = new DeleteUserCommandHandler(_userService.Object);

            //Act
            var result = await handler.Handle(command, default);

            //Assert
            Assert.That(result, Is.EqualTo(true));
        }
    }
}
