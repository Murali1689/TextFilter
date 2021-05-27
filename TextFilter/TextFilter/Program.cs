using System;
using System.Collections.Generic;
using System.IO;
using TextFilter.Filters;

namespace TextFilter
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var text = File.ReadAllText(Path.Combine($"{Directory.GetCurrentDirectory()}\\Input\\", "InputParagraph.txt"));

            //Add the filters to process
            var textProcessor = new TextProcessor(new List<IFilter>() { new LetterFilter("t"), new VowelIntheMiddleFilter(), new WordLengthFilter(3) });
            var filteredOutput = textProcessor.ProcessText(text);

            Console.Write(filteredOutput);
        }
    }
}