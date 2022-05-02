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

    public async Task<SubForum> CreateAPost(SubForum subForum)
    {
        //subForum.OwnedBy = User
         
       // subForum.OwnedBy.Username = 
        context.Forums.Add(subForum);
        await  context.SaveChangesAsync();
          return subForum;
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