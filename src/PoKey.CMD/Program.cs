using System;
using PoKey.BL;
using PoKey.BL.Model;

internal class Program
{
    private static void Main(string[] args)
    {
        var trainer = new Trainer(new Exercise("a"), new ConsoleDisplay());
        UserConrtoller userConrtoller;

        Console.Clear();
        Console.WriteLine("Добро пожаловать в клавиатурный тренажер!");
        Console.WriteLine("Нажмите любую клавишу что бы начать.");
        Console.ReadKey();
        Console.Clear();

        while (true)
        {
            Console.WriteLine("Введите имя");
            Console.Write(">");
            var name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name) == false)
            {
                userConrtoller = new UserConrtoller(name);
                break;
            }
            Console.Clear();
            Console.WriteLine("Ошибка ввода!");
        }
        Console.WriteLine($"{userConrtoller.User.Name}, добро пожаловать в клавиатурный тренажер!");


        while (MainMenu(ref trainer, userConrtoller)) ;
    }

    public static bool MainMenu(ref Trainer trainer, UserConrtoller? userConrtoller = null)
    {
        Console.Clear();
        if(userConrtoller is not null)
        {
            userConrtoller.UpdataAccuracy(88);
            Console.WriteLine($"Игрок: {userConrtoller.User.Name}");
            Console.WriteLine($"Счет:  {userConrtoller.User.OverallAccuracy}");
        }
        Console.WriteLine("N   - новая игра");
        Console.WriteLine("R   - перезапуск текущей игры");
        Console.WriteLine("ESC - выход");
        Console.Write("> ");
        switch (Console.ReadKey().Key)
        {
            case ConsoleKey.Escape:
                Console.Write("Exit\n");
                return false;
            case ConsoleKey.R:
                trainer.Reset();
                break;
            case ConsoleKey.N:
                NewGameMenu(ref trainer);
                break;
        }
        return true;
    }

    private static void NewGameMenu(ref Trainer trainer)
    {
        Console.Clear();
        Console.WriteLine("ESC - Назад");
        Console.WriteLine("0   - Символы - F J");
        Console.WriteLine("1   - Символы - F G H J");
        Console.WriteLine("2   - Символы - D F G H J K");
        Console.WriteLine("D   - Символы - 0 1 .. 8 9");
        Console.WriteLine("F   - Символы - A .. Z");
        // Console.WriteLine("C   - Символы - Пользовательские");
        Console.Write("> ");

        switch (Console.ReadKey().Key)
        {
            case ConsoleKey.Escape:
                break;
            case ConsoleKey.D0:
                TrainerPlay(ref trainer, Exercise.Level0);
                break;
            case ConsoleKey.D1:
                TrainerPlay(ref trainer, Exercise.Level1);
                break;
            case ConsoleKey.D2:
                TrainerPlay(ref trainer, Exercise.Level2);
                break;
            case ConsoleKey.D:
                TrainerPlay(ref trainer, Exercise.Digital);
                break;
            case ConsoleKey.F:
                TrainerPlay(ref trainer, Exercise.Full);
                break;
        }

        void TrainerPlay(ref Trainer trainer, Exercise exercise)
        {
            trainer = new Trainer(exercise, new ConsoleDisplay());
            trainer.Play();
        }
    }
}