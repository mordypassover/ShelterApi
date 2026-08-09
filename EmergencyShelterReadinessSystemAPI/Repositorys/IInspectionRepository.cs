using EmergencyShelterReadinessSystemAPI.DTOs;

namespace EmergencyShelterReadinessSystemAPI.Repositorys
{
    public interface IInspectionRepository
    {
        Task<IEnumerable<InspectionDetailedDto>> GetInspectionDetailedAsynk();
    }
}
