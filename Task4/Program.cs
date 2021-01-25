using System;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Задача 4. «Морской бой» — вывести на экран массив 10х10, состоящий из символов X и O, где Х — элементы кораблей, а О — свободные клетки.");
            // Автоматического (рамдомного) расположения кораблей использую 2-мерный массив int, все элементы которого по умолчанию 0
            // 0 - свободная место
            // 1 - корабль/часть корабля

            int[,] numField = new int[10, 10];

            string[,] field = new string[10, 10]; //игровое поле

            CreateShip(numField, 1);
            CreateShip(numField, 1);
            CreateShip(numField, 1);
            CreateShip(numField, 1);

            for (int i = 0; i < numField.GetLength(0); i++)
            {
                for (int j = 0; j < numField.GetLength(1); j++)
                {
                    Console.Write($" {numField[i, j]} ");
                    if (j == numField.GetLength(1) - 1) Console.WriteLine();
                }
            }
        }

        static void CreateShip(int[,] numField, int dimension)
        {
           Random rnd = new Random();
           if (dimension == 1)
           {
               for (int cnt = 0; cnt < 100; cnt++)
               {
                   int vPos = rnd.Next(0, numField.GetLength(0) - 1);
                   int gPos = rnd.Next(0, numField.GetLength(1) - 1);

                   //Проверка области, где планируется расположить корабль, на занятость или соседство с другими кораблями
                   int vStart = (vPos - 1 >= 0) ? (vPos - 1) : 0;
                   int vEnd = (vPos + 1 <= dimension - 1) ? (vPos + 1) : (dimension - 1);
                   int gStart = (gPos - 1 >= 0) ? (gPos - 1) : 0;
                   int gEnd = (gPos + 1 <= dimension - 1) ? (gPos + 1) : (dimension - 1);

                   if (IsFreeArea(numField, vStart, vEnd, gStart, gEnd))
                   {
                       //подходящее место для корабля
                       numField[vPos, gPos] = 1;
                       break;
                   }

               }


           }
       

        }

        static bool IsFreeArea(int[,] field, int vStart, int vEnd, int gStart, int gEnd)
        {
            for (int i = vStart; i <= vEnd; i++)
            {
                for (int j = gStart; j < gEnd; j++)
                {
                    if (field[i, j] == 1) return false;
                }
            }
            return true;
        }
    }
}
