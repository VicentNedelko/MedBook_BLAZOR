using System.Diagnostics.CodeAnalysis;

namespace DAL.Data
{
    public class CheckUp : IEquatable<CheckUp>
    {
        public int Id { get; set; }
        public string? Laboratory { get; set; }
        public string? OrderPID { get; set; }
        public DateTime ResearchDate { get; set; }

        public string? Comment { get; set; }

        // Patient FK
        public required string PatientId { get; set; }
        public required Patient Patient { get; set; }

        //Visit FK
        public int? VisitId { get; set; }
        public Visit? Visit { get; set; }

        public required List<Indicator> Indicators { get; set; }


        public bool Equals([AllowNull] CheckUp other)
        {
            if (other is null)
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

        private static bool IndicatorsEquality(List<Indicator> indicators1, List<Indicator> indicators2)
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
