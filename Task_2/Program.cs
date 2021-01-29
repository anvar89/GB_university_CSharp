using System;


namespace Task2
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Задача 2. Написать программу, принимающую на вход строку — набор чисел, разделенных пробелом, и возвращающую число — сумму всех чисел в строке." +
                "Ввести данные с клавиатуры и вывести результат на экран.");

            string info = "Введите последовательность чисел: ";
            string errorMessage = "Ваша последовательность должна содержать цифры, разделённые пробелами";

            AskUser<int[]>(info, errorMessage, Task2conditions, out int[] userInput);

            Console.WriteLine($"Сумма введёных вами чисел: {GetSum(userInput)}");

            Console.ReadKey();

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

        public static bool Task2conditions(string input, out int[] array)
        {
            string[] number = input.Split(" ", StringSplitOptions.RemoveEmptyEntries); // Массив с числами-строками
            int[] result = new int[number.Length]; // Массив с числами

            for (int i = 0; i < number.Length; i++)
            {
                if (!int.TryParse(number[i], out result[i]))
                {
                    array = result;
                    return false;
                }
            }

            array = result;
            return true;
        }

        public static void AskUser<T>(string info, string errorMessage, ConvertAndCheck<T> check, out T result)
        {
            while (true)
            {
                Console.Write(info);

                if (check(Console.ReadLine(), out result)) break;
                else
                    Console.WriteLine(errorMessage);
            }

        }

        public delegate bool ConvertAndCheck<T>(string input, out T result);
    }
}
