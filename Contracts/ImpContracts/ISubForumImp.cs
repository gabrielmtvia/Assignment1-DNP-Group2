using System.Diagnostics;
using Application;
using Assigntment1.models;

namespace Contracts.ImpContracts;

public class ISubForumImp : ISubForum
{

    private SubForumDao subForumDao;


    public ISubForumImp(SubForumDao subForumDao)
    {
        this.subForumDao = subForumDao;
    }

    public async Task CreateAPost(string title, string description )
    {
       await subForumDao.CreateAPost(title, description );
    }

    public async Task<List<SubForum>?> GetAllTitlesAsync()
    {
        return await subForumDao.GetAllTitlesAsync();
    }

    public async Task<SubForum> GetPostById(Guid id)
    {
        return await subForumDao.getPostById(id);
    }
}