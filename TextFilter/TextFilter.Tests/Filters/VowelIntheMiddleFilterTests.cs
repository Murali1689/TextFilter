using System;
using System.Collections.Generic;
using System.Text;
using TextFilter.Filters;
using Xunit;

namespace TextFilter.Tests.Filters
{
    public class VowelIntheMiddleFilterTests
    {
        [Theory]
        [InlineData("a in to", "a in to")]
        public void GivenAStringWithLessThanThreeCharacters_ReturnsString(string input, string expectedOutput)
        {
            //Arrange
            var VowelInTheMiddleFilter = new VowelIntheMiddleFilter();

            //Act
            var result = VowelInTheMiddleFilter.Apply(input);

            //Assert
            Assert.Equal(expectedOutput, result);
        }

        [Theory]
        [InlineData("ate crwth ace flyby world glyph", "ate crwth ace flyby world glyph")]
        public void GivenAStringWithoutVowelsIntheMiddle_ReturnsString(string input, string expectedOutput)
        {
            //Arrange
            var VowelInTheMiddleFilter = new VowelIntheMiddleFilter();

            //Act
            var result = VowelInTheMiddleFilter.Apply(input);

            //Assert
            Assert.Equal(expectedOutput, result);
        }

        [Theory]
        [InlineData("car bus cat", "")]
        [InlineData("CAT BAT Alice", "")]
        public void GivenAStringWithVowelsIntheMiddleOddLetterCount_ReturnsStringWithOutVowelsInMiddle(string input, string expectedOutput)
        {
            //Arrange
            var VowelInTheMiddleFilter = new VowelIntheMiddleFilter();

            //Act
            var result = VowelInTheMiddleFilter.Apply(input);

            //Assert
            Assert.Equal(expectedOutput, result);
        }

        [Theory]
        [InlineData("cart make took", "")]
        [InlineData("CART MAKE TOOK", "")]
        public void GivenAStringWithVowelsIntheMiddleEvenLetterCount_ReturnsStringWithOutVowelsInMiddle(string input, string expectedOutput)
        {
            //Arrange
            var VowelInTheMiddleFilter = new VowelIntheMiddleFilter();

            //Act
            var result = VowelInTheMiddleFilter.Apply(input);

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