using Microsoft.AspNetCore.Components;
using AdoptionCenterDA.Web.Models;
using AdoptionCenterDA.Web.Services;

namespace AdoptionCenterDA.Web.Components.Pages;

public partial class Cats : ComponentBase
{
    [Inject]
    private PetService PetService { get; set; } = default!;

    protected List<Pet> Cats { get; private set; } = new();

    protected override void OnInitialized()
    {
        Cats = PetService.GetCats();
    }
}
