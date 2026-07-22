using AdoptionCenterDA.Web.Models;
using AdoptionCenterDA.Web.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Identity;

namespace AdoptionCenterDA.Web.Pages;

public class RegisterBase : ComponentBase
{
    [Inject]
    protected IAuthService AuthService { get; set; } = default!;

    [Inject]
    protected NavigationManager Navigation { get; set; } = default!;

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
            result.Errors.Select(e => e.Description));
    }
}
