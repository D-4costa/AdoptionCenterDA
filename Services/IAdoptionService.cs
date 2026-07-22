using AdoptionCenterDA.Web.Models;

namespace AdoptionCenterDA.Web.Services;

public interface IAdoptionService
{
    Task<List<AdoptionRequest>> GetAllRequestsAsync();

    Task<List<AdoptionRequest>> GetUserRequestsAsync(string userId);

    Task<AdoptionRequest?> GetRequestByIdAsync(int id);

    Task AddRequestAsync(AdoptionRequest request);

    Task UpdateRequestAsync(AdoptionRequest request);

    Task DeleteRequestAsync(int id);

    Task ApproveRequestAsync(int id);

    Task RejectRequestAsync(int id);
}
