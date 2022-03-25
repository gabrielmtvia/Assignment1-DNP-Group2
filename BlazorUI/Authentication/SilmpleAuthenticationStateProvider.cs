using System.Security.Claims;
using Contracts;
using Microsoft.AspNetCore.Components.Authorization;

namespace Blazor.Authentication;


public class SimpleAuthenticationStateProvider : AuthenticationStateProvider
{
    private readonly IUserService iUserService;

    public SimpleAuthenticationStateProvider(IUserService iUserService)
    {
        
        /*
         * In the constructor, the second line, we subscribe to events from the IAuthService,
         * i.e. when you log in, an event will be fired. In that case,
         * we want the SimpleAuthenticationStateProvider
         * to notify the blazor app about a change to the current authentication state:
         * The method AuthStateChanged is called upon such an event,
         * and this method itself notifies the app about a change.
         */
        this.iUserService = iUserService;
        iUserService.OnAuthStatesChanged += AuthStateChanged;
    }

    // This method is called by Blazor framework whenever authentication or authorization needs to be evaluated.
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        ClaimsPrincipal principal = await iUserService.GetUserAsync(); // get the user-as-ClaimsPrincipal from IAuthService
        return await Task.FromResult(new AuthenticationState(principal));
    }

    private void AuthStateChanged(ClaimsPrincipal principal)
    {
        NotifyAuthenticationStateChanged(
            Task.FromResult(
                new AuthenticationState(principal)
            )
        );
    }
}