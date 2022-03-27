using Assigntment1.models;

namespace Contracts;

public interface ISubForum
{
   Task CreateAPost(String title, String forumdescriptionId);

   Task<List<SubForum>?> GetAllTitlesAsync();
   Task<SubForum> GetPostById(Guid id);
}