using Microsoft.AspNetCore.Components;
using AdoptionCenterDA.Web.Models;
using AdoptionCenterDA.Web.Services;

namespace AdoptionCenterDA.Web.Components.Pages;

public partial class Home : ComponentBase
{
    [Inject]
    private PetService PetService { get; set; } = default!;

    protected List<Pet> FeaturedPets { get; set; } = new();

    protected override void OnInitialized()
    {
        FeaturedPets = PetService
            .GetAllPets()
            .Take(6)
            .ToList();
    }
}
