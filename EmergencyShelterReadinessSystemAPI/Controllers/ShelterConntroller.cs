using EmergencyShelterReadinessSystemAPI.DTOs;
using EmergencyShelterReadinessSystemAPI.Repositorys;
using Microsoft.AspNetCore.Mvc;

namespace EmergencyShelterReadinessSystemAPI.Controllers;

[Route("api/shelters/[controller]")]
[ApiController]
public class ShelterConntroller: ControllerBase
{
    IShelterRepository _repository;

    public ShelterConntroller(IShelterRepository repository)
    {
        _repository = repository;
    }

    [HttpGet("With-area/")]
    public async Task<ActionResult<IEnumerable<ShelterWithAreaDto>>> GetShelterWithAreaAsynk()
    {
        return Ok(await _repository.GetShelterWithAreaAsynk());
    }
    [HttpGet("search/")]
    public async Task<ActionResult<IEnumerable<ShelterSearchResultDto>>> SearchAsync(string? city,
        int? minCapacity,
        bool? isAccessible,
        bool? isPublic)
    {
        return Ok(await _repository.GetFilteredShelters(city, minCapacity, isAccessible, isPublic));
    }

    [HttpGet("sort/")]
    public async Task<ActionResult<IEnumerable<ShelterSearchResultDto>>> SortAsynk(string sortBy = "name",
    bool ascending = true)
    {
        return Ok(await _repository.GetSorted(sortBy, ascending));
    }

    [HttpGet("with-inspection-count/")]
    public async Task<ActionResult<IEnumerable<ShelterWithInspectionCountDto>>> GetSheltersWithReportCountAsynk()
    {
        return Ok(await _repository.GetSheltersWithReportCount());
    }
    [HttpGet("Type-Average/")]
    public async Task<ActionResult<IEnumerable<ShelterTypeAverageDto>>> ShelterTypeAverage()
    {
        return Ok(await _repository.ShelterTypeAverage());
    }

    [HttpGet("paged/")]
    public async Task<ActionResult<PagedResultDto>> PagedAsync(int page, int pageSize)
    {
        return Ok(await _repository.PagedsAsync(page, pageSize));


    }
    [HttpGet("Last-inspection/")]
    public async Task<ActionResult<IEnumerable<ShelterLatestInspectionDto>>> SheltersLastInspection()
    {
        return Ok(await _repository.SheltersLastInspection());
    }
}
