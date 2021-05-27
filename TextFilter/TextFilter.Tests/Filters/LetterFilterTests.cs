using System;
using System.Collections.Generic;
using System.Text;
using TextFilter.Filters;
using Xunit;

namespace TextFilter.Tests.Filters
{
    public class LetterFilterTests
    {
        [Theory]
        [InlineData("a in by mask", "a in by mask")]
        [InlineData("WALL IS HIGH", "WALL IS HIGH")]
        public void GivenAStringWithoutFilterLetterInWords_ReturnsString(string input, string expectedOutput)
        {
            //Arrange
            var letterFilter = new LetterFilter("t");

            //Act
            var result = letterFilter.Apply(input);

            //Assert
            Assert.Equal(expectedOutput, result);
        }

        [Theory]
        [InlineData("Man stuck in the well", "Man in well")]
        public void GivenAStringWithFilterLetterInWords_ReturnsStringAfterFiltering(string input, string expectedOutput)
        {
            //Arrange
            var letterFilter = new LetterFilter("t");

            //Act
            var result = letterFilter.Apply(input);

            //Assert
            Assert.Equal(expectedOutput, result);
        }
    }
}