using AdoptionCenterDA.Web.Models;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;

namespace AdoptionCenterDA.Web.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly AuthenticationStateProvider _authenticationStateProvider;


    public AuthService(
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        AuthenticationStateProvider authenticationStateProvider)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _authenticationStateProvider = authenticationStateProvider;
    }



    public async Task<bool> RegisterAsync(
        string fullName,
        string email,
        string password)
    {
        var user = new ApplicationUser
        {
            UserName = email,
            Email = email,
            FullName = fullName
        };


        var result = await _userManager.CreateAsync(user, password);


        if (result.Succeeded)
        {
            await _userManager.AddToRoleAsync(user, "User");

            await _signInManager.SignInAsync(
                user,
                isPersistent: false);

            return true;
        }


        return false;
    }



    public async Task<bool> LoginAsync(
        string email,
        string password)
    {
        var result = await _signInManager.PasswordSignInAsync(
            email,
            password,
            false,
            false);


        return result.Succeeded;
    }



    public async Task LogoutAsync()
    {
        await _signInManager.SignOutAsync();
    }



    public async Task<ApplicationUser?> GetCurrentUserAsync()
    {
        var authState =
            await _authenticationStateProvider
                .GetAuthenticationStateAsync();


        var user =
            authState.User;


        if (!user.Identity!.IsAuthenticated)
        {
            return null;
        }


        return await _userManager
            .GetUserAsync(user);
    }
}
