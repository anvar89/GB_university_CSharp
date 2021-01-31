using System;
using System.IO;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Задача 1. Ввести с клавиатуры произвольный набор данных и сохранить его в текстовый файл.");
            Console.Write("Введите что-нибудь: ");

            File.WriteAllText("Task1.txt", Console.ReadLine());
        }
    }
}
