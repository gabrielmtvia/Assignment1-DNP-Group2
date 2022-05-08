using Application;
using Assigntment1.models;
using Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EfcData;

public class SubForumDAO : SubForumDao

{

    private readonly Context context;

    public SubForumDAO(Context context)
    {
        this.context = context;
    }

    public async Task<SubForum> CreateAPost(SubForum subForum)
    {
        EntityEntry<SubForum> added = await context.AddAsync(subForum);
        await context.SaveChangesAsync();
        return added.Entity;
    }

    public async Task<List<SubForum>?> GetAllTitlesAsync()
    {
        ICollection<SubForum> sub = await context.SubForums.ToListAsync();
        return (List<SubForum>?) sub;
    }

    // public async Task<SubForum> GetPostById(Guid id)
    // {
    //     SubForum? sub =  await context.SubForums.FindAsync(id);
    //     
    //    
    //     return sub; 
    //
    // }

    public async Task<SubForum?> getPostById(Guid id)
    {
        SubForum? sub =  await context.SubForums.FindAsync(id);
        
       
     return sub; 
     
       
    
    }

    
}

//     public  Task<SubForum> GetPostById(Guid id)
//     {
//     //     IQueryable<SubForum> sub = context.SubForums.AsQueryable();
//     //     if (id != null)
//     //     {
//     //         sub = sub.Where(subForum => subForum.Guid == id);
//     //     }
//     //
//     //     
//     //     return await sub.ToListAsync();
//     //      
//     // }
//     throw new NotImplementedException();
// }