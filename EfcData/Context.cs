using Assigntment1.models;
using Microsoft.EntityFrameworkCore;

namespace EfcData;

public class Context : DbContext
{
    //The DbSet<SubForum>. represents the SubForum table in the database
    public DbSet<SubForum> SubForums { get; set; }

    //The OnConfiguring(...) method is here used to specify the database to be used This is done with the method UseSqlite(...).
    //Sqlite is just a single file, so that makes it easier to work with, instead of having to use Postgres or MySql or similar.
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(@"Data Source = C:\Users\hamod\DNPTutorial\Assignment1-DNP-Group2\EfcData\SubForums.db");
    }
    
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //This says that the Entity .SubForum has a Key, defined as the property SubForum.guid.\
        modelBuilder.Entity<SubForum>().HasKey(s => s.Guid);
    }
    
    public void Seed()
    {
        if (SubForums.Any()) return;

        SubForum[] ts =
        {
            new SubForum("world cup", "soon"),
            new SubForum("news", "is bad"),
          
        };
        //The method AddRange(..) just takes some kind of collection, and adds all elements.
        //When calling SaveChanges(), whatever you've done to your DbSets, e.g. added, updated,
        //removed, etc, those changes will be applied to the database, in one transaction.
        SubForums.AddRange(ts);
        SaveChanges();
    }
}