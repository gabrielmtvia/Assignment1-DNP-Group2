using Application;
using Assigntment1.models;

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
        context.Forums.Add(subForum);
        await context.SaveChangesAsync();

    }
}