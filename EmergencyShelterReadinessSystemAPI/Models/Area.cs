using System.ComponentModel.DataAnnotations;

namespace EmergencyShelterReadinessSystemAPI.Models;

public class Area
{
    public int Id { get; set; }

    [Required]
    public string City { get; set; } = string.Empty;
    [Required]
    public string Neighborhood { get; set; } = string.Empty;

    [Required]
    public int AreaCode { get; set; }

    [Required]
    public int RiskLevel { get; set; }


}
