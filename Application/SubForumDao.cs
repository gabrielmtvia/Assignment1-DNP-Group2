using Assigntment1.models;

namespace Application;

public interface SubForumDao
{
     Task<SubForum> CreateAPost(SubForum subForum);
     Task<List<SubForum>?> GetAllTitlesAsync();

     Task<SubForum> getPostById(Guid id);
}