using System;

namespace Console_SaveToReg.Classes
{
    public class ConsoleMenu
    {
        private User user = new User();
        private readonly string[] menu = new string[]
      {
            " -> Name: ",
            "    Surname: ",
            "    Patronymic: ",
            "    Gender:    Male  /  Female",
            "    Text color",
            "    Background color"
      };
        public ConsoleMenu()
        {
            user.LoadDataFromReg();
            DrawMenu();
        }

        public void DrawMenu()
        {
            Console.Clear();
            Console.BackgroundColor = user.BackgroundColor;
            Console.ForegroundColor = user.ForegroundColor;

            string newStr = " -> Name: " + user.Name + Environment.NewLine;
            newStr += "    Surname: " + user.Surname + Environment.NewLine;
            newStr += "    Patronymic: " + user.Patronymic + Environment.NewLine;
            newStr += "    Gender:    Male  /  Female" + Environment.NewLine;
            newStr += "    Text color" + Environment.NewLine;
            newStr += "    Background color";
            Console.WriteLine(newStr);

            if (user.Gender != UserGender.None)
            {
                if (user.Gender == UserGender.Male)
                {
                    Console.SetCursorPosition(14, 3);
                }
                else
                {
                    Console.SetCursorPosition(23, 3);
                }
                Console.Write(">");
            }

            Console.CursorVisible = true;
            if (user.Name != null)
            {
                Console.SetCursorPosition(menu[menuNum].Length + user.Name.Length, menuNum);
            }
            else
            {
                Console.SetCursorPosition(menu[menuNum].Length, menuNum);
            }
            
        }
        public void DrawColorMenu()
        {
            Console.Clear();
            Console.CursorVisible = false;

            Console.Write(" -> ");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Text");
            for (int i = 1; i < 16; i++)
            {
                Console.ForegroundColor = (ConsoleColor)i;
                Console.WriteLine("    Text");
            }
        }

        private byte menuNum = 0;
        private ConsoleMenuState menuState = ConsoleMenuState.MainMenu;

        public void WriteSymbol(char symbol)
        {
            if (menuNum < 3 && menuState == ConsoleMenuState.MainMenu)
            {
                switch (menuNum)
                {
                    case 0:
                        if (user.Name != null)
                        {
                            if (user.Name.Length < 16)
                            {
                                user.Name += symbol;
                                break;
                            }
                        }
                        else
                        {
                            user.Name += symbol;
                            break;
                        }
                        return;
                    case 1:
                        if (user.Surname != null)
                        {
                            if (user.Surname.Length < 16)
                            {
                                user.Surname += symbol;
                                break;
                            }
                        }
                        else
                        {
                            user.Surname += symbol;
                            break;
                        }
                        return;
                    case 2:
                        if (user.Patronymic != null)
                        {
                            if (user.Patronymic.Length < 16)
                            {
                                user.Patronymic += symbol;
                                break;
                            }
                        }
                        else
                        {
                            user.Patronymic += symbol;
                            break;
                        }
                        return;
                }
                Console.Write(symbol);
            }
        }
        public void ClickEnter()
        {
            if (menuState == ConsoleMenuState.MainMenu)
            {
                switch (menuNum)
                {
                    case 4:
                        menuState = ConsoleMenuState.FGColorSelection;
                        break;
                    case 5:
                        menuState = ConsoleMenuState.BGColorSelection;
                        break;

                    default:
                        return;
                }

                menuNum = 0;
                DrawColorMenu();
            }
            else 
            {
                if (menuState == ConsoleMenuState.FGColorSelection)
                {
                    user.ForegroundColor = (ConsoleColor)menuNum;
                }
                else
                {
                    user.BackgroundColor = (ConsoleColor)menuNum;
                }
                menuNum = 0;
                menuState = ConsoleMenuState.MainMenu;
                DrawMenu();
            }
        }
        public void ClickBackspase()
        {
            if (menuState == ConsoleMenuState.MainMenu && menuNum < 3)
            {
                switch (menuNum)
                {
                    case 0:
                        if (!String.IsNullOrEmpty(user.Name))
                        {
                            user.Name = user.Name.Substring(0, user.Name.Length - 1);
                            Console.SetCursorPosition(menu[menuNum].Length + user.Name.Length, menuNum);
                            Console.Write(" ");
                            Console.SetCursorPosition(menu[menuNum].Length + user.Name.Length, menuNum);
                        }
                        break;
                    case 1:
                        if (!String.IsNullOrEmpty(user.Surname))
                        {
                            user.Surname = user.Surname.Substring(0, user.Surname.Length - 1);
                            Console.SetCursorPosition(menu[menuNum].Length + user.Surname.Length, menuNum);
                            Console.Write(" ");
                            Console.SetCursorPosition(menu[menuNum].Length + user.Surname.Length, menuNum);
                        }
                        break;
                    case 2:
                        if (!String.IsNullOrEmpty(user.Patronymic))
                        {
                            user.Patronymic = user.Patronymic.Substring(0, user.Patronymic.Length - 1);
                            Console.SetCursorPosition(menu[menuNum].Length + user.Patronymic.Length, menuNum);
                            Console.Write(" ");
                            Console.SetCursorPosition(menu[menuNum].Length + user.Patronymic.Length, menuNum);
                        }
                        break;
                }
            }
        }

