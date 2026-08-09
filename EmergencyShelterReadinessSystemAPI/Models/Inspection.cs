using System.ComponentModel.DataAnnotations;

namespace EmergencyShelterReadinessSystemAPI.Models;

public class Inspection
{
    public int Id {  get; set; }
    [Required]
    public DateTime InspectionDate { get; set; }

    [Range(0,100)]
    public int ReadinessScore { get; set; }
    public bool Passed { get; set; }
    public int DefectsCountv { get; set; }


}
