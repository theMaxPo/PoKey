using System;
using PoKey.BL;
using PoKey.BL.Model;

internal class Program
{
    private static void Main(string[] args)
    {
        var trainer = new Trainer(new Exercise("a"), new ConsoleDisplay());

        Console.Clear();
        Console.WriteLine("Нажмите любую клавишу что бы начать.");
        Console.ReadKey();

        while (MainMenu(ref trainer)) ;
    }

    public static bool MainMenu(ref Trainer trainer)
    {
        Console.Clear();
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
                TrainerPlay(trainer, Exercise.Level0);
                break;
            case ConsoleKey.D1:
                TrainerPlay(trainer, Exercise.Level1);
                break;
            case ConsoleKey.D2:
                TrainerPlay(trainer, Exercise.Level2);
                break;
            case ConsoleKey.D:
                TrainerPlay(trainer, Exercise.Digital);
                break;
            case ConsoleKey.F:
                TrainerPlay(trainer, Exercise.Full);
                break;
        }

        void TrainerPlay(Trainer trainer, Exercise exercise)
        {
            trainer = new Trainer(exercise, new ConsoleDisplay());
            trainer.Play();
        }
    }
}