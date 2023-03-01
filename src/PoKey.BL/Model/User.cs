using System;

namespace PoKey.BL.Model;

/// <summary>
/// Пользователь.
/// </summary>
[Serializable]
public class User
{
    #region Свойства
    public int Id { get; set; }

    /// <summary>
    /// Имя.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Общая аккуратность.
    /// </summary>
    public int OverallAccuracy { get; set; } = 100;

    #endregion

    /// <summary>
    /// Создать нового пользователя
    /// </summary>
    /// <param name="name"> Имя. </param>
    /// <exception cref="ArgumentNullException"></exception>
    public User(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentNullException("Имя не может быть пустым или null.", nameof(name));
        }
        Name = name;
    }

    public override string ToString() => Name + " " + OverallAccuracy;
}