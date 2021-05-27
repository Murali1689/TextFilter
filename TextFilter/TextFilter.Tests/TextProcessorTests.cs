using System;
using System.Collections.Generic;
using System.Text;
using TextFilter.Filters;
using Xunit;

namespace TextFilter.Tests
{
    public class TextProcessorTests
    {
        [Theory]
        [InlineData("", "Invalid text")]
        [InlineData("     ", "Invalid text")]
        public void GivenInvalidTextToProcess_ThrowsException(string input, string exceptionMessage)
        {
            //Arrange
            IFilter vowelfilter = new VowelIntheMiddleFilter();
            var textProcessor = new TextProcessor(new List<IFilter> { vowelfilter });

            //Act
            var result = Assert.Throws<InvalidOperationException>(() => textProcessor.ProcessText(input));

            //Assert
            Assert.Equal(exceptionMessage, result.Message);
        }

        [Theory]
        [InlineData("Alice was beginning to get very tired of sitting by her sister on the bank", "beginning to tired of sitting by sister on the")]
        public void GivenValidTextToProcessWithVowelFilter_ReturnsStringAfterApplyingVowelFilter(string input, string expectedOutput)
        {
            //Arrange
            var vowelfilter = new VowelIntheMiddleFilter();
            var textProcessor = new TextProcessor(new List<IFilter> { vowelfilter });

            //Act
            var result = textProcessor.ProcessText(input);

            //Assert
            Assert.Equal(expectedOutput, result);
        }

        [Theory]
        [InlineData("Alice was beginning to get very tired of sitting by her sister on the bank", "beginning of by on")]
        public void GivenValidTextToProcessWithMoreThanOneFilter_ReturnsStringAfterApplyingAllFilters(string input, string expectedOutput)
        {
            //Arrange
            var vowelfilter = new VowelIntheMiddleFilter();
            var letterfilter = new LetterFilter("t");
            var textProcessor = new TextProcessor(new List<IFilter> { vowelfilter, letterfilter });

            //Act
            var result = textProcessor.ProcessText(input);

            //Assert
            Assert.Equal(expectedOutput, result);
        }
    }
}