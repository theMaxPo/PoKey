namespace PoKey.BL.Model;

/// <summary>
/// Значение символа(верно/неверон набран символ).
/// </summary>
public enum InputState
{
    /// <summary>
    /// еще не произведено никаких действий.
    /// </summary>
    NotAttempted,
    /// <summary>
    /// ошибочный ввод .
    /// </summary>
    Incorrect,
    /// <summary>
    /// верный ввод.
    /// </summary>
    Correct
}

public class Text
{
    /// <summary>
    /// Текст (символы) для печати.
    /// </summary>
    public readonly string Content;

    /// <summary>
    /// Индекс текущего символа.
    /// </summary>
    public int CurrentIndex { get; private set; }

    /// <summary>
    /// Колличество ошибок.
    /// </summary>
    public int ErrorCount { get; private set; }

    /// <summary>
    /// Результаты набора текста (Right=Верно|Error=Ошибка|None=Ещё не пройден).
    /// </summary>
    public InputState[] ErrorIndices { get; private set; }

    /// <summary>
    /// Значение набора текущего символа (Right=Верно|Error=Ошибка|None=Ещё не пройден).
    /// </summary>
    public InputState ErrorIndice
    {
        get
        {
            if (CurrentIndex >= 0 && CurrentIndex < Content.Length)
            {
                return ErrorIndices[CurrentIndex];
            }
            return InputState.NotAttempted;
        }
    }

    /// <summary>
    /// Текущий символ
    /// <summary>
    public char? CurrentChar
    {
        get
        {
            if (CurrentIndex >= 0 && CurrentIndex < Content.Length)
            {
                return Content[CurrentIndex];
            }
            return null;
        }
    }

    /// <summary>
    /// Следующий символ
    /// <summary>
    public char? FollowingChar
    {
        get
        {
            if (CurrentIndex + 1 >= 0 && CurrentIndex + 1 < Content.Length)
            {
                return Content[CurrentIndex + 1];
            }
            return null;
        }
    }

    public Text(Exercise exercise)
    {
        Content = exercise.Text;

        Reset();
    }

    /// <summary>
    /// Переход на один символ вперед.
    /// <summary>
    public void MoveToNextChar()
    {
        // if (CurrentIndex < Content.Length)
        // {
            CurrentIndex++;
        // }
    }

    public void CheckAndMoveToNextCharacter(char input)
    {
        CheckCharacter(input);

        MoveToNextChar();
    }

    public void CheckCharacter(char input)
    {
        if (CurrentChar.Equals(input))
        {
            ErrorIndices[CurrentIndex] = InputState.Correct;
        }
        else
        {
            ErrorIndices[CurrentIndex] = InputState.Incorrect;
            ErrorCount++;
        }
    }

    /// <summary>
    /// Обнулить все занчения.
    /// <summary>
    public void Reset()
    {
        ErrorCount = 0;
        CurrentIndex = 0;
        ErrorIndices = new InputState[Content.Length];
    }
}