using System;
using System.Diagnostics;

namespace Lesson6
{
    class Program
    {
        static void Main(string[] args)
        {
            Process[] processesArray;

            string ProcNameColumn = "Имя процесса";
            string IdColumn = "ID";

            // Число строк на экране
            int rowsAtScreen = 30;
            // текущая страница
            int currentPage = 1;

            int selectedProcess = 0;



            while (true)
            {
                processesArray = Process.GetProcesses();


                // Общее число страниц
                int pageCnt = processesArray.Length / rowsAtScreen + (processesArray.Length % rowsAtScreen == 0 ? 0 : 1);

                // Число строк в текущей странице (может быть меньше чем rowsAtScreen на последней странице)
                int currentPageLimit = (currentPage + 1) * rowsAtScreen < processesArray.Length ? rowsAtScreen : (processesArray.Length - currentPage * rowsAtScreen);
                
                Console.WriteLine("╔".PadRight(67, '═') + "╦".PadRight(12, '═') + "╗");
                Console.WriteLine($"║ {ProcNameColumn,-65}║ {IdColumn,-10}║");
                Console.WriteLine("╠".PadRight(67, '═') + "╬".PadRight(12, '═') + "╣");

                int pageStartIndex = rowsAtScreen * (currentPage - 1);
                int pageEndIndex = rowsAtScreen * (currentPage - 1) + currentPageLimit;

                for (int i = pageStartIndex; i < pageEndIndex; i++)
                {
                    if (i == selectedProcess)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }

                    Console.WriteLine($"║ {processesArray[i].ProcessName,-65}║ {processesArray[i].Id,-10}║");

                    if (i == selectedProcess)
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }

                Console.WriteLine("╚".PadRight(67, '═') + "╩".PadRight(12, '═') + "╝");
                Console.WriteLine($"Страница {currentPage} из {pageCnt}");
                Console.WriteLine("<PageUp> <PageDown> - навигация по страницам");
                Console.WriteLine("<ArrowUp> <ArrowDown> - выбор процесса");
                Console.WriteLine("<Delete> - завершить указанный процесс (Нужны права администратора)");
                Console.SetCursorPosition(0, 0);


                ConsoleKey key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.PageUp:
                        if (currentPage > 1)
                        {
                            currentPage--;
                            selectedProcess = rowsAtScreen * (currentPage - 1);
                        }
                        break;
                    case ConsoleKey.PageDown:
                        if (currentPage < pageCnt)
                        {
                            currentPage++;
                            selectedProcess = rowsAtScreen * (currentPage - 1);
                        }
                        break;

                    case ConsoleKey.UpArrow:
                        selectedProcess = selectedProcess > pageStartIndex ? selectedProcess - 1 : pageStartIndex;
                        break;
                    case ConsoleKey.RightArrow:
                        break;
                    case ConsoleKey.DownArrow:
                        selectedProcess = selectedProcess < pageEndIndex - 1 ? selectedProcess + 1 : pageEndIndex - 1;
                        break;

                    case ConsoleKey.Delete:
                        try
                        {
                            processesArray[selectedProcess].Kill();
                            //Process.Start("CMD.exe", "Taskkill /PID " + processesArray[selectedProcess].Id + " / F");
                        }
                        catch(Exception e)
                        {
                            Console.Clear();
                            Console.SetCursorPosition(0, 0);
                            Console.WriteLine("Возникла ошибка!");
                            Console.WriteLine(e.Message);
                            Console.WriteLine("Нажмите любую клавиршу чтобы продолжить..");
                            Console.ReadKey();
                            Console.SetCursorPosition(0, 0);
                        }
                        break;

                    case ConsoleKey.F10:
                        return;
                    default:
                        break;
                }

                Console.Clear();
            }

        }


    }
}
