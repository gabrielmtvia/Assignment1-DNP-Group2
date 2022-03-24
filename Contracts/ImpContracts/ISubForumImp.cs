using Application;

namespace Contracts.ImpContracts;

public class ISubForumImp : ISubForum
{

    private SubForumDao subForumDao;
    public async Task CreateAPost(string title, string description )
    {
       await subForumDao.CreateAPost(title, description );
    }
}