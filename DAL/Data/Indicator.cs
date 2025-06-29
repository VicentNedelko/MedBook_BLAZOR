using System.Diagnostics.CodeAnalysis;

namespace DAL.Data
{
    public class Indicator : BaseIndicator, IComparable<Indicator>
    {
        public int? Number { get; set; }
        public double Value { get; set; }

        public int BearingIndicatorId { get; set; }
        public BearingIndicator BearingIndicator { get; set; }

        public int CheckUpId { get; set; }
        public CheckUp CheckUp { get; set; }

        public int CompareTo([AllowNull] Indicator other)
        {
            return Name.CompareTo(other.Name);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (obj is not Indicator)
            {
                return false;
            }
            var result = Name.Equals(((Indicator)obj).Name, StringComparison.InvariantCultureIgnoreCase);
            return result;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name);
        }
    }
}
