using System;
using System.IO;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Задача 4. Сохранить дерево каталогов и файлов по заданному пути в текстовый файл — с рекурсией и без.");

            string path = @"C:\Users\khali\Documents\gitHub\GB_university_CSharp";

            filesTreeRecursive(new DirectoryInfo(path));
        }

        static void filesTreeLoop(DriveInfo driveInfo)
        {

        }

        static void filesTreeRecursive(DirectoryInfo dirInfo, string ident)
        {
            FileInfo[] files = null;
            DirectoryInfo[] subDirs = null;

            string identMiddle = "├─";
            string identLast = "└─";
            string identLine = "│ ";
            string identEmpty = "  ";


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

        static void filesTreeRecursive(DirectoryInfo dirInfo)
        {
            filesTreeRecursive(dirInfo, "");
        }
    }
}
