using System;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Задача 4. Написать программу, вычисляющую число Фибоначчи для заданного значения рекурсивным способом. ");

            Task2.Program.AskUser<int>("Введите целое число: ", "Ошибка: нужно ввести число", (string x, out int n) => int.TryParse(x, out n), out int userInput);

            if (userInput >= 0)
            {
                for (int i = 0; i <= userInput; i++)
                {
                    Console.Write($"{Fibonacci(i)} ");
                }
            }
            else
            {
                for (int i = userInput; i <= 0; i++)
                {
                    Console.Write($"{Fibonacci(i)} ");
                }
            }

            Console.ReadKey();
        }

        static int Fibonacci(int num)
        {
            int p = Math.Abs(num);

            if (p == 0 || p == 1)
                return p;
            else
            {
                if (num > 0) return Fibonacci(num - 1) + Fibonacci(num - 2);
                else
                    return Fibonacci(num + 2) - Fibonacci(num + 1);
            }
        }
    }
}
