using System.ComponentModel.DataAnnotations;

namespace EmergencyShelterReadinessSystemAPI.Models;

public class Area
{
    public int Id { get; set; }


    [Required]
    [MaxLength(100)]
    public string City { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string Neighborhood { get; set; } = string.Empty;

    [Required]
    [MaxLength(20)]
    public string AreaCode { get; set; }

    [Required]
    [Range(1,5)]
    public int RiskLevel { get; set; }

    public List<Shelter> Shelters { get; set; }


}
