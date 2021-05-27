using System.Text.RegularExpressions;

namespace TextFilter.Filters
{
    public class WordLengthFilter : FilterBase, IFilter
    {
        private readonly int _minimumWordLength;

        public WordLengthFilter(int minimumWordLength)
        {
            _minimumWordLength = minimumWordLength;
        }

        public string Apply(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return string.Empty;
            }
            //add the delegate criteria to apply
            return FilterByCriteria(input, FilterByLength);
        }

        /// <summary>
        ///  Builds the filter criteria
        /// </summary>
        /// <param name="match"></param>
        /// <returns> Returns true if the length filter matches criteria</returns>
        private bool FilterByLength(Match match)
        {
            string word = match.Value;

            return word.Length < _minimumWordLength;
        }
    }
}