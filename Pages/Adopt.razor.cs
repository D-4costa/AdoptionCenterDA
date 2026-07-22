using AdoptionCenterDA.Web.Models;
using AdoptionCenterDA.Web.Services;
using Microsoft.AspNetCore.Components;

namespace AdoptionCenterDA.Web.Pages;

public partial class Adopt
{
    [Parameter]
    public int PetId { get; set; }

    [Inject]
    private IAdoptionService AdoptionService { get; set; } = default!;

    [Inject]
    private IAuthService AuthService { get; set; } = default!;

    [Inject]
    private NavigationManager Navigation { get; set; } = default!;

    protected AdoptionRequest Request { get; set; } = new();

    protected string SuccessMessage { get; set; } = string.Empty;

    protected string ErrorMessage { get; set; } = string.Empty;

    protected override async Task OnInitializedAsync()
    {
        var user = await AuthService.GetCurrentUserAsync();

        if (user is null)
        {
            Navigation.NavigateTo("/login");
            return;
        }

        Request.UserId = user.Id;
        Request.FullName = user.FullName ?? string.Empty;
        Request.Email = user.Email ?? string.Empty;
        Request.PetId = PetId;
    }

    protected async Task SubmitRequestAsync()
    {
        try
        {
            Request.RequestDate = DateTime.Now;
            Request.Status = AdoptionStatus.Pending;

            await AdoptionService.AddRequestAsync(Request);

            SuccessMessage = "Your adoption request has been submitted successfully.";
            ErrorMessage = string.Empty;

            Request = new AdoptionRequest
            {
                UserId = Request.UserId,
                FullName = Request.FullName,
                Email = Request.Email,
                PetId = PetId
            };
        }
        catch (Exception)
        {
            ErrorMessage = "An unexpected error occurred while submitting your request.";
            SuccessMessage = string.Empty;
        }
    }
}
