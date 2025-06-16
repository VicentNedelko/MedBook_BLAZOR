using DAL.Data;
using System.Globalization;
using UglyToad.PdfPig;
using UglyToad.PdfPig.Content;
using UglyToad.PdfPig.DocumentLayoutAnalysis.TextExtractor;
using UglyToad.PdfPig.DocumentLayoutAnalysis.WordExtractor;

namespace Business.PDF
{
    public class PdfParser
    {
        private static readonly char[] separators = [' '];

        public static Dictionary<int, double> GetNumericIndicatorsWithValues(string path, List<SampleIndicator> sampleIndicators)
        {
            var indicatorIdsWithValues = new Dictionary<int, double>();

            using PdfDocument document = PdfDocument.Open(path);
            foreach (Page page in document.GetPages())
            {
                IReadOnlyList<Letter> letters = page.Letters;
                string example = string.Join(string.Empty, letters.Select(x => x.Value));

                var wordExtractor = NearestNeighbourWordExtractor.Instance;
                var wordExtractorOptions = new NearestNeighbourWordExtractor.NearestNeighbourWordExtractorOptions()
                {
                    Filter = (pivot, candidate) =>
                    {
                        // check if white space (default implementation of 'Filter')
                        if (string.IsNullOrWhiteSpace(candidate.Value))
                        {
                            // pivot and candidate letters cannot belong to the same word 
                            // if candidate letter is null or white space.
                            // ('FilterPivot' already checks if the pivot is null or white space by default)
                            return false;
                        }
                        return true;
                    }
                };

                var words = wordExtractor.GetWords(letters);

                var text = ContentOrderTextExtractor.GetText(page, true);

                var sentences = text.Split('\n', StringSplitOptions.None);

                foreach (var sentence in sentences)
                {
                    if (sampleIndicators.Any(si => sentence.Contains(si.Name)))
                    {
                        var indicator = sampleIndicators.First(si => sentence.Contains(si.Name));
                        bool valueNotFound = true;
                        var index = Array.IndexOf(sentences, sentence);
                        while (valueNotFound)
                        {
                            var indicatorValue = GetNumericIndicatorValue(sentences[index]);
                            indicatorIdsWithValues.Add(indicator.BearingIndicatorId, indicatorValue);
                            if (indicatorValue != 0)
                            {
                                valueNotFound = false;
                            }
                            index++;
                        }
                    }
                }
            }

            return indicatorIdsWithValues;
        }

        private static double GetNumericIndicatorValue(string sentence)
        {
            bool isValueParsed = false;
            double result = -1;
            int i = 0;

            var words = sentence.Split(separators, StringSplitOptions.None);
            while (!isValueParsed && i < words.Length)
            {
                isValueParsed = double.TryParse(words[i].Trim(), NumberStyles.Any, CultureInfo.InvariantCulture, out result);
                i++;
            }

            return result;
        }
    }
}
