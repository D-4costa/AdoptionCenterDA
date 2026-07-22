using System.ComponentModel.DataAnnotations;
using AdoptionCenterDA.Web.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;

namespace AdoptionCenterDA.Web.Pages;

public partial class Login
{
    [Inject]
    private IAuthService AuthService { get; set; } = default!;

    [Inject]
    private NavigationManager Navigation { get; set; } = default!;

    protected LoginInputModel LoginModel { get; set; } = new();

    protected string ErrorMessage { get; set; } = string.Empty;

    protected async Task LoginAsync()
    {
        ErrorMessage = string.Empty;

        SignInResult result = await AuthService.LoginAsync(
            LoginModel.Email,
            LoginModel.Password,
            LoginModel.RememberMe);

        if (result.Succeeded)
        {
            Navigation.NavigateTo("/");
            return;
        }

        ErrorMessage = "Invalid email or password.";
    }

    protected class LoginInputModel
    {
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        public bool RememberMe { get; set; }
    }
}
