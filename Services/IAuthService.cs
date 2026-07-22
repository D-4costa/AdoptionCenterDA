using AdoptionCenterDA.Web.Models;

namespace AdoptionCenterDA.Web.Services;

public interface IAuthService
{
    Task<bool> RegisterAsync(string fullName, string email, string password);

    Task<bool> LoginAsync(string email, string password);

    Task LogoutAsync();

    Task<ApplicationUser?> GetCurrentUserAsync();
}
