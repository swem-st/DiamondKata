using System.ComponentModel.DataAnnotations;

namespace DiamondKata.Extensions;

public static class CharExtension
{
    private const string _uppercaseLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    private static char[] _uppercaseLettersArr => _uppercaseLetters.ToCharArray();
    
    public static int Index(this char letter)
    {
        var index = _uppercaseLetters.IndexOf(char.ToUpper(letter));
        ValidateIndex(index, letter);
        
        return index;
    }
    
    public static char GetLetterByIndex(this int index)
    {   
        ValidateGetLetterByIndex(index);
        return _uppercaseLettersArr[index];
    }

    private static void ValidateIndex(int index, char letter)
    {
        if (index == -1)
        {
            throw new ValidationException($"The input character is not a Latin letter. | Invalid char : {letter}.");
        }
    }
    
    private static void ValidateGetLetterByIndex(int index)
    {
        if (index < 0 || index > 25)
        {
            throw new ArgumentOutOfRangeException($"The input index is out of range. | Invalid index : {index}.");
        }
    }
}