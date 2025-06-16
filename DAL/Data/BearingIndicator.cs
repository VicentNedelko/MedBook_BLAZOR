using System.Diagnostics.CodeAnalysis;

namespace DAL.Data
{
    public class BearingIndicator : BaseIndicator, IComparable<BearingIndicator>
    {
        public string? Description { get; set; }

        public List<SampleIndicator>? Samples { get; set; }

        public int CompareTo([AllowNull] BearingIndicator indicator)
        {
            return this.Name.CompareTo(indicator!.Name);
        }
    }
}
