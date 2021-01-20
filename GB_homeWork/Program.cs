using System;


//  Задача 1
//  
namespace GB_homeWork
{
    class Program
    {
        static void Main(string[] args)
        {
            double tempMin, tempMax, tempAver;

            while (true)
            {
                Console.Write("Введите минимальую температуру: ");

                if (double.TryParse(Console.ReadLine(), out tempMin))
                    break;
                else
                    Console.WriteLine("Вы должны ввести число!");
            }


            while (true)
            {
                Console.Write("Введите максимальную температуру температуру: ");

                if (double.TryParse(Console.ReadLine(), out tempMax))
                {
                    if (tempMax > tempMin) break;
                    else
                        Console.WriteLine("Максимальная температура не может быть меньше минимальной");
                }
                else
                    Console.WriteLine("Вы должны ввести число!");
            }

            Console.WriteLine($"Среднесуточная температура: {(tempMin + tempMax) / 2}");

        }
    }
}
