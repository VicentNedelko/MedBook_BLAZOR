using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
    public class Visit
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public DateTime Date { get; set; }

        public string? Comment { get; set; }

        public List<CheckUp>? Researches { get; set; }

        public List<Prescription>? Prescriptions { get; set; }

        //Patient FK
        public required string PatientId { get; set; }
        public required Patient Patient { get; set; }

        //Doctor FK
        public required string DoctorId { get; set; }
        public required Doctor Doctor { get; set; }
    }
}
