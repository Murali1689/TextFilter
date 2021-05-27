using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace TextFilter.Filters
{
    public class FilterBase
    {
        // to match words in the paragraph using boundary identifier in regex
        private const string TextPattern = @"\b[0-9A-Za-z']+\b";

        /// <summary>
        /// Applies the delegate filter criteria on the text matched using regular expression and filter them
        /// </summary>
        /// <param name="paragraph"></param>
        /// <param name="criteria"></param>
        /// <returns>Filtered text</returns>
        public string FilterByCriteria(string paragraph, Func<Match, bool> criteria)
        {
            var regex = new Regex(TextPattern);
            var matches = regex.Matches(paragraph).Where(criteria);

            return RemoveMatches(paragraph, matches);
        }

        /// <summary>
        /// Applies regular expression on the text to match words and filter them
        /// </summary>
        /// <param name="paragraph"></param>
        /// <param name="regexExpression"></param>
        /// <returns>Filtered text</returns>
        public string FilterByMatchingExpression(string paragraph, string regexExpression)
        {
            var regex = new Regex(regexExpression, RegexOptions.Compiled);
            var matches = regex.Matches(paragraph);

            return RemoveMatches(paragraph, matches);
        }

        private string RemoveMatches(string paragraph, IEnumerable<Match> matches)
        {
            StringBuilder builder = new StringBuilder(paragraph);

            // iterate and remove matched words from the paragraph
            foreach (Match match in matches.Reverse())
            {
                builder.Remove(match.Index, match.Length);
            }

            // replace out extra whitespace caused by removing words
            return Regex.Replace(builder.ToString(), @"\s\s+", " ").Trim();
        }
    }
}