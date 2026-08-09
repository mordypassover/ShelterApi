namespace EmergencyShelterReadinessSystemAPI.DTOs
{
    public class ShelterSortedDto
    {
        public int Id { get; set; }
        public string Name {  get; set; }
       public string Street { get; set; }
        public int Capacity { get; set; }
        public bool IsAccessible {  get; set; }
        public string City {  get; set; }
    }
}
