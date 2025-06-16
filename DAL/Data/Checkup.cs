using System.Diagnostics.CodeAnalysis;

namespace DAL.Data
{
    public class Checkup
    {
        public int Id { get; set; }
        public string Laboratory { get; set; } // Laboratory Name
        public string SerialNum { get; set; } // Order PID
        public DateTime ResearchDate { get; set; }

        public string? Comment { get; set; }

        // Patient FK
        public string PatientId { get; set; }
        public Patient Patient { get; set; }

        public List<Indicator> Indicators { get; set; }


        public bool Equals([AllowNull] Checkup other)
        {
            if (other is not Checkup)
            {
                return false;
            }
            var result = ResearchDate == other.ResearchDate
                && PatientId == other.PatientId
                && Indicators.Count == other.Indicators.Count
                && IndicatorsEquality(Indicators, other.Indicators);
            return result;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        private bool IndicatorsEquality(List<Indicator> indicators1, List<Indicator> indicators2)
        {
            for (var i = 0; i < indicators1.Count; i++)
            {
                if (!(indicators1[i].Equals(indicators2[i])))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
