using AdoptionCenterDA.Web.Models;

namespace AdoptionCenterDA.Web.Services;

public interface IPetService
{

    List<Pet> GetAllPets();


    List<Pet> GetDogs();


    List<Pet> GetCats();


    Pet? GetPetById(int id);

}
