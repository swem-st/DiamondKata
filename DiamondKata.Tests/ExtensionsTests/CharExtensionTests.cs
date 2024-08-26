using System.ComponentModel.DataAnnotations;
using DiamondKata.Extensions;
using FluentAssertions;

namespace DiamondKata.Tests.ExtensionsTests;

public class CharExtensionTests
{
    [Theory]
    [InlineData('A', 0)]
    [InlineData('B', 1)]
    [InlineData('Z', 25)]
    [InlineData('a', 0)]
    [InlineData('b', 1)]
    [InlineData('z', 25)]
    public void Index_ValidLetter_ReturnsCorrectIndex(char letter, int expectedIndex)
    {
        //Arrange // Act
        var actualIndex = letter.Index();
        
        // Assert
        actualIndex.Should().Be(expectedIndex);
    }

    [Theory]
    [InlineData('1')]
    [InlineData('!')]
    [InlineData(' ')]
    public void Index_InvalidCharacter_ThrowsValidationException(char character)
    {
        //Arrange //Act    
        Action act = () => character.Index();
        
        //Assert     
        act.Should().Throw<ValidationException>();
    }

    [Theory]
    [InlineData(0, 'A')]
    [InlineData(1, 'B')]
    [InlineData(25, 'Z')]
    public void GetLetterByIndex_ValidIndex_ReturnsCorrectLetter(int index, char expectedLetter)
    {
        //Arrange // Act
        var actualLetter = index.GetLetterByIndex();
        
        // Assert
        actualLetter.Should().Be(expectedLetter);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(26)]
    public void GetLetterByIndex_InvalidIndex_ThrowsArgumentOutOfRangeException(int index)
    {
        //Arrange // Act
        Action act = () => index.GetLetterByIndex();
        
        // Assert
        act.Should().Throw<ArgumentOutOfRangeException>();
    }
}