namespace DAL.Data
{
    public class Cure
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }

        // Prescription FK
        public required int PrescriptionId { get; set; }
        public required Prescription Prescription { get; set; }
    }
}
