using System;

//  Задача 6
//  Для полного закрепления битовых масок, попытайтесь создать универсальную структуру расписания недели, к примеру, чтобы описать работу какого
//  либо офиса. Явный пример - офис номер 1 работает со вторника до пятницы, офис номер 2 работает с понедельника до воскресенья.

namespace Task6
{
    class Program
    {
        [Flags]
        public enum DayOfWeek
        {
            Monday    = 0b_0000_0001,
            Tuesday   = 0b_0000_0010,
            Wednesday = 0b_0000_0100,
            Thursday  = 0b_0000_1000,
            Friday    = 0b_0001_0000,
            Saturday  = 0b_0010_0000,
            Sunday    = 0b_0100_0000
        }

        static void Main(string[] args)
        {
            //Расписание офиса 1
            DayOfWeek sheduleOffice1 = DayOfWeek.Tuesday | DayOfWeek.Wednesday | DayOfWeek.Thursday | DayOfWeek.Friday;

            //Расписание офиса 2
            DayOfWeek sheduleOffice2 = DayOfWeek.Monday | DayOfWeek.Tuesday | DayOfWeek.Wednesday | DayOfWeek.Thursday | DayOfWeek.Friday | DayOfWeek.Saturday | DayOfWeek.Sunday;

            bool office1AtFriday = (sheduleOffice1 & DayOfWeek.Friday) != 0;
            bool office2AtFriday = (sheduleOffice2 & DayOfWeek.Friday) != 0;

            bool office1AtSunday = (sheduleOffice1 & DayOfWeek.Sunday) != 0;
            bool office2AtSunday = (sheduleOffice2 & DayOfWeek.Sunday) != 0;

            Console.WriteLine("Какой офис работает в пятницу?");

            Console.Write("Офис №1 - ");
            Console.WriteLine(office1AtFriday ? "работает" : "не работает");

            Console.Write("Офис №2 - ");
            Console.WriteLine(office2AtFriday ? "работает" : "не работает");

            Console.WriteLine();

            Console.WriteLine("Какой офис работает в воскресенье?");

            Console.Write("Офис №1 - ");
            Console.WriteLine(office1AtSunday ? "работает" : "не работает");

            Console.Write("Офис №2 - ");
            Console.WriteLine(office2AtSunday ? "работает" : "не работает");

            Console.ReadKey();
        }
    }
}
