using System;
using System.Collections.Generic;
using System.Text;
using TextFilter.Filters;

namespace TextFilter
{
    public class TextProcessor
    {
        private readonly IEnumerable<IFilter> _filters;

        public TextProcessor(IEnumerable<IFilter> filters)
        {
            _filters = filters;
        }

        /// <summary>
        /// To Process the text by applying the various filters available
        /// </summary>
        /// <param name="text"></param>
        /// <returns>filtered text</returns>
        public string ProcessText(string text)
        {
            if (string.IsNullOrEmpty(text) || string.IsNullOrWhiteSpace(text))
            {
                throw new InvalidOperationException("Invalid text");
            }
            var filteredOutput = text;

            foreach (IFilter filter in _filters)
            {
                filteredOutput = filter.Apply(filteredOutput);
            }

            return filteredOutput;
        }
    }
}