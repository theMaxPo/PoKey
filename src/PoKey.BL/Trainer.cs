using System;
using PoKey.BL.Model;

namespace PoKey.BL;

public class Trainer
{
    private Text text;

    private readonly IDisplay Display;

    public bool IsFinished { get; private set; } = false;

    private DateTime startTime;
    private DateTime finishTime;

    /// <summary>
    /// Прошедшее время с запуска тренажера.
    /// По завершению текущей партии время останавливается.
    /// </summary>
    public TimeSpan ElapsedTime
    {
        get
        {
            if (IsFinished)
            {
                return finishTime - startTime;
            }
            else
            {
                return DateTime.Now - startTime;
            }
        }
    }

    public Trainer(Exercise exercise, IDisplay display)
    {
        this.text = new Text(exercise);

        this.Display = display;
    }

    /// <summary>
    /// Запуск тренажера.
    /// </summary>
    public virtual void Play()
    {
        startTime = DateTime.Now;

        Display.Start(text);

        while (text.CurrentChar != null)
        {
            char key = Display.ReadInput();

            text.CheckCharacter(key);

            Display.ProcessingInput(text);

            text.MoveToNextChar();
        }

        finishTime = DateTime.Now;

        IsFinished = true;
        Display.Finish(text, ElapsedTime);
    }

    /// <summary>
    /// Перезапустить текущую партию.
    /// </summary>
    public virtual void Reset()
    {
        text.Reset();
        Play();
    }
}
