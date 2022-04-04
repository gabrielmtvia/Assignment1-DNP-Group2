using Entities.Models;

namespace Assigntment1.models;

public class SubForum
{
    
  
    public Guid Guid
    {
        set;
        get;
    }
    
    public User OwnedBy
    {
        set;
        get;
    }
    public String Title
    {
        set;
        get;
    }

    public String Description
    {
        set;
        get;
    }

    public SubForum( string title, string description)
    {
        
        Title = title;
        Description = description;
    }
    public SubForum() {
       // AllSubForums = new List<SubForum>();

    }
       
    
   // public ICollection<Post> Posts { get; set; }
}