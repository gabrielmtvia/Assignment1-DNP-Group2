using Assigntment1.models;

namespace Contracts;

public interface ISubForum
{
   Task CreateAPost(SubForum subForum);

   Task<List<SubForum>?> GetAllTitlesAsync();
   Task<SubForum> GetPostById(Guid id);
}