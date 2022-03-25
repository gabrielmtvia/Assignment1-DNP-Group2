using Entities.Models;

namespace Assigntment1.models;

public class Post
{
    public User writtenBy
    {
        set;
        get;
    }
    public String Header
    {
        set;
        get;    
    }
    public String Body
    {
        set;
        get;    
    }
    
}