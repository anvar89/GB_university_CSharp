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

            // Расстановка кораблей
            CreateShip(numField, 4);

            CreateShip(numField, 3);
            CreateShip(numField, 3);

            CreateShip(numField, 2);
            CreateShip(numField, 2);
            CreateShip(numField, 2);

            CreateShip(numField, 1);
            CreateShip(numField, 1);
            CreateShip(numField, 1);
            CreateShip(numField, 1);

            // Вывод игрового поля в консоль
            for (int i = 0; i < numField.GetLength(0); i++)
            {
                for (int j = 0; j < numField.GetLength(1); j++)
                {
                    if (numField[i, j] == 1) Console.Write("[X]");
                    else Console.Write(" o ");
                }
                Console.WriteLine();
            }
        }

        static void CreateShip(int[,] numField, int dimension)
        {
           Random rnd = new Random();
           if (dimension == 1)
           {
                // Создание 1-трубного корабля
               for (int cnt = 0; cnt < 10000; cnt++) // 10к попыток создать корабль, чтобы не ставить бесконечный цикл
               {
                   int vPos = rnd.Next(0, numField.GetLength(0) - 1);
                   int gPos = rnd.Next(0, numField.GetLength(1) - 1);

                   //Проверка области, где планируется расположить корабль, на занятость или соседство с другими кораблями
                   int vStart = (vPos - 1 >= 0) ? (vPos - 1) : 0;
                   int vEnd = (vPos + 1 < numField.GetLength(0)) ? (vPos + 1) : (numField.GetLength(0) - 1);
                   int gStart = (gPos - 1 >= 0) ? (gPos - 1) : 0;
                   int gEnd = (gPos + 1 < numField.GetLength(1)) ? (gPos + 1) : gPos;

                   if (IsFreeArea(numField, vStart, vEnd, gStart, gEnd))
                   {
                       //подходящее место для корабля
                       numField[vPos, gPos] = 1;
                       break;
                   }

               }

           }
           if (dimension > 1)
           {
                // Создание 2,3,4-трубных кораблей

                for (int i = 0; i < 10000; i++)
                {
                    bool vertical = rnd.Next(1, 100) < 50;
                    int vPos = rnd.Next(0, numField.GetLength(0) - 1);
                    int gPos = rnd.Next(0, numField.GetLength(1) - 1);

                    //Проверка области, где планируется расположить корабль, на занятость или соседство с другими кораблями

                    int vStart;
                    int vEnd;
                    int gStart;
                    int gEnd;

                    vStart = (vPos - 1 >= 0) ? (vPos - 1) : 0;
                    gStart = (gPos - 1 >= 0) ? (gPos - 1) : 0;


                    if (vertical)
                    {
                        if (vPos + dimension < numField.GetLength(0))
                        {
                            vEnd = (vPos + dimension + 1 < numField.GetLength(0)) ? (vPos + dimension + 1) : (vPos + dimension);
                            gEnd = (gPos < numField.GetLength(1)) ? (gPos + 1) : gPos;
                        }
                        else continue;
                    }
                    else
                    {
                        if (gPos + dimension < numField.GetLength(1))
                        {
                            vEnd = (vPos < numField.GetLength(0)) ? (vPos + 1) : vPos;
                            gEnd = (gPos + dimension + 1 < numField.GetLength(1)) ? (gPos + dimension + 1) : (gPos + dimension);

                        }
                        else continue;
                    }

                    if (IsFreeArea(numField, vStart, vEnd, gStart, gEnd))
                    {
                        //подходящее место для корабля
                        if (vertical)
                        {
                            for (int j = vPos; j < vPos + dimension; j++)
                            {
                                numField[j, gPos] = 1;
                            }
                        }
                        else
                        {
                            for (int j = gPos; j < gPos + dimension; j++)
                            {
                                numField[vPos, j] = 1;
                            }
                        }
                        break;
                    }

                }
            }
       

        }

        static bool IsFreeArea(int[,] field, int vStart, int vEnd, int gStart, int gEnd)
        {
            for (int i = vStart; i <= vEnd; i++)
            {
                for (int j = gStart; j <= gEnd; j++)
                {
                    if (field[i, j] == 1) return false;
                }
            }
            return true;
        }
    }
}
