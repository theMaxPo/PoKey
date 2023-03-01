using System;

namespace PoKey.BL.Model
{
    /// <summary>
    /// Контроллер Пользователя.
    /// </summary>
    public class UserConrtoller
    {
        /// <summary>
        /// Текущий(Выбронный) пользователь.
        /// </summary>
        public User User { get; }

        private IDataSaveMode saver = new DatabaseSaver();

        /// <summary>
        /// Создание нового контроллера пользователя.
        /// </summary>
        /// <param name="user"> Имя Пользоваетль. </param>
        /// <exception cref="ArgumentNullException"></exception>
        public UserConrtoller(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым.", nameof(userName));
            }

            User = GetUserData(userName);
        }

        /// <summary>
        /// Обновить данные точности.
        /// </summary>
        /// <param name="lastValueAccuracy"> Последние данные точности. </param>
        public void UpdataAccuracy(int lastValueAccuracy)
        {
            User.OverallAccuracy = Convert.ToInt32((User.OverallAccuracy + lastValueAccuracy) / 2.0);
            Save();
        }

        /// <summary>
        /// Получить сохраненные данные пользователя().
        /// </summary>
        private User GetUserData(string name) => saver.Load(name);

        /// <summary>
        /// Сохранить данные Пользователя.
        /// </summary>
        public void Save() => saver.Save(User);
    }
}