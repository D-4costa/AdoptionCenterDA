using Microsoft.AspNetCore.Identity;

namespace AdoptionCenterDA.Web.Models;

public class ApplicationUser : IdentityUser
{
    public string? FullName { get; set; }

    public DateTime RegistrationDate { get; set; } = DateTime.Now;

    public ICollection<AdoptionRequest>? AdoptionRequests { get; set; }
}
