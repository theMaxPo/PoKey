using Xunit;
using PoKey.BL.Model;
using System;

namespace PoKey.BL.Tests;

public class ExerciseTests
{
    [Fact]
    public void CharactersProperty_SetsCharacterEmptyStringAndGetInvalidArguments_ThrowsArgumentException()
    {
        // Arrange & Act
        Action act = () => new Exercise("");

        // Assert
        ArgumentException exception = Assert.Throws<ArgumentException>(act);
        Assert.Equal("Строка не может быть пусто или null. (Parameter 'characters')", exception.Message);
    }

    [Fact]
    public void CharactersProperty_ReturnsCorrectString()
    {
        // Arrange
        var txt = "test";
        var exercise = new Exercise(txt);

        // Act
        var chars = exercise.Characters;

        // Assert
        Assert.Equal(txt, chars);
    }

    [Fact]
    public void CharactersProperty_ReturnsCorrectStringFromEmptyCtor()
    {
        // Arrange
        var exercise = new Exercise();

        // Act
        var correctChars = "abcdefghijklmnopqrstuvwxyz";
        var chars = exercise.Characters;

        // Assert
        Assert.Equal(correctChars, chars);
    }

    [Fact]
    public void CharactersProperty_ReturnsCorrectStringFromLevel0()
    {
        // Arrange
        var exercise = Exercise.Level0;

        // Act
        var correctChars = "fj";
        var chars = exercise.Characters;

        // Assert
        Assert.Equal(correctChars, chars);
    }

    [Fact]
    public void CharactersProperty_ReturnsCorrectStringFromLevel1()
    {
        // Arrange
        var exercise = Exercise.Level1;

        // Act
        var correctChars = "fghj";
        var chars = exercise.Characters;

        // Assert
        Assert.Equal(correctChars, chars);
    }

    [Fact]
    public void CharactersProperty_ReturnsCorrectStringFromLevel2()
    {
        // Arrange
        var exercise = Exercise.Level2;

        // Act
        var correctChars = "dfghjk";
        var chars = exercise.Characters;

        // Assert
        Assert.Equal(correctChars, chars);
    }

    [Fact]
    public void CharactersProperty_ReturnsCorrectStringFromDigital()
    {
        // Arrange
        var exercise = Exercise.Digital;

        // Act
        var correctChars = "0123456789";
        var chars = exercise.Characters;

        // Assert
        Assert.Equal(correctChars, chars);
    }

    [Fact]
    public void CharactersProperty_ReturnsCorrectStringFromFull()
    {
        // Arrange
        var exercise = Exercise.Full;

        // Act
        var correctChars = "abcdefghijklmnopqrstuvwxyz";
        var chars = exercise.Characters;

        // Assert
        Assert.Equal(correctChars, chars);
    }
}