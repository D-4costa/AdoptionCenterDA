using AdoptionCenterDA.Web.Models;
using Microsoft.AspNetCore.Identity;

namespace AdoptionCenterDA.Web.Services;

public interface IAuthService
{
    Task<IdentityResult> RegisterAsync(
        string fullName,
        string email,
        string password);

    Task<SignInResult> LoginAsync(
        string email,
        string password,
        bool rememberMe = false);

    Task LogoutAsync();

    Task<ApplicationUser?> GetCurrentUserAsync();

    Task<bool> IsInRoleAsync(
        ApplicationUser user,
        string role);

    Task EnsureRolesCreatedAsync();
}
