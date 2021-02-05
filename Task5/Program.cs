using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Task5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(
@"Задача 5. Список задач (ToDo-list):
    - написать приложение для ввода списка задач;
    - задачу описать классом ToDo с полями Title и IsDone;
    - на старте, если есть файл tasks.json / xml / bin(выбрать формат), загрузить из него массив имеющихся задач и вывести их на экран;
    - если задача выполнена, вывести перед её названием строку «[x]»;
    - вывести порядковый номер для каждой задачи;
    - при вводе пользователем порядкового номера задачи отметить задачу с этим порядковым номером как выполненную;
    - записать актуальный массив задач в файл tasks.json / xml / bin.");

            string fileName = "tasks.json";
            List<ToDo> tasks = new List<ToDo>();

            if (File.Exists(fileName))
            {
                string json = File.ReadAllText(fileName);
                tasks = JsonSerializer.Deserialize<List<ToDo>>(json);

            }

            while (true)
            {
                string cmd = Console.ReadLine().Trim();

                if (cmd.Contains("-exit"))
                {
                    WriteToFile(fileName, tasks);
                    break;
                }

                if (cmd.StartsWith("-"))
                {
                    //Обработка команд
                    string[] cmdArg = cmd.Split(' ');

                    switch (cmdArg[0])
                    {
                        case "-list":
                            for (int i = 0; i < tasks.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. {tasks[i]}");
                            }
                            break;

                        case "-add":
                            if (cmdArg.Length > 1)
                            {
                                tasks.Add(new ToDo(cmd.Replace("-add", "")));
                                WriteToFile(fileName, tasks);
                            }
                            else
                                Console.WriteLine("Параметры команды не обнаружены");
                            break;

                        default:
                            break;
                    }
                }
                else
                {
                    if (int.TryParse(cmd, out int numTask))
                    {
                        tasks[numTask - 1].IsDone = true;
                        WriteToFile(fileName, tasks);
                    }
                }
            }
            
        }

        static void DeleteVoidTask(List<ToDo> list)
        {
            foreach (ToDo task in list)
            {
                if (task.Title == "Нет имени") list.Remove(task);
            }
        }

        static void WriteToFile(string file, List<ToDo> list)
        {
            string json = JsonSerializer.Serialize(list);
            File.WriteAllText(file, json);
        }
    }
}
