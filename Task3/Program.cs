using System;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Задача 3. Написать программу, выводящую введенную пользователем строку в обратном порядке (olleH вместо Hello).");

            Console.Write("Ваша строка: ");

            char[] userInputArray = Console.ReadLine().ToCharArray();

            for (int i = 0; i < userInputArray.Length / 2; i++)
            {
                char tmp = userInputArray[i];
                userInputArray[i] = userInputArray[userInputArray.Length - 1 - i];
                userInputArray[userInputArray.Length - 1 - i] = tmp;
            }

            Console.WriteLine(new String(userInputArray));
        }
    }
}
