using System.ComponentModel.DataAnnotations;
using System.Text;
using DiamondKata.Extensions;

namespace DiamondKata.DomainModels;

public class Diamond
{
    public char LastChar { get; init; }
    
    private const char _dashChar = '_';
    
    public string GetDiamondAsString()
    {
        int lineLength = (LastChar.Index()*2) + 1;
        if (lineLength == 1) return LastChar.ToString();
        
        int midPoint = lineLength / 2;

        var result = new StringBuilder();
            
        for (int letterIndex = 0; letterIndex <= LastChar.Index(); letterIndex++)
        {
            var currentLine = CreateDiamondLine(letterIndex, lineLength, midPoint);

            result.Append(currentLine).Append('\n');
        }

        for (int letterIndex = LastChar.Index() - 1; letterIndex >= 0; letterIndex--)
        {
            var currentLine = CreateDiamondLine(letterIndex, lineLength, midPoint);

            result.Append(currentLine);
            if (letterIndex != 0) result.Append('\n');
        }
        
        return result.ToString();
    }
    
    private char[] CreateDiamondLine(int letterIndex, int lineLength, int midPoint)
    {
        char letter = letterIndex.GetLetterByIndex();
        var currentLine = new char[lineLength];
        Array.Fill(currentLine, _dashChar);

        currentLine[midPoint - letterIndex] = letter;
        currentLine[midPoint + letterIndex] = letter;

        return currentLine;
    }
    
    #region Factory Pattern
    public static Diamond CreateNew(char letter)
    {
        var diamond = new Diamond
        {
            LastChar = Char.ToUpper(letter)
        };

        diamond.Validate();
         
        return diamond;
    }
    
    private void Validate()
    {
        if (!Char.IsLetter(LastChar) || !Char.IsAscii(LastChar))
        {
            throw new ValidationException($"The input character is not a Latin letter. | Invalid char : {LastChar}.");
        }
    }
    #endregion
}