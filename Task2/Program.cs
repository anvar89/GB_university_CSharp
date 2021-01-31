using System;
using System.IO;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Задача 2. Написать программу, которая при старте дописывает текущее время в файл «startup.txt».");
            Console.WriteLine("Фиксирую время запуска программы...");

            File.WriteAllText("startup.txt", DateTime.Now.ToString());

        }
    }
}
