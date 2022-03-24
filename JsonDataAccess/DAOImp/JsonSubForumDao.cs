using Application;
using Assigntment1.models;

namespace JsonDataAccess;


public class JsonSubForumDao : SubForumDao
{
    private JsonForumContext context;
    public async Task CreateAPost(string title, string description)
    {
       SubForum subForum = new SubForum(title, description);
        
        await context.SaveChangesAsync();

    }
}