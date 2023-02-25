using System;
using System.IO;

namespace PoKey.BL.Model;

public class TextReadFiles
{
    public readonly string? Text;

    public TextReadFiles(string path)
    {
        if (string.IsNullOrWhiteSpace(path)) throw new ArgumentException("Путь не может быть пустым или null.", nameof(path));

        using var reader = new StreamReader(path);
        Text = reader.ReadLine();
        
        if (string.IsNullOrWhiteSpace(Text)) throw new ArgumentException("Строка не может быть пустой или null.", nameof(Text));
    }
}