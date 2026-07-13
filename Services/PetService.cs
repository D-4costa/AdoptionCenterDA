using AdoptionCenterDA.Web.Models;

namespace AdoptionCenterDA.Web.Services;

public class PetService : IPetService
{

    private readonly List<Pet> pets = new()
    {

        new Pet
        {
            Id = 1,
            Name = "Bella",
            Type = PetType.Dog,
            Breed = "Golden Retriever",
            Age = 3,
            Gender = Gender.Female,
            Description = "Bella is a friendly and energetic dog who loves playing outdoors.",
            ImageUrl = "images/bella.jpg",
            Status = PetStatus.Available
        },


        new Pet
        {
            Id = 2,
            Name = "Max",
            Type = PetType.Dog,
            Breed = "Labrador",
            Age = 5,
            Gender = Gender.Male,
            Description = "Max is a calm and loyal dog looking for a loving family.",
            ImageUrl = "images/max.jpg",
            Status = PetStatus.Available
        },


        new Pet
        {
            Id = 3,
            Name = "Rocky",
            Type = PetType.Dog,
            Breed = "Beagle",
            Age = 2,
            Gender = Gender.Male,
            Description = "Rocky is playful and enjoys spending time with people.",
            ImageUrl = "images/rocky.jpg",
            Status = PetStatus.Adopted
        },


        new Pet
        {
            Id = 4,
            Name = "Luna",
            Type = PetType.Cat,
            Breed = "Siamese",
            Age = 4,
            Gender = Gender.Female,
            Description = "Luna is a sweet cat who enjoys quiet spaces and affection.",
            ImageUrl = "images/luna.jpg",
            Status = PetStatus.Available
        },


        new Pet
        {
            Id = 5,
            Name = "Milo",
            Type = PetType.Cat,
            Breed = "Persian",
            Age = 3,
            Gender = Gender.Male,
            Description = "Milo is a gentle cat who loves attention and cuddles.",
            ImageUrl = "images/milo.jpg",
            Status = PetStatus.Available
        },


        new Pet
        {
            Id = 6,
            Name = "Nala",
            Type = PetType.Cat,
            Breed = "Calico",
            Age = 1,
            Gender = Gender.Female,
            Description = "Nala is a curious kitten full of energy and love.",
            ImageUrl = "images/nala.jpg",
            Status = PetStatus.Adopted
        }

    };



    public List<Pet> GetAllPets()
    {
        return pets;
    }



    public List<Pet> GetDogs()
    {
        return pets
            .Where(p => p.Type == PetType.Dog)
            .ToList();
    }



    public List<Pet> GetCats()
    {
        return pets
            .Where(p => p.Type == PetType.Cat)
            .ToList();
    }



    public Pet? GetPetById(int id)
    {
        return pets.FirstOrDefault(p => p.Id == id);
    }

}
