using AdoptionCenterDA.Web.Models;

namespace AdoptionCenterDA.Web.Services;

public class PetService
{
    private readonly List<Pet> pets = new()
    {
        new Pet
        {
            Id = 1,
            Name = "Bella",
            Type = "Dog",
            Breed = "Golden Retriever",
            Age = 3,
            Gender = "Female",
            Description = "Bella is a friendly and loving dog.",
            ImageUrl = "https://images.unsplash.com/photo-1552053831-71594a27632d",
            IsAdopted = false
        },

        new Pet
        {
            Id = 2,
            Name = "Max",
            Type = "Dog",
            Breed = "Labrador",
            Age = 2,
            Gender = "Male",
            Description = "Max loves playing and outdoor activities.",
            ImageUrl = "https://images.unsplash.com/photo-1530281700549-e82e7bf110d6",
            IsAdopted = false
        },

        new Pet
        {
            Id = 3,
            Name = "Luna",
            Type = "Cat",
            Breed = "British Shorthair",
            Age = 1,
            Gender = "Female",
            Description = "Luna is calm and affectionate.",
            ImageUrl = "https://images.unsplash.com/photo-1518791841217-8f162f1e1131",
            IsAdopted = false
        },

        new Pet
        {
            Id = 4,
            Name = "Oliver",
            Type = "Cat",
            Breed = "Domestic Cat",
            Age = 4,
            Gender = "Male",
            Description = "Oliver enjoys relaxing and being loved.",
            ImageUrl = "https://images.unsplash.com/photo-1574158622682-e40e69881006",
            IsAdopted = false
        }
    };


    public List<Pet> GetAllPets()
    {
        return pets;
    }


    public List<Pet> GetDogs()
    {
        return pets
            .Where(p => p.Type == "Dog")
            .ToList();
    }


    public List<Pet> GetCats()
    {
        return pets
            .Where(p => p.Type == "Cat")
            .ToList();
    }


public Pet? GetPetById(int id)
{
    return pets.FirstOrDefault(p => p.Id == id);
}


public List<Pet> GetFeaturedPets()
{
    return pets
        .Where(p => !p.IsAdopted)
        .Take(3)
        .ToList();
    }
}