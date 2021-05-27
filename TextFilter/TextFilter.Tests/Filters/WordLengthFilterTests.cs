using System;
using System.Collections.Generic;
using System.Text;
using TextFilter.Filters;
using Xunit;

namespace TextFilter.Tests.Filters
{
    public class WordLengthFilterTests
    {
        [Theory]
        [InlineData("Alice was beginning to get very", "Alice was beginning get very")]
        [InlineData("at is by", "")]
        public void GivenAStringWithWordsLessThanMinimumLength_ReturnsStringWithWordsGreaterThanMinimumLength(string input, string expectedOutput)
        {
            //Arrange
            var wordLengthFilter = new WordLengthFilter(3);

            //Act
            var result = wordLengthFilter.Apply(input);

            //Assert
            Assert.Equal(expectedOutput, result);
        }

        [Fact]
        public void GivenAEmptyString_ReturnsEmptyString()
        {
            //Arrange
            var input = " ";
            var expectedOutput = string.Empty;
            var wordLengthFilter = new WordLengthFilter(3);

            //Act
            var result = wordLengthFilter.Apply(input);

            //Assert
            Assert.Equal(expectedOutput, result);
        }
    }
}