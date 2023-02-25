using System;
using System.Linq;

namespace PoKey.BL.Model;
public class ConsoleDisplay : IDisplay
{
    public void Start(Text text)
    {
        Console.Clear();
        Console.CursorVisible = false;

        var txt = text.Content.Replace(' ', '∙');

        ConsoleWrite(txt, ConsoleColor.DarkGray);

        ConsoleWrite(text.CurrentChar, ConsoleColor.Blue, 0, Console.GetCursorPosition().Top);
    }

    public void Finish(Text text)
    {
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("Финиш!");
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine($"Ошибок: {text.ErrorCount}");
        Console.ForegroundColor = ConsoleColor.DarkGray;
    }

    public void Finish(Text text, TimeSpan time)
    {
        Finish(text);

        var correctInputCharCount = text.ErrorIndices.Where(err => err == InputState.Correct).Count();

        var textLength = text.Content.Length;

        var accuracy = Math.Round(((double)correctInputCharCount / (double)textLength) * 100.0);

        var seconds = time.TotalSeconds;

        var wpm = (int)(textLength * 60 / (seconds > 0 ? seconds : 1));

        Console.WriteLine("Время: {0:mm\\:ss}", time);
        Console.WriteLine($"Аккуратность: {accuracy}%");
        Console.WriteLine($"Сим. в минуту: {wpm}");

        Console.CursorVisible = true;

        Console.WriteLine("Нажмите любую клавишу что бы продолжить.");
        Console.ReadKey();
    }

    public void ProcessingInput(Text text)
    {
        // Удаляем набронный символ
        Console.SetCursorPosition(text.Content.Length + 1, Console.GetCursorPosition().Top);
        Console.Write("\b \b");

        var color = text.ErrorIndice == InputState.Correct ? ConsoleColor.DarkGreen : ConsoleColor.DarkRed;
        ConsoleWrite(text.CurrentChar, color, text.CurrentIndex, Console.GetCursorPosition().Top);

        ConsoleWrite(text.FollowingChar, ConsoleColor.Blue, text.CurrentIndex + 1, Console.GetCursorPosition().Top);
    }

    public void ProcessingInput(Text text, TimeSpan time)
    {
        ProcessingInput(text);
    }

    public char ReadInput() => Console.ReadKey().KeyChar;

    private void ConsoleWrite(string? text, ConsoleColor color, int positionLeft = 0, int positionTop = 0)
    {
        Console.SetCursorPosition(positionLeft, positionTop);
        Console.ForegroundColor = color;
        Console.Write(text);
    }

    private void ConsoleWrite(char? text, ConsoleColor color, int positionLeft = 0, int positionTop = 0)
    {
        text = text.Equals(' ') ? '∙' : text;

        ConsoleWrite(text.ToString(), color, positionLeft, positionTop);
    }
}