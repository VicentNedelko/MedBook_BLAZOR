using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Data
{
    public class Patient : ApplicationUser
    {
        public required DateTime DateOfBirth { get; set; }

        public int? Age { get; set; }

        public string? Diagnosis { get; set; }

        public int? DoctorId { get; set; }

        public Doctor? Doctor { get; set; }
    }
}
