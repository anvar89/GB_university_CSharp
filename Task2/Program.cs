using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Задача 2. Написать программу — телефонный справочник — создать двумерный массив 5*2, хранящий список телефонных" +
                " \nконтактов: первый элемент хранит имя контакта, второй — номер телефона/e-mail.");
            
            bool exit = false;
            string[,] phoneDB = new string[5, 2] { { "Иванов", "ivanov@gmail.com" }, 
                                                   { "Петров", "+79996665544" },
                                                   { "Сидоров", "+71112223344" },
                                                   { "Орлов", "orlov@gmail.com" },
                                                   { "Соколов", "sokolov@gmail.com" }, };
            Console.WriteLine("Доступны команды:");
            Console.WriteLine("\t-list - вывести полный список контактов");
            Console.WriteLine("\t-edit number - изменить контакт под номером number (чтобы узнать номера воспользуйтесь командой -list)");
            Console.WriteLine("\t-exit - выход из программы");

            while (!exit)
            {
                Console.Write("Введите команду или строку для поиска: ");
                string userInput = Console.ReadLine();

                if (userInput.StartsWith("-"))
                {
                    //  Введена команда
                    string[] userInputArray = userInput.Split(' ');

                    switch (userInputArray[0])
                    {
                        case "-exit":
                            // выход из программы
                            exit = true;
                            break;

                        case "-list":
                            // вывести список всех контактов
                            for (int i = 0; i < phoneDB.GetLength(0); i++)
                            {
                                Console.WriteLine($"{i}. {phoneDB[i, 0]} - {phoneDB[i, 1]}");
                            }
                            Console.WriteLine();
                            break;

                        case "-edit":
                            // изменить контакт
                            if (userInputArray.Length > 1)
                            {
                                if (int.TryParse(userInputArray[1], out int number))
                                {
                                    Console.Write($"Введите новое имя для контакта {phoneDB[number, 0]}:");
                                    string newName = Console.ReadLine();
                                    phoneDB[number, 0] = newName;

                                    Console.Write($"Введите новый номер телефона/e-mail для контакта {phoneDB[number, 0]}:");
                                    string newAddress = Console.ReadLine();
                                    phoneDB[number, 1] = newAddress;

                                    Console.WriteLine("Контакт изменён");
                                }
                                else
                                    Console.WriteLine("Введите номер контакта в справочнике");
                            }
                            else
                                Console.WriteLine("Введите номер контакта в справочнике");
                            break;

                        default:
                            Console.WriteLine("Неизвестная команда");
                            break;

                    }
                }
                else
                {
                    bool noMatch = true;
                    for (int i = 0; i < phoneDB.GetLength(0); i++)
                    {
                        if (phoneDB[i, 0].Contains(userInput) || phoneDB[i, 1].Contains(userInput))
                        {
                            Console.WriteLine($"{phoneDB[i, 0]} - {phoneDB[i, 1]}");
                            noMatch = false;
                        }
                    }

                    if (noMatch) Console.WriteLine("Нет совпадений!");
                    Console.WriteLine();

                }
            }

        }
    }
}
