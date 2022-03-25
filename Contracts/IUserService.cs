using System.Security.Claims;
using Entities.Models;

namespace Contracts;

public interface IUserService
{
    Task CreateUserAsync(string username, string password);
    Task LoginAsync(string username, string password);
    Task LogoutAsync();
    public Task<User?> GetUserAsync(string username);
    public Task<ClaimsPrincipal?> GetUserAsync();
    public Action<ClaimsPrincipal> OnAuthStatesChanged { get; set; }
}