using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmergencyShelterReadinessSystemAPI.DTOs;

public class PagedResultDto
{
public object Items {  get; set; }
public int TotalCount {  get; set; }
public int Page {  get; set; }
public int PageSize {  get; set; }
public int TotalPages {  get; set; }
}
