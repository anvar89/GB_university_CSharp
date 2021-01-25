using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Задача 1. Написать программу, выводящую элементы двухмерного массива по диагонали.");
            int dimension = AskUserForInt("Введите размер массива: ");

            //Заполнение и вывод массива
            int[,] array = new int[dimension, dimension];
            Random rnd = new Random();

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = rnd.Next(0, 100);

                    Console.Write($"{array[i, j]}\t");
                }
                Console.WriteLine();
            }

            Console.Write("Главная диагональ: ");
            for (int i = 0; i < dimension; i++)
            {
                Console.Write($"{array[i, i]} ");
            }
            
            Console.Write("\nПобочная диагональ: ");
            for (int i = 0; i < dimension; i++)
            {
                Console.Write($"{array[i, dimension - 1 - i]} ");
            }
        }

        static int AskUserForInt(string info)
        {
            while (true)
            {
                Console.Write(info);
                if(int.TryParse(Console.ReadLine(), out int result))
                {
                    if (result > 2) return result;
                }
                Console.WriteLine("Введите число больше 2");
            }
        }
    }
}
