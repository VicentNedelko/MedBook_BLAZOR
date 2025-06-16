using DAL.Enum;
using System.ComponentModel.DataAnnotations;

namespace Business.DTO
{
    public class SampleIndicatorDto
    {
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        public IndTYPE Type { get; set; } // absolute, relative etc.

        public double? ReferenceMax { get; set; }

        public double? ReferenceMin { get; set; }

        public string? Unit { get; set; }

        [Required]
        [Display(Name = "Bearing indicator")]
        public int BearingIndicatorId { get; set; }
    }
}
