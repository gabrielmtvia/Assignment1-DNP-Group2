using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Entities.Models;

 [Keyless]
public class User
{

    [MaxLength(50)]
   
    public string? Username { get; set; }

    public  string? Password { get; set; }
 

    public User(string Username, string Password) {
        this.Username = Username;
        this.Password = Password;
     
    }
    
    public User(string Username) {
        this.Username = Username;
    }

    public User() {

    }
   
}