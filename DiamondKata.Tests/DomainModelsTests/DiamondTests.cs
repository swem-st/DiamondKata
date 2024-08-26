using System.ComponentModel.DataAnnotations;
using DiamondKata.DomainModels;
using FluentAssertions;

namespace DiamondKata.Tests.DomainModelsTests;

public class DiamondTests
{
    [Theory]
    [InlineData('A', 'A')]
    [InlineData('b', 'B')]
    [InlineData('C', 'C')]
    public void CreateNew_ReceiveExpectedChar(char letter, char expected)
    {
        //Arrange //Act
        var actualResult = Diamond.CreateNew(letter);
        
        //Assert 
        expected.Should().Be(actualResult.LastChar);
    }
    
    [Theory]
    [InlineData('1')]
    [InlineData('!')]
    public void CreateNew_ReceiveInvalidChar_ThrowException(char letter)
    {
        //Arrange //Act    
        Action act = () => Diamond.CreateNew(letter);
        
        //Assert     
        act.Should().Throw<ValidationException>();
    }
    
    [Theory] 
    [InlineData('A', "A")]
    [InlineData('B', "_A_\nB_B\n_A_")]
    [InlineData('C', "__A__\n_B_B_\nC___C\n_B_B_\n__A__")]
    [InlineData('D', "___A___\n__B_B__\n_C___C_\nD_____D\n_C___C_\n__B_B__\n___A___")]
    public void GetDiamondAsString_ReceiveExpectedString(char letter, string expected)
    {
        {
            //Arrange 
            var diamond = Diamond.CreateNew(letter);

            //Act
            var actualResult = diamond.GetDiamondAsString();
        
            //Assert 
            Assert.Equal(expected, actualResult);
        }
    }
}