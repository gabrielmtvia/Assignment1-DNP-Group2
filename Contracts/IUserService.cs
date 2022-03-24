using Entities.Models;

namespace Contracts;

public interface IUserService
{
    Task CreateUserAsync(string username, string password);
    Task LoginAsync(string username, string password);
    Task LogoutAsync();
    public Task<User?> GetUserAsync(string username);
}