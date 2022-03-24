using System.Text.Json;
using Entities.Models;

namespace JsonDataAccess;

public class JsonContext
{
    private string userPath = "users.json";
    private ICollection<User> users;

    public ICollection<User> Users {
        get {
            if (users==null) {
                LoadData();
            }

            return users;   //TODO ask troels what this ! does....
        }
    }

    public JsonContext()
    {
        if (File.Exists(userPath))
        {
            LoadData();
        }
        else
        {
            CreateFile();
        }
    }

    private void CreateFile() {
        users = new List<User>();
        Task.FromResult(SaveChangesAsync());
    }

    private void LoadData() {
        string usersAsJson = File.ReadAllText(userPath);
        users = JsonSerializer.Deserialize<List<User>>(usersAsJson);
    }

    public async Task SaveChangesAsync()
    {
        string usersAsJson = JsonSerializer.Serialize(users, new JsonSerializerOptions
        {
            WriteIndented = true,
            PropertyNameCaseInsensitive = false
        });
        await File.WriteAllTextAsync(userPath,usersAsJson);
        users = null;
    }
}