        public void MoveCursorDown()
        {
            switch (menuState)
            {
                case ConsoleMenuState.MainMenu:
                    if (menuNum < menu.Length - 1)
                    {
                        Console.SetCursorPosition(1, menuNum);
                        Console.Write("  ");

                        Console.SetCursorPosition(1, ++menuNum);
                        Console.Write("->");

                        if (menuNum < 3)
                        {
                            Console.CursorVisible = true;
                            switch (menuNum)
                            {
                                case 0:
                                    if (!String.IsNullOrEmpty(user.Name))
                                    {
                                        Console.SetCursorPosition(menu[menuNum].Length + user.Name.Length, menuNum);
                                        return;
                                    }
                                    break;
                                case 1:
                                    if (!String.IsNullOrEmpty(user.Surname))
                                    {
                                        Console.SetCursorPosition(menu[menuNum].Length + user.Surname.Length, menuNum);
                                        return;
                                    }
                                    break;
                                case 2:
                                    if (!String.IsNullOrEmpty(user.Patronymic))
                                    {
                                        Console.SetCursorPosition(menu[menuNum].Length + user.Patronymic.Length, menuNum);
                                        return;
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            Console.CursorVisible = false;
                        }
                        Console.SetCursorPosition(menu[menuNum].Length, menuNum);
                    }
                    return;

                default:
                    if (menuNum < 16 - 1) // count console colors
                    {
                        Console.SetCursorPosition(1, menuNum);
                        Console.Write("  ");

                        Console.SetCursorPosition(1, ++menuNum);
                        Console.ForegroundColor = (ConsoleColor)menuNum;
                        Console.Write("->");
                    }
                    return;
            }
        }
        public void MoveCursorUp()
        {
            if (menuNum != 0)
            {
                Console.SetCursorPosition(1, menuNum);
                Console.Write("  ");

                Console.SetCursorPosition(1, --menuNum);
                if (menuState == ConsoleMenuState.FGColorSelection
                    || menuState == ConsoleMenuState.BGColorSelection)
                { Console.ForegroundColor = (ConsoleColor)menuNum; }
                Console.Write("->");
            }

            switch (menuState)
            {
                case ConsoleMenuState.MainMenu:
                    if (menuNum < 3)
                    {
                        Console.CursorVisible = true;
                        switch (menuNum)
                        {
                            case 0:
                                if (!String.IsNullOrEmpty(user.Name))
                                {
                                    Console.SetCursorPosition(menu[menuNum].Length + user.Name.Length, menuNum);
                                    return;
                                }
                                break;
                            case 1:
                                if (!String.IsNullOrEmpty(user.Surname))
                                {
                                    Console.SetCursorPosition(menu[menuNum].Length + user.Surname.Length, menuNum);
                                    return;
                                }
                                break;
                            case 2:
                                if (!String.IsNullOrEmpty(user.Patronymic))
                                {
                                    Console.SetCursorPosition(menu[menuNum].Length + user.Patronymic.Length, menuNum);
                                    return;
                                }
                                break;
                        }
                        Console.SetCursorPosition(menu[menuNum].Length, menuNum);
                    }
                    break;
                default:
                    break;
            }
        }
        public void MoveCursorRight()
        {
            if (menuNum == 3)
            {
                if (user.Gender == UserGender.Male)
                {
                    user.Gender = UserGender.Female;
                    Console.SetCursorPosition(14, menuNum);
                    Console.Write(" ");
                    Console.SetCursorPosition(23, menuNum);
                    Console.Write(">");
                    return;
                }
                if (user.Gender == UserGender.None)
                {
                    user.Gender = UserGender.Female;
                    Console.SetCursorPosition(23, menuNum);
                    Console.Write(">");
                }
            }
        }
        public void MoveCursorLeft()
        {
            if (menuNum == 3)
            {
                if (user.Gender == UserGender.Female)
                {
                    user.Gender = UserGender.Male;
                    Console.SetCursorPosition(23, menuNum);
                    Console.Write(" ");
                    Console.SetCursorPosition(14, menuNum);
                    Console.Write(">");
                    return;
                }
                if (user.Gender == UserGender.None)
                {
                    user.Gender = UserGender.Male;
                    Console.SetCursorPosition(14, menuNum);
                    Console.Write(">");
                }
            }
        } 
    }

    public enum ConsoleMenuState
    {
        MainMenu = 0,
        FGColorSelection = 1,
        BGColorSelection = 2
    }
}
