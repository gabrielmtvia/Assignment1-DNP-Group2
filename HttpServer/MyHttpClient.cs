using System.Text;
using System.Text.Json;
using Assigntment1.models;
using Contracts;

namespace HttpServer;

public class MyHttpClient : ISubForum
{
    // public async Task<ICollection<SubForum>> GetAsync()
    // {
    //    
    //     
    // }

    public async Task<SubForum> CreateAPost(SubForum subForum)
    {
        using HttpClient client = new();

        string todoAsJson = JsonSerializer.Serialize(subForum);

        StringContent content = new(todoAsJson, Encoding.UTF8, "application/json");

        HttpResponseMessage response = await client.PostAsync("https://localhost:7204/todos", content);
        string responseContent = await response.Content.ReadAsStringAsync();
        
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Error: {response.StatusCode}, {responseContent}");
        }
        
        SubForum returned = JsonSerializer.Deserialize<SubForum>(responseContent, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        
        return returned;
    }

    public async Task<List<SubForum>?> GetAllTitlesAsync()
    {
        using HttpClient client = new ();
        
        HttpResponseMessage response = await client.GetAsync("https://localhost:7012/Forum");
        string content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Error: {response.StatusCode}, {content}");
        }

        ICollection<SubForum> subForums = JsonSerializer.Deserialize<ICollection<SubForum>>(content)!;
        return subForums as List<SubForum>;
    }

    public Task<SubForum> GetPostById(Guid id)
    {
        throw new NotImplementedException();
    }
}    