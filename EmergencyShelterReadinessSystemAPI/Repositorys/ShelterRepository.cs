using EmergencyShelterReadinessSystemAPI.Data;
using EmergencyShelterReadinessSystemAPI.DTOs;
using EmergencyShelterReadinessSystemAPI.Models;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace EmergencyShelterReadinessSystemAPI.Repositorys;

public class ShelterRepository : IShelterRepository
{
    MyDbContext _dbContext;

    public ShelterRepository(MyDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<IEnumerable<ShelterWithAreaDto>> GetShelterWithAreaAsynk()
    {
        var data = _dbContext.Shelters
        .Select(s => new ShelterWithAreaDto
        {
            ShelterId = s.Id,
            ShelterName = s.Name,
            Capacity = s.Capacity,
            City = s.Area.City,
            Neighborhood = s.Area.Neighborhood
        });

        return await data.ToListAsync();
    }
    public async Task<IEnumerable<ShelterSearchResultDto>> GetFilteredShelters(
        string? city,
        int? minCapacity,
        bool? isAccessible,
        bool? isPublic
        )
    {
        var query = _dbContext.Shelters
        .Include(s => s.Area)
        .AsQueryable();

        if (!string.IsNullOrWhiteSpace(city))
        {
            query = query.Where(s => s.Area.City == city);
        }

        if (minCapacity.HasValue)
        {
            query = query.Where(s => s.Capacity >= minCapacity.Value);
        }

        if (isAccessible.HasValue)
        {
            query = query.Where(s => s.IsAccessible == isAccessible.Value);
        }

        if (isPublic.HasValue)
        {
            query = query.Where(s => s.IsPublic == isPublic.Value);
        }

        return await query
            .Select(s => new ShelterSearchResultDto
            {
                Id = s.Id,
                Name = s.Name,
                Street = s.Street,
                Capacity = s.Capacity,
                IsAccessible = s.IsAccessible,
                City = s.Area.City
            })
            .ToListAsync();
    }

    public async Task<IEnumerable<ShelterSortedDto>> GetSorted(string sortBy = "name",
    bool ascending = true)

    {
        IQueryable<Shelter> query = _dbContext.Shelters
            .Include(s => s.Area);



        if (sortBy == "capacity")
        {
            query = ascending ?
                 query.OrderBy(s => s.Capacity)
                : query.OrderByDescending(s => s.Capacity);
        }
        else if (sortBy == "city")
        {
            query = ascending
                ? query.OrderBy(s => s.Area.City)
                : query.OrderByDescending(s => s.Area.City);
        }
        else
        {
            query = ascending
                ? query.OrderBy(s => s.Name)
                : query.OrderByDescending(s => s.Name);
        }

        return await query
            .Select(s => new ShelterSortedDto
            {
                Id = s.Id,
                Name = s.Name,
                Street = s.Street,
                Capacity = s.Capacity,
                IsAccessible = s.IsAccessible,
                City = s.Area.City
            })
            .ToListAsync();
    }
    public async Task<IEnumerable<ShelterWithInspectionCountDto>> GetSheltersWithReportCount()
    {

        var data = _dbContext.Shelters
            .Select(s => new ShelterWithInspectionCountDto
            {
                ShelterId = s.Id,
                ShelterName = s.Name,
                InspectionCount = s.Inspections.Count
            });
        return await data.ToListAsync();
    }

    public async Task<IEnumerable<ShelterTypeAverageDto>> ShelterTypeAverage()
    {
        var data = _dbContext.Inspections
            .GroupBy(i => i.Shelter.ShelterType)
            .Select(g => new ShelterTypeAverageDto
            {
                ShelterType = g.Key.ToString(),
                AverageReadinessScore = g.Average(i => i.ReadinessScore),
                TotalInspections = g.Count()
            });
        return await data.ToListAsync();
    }


    public async Task<PagedResultDto> PagedsAsync(int page, int pageSize)
    {
        var query = _dbContext.Shelters
        .OrderBy(s => s.Name);

        var totalCount = await query.CountAsync();

        var items = await query
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .Select(s => new
            {
                Id = s.Id,
                Name = s.Name,
                Capacity = s.Capacity
            })
            .ToListAsync();

        var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);
        return new PagedResultDto
        {
            Items = items,
            TotalCount = totalCount,
            Page = page,
            PageSize = pageSize,
            TotalPages = totalPages
        };
    }


    public async Task<IEnumerable<ShelterLatestInspectionDto>> SheltersLastInspection()
    {
        var data = _dbContext.Shelters
            .GroupJoin(
                _dbContext.Inspections,
                shelter => shelter.Id,
                inspection => inspection.ShelterId,
                (shelter, shelterInspections) => new { shelter, shelterInspections }
            )
            .Select(x => new ShelterLatestInspectionDto
            {
                ShelterId = x.shelter.Id,
                ShelterName = x.shelter.Name,

                LatestInspectionDate = x.shelterInspections
                    .OrderByDescending(i => i.InspectionDate)
                    .Select(i => (DateTime?)i.InspectionDate)
                    .FirstOrDefault(),

                LatestReadinessScore = x.shelterInspections
                    .OrderByDescending(i => i.InspectionDate)
                    .Select(i => (int?)i.ReadinessScore)
                    .FirstOrDefault()
            });

        return await data.ToListAsync();
    }
}