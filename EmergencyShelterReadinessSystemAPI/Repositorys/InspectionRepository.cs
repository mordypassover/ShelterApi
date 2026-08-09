using EmergencyShelterReadinessSystemAPI.Data;
using EmergencyShelterReadinessSystemAPI.DTOs;
using EmergencyShelterReadinessSystemAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmergencyShelterReadinessSystemAPI.Repositorys;

public class InspectionRepository:IInspectionRepository
{
    MyDbContext _dbContext;
    public InspectionRepository(MyDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<IEnumerable<InspectionDetailedDto>> GetInspectionDetailedAsynk()
    {
        var data = _dbContext.Inspections
            .Select(i => new InspectionDetailedDto
            {
                InspectionId = i.Id,
                InspectionDate = i.InspectionDate,
                ReadinessScore = i.ReadinessScore,
                Passed = i.Passed,
                ShelterName = i.Shelter.Name,
                City = i.Shelter.Area.City,
                Neighborhood = i.Shelter.Area.Neighborhood
            });
            return await data.ToListAsync(); 
    }

    public async Task<IEnumerable<FailedInspectionDto>> FailedInspectionsAsynk()
    {
        var data = _dbContext.Inspections
            .Where(i => i.Passed == false)
            .Select(i => new FailedInspectionDto
            {
                InspectionId = i.Id,
                InspectionDate = i.InspectionDate,
                ReadinessScore = i.ReadinessScore,
                DefectsCount = i.DefectsCount,
                ShelterName = i.Shelter.Name,
                City = i.Shelter.Area.City,
            });
        return await data.ToListAsync() ;
    }
}
