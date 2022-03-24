namespace Contracts;

public interface ISubForum
{
   Task CreateAPost(String title, String forumdescriptionId);
    
}