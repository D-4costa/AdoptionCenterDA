using AdoptionCenterDA.Web.Models;
using AdoptionCenterDA.Web.Services;
using Microsoft.AspNetCore.Components;

namespace AdoptionCenterDA.Web.Components.Pages;

public partial class Details : ComponentBase
{
    [Parameter]
    public int Id { get; set; }

    [Inject]
    private IPetService PetService { get; set; } = default!;

    [Inject]
    private IAuthService AuthService { get; set; } = default!;

    protected Pet? Pet { get; private set; }

    protected bool IsAuthenticated { get; private set; }

    protected override async Task OnInitializedAsync()
    {
        Pet = PetService.GetPetById(Id);

        var user = await AuthService.GetCurrentUserAsync();

        IsAuthenticated = user is not null;
    }
}
