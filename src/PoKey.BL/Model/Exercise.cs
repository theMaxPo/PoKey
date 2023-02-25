using System;
using System.Text;

namespace PoKey.BL.Model;

public class Exercise
{
    /// <summary>
    /// Символы - F J
    /// <summary>
    public static Exercise Level0 => new Exercise("fj");

    /// <summary>
    /// Символы - F G H J
    /// <summary>
    public static Exercise Level1 => new Exercise("fghj");

    /// <summary>
    /// Символы - D F G H J K
    /// <summary>
    public static Exercise Level2 => new Exercise("dfghjk");

    /// <summary>
    /// Символы - 0 1 .. 8 9
    /// <summary>
    public static Exercise Digital => new Exercise("0123456789");

    /// <summary>
    /// Символы - a .. z
    /// <summary>
    public static Exercise Full => new Exercise();

    /// <summary>
    /// Строка для составления последовательности символов.
    /// модификатор public - для тестов
    /// <summary>
    public readonly string Characters;

    public string Text { get; private set; }

    public Exercise()
    {
        Characters = GenerateText();
        RandomGenerateText();
    }

    public Exercise(string characters)
    {
        if (string.IsNullOrWhiteSpace(characters)) throw new ArgumentException("Строка не может быть пусто или null.", nameof(characters));

        Characters = characters;

        RandomGenerateText();
    }

    public Exercise(TextReadFiles textReadFiles) : this(textReadFiles.Text) { }

    /// <summary>
    /// Генерирует 
    /// <summary>
    public string RandomGenerateText(int length = 100, bool isSpace = true, int? seed = null)
    {
        if (length <= 0) throw new ArgumentException("Длина текста должна быть больше 0(нуля).", nameof(length));

        var result = new StringBuilder();
        var charCount = Characters.Length;

        var random = seed.HasValue ? new Random(seed.Value) : new Random();

        var isSecondSpace = false;

        for (int i = 0; i < length; i++)
        {
            // первый и последний символ НЕ пробел(space) и НЕ может быть два пробела подряд
            if (isSpace == false || i == 0 || i == length - 1 || isSecondSpace || length / 10 < random.Next(0, length))
            {
                var index = random.Next(0, charCount);

                result.Append(Characters[index]);

                isSecondSpace = false;
            }
            else
            {
                result.Append(' ');

                isSecondSpace = true;
            }
        }

        Text = result.ToString();
        return Text;
    }

    private string GenerateText(int length = 26)
    {
        if (length <= 0) throw new ArgumentException("Длина текста должна быть больше 0(нуля).", nameof(length));

        var result = new StringBuilder();
        for (var i = 0; i < length; i++)
        {
            result.Append((char)('a' + (i % 26)));
        }
        return result.ToString();
    }

    public override string ToString() => Characters;

}