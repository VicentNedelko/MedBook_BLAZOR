using DAL.Enum;

namespace DAL.Data
{
    public abstract class BaseIndicator
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public IndTYPE Type { get; set; } // absolute, relative etc.
        public double? ReferenceMax { get; set; }
        public double? ReferenceMin { get; set; }
        public string? Unit { get; set; }
    }
}
