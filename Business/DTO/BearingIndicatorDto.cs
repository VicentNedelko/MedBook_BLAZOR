using Business.Helpers;
using DAL.Enum;
using System.ComponentModel.DataAnnotations;

namespace Business.DTO
{
    public class BearingIndicatorDto
    {
        public int? Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Type - digit OR Yes/No")]
        public IndTYPE Type { get; set; } // absolute, relative etc.

        [Display(Name = "Reference Max value")]
        [GraterThen("ReferenceMin", ErrorMessage = "Value should be grater than MIN")]
        public double? ReferenceMax { get; set; }

        [Display(Name = "Reference Min value")]
        public double? ReferenceMin { get; set; }

        [Display(Name = "Units")]
        public string? Unit { get; set; }

        [Display(Name = "Description")]
        public string? Description { get; set; }
    }
}
