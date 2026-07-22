using AdoptionCenterDA.Web.Models;
using AdoptionCenterDA.Web.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;

namespace AdoptionCenterDA.Web.Pages;

public partial class Register
{
    [Inject]
    private IAuthService AuthService { get; set; } = default!;

    [Inject]
    private NavigationManager Navigation { get; set; } = default!;

    protected RegisterModel RegisterModel { get; set; } = new();

    protected string ErrorMessage { get; set; } = string.Empty;

    protected async Task RegisterAsync()
    {
        ErrorMessage = string.Empty;

        IdentityResult result = await AuthService.RegisterAsync(
            RegisterModel.FullName,
            RegisterModel.Email,
            RegisterModel.Password);

        if (result.Succeeded)
        {
            Navigation.NavigateTo("/");
            return;
        }

        ErrorMessage = string.Join(
            Environment.NewLine,
            result.Errors.Select(error => error.Description));
    }
}
