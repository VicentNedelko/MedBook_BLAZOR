using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Data
{
    public class Doctor : ApplicationUser
    {
        public string? Profile { get; set; }

        public byte[]? Picture { get; set; }

        public List<Patient>? Patients { get; set; }
    }
}
