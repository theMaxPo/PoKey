using System;
using System.Threading.Tasks;

namespace PoKey.BL.Model;
public interface IDisplay
{
    /// <summary>
    /// Обработка считывания символов.
    /// </summary>
    char ReadInput();

    /// <summary>
    /// Вызывается ПОСЛЕ ввода каждого символа.
    /// </summary>
    void ProcessingInput(Text text);

    /// <summary>
    /// Вызывается постоянно после Start().
    /// </summary>
    /// <param name="time">Время прошедшее с запуска тренажера</param>
    void ProcessingInput(Text text, TimeSpan time);

    /// <summary>
    /// Вызывается ДО считавания ПЕРВОГО символа.
    /// </summary>
    void Start(Text text);

    /// <summary>
    /// Вызывается ПОСЛЕ считавания ПОСЛЕДНЕГО символа.
    /// </summary>
    void Finish(Text text);

    /// <summary>
    /// Вызывается ПОСЛЕ считавания ПОСЛЕДНЕГО символа.
    /// </summary>
    /// <param name="time">Итоговое время прошедшее с запуска тренажера</param>
    void Finish(Text text, TimeSpan time);
}