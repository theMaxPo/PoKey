using Xunit;
using PoKey.BL.Model;

namespace PoKey.BL.Tests;

public class TextTests
{
    [Fact]
    public void CheckingFirstCurrentChar()
    {
        // Arrange
        var txt = "test";
        Text text = new Text(new Exercise(txt));

        // Act
        var character = text.CurrentChar;
        var firstChar = text.Content[0];

        // Assert
        Assert.Equal(firstChar, character);
    }

    [Fact]
    public void MoveToNextChar_SetsCurrentCharToE()
    {
        // Arrange
        var txt = "test";
        Text text = new Text(new Exercise(txt));

        // Act
        text.MoveToNextChar();
        var character = text.CurrentChar;
        var secondChar = text.Content[1];

        // Assert
        Assert.Equal(secondChar, character);
    }

    [Fact]
    public void MoveToNextChar_SetsСurrentСharToLastCharOfString()
    {
        // Arrange
        var txt = "test";
        Text text = new Text(new Exercise(txt));

        // Act
        for (var i = 0; i < text.Content.Length-1; i++)
        {
            text.MoveToNextChar();
        }
        var character = text.CurrentChar;
        var lastChar = text.Content[^1];

        // Assert
        Assert.Equal(lastChar, character);
    }

    [Fact]
    public void Reset_SetsCurrentIndexToZero()
    {
        // Arrange
        Text text = new Text(new Exercise());
        text.CheckAndMoveToNextCharacter('a');

        // Act
        text.Reset();
        var index = text.CurrentIndex;

        // Assert
        Assert.Equal(0, index);
    }

    [Fact]
    public void CheckCharacter_HandlesCorrectInputCorrectly()
    {
        // Arrange
        var txt = "test";
        Text text = new Text(new Exercise(txt));
        int index = text.CurrentIndex;

        // Act
        var firstChar = text.Content[0];
        text.CheckCharacter(firstChar);
        var inputState = text.ErrorIndices[index];

        // Assert
        Assert.Equal(InputState.Correct, inputState);
    }

    [Fact]
    public void CheckCharacter_HandlesIncorrectInputCorrectly()
    {
        // Arrange
        var txt = "test";
        Text text = new Text(new Exercise(txt));
        int index = text.CurrentIndex;

        // Act
        var incorrectChar = (char)-text.Content[0];
        text.CheckCharacter(incorrectChar);
        var inputState = text.ErrorIndices[index];

        // Assert
        Assert.Equal(InputState.Incorrect, inputState);
    }
}