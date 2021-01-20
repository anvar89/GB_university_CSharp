using System;

//  Задача 2 и 3
//  2. Запросить у пользователя порядковый номер текущего месяца и вывести его название.
//  3. Определить, является ли введённое пользователем число чётным.

namespace Task2_3
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
            Console.Write("Вы выбрали месяц: ");
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

            if (monthNumber % 2 == 0) Console.WriteLine("Это было чётное число");
            else Console.WriteLine("Это было нечётное число");

            Console.ReadKey();

        }
        


    }
}
