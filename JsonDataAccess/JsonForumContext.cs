using System.Text.Json;
using Assigntment1.models;
using Entities.Models;

namespace JsonDataAccess;

public class JsonForumContext
{
    private string userPath = "MyForum.json";
    private ICollection<SubForum>? forums;

    
    public ICollection<SubForum> Forums {
        get {
            if (forums==null) {
                LoadData();
            }

            return forums;    
        }
    }

    public JsonForumContext()
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
        forums = new List<SubForum>();
        Task.FromResult(SaveChangesAsync());
    }

    private void LoadData() {
        string usersAsJson = File.ReadAllText(userPath);
        forums = JsonSerializer.Deserialize<List<SubForum>>(usersAsJson);
    }

    public async Task SaveChangesAsync()
    {
        string usersAsJson = JsonSerializer.Serialize(forums, new JsonSerializerOptions
        {
            WriteIndented = true,
            PropertyNameCaseInsensitive = false
        });
        await File.WriteAllTextAsync(userPath,usersAsJson);
        forums = null;
    }
}