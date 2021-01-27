using System;


namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Задача 3. Написать метод по определению времени года. На вход подаётся число – порядковый номер месяца. " +
                "На выходе — значение из перечисления (enum) — Winter, Spring, Summer, Autumn. Написать метод, принимающий на вход значение " +
                "из этого перечисления и возвращающий название времени года (зима, весна, лето, осень). Используя эти методы, ввести с клавиатуры " +
                "номер месяца и вывести название времени года. Если введено некорректное число, вывести в консоль текст «Ошибка: введите число от 1 до 12».");

            Task2.Program.AskUser<int>("Введите порядковый номер месяца: ", "Ошибка: введите число от 1 до 12", Task3conditions, out int userInput);

            Console.WriteLine(TrancelateSeason(DetectSeason(userInput)));

            Console.ReadKey();
        }
        enum Seasons { Winter, Spring, Summer, Autumn }
        
        static Seasons DetectSeason(int number)
        {
            switch (number)
            {
                case 1:
                case 2:
                case 12:
                    return Seasons.Winter;

                case 3:
                case 4:
                case 5:
                    return Seasons.Spring;

                case 6:
                case 7:
                case 8:
                    return Seasons.Summer;

                default:
                    return Seasons.Autumn;
            }
        }

        static string TrancelateSeason(Seasons season)
        {
            switch (season)
            {
                case Seasons.Winter:
                    return "Зима";

                case Seasons.Spring:
                    return "Весна";

                case Seasons.Summer:
                    return "Лето";

                default:
                    return "Зима";
            }
        }

        public static bool Task3conditions(string input, out int num)
        {
            if (int.TryParse(input, out num))
                return num >= 1 && num <= 12;
            else
                return false;
        }
    }
}
