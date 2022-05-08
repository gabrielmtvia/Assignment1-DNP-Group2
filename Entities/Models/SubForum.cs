using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Models;

namespace Assigntment1.models;

public class SubForum
{
    
    [Key]
    public Guid Guid
    {
        set;
        get;
    }
    // [NotMapped] means iam just ignoring this object wather it has Fk or not, try remove this key and read the error from compiler
    [NotMapped]
    public User? OwnedBy
    {
        set;
        get;
    }
    public String? Title
    {
        set;
        get;
    }

    public String? Description
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