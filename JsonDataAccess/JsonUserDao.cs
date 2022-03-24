using Application;
using Entities.Models;

namespace JsonDataAccess;

public class JsonUserDao : IUserDao
{
    private JsonContext context;

    public JsonUserDao(JsonContext context)
    {
        this.context = context;
    }

    public async Task SaveUserAsync(User user)
    {
        context.Users.Add(user);
        await context.SaveChangesAsync();
    }

    public async Task<User> GetUserAsync(string username)
    {
        List<User> users = context.Users.ToList();
        User? find = users.Find(user => user.Username.Equals(username));
        return find;
    }

    public async Task<bool>? UsernameExist(string username)
    {
        ICollection<User> allUsers = context.Users;

        return allUsers.Any(user => user.Username.Equals(username));
    }
}