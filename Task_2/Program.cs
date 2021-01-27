using System;

namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Задача 2. Написать программу, принимающую на вход строку — набор чисел, разделенных пробелом, и возвращающую число — сумму всех чисел в строке." +
                "Ввести данные с клавиатуры и вывести результат на экран.");

            Console.WriteLine("Введите последовательность чисел:");
            string[] userInput = Console.ReadLine().Split(" ");

        }

        public static int GetSum(params int[] arr)
        {
            int result = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                result += arr[i];
            }
            return result;
        }



        public static T AskUser<T>(string info, string errorMessage, Predicate<T> condition)
        {
            if (typeof(T) == typeof(string))
            {
                Console.
                if (condition(string)) return 
            }

            if (typeof(T) == typeof(int))
            {

            }

            throw new Exception($"Запрос у пользователя типа {T.ToString} ещё не реализован");
        }
    }
}
