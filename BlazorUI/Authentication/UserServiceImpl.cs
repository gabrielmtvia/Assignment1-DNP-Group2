using System.Security.Claims;
using System.Text.Json;
using Application;
using Contracts;
using Entities.Models;
using Microsoft.JSInterop;

namespace BlazorUI;

public class UserServiceImpl : IUserService
{
    public Action<ClaimsPrincipal> OnAuthStateChanged { get; set; } = null!;
    private readonly IUserDao userDao;
    private readonly IJSRuntime jsRuntime;
    private ClaimsPrincipal? principal;
    public String currentUser;
    public UserServiceImpl(IUserDao userDao, IJSRuntime jsRuntime)
    {
        this.userDao = userDao;
        this.jsRuntime = jsRuntime;
    }
    

    public async Task CreateUserAsync(string username, string password)
    {
        validateUsername(username);
        validatePassword(password);
        
        //if (await userDao.UsernameExist(username)) {
        //    throw new Exception($"Error: Username, {username} already exists.");
       // }

        await userDao.SaveUserAsync(new User(username, password)); 
    }

    

    public async Task LoginAsync(string username, string password)
    {
        User? user = await userDao.GetUserAsync(username); // Get user from database

        ValidateLoginCredentials(password, user); // Validate input data against data from database
        // validation success
        await CacheUserAsync(user!); // Cache the user object in the browser 

        ClaimsPrincipal principal = CreateClaimsPrincipal(user); // convert user object to ClaimsPrincipal

        OnAuthStateChanged?.Invoke(principal); // notify interested classes in the change of authentication state
    }

    public async Task LogoutAsync()
    {
        await ClearUserFromCacheAsync(); // remove the user object from browser cache
        ClaimsPrincipal principal = CreateClaimsPrincipal(null); // create a new ClaimsPrincipal with nothing.
        OnAuthStateChanged?.Invoke(principal); // notify about change in authentication state
    }

    public async Task<ClaimsPrincipal?> GetUserAsync()
    {
        if (principal != null)
        {
            return principal;
        }

        string userAsJson = await jsRuntime.InvokeAsync<string>("sessionStorage.getItem", "currentUser");
        if (string.IsNullOrEmpty(userAsJson))
        {
            return new ClaimsPrincipal(new ClaimsIdentity());
        }

        return principal;
    }

    private async Task ClearUserFromCacheAsync()
    {
        await jsRuntime.InvokeVoidAsync("sessionStorage.setItem", "currentUser", "");
        
    }

    private ClaimsPrincipal CreateClaimsPrincipal(User? user)
    {
        if (user != null)
        {
            ClaimsIdentity identity = ConvertUserToClaimsIdentity(user);
            return new ClaimsPrincipal(identity);
        }

        return new ClaimsPrincipal();
    }

    private ClaimsIdentity ConvertUserToClaimsIdentity(User user)
    {
        List<Claim> claims = new()
        {
            new Claim(ClaimTypes.Name, user.Username),
            /*new Claim("Role", user.Role),
            new Claim("SecurityLevel", user.SecurityLevel.ToString()),
            new Claim("BirthYear", user.BirthYear.ToString()),
            new Claim("Domain", user.Domain)*/
        };

        return new ClaimsIdentity(claims, "apiauth_type");
    }

    public async Task CacheUserAsync(User user)
    {
        string serialisedData = JsonSerializer.Serialize(user);
        await jsRuntime.InvokeVoidAsync("sessionStorage.setItem", "currentUser", serialisedData);
    }

    public void  ValidateLoginCredentials(string password, User user)
    {
        if (user==null) {
            throw new Exception("Username not found");
        }

        if (!password.Equals(user.Password))
        {
            throw new Exception("Password Incorrect");
        }

        GetCurrentUser(user.Username);
       

    }

    public void GetCurrentUser(String userName)
    {
        currentUser = userName;
   
        Console.WriteLine( "i am here in user serviceImp "+ currentUser);
    }
    
    
    public async Task<User?> GetUserAsync(string username)
    {
        throw new NotImplementedException();
    }
    
    private void validateUsername(string username)
    {
        if (string.IsNullOrEmpty(username)) {
            throw new Exception("Username cannot be empty");
        }
        if (username.Length <= 5) {
            throw new Exception("Username must be greater than five characters");
        }
    }
    
    private void validatePassword(string password)
    {
        if (string.IsNullOrEmpty(password)) {
            throw new Exception("Password cannot be empty"); 
        }

        if (password.Length <= 5) {
            throw new Exception("Password must be greater than five characters");
        }

        int count = 0;
        foreach (char c in password) {
            if (Char.IsNumber(c)) {
                count++;
                break;
            }
        }

        if (count == 0) {
            throw new Exception("Password must have at least one digit for security reasons");
        }
    }
}