using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TextFilter.Filters
{
    public class VowelIntheMiddleFilter : FilterBase, IFilter
    {
        private List<string> vowels = new List<string> { "a", "e", "i", "o", "u" };

        /// <summary>
        /// Applies vowel filter to the text
        /// </summary>
        /// <param name="input"></param>
        /// <returns>filtered Text</returns>
        public string Apply(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return string.Empty;
            }
            return FilterByCriteria(input, FilterByVowelOccurance);
        }

        /// <summary>
        /// Builds the filter criteria
        /// </summary>
        /// <param name="match"></param>
        /// <returns>boolean result if the criteria is met for a word</returns>
        private bool FilterByVowelOccurance(Match match)
        {
            string word = match.Value;

            if (word.Length >= 3)
            {
                var middleLetters = GetMiddleLetters(word);

                if (middleLetters.Length == 1 && vowels.Any(c => c.Equals(middleLetters, StringComparison.OrdinalIgnoreCase)))
                {
                    return true;
                }
                else if (vowels.Any(c => middleLetters.StartsWith(c, StringComparison.OrdinalIgnoreCase)) ||
                vowels.Any(c => middleLetters.EndsWith(c, StringComparison.OrdinalIgnoreCase)))
                {
                    return true;
                }
            }

            return false;
        }

        private string GetMiddleLetters(string word)
        {
            if (IsWordLetterCountEvenNumber(word))
            {
                return word.Substring((word.Length / 2) - 1, 2);
            }
            else
            {
                return word.Substring(word.Length / 2, 1);
            }
        }

        private bool IsWordLetterCountEvenNumber(string word)
        {
            return word.Length % 2 == 0;
        }
    }
}