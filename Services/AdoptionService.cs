using AdoptionCenterDA.Web.Data;
using AdoptionCenterDA.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace AdoptionCenterDA.Web.Services;

public class AdoptionService : IAdoptionService
{
    private readonly ApplicationDbContext _context;

    public AdoptionService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<AdoptionRequest>> GetAllRequestsAsync()
    {
        return await _context.AdoptionRequests
            .Include(a => a.Pet)
            .Include(a => a.User)
            .OrderByDescending(a => a.RequestDate)
            .ToListAsync();
    }

    public async Task<List<AdoptionRequest>> GetUserRequestsAsync(string userId)
    {
        return await _context.AdoptionRequests
            .Include(a => a.Pet)
            .Where(a => a.UserId == userId)
            .OrderByDescending(a => a.RequestDate)
            .ToListAsync();
    }

    public async Task<AdoptionRequest?> GetRequestByIdAsync(int id)
    {
        return await _context.AdoptionRequests
            .Include(a => a.Pet)
            .Include(a => a.User)
            .FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task AddRequestAsync(AdoptionRequest request)
    {
        _context.AdoptionRequests.Add(request);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateRequestAsync(AdoptionRequest request)
    {
        _context.AdoptionRequests.Update(request);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteRequestAsync(int id)
    {
        var request = await _context.AdoptionRequests.FindAsync(id);

        if (request is null)
            return;

        _context.AdoptionRequests.Remove(request);
        await _context.SaveChangesAsync();
    }

    public async Task ApproveRequestAsync(int id)
    {
        var request = await _context.AdoptionRequests.FindAsync(id);

        if (request is null)
            return;

        request.Status = AdoptionStatus.Approved;

        _context.AdoptionRequests.Update(request);

        await _context.SaveChangesAsync();
    }

    public async Task RejectRequestAsync(int id)
    {
        var request = await _context.AdoptionRequests.FindAsync(id);

        if (request is null)
            return;

        request.Status = AdoptionStatus.Rejected;

        _context.AdoptionRequests.Update(request);

        await _context.SaveChangesAsync();
    }
}
