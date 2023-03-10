using System;
using System.Threading.Tasks;
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
    private TimeSpan ElapsedTime
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

        char key = default;

        LoopAsync();

        while (text.CurrentChar != null)
        {
            key = Display.ReadInput();

            text.CheckCharacter(key);

            Display.ProcessingInput(text);

            text.MoveToNextChar();
        }

        finishTime = DateTime.Now;

        IsFinished = true;
        Display.Finish(text, ElapsedTime);
    }

    private async Task LoopAsync() => await Task.Run(() => Loop());

    private void Loop()
    {
        while (text.CurrentChar != null)
        {
            Display.Loop(text, ElapsedTime);
        }
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
