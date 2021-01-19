using System;

//  Задача 2
//  Запросить у пользователя порядковый номер текущего месяца и вывести его название.

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            int monthNumber;
            while (true)
            {
                Console.Write("Введите номер месяца: ");

                if (int.TryParse(Console.ReadLine(), out monthNumber))
                {
                    if ((monthNumber > 1) && (monthNumber <= 12)) break;
                    else
                        Console.WriteLine("Введите число в диапазоне  1..12");
                }
                else
                    Console.WriteLine("Вы должны ввести число!");
            }

            switch (monthNumber)
            {
                case 1: Console.WriteLine("Январь"); break;
                case 2: Console.WriteLine("Февраль"); break;
                case 3: Console.WriteLine("Март"); break;
                case 4: Console.WriteLine("Апрель"); break;
                case 5: Console.WriteLine("Май"); break;
                case 6: Console.WriteLine("Июнь"); break;
                case 7: Console.WriteLine("Июль"); break;
                case 8: Console.WriteLine("Август"); break;
                case 9: Console.WriteLine("Сентябрь"); break;
                case 10: Console.WriteLine("Октябрь"); break;
                case 11: Console.WriteLine("Ноябрь"); break;
                case 12: Console.WriteLine("Декабрь"); break;
            }

            Console.ReadKey();

        }
        


    }
}
