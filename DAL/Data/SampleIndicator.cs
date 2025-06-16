using System.Diagnostics.CodeAnalysis;

namespace DAL.Data
{
    public class SampleIndicator : BaseIndicator, IComparable<SampleIndicator>
    {
        //Bearing FK

        public int BearingIndicatorId { get; set; }
        public BearingIndicator BearingIndicator { get; set; }

        public int CompareTo([AllowNull] SampleIndicator indicator)
        {
            return this.Name.CompareTo(indicator!.Name);
        }
    }
}
