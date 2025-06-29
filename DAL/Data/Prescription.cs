namespace DAL.Data
{
    public class Prescription
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        public List<Cure>? Cures { get; set; }

        // Visit FK
        public required int VisitId { get; set; }
        public required Visit Visit { get; set; }
    }
}
