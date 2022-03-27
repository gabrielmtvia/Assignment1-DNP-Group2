using Assigntment1.models;

namespace Application;

public interface SubForumDao
{
     Task CreateAPost(String title, String description );
     Task<List<SubForum>?> GetAllTitlesAsync();

     Task<SubForum> getPostById(Guid id);
}