using System.ComponentModel.DataAnnotations;
using System.IO;

namespace EmergencyShelterReadinessSystemAPI.Models;

public class Shelter
{
    public int Id {  get; set; }

    public int AreaId { get; set; }

    [Required]
    [MaxLength(200)]
    public string Name {  get; set; }

    [Required]
    [MaxLength (100)]
    public string Street {  get; set; }

    [Required]
    [MaxLength(20)]
    public int BuildingNumber {  get; set; }

    [Required]
    [Range(1,10000)]
    public int Capacity { get; set; }

    [Required]
    public bool IsAccessible { get; set; } = false;

    [Required]
    public bool IsPublic { get; set; } = false;

    [Required]
    [RegularExpression("^PublicBuilding|School|Parking|Residential|Commercial$")]
    public string ShelterType { get; set; }

    public Area Area { get; set; }

}
