using Microsoft.AspNetCore.Components;
using AdoptionCenterDA.Web.Models;
using AdoptionCenterDA.Web.Services;

namespace AdoptionCenterDA.Web.Components.Pages;

public partial class Dogs : ComponentBase
{
    [Inject]
    private PetService PetService { get; set; } = default!;

    protected List<Pet> Dogs { get; private set; } = new();

    protected override void OnInitialized()
    {
        Dogs = PetService.GetDogs();
    }
}
