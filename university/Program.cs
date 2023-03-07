using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace university
{
    // тут ввод еще должен быть ...
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\t\t\t - Меню -");
                Console.WriteLine("1. Заполнение данных");
                Console.WriteLine("2. Выборки");
                Console.WriteLine("3. Выход");
                Console.SetCursorPosition(23, 1);
                bool a = true;
                int c = 1;
                while (a)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.Enter && c == 1)
                    {
                        a = false;
                        Console.Clear();
                        Console.WriteLine("Скорее всего Вам лень заполнять, поэтому все данные уже находятся в файлах:)");
                        Console.WriteLine("Используйте их, пожалуйста ... ручного заполнения еще не накодили");

                    }
                    if (key.Key == ConsoleKey.Enter && c == 2)
                    {
                        a = false;
                        Console.Clear();
                        bool e = true;
                        Menu menu = new Menu();
                        while (e)
                        {
                            Console.WriteLine("\t\t Вы кто?");
                            Console.WriteLine("1. Управляющий");
                            Console.WriteLine("2. Преподаватель");
                            Console.WriteLine("3. Студентик");
                            Console.WriteLine("4. Обслуживающий персонал");
                            Console.SetCursorPosition(30, 1);
                            bool b = true;
                            int d = 1;
                            while (b)
                            {
                                key = Console.ReadKey(true);
                                if (key.Key == ConsoleKey.Enter && d == 1)
                                {
                                    b = false;
                                    Console.Clear();
                                    Console.Write("Для входа как управляющий введите фамилию: ");
                                    string f_boss = Console.ReadLine();
                                    menu.I_boss(f_boss);

                                }
                                if (key.Key == ConsoleKey.Enter && d == 2)
                                {
                                    b = false;
                                    Console.Clear();
                                    Console.Write("Для входа как преподователь введите фамилию: ");
                                    string f_prepod = Console.ReadLine();
                                    menu.I_prepod(f_prepod);

                                }
                                if (key.Key == ConsoleKey.Enter && d == 3)
                                {
                                    b = false;
                                    Console.Clear();
                                    Console.Write("Для входа как студент введите фамилию: ");
                                    string f_student = Console.ReadLine();
                                    menu.I_student(f_student);

                                }
                                if (key.Key == ConsoleKey.Enter && d == 4)
                                {
                                    b = false;
                                    Console.Clear();
                                    Console.Write("Для входа как обслуживающий персонал введите фамилию: ");
                                    string f_rab = Console.ReadLine();
                                    menu.I_rab(f_rab);

                                }
                                else if ((key.Key == ConsoleKey.DownArrow && d == 4) || (key.Key == ConsoleKey.UpArrow && d == 2))
                                {
                                    Console.SetCursorPosition(30, 1);
                                    d = 1;
                                }
                                else if ((key.Key == ConsoleKey.DownArrow && d == 1) || (key.Key == ConsoleKey.UpArrow && d == 3))
                                {
                                    Console.SetCursorPosition(30, 2);
                                    d = 2;
                                }
                                else if ((key.Key == ConsoleKey.DownArrow && d == 2) || (key.Key == ConsoleKey.UpArrow && d == 4))
                                {
                                    Console.SetCursorPosition(30, 3);
                                    d = 3;
                                }
                                else if ((key.Key == ConsoleKey.DownArrow && d == 3) || (key.Key == ConsoleKey.UpArrow && d == 1))
                                {
                                    Console.SetCursorPosition(30, 4);
                                    d = 4;
                                }
                            }
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.Write("Вернуться в меню? (да - Enter)");
                            Console.ForegroundColor = ConsoleColor.White;
                            ConsoleKeyInfo key2 = Console.ReadKey();
                            //если нажать не на Enter выбросит на предыдущую страницу, а не на главное меню
                            if (key2.Key == ConsoleKey.Enter)
                            {
                                e = false;
                            }
                            else e = true;
                            Console.Clear();
                        }
                    }
                    if (key.Key == ConsoleKey.Enter && c == 3)
                    {
                        a = false;
                        Console.Clear();
                        Environment.Exit(0);
                    }
                    else if ((key.Key == ConsoleKey.DownArrow && c == 3) || (key.Key == ConsoleKey.UpArrow && c == 2))
                    {
                        Console.SetCursorPosition(23, 1);
                        c = 1;
                    }
                    else if ((key.Key == ConsoleKey.DownArrow && c == 1) || (key.Key == ConsoleKey.UpArrow && c == 3))
                    {
                        Console.SetCursorPosition(23, 2);
                        c = 2;
                    }
                    else if ((key.Key == ConsoleKey.DownArrow && c == 2) || (key.Key == ConsoleKey.UpArrow && c == 1))
                    {
                        Console.SetCursorPosition(23, 3);
                        c = 3;
                    }
                }
                if (c != 2)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("Вернуться назад? ");
                    Console.ForegroundColor = ConsoleColor.White;
                    ConsoleKeyInfo key1 = Console.ReadKey();
                    Console.Clear();
                } 
            }
        }
    }
}