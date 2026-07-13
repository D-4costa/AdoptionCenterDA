using Microsoft.AspNetCore.Components;
using AdoptionCenterDA.Web.Models;
using AdoptionCenterDA.Web.Services;

namespace AdoptionCenterDA.Web.Components.Pages;

public partial class Details : ComponentBase
{

    [Parameter]
    public int Id { get; set; }


    [Inject]
    private PetService PetService { get; set; } = default!;


    protected Pet? Pet { get; private set; }



    protected override void OnInitialized()
    {

        Pet = PetService.GetPetById(Id);

    }

}
