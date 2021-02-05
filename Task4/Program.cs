using System;
using System.Collections.Generic;
using System.IO;

namespace Task4
{
    class Program
    {
        static string identMiddle = "├─";
        static string identLast = "└─";
        static string identLine = "│ ";
        static string identEmpty = "  ";

        static void Main(string[] args)
        {
            Console.WriteLine("Задача 4. Сохранить дерево каталогов и файлов по заданному пути в текстовый файл — с рекурсией и без.");

            string path = Directory.GetCurrentDirectory();

            //filesTreeRecursive(new DirectoryInfo(@"E:\"));
            filesTreeLoop(@"E:\");
        }

        static void filesTreeLoop(string path)
        {

            Stack<string> directoryStack = new Stack<string>();
            directoryStack.Push(path);

            while (directoryStack.Count > 0)
            {
                var dirs = directoryStack.Pop();
                Console.WriteLine(dirs);

                try
                {
                    foreach (var item in Directory.GetDirectories(dirs))
                    {
                        directoryStack.Push(item);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }


        }

        static void filesTreeRecursive(DirectoryInfo dirInfo, string ident)
        {
            FileInfo[] files = null;
            DirectoryInfo[] subDirs = null;




            Console.WriteLine(dirInfo.Name);
            try
            {
                files = dirInfo.GetFiles("*.*");
                subDirs = dirInfo.GetDirectories();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            if (files != null)
            {
                foreach (DirectoryInfo item in subDirs)
                {
                    Console.Write(ident);
                    if ((item == subDirs[subDirs.Length - 1]) & (files.Length == 0))
                    {
                        Console.Write(identLast);
                        filesTreeRecursive(item, ident + identEmpty);
                    }
                    else
                    {
                        Console.Write(identMiddle);
                        filesTreeRecursive(item, ident + identLine);
                    }
                }
            }

            if (subDirs != null)
            {
                foreach (FileInfo item in files)
                {
                    Console.Write(ident);

                    if (item == files[files.Length - 1])
                        Console.Write(identLast);
                    else
                        Console.Write(identMiddle);

                    Console.WriteLine(item.Name);
                }
            }
        }

        static void filesTreeRecursive(DirectoryInfo dirInfo)
        {
            filesTreeRecursive(dirInfo, "");
        }
    }
}
