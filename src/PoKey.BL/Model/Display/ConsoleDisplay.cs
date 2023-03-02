using System;
using System.Linq;

namespace PoKey.BL.Model;
public class ConsoleDisplay : IDisplay
{
    private const int LAYER_0 = 0;
    private const int LAYER_1 = 1;
    private const int LAYER_2 = 2;
    public void Start(Text text)
    {
        Console.Clear();
        Console.SetCursorPosition(0, LAYER_0);
        Console.WriteLine("Время: {0:mm\\:ss}", new TimeSpan());

        Console.CursorVisible = false;

        var txt = text.Content.Replace(' ', '∙');

        ConsoleWrite(txt, ConsoleColor.DarkGray, 0, LAYER_1);

        ConsoleWrite(text.CurrentChar, ConsoleColor.Blue, 0, LAYER_1);
        Console.SetCursorPosition(text.Content.Length + 1, LAYER_1);
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

        Console.WriteLine("Нажмите Enter что бы продолжить.");
        while (Console.ReadKey().Key != ConsoleKey.Enter);
    }

    public void ProcessingInput(Text text)
    {
        // Удаляем набронный символ
        Console.SetCursorPosition(text.Content.Length + 1, LAYER_1);
        Console.Write("\b \b");

        var color = text.ErrorIndice == InputState.Correct ? ConsoleColor.DarkGreen : ConsoleColor.DarkRed;
        ConsoleWrite(text.CurrentChar, color, text.CurrentIndex, LAYER_1);

        ConsoleWrite(text.FollowingChar, ConsoleColor.Blue, text.CurrentIndex + 1, LAYER_1);
    }

    public void ProcessingInput(Text text, TimeSpan time)
    {
        Console.SetCursorPosition(0, 0);

        var correctInputCharCount = text.ErrorIndices.Where(err => err == InputState.Correct).Count();

        var textLength = text.Content.Length;

        var accuracy = Math.Round(((double)correctInputCharCount / (double)textLength) * 100.0);

        var seconds = time.TotalSeconds;

        var wpm = (int)(textLength * 60 / (seconds > 0 ? seconds : 1));

        Console.Write("Время: {0,3:000}с. ", time.TotalSeconds);
        Console.Write("Аккуратность: {0: 00}% ", accuracy);
        Console.Write("Сим. в минуту: {0:0000} ", wpm);

        Console.SetCursorPosition(text.Content.Length, LAYER_1);
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