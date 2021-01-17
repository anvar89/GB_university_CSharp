using System;

//  Факультет C#-разработки
//  Практическое занятие урока №1
//  Выполнил: Халитов Анвар
namespace Lesson1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Имя пользователя: ");
            string userName = Console.ReadLine();

            Console.WriteLine($"Привет, {userName}, сегодня {DateTime.Today.ToShortDateString()}");

            Console.ReadLine();
        }
    }
}
