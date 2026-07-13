using System.ComponentModel.DataAnnotations;

namespace AdoptionCenterDA.Web.Models;

public class Pet
{

    public int Id { get; set; }


    [Required]
    public string Name { get; set; } = string.Empty;


    [Required]
    public PetType Type { get; set; }


    [Required]
    public string Breed { get; set; } = string.Empty;


    public int Age { get; set; }


    public Gender Gender { get; set; }


    public string Description { get; set; } = string.Empty;


    public string ImageUrl { get; set; } = string.Empty;


    public PetStatus Status { get; set; }


    public bool IsAdopted
    {
        get
        {
            return Status == PetStatus.Adopted;
        }
    }

}
