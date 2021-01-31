using System;
using System.IO;
using System.Collections.Generic;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Задача 3. Ввести с клавиатуры произвольный набор чисел (0...255) и записать их в бинарный файл.");
            Console.Write("Введите числа 0..255: ");
            List<byte> numList = new List<byte>();

            while (true)
            {
                if (byte.TryParse(Console.ReadLine(), out byte num))
                    numList.Add(num);
                else
                {
                    Console.WriteLine("Ввод окончен!");
                    break;
                }
            }

            File.WriteAllBytes("Task3.bin", numList.ToArray());
        }
    }
}
