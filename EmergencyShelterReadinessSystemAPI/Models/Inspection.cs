using System.ComponentModel.DataAnnotations;

namespace EmergencyShelterReadinessSystemAPI.Models;

public class Inspection
{
    public int Id {  get; set; }

    public int ShelterId { get; set; }
    [Required]
    public DateTime InspectionDate { get; set; }

    [Range(0,100)]
    public int ReadinessScore { get; set; }
    public bool Passed { get; set; }

    [Range(0,100)]
    public int DefectsCount { get; set; }

    [MaxLength(500)]
    public string Notes {  get; set; }

    public Shelter Shelter { get; set; } = null!;
}
