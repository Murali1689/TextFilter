using System;
using System.Collections.Generic;
using System.Text;

namespace TextFilter.Filters
{
    public class LetterFilter : FilterBase, IFilter
    {
        private readonly string _letterToFilter;

        public LetterFilter(string letterToFilter)
        {
            _letterToFilter = letterToFilter;
        }

        /// <summary>
        /// Applies Letter filerting on the given text
        /// </summary>
        /// <param name="input"></param>
        /// <returns>Returns filtered result</returns>
        public string Apply(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return string.Empty;
            }
            //// to match a word with given character in the paragraph
            var regexExpression = $@"\b[a-zA-Z']*[{ _letterToFilter.ToLower() }{_letterToFilter.ToUpper() }][a-zA-Z']*\b";
            return FilterByMatchingExpression(input, regexExpression);
        }
    }
}