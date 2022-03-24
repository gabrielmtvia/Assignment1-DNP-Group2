using Entities.Models;

namespace Assigntment1.models;

public class Comment
{
    
    public User Body
    {
        set;
        get;
    }
    
    public User WrittenBy
    {
        set;
        get;
    }
}