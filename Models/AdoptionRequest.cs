using System.ComponentModel.DataAnnotations;

namespace AdoptionCenterDA.Web.Models;

public class AdoptionRequest
{
    public int Id { get; set; }


    // Applicant information

    [Required(ErrorMessage = "Full name is required.")]
    [StringLength(100)]
    public string FullName { get; set; } = string.Empty;


    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
    public string Email { get; set; } = string.Empty;


    [Required(ErrorMessage = "Phone number is required.")]
    [Phone(ErrorMessage = "Please enter a valid phone number.")]
    public string Phone { get; set; } = string.Empty;


    [Required(ErrorMessage = "Message is required.")]
    [StringLength(500)]
    public string Message { get; set; } = string.Empty;



    // Pet relationship

    public int PetId { get; set; }

    public Pet? Pet { get; set; }



    // User relationship

    public string? UserId { get; set; }

    public ApplicationUser? User { get; set; }



    // Request information

    public DateTime RequestDate { get; set; } = DateTime.Now;


    public AdoptionStatus Status { get; set; } = AdoptionStatus.Pending;
}
