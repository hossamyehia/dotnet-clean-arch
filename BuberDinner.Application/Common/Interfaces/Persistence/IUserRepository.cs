using BuberDinner.Domain.User;

namespace BuberDinner.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    // User GetUserById(Guid id);
    User? GetUserByEmail(string email);
    void AddUser(User user);
}
