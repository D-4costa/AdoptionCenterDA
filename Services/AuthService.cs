using AdoptionCenterDA.Web.Models;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;

namespace AdoptionCenterDA.Web.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly AuthenticationStateProvider _authenticationStateProvider;

    public AuthService(
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        RoleManager<IdentityRole> roleManager,
        AuthenticationStateProvider authenticationStateProvider)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _roleManager = roleManager;
        _authenticationStateProvider = authenticationStateProvider;
    }

    public async Task<IdentityResult> RegisterAsync(
        string fullName,
        string email,
        string password)
    {
        await EnsureRolesCreatedAsync();

        var user = new ApplicationUser
        {
            UserName = email,
            Email = email,
            FullName = fullName,
            RegistrationDate = DateTime.Now
        };

        var result = await _userManager.CreateAsync(user, password);

        if (result.Succeeded)
        {
            await _userManager.AddToRoleAsync(user, "User");

            await _signInManager.SignInAsync(user, isPersistent: false);
        }

        return result;
    }

    public async Task<SignInResult> LoginAsync(
        string email,
        string password,
        bool rememberMe = false)
    {
        return await _signInManager.PasswordSignInAsync(
            email,
            password,
            rememberMe,
            lockoutOnFailure: false);
    }

    public async Task LogoutAsync()
    {
        await _signInManager.SignOutAsync();
    }

    public async Task<ApplicationUser?> GetCurrentUserAsync()
    {
        var authState =
            await _authenticationStateProvider.GetAuthenticationStateAsync();

        var principal = authState.User;

        if (principal.Identity is null || !principal.Identity.IsAuthenticated)
            return null;

        return await _userManager.GetUserAsync(principal);
    }

    public async Task<bool> IsInRoleAsync(
        ApplicationUser user,
        string role)
    {
        return await _userManager.IsInRoleAsync(user, role);
    }

    public async Task EnsureRolesCreatedAsync()
    {
        if (!await _roleManager.RoleExistsAsync("Admin"))
        {
            await _roleManager.CreateAsync(new IdentityRole("Admin"));
        }

        if (!await _roleManager.RoleExistsAsync("User"))
        {
            await _roleManager.CreateAsync(new IdentityRole("User"));
        }
    }
}
