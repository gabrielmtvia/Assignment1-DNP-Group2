using Entities.Models;

namespace Application;

public interface IUserDao
{
    Task SaveUserAsync(User user);
    Task<User> GetUserAsync(string username);
    Task<bool> UsernameExist(string username);
}