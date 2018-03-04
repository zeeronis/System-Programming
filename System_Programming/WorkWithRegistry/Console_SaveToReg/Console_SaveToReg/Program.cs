using Console_SaveToReg.Classes;
using System;

namespace Console_SaveToReg
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleMenu menu = new ConsoleMenu();

            while (true)
            {
                var consoleKey = Console.ReadKey(true);
                switch (consoleKey.Key)
                {
                    case ConsoleKey.DownArrow: menu.MoveCursorDown();
                        break;
                    case ConsoleKey.UpArrow: menu.MoveCursorUp();
                        break;
                    case ConsoleKey.LeftArrow: menu.MoveCursorLeft();
                        break;
                    case ConsoleKey.RightArrow: menu.MoveCursorRight();
                        break;


                    case ConsoleKey.Backspace: menu.ClickBackspase();
                        break;
                    case ConsoleKey.Enter: menu.ClickEnter();
                        break;

                    default: menu.WriteSymbol(consoleKey.KeyChar);
                        break;
                }
            }
        }

    }
}
