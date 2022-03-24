using Assigntment1.models;

namespace Application;

public interface SubForumDao
{
     Task CreateAPost(String title, String description );
}