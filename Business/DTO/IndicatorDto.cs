using DAL.Enum;

namespace Business.DTO
{
    public class IndicatorDto
    {
        public int? Id { get; set; }

        public required string Name { get; set; }

        public IndTYPE Type { get; set; } // absolute, relative etc.

        public double Value { get; set; }

        public double? ReferenceMax { get; set; }

        public double? ReferenceMin { get; set; }

        public string? Unit { get; set; }

        public int BearingIndicatorId { get; set; }
    }
}
