using BlackoutMonitorAPI.Model;

namespace BlackoutMonitorAPI.Service
{
    public interface IRegionService
    {
        Task<Region> GetOrCreateRegionByCepAsync(string cep);
    }
}
