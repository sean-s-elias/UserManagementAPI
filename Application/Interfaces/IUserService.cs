using Application.Core;
using Domain;
using MediatR;

namespace Application.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetUsers();
        Task<Result<Unit>> CreateUser(User request);
        Task<Result<Unit>> UpdateUser(User request);
        Task<bool> DeleteUser(int userId);
    }
}
