using System;

//  Задачи 1-3
//  1. Запросить у пользователя минимальную и максимальную температуру за сутки и вывести среднесуточную температуру.
//  2. Запросить у пользователя порядковый номер текущего месяца и вывести его название.
//  3. Определить, является ли введённое пользователем число чётным.
//  5. Если пользователь указал месяц из зимнего периода, а средняя температура > 0, вывести сообщение «Дождливая зима».

namespace Task1_2_3_5
{
    class Program
    {
        static void Main(string[] args)
        {
            int monthNumber;
            double tempMin, tempMax, tempAver;

            // Ввод данных по задаче 1
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

            // Ввод данных по задаче 2
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

            // Решение Задачи 1
            tempAver = (tempMin + tempMax) / 2;
            Console.WriteLine($"Задача 1. Среднесуточная температура: {tempAver}");

            // Задача 2
            Console.Write("Задача 2. Вы выбрали месяц: ");
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

            // Задача 3
            Console.Write("Задача 3. ");
            if (monthNumber % 2 == 0) Console.WriteLine("Это было чётное число");
            else Console.WriteLine("Это было нечётное число");

            //Задача 5
            if (tempAver > 0 && (monthNumber == 1 || monthNumber == 2 || monthNumber == 12))
                Console.WriteLine("Задача 5. Дождливая зима");

            Console.ReadKey();

        }
        


    }
}
