namespace EmergencyShelterReadinessSystemAPI.DTOs;

public class ShelterLatestInspectionDto
{
    public int ShelterId {  get; set; }
    public string ShelterName {  get; set; }
    public DateTime? LatestInspectionDate {  get; set; }
    public int? LatestReadinessScore {  get; set; }
}
