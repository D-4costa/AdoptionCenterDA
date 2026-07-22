using AdoptionCenterDA.Web.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AdoptionCenterDA.Web.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }


    public DbSet<Pet> Pets { get; set; }

    public DbSet<AdoptionRequest> AdoptionRequests { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);


        builder.Entity<AdoptionRequest>()
            .HasOne(request => request.Pet)
            .WithMany()
            .HasForeignKey(request => request.PetId)
            .OnDelete(DeleteBehavior.Cascade);


        builder.Entity<AdoptionRequest>()
            .HasOne(request => request.User)
            .WithMany(user => user.AdoptionRequests)
            .HasForeignKey(request => request.UserId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
