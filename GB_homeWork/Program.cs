using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Написать метод GetFullName(string firstName, string lastName, string patronymic), принимающий на вход ФИО в разных аргументах и возвращающий" +
                " объединённую строку с ФИО. Используя метод, написать программу, выводящую в консоль 3–4 разных ФИО.");

            Console.WriteLine(GetFullName("Владимир", "Ленин", "Ильич"));
            Console.WriteLine(GetFullName("Иосиф", "Сталин", "Виссарионович"));
            Console.WriteLine(GetFullName("Никита", "Хрущёв", "Сергеевич"));

            Console.ReadKey();
        }

        static string GetFullName(string firstName, string lastName, string patronymic) => $"{firstName} {patronymic} {lastName}";
    }
}
