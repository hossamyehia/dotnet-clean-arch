using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Entities;

namespace BuberDinner.Infrastructure.Persistence;

public class UserRepository : IUserRepository
{

    private static readonly List<User> _users = new List<User>();

    public User? GetUserByEmail(string email)
    {
        return _users.SingleOrDefault<User>(u => u.Email == email);
    }

    public void AddUser(User user)
    {
        _users.Add(user);
    }

}
