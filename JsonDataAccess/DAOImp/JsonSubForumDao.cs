using Application;
using Assigntment1.models;
using Entities.Models;

namespace JsonDataAccess;

public class JsonSubForumDao : SubForumDao
{
    private JsonForumContext context;

    public JsonSubForumDao(JsonForumContext context)
    {
        this.context = context;
    }

    public async Task CreateAPost(string title, string description)
    {
        SubForum subForum = new SubForum(title, description);
        //subForum.OwnedBy = User
        subForum.Guid = Guid.NewGuid();

        context.Forums.Add(subForum);
        await context.SaveChangesAsync();
    }

    public async Task<List<SubForum>?> GetAllTitlesAsync()
    {
        return context.Forums.ToList();
    }

    public async Task<SubForum> getPostById(Guid id)
    {
        return context.Forums.First(t => t.Guid.Equals(id));
    }
}