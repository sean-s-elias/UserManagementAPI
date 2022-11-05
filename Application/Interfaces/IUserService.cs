using Domain;

namespace Application.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetUsers();
    }
}
