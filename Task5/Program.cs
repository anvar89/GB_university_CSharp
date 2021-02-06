using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Xml.Serialization;

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

            Console.WriteLine(
@"  Команды:
        -exit - выход
        -add - добавить задачу
        -list - вывести список задач
        номер задачи из списка list - пометить задачу под соответствующим номером как выполненную");

            string fileName = "tasks";
            int typeSer;
            List<ToDo> tasks = new List<ToDo>();

            // Выбор пользователем типа сериализации
            Console.Write("Выберите сериализацию (1 - JSON, 2 - XML, 3 - BIN):");
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out typeSer) && (typeSer >= 1) && (typeSer <= 3)) break;
                else
                    Console.WriteLine("Введите число 1..3");
            }

            ReadFromFile(fileName, (SerializationType)typeSer, out tasks);


            while (true)
            {
                string cmd = Console.ReadLine().Trim();

                if (cmd.Contains("-exit"))
                {
                    WriteToFile(fileName, (SerializationType)typeSer, tasks);
                    break;
                }

                if (cmd.StartsWith("-"))
                {
                    //Обработка команд
                    string[] cmdArg = cmd.Split(' ');

                    switch (cmdArg[0])
                    {
                        case "-list": // Список задач с номерами
                            if (tasks == null) break;

                            for (int i = 0; i < tasks.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. {tasks[i]}");
                            }
                            break;

                        case "-add": // добавить новую задачу
                            if (cmdArg.Length > 1)
                            {
                                tasks.Add(new ToDo() { Title = cmd.Replace("-add", "").Trim(), IsDone = false });
                                Console.WriteLine("Добавлена новая задача!");
                            }
                            else
                                Console.WriteLine("Параметры команды не обнаружены");
                            break;

                        default:
                            break;
                    }
                }
                else
                {   // Выбранная задача становится выполненой
                    if (int.TryParse(cmd, out int numTask) && (numTask > 0) && (numTask <= tasks.Count))
                    {
                        tasks[numTask - 1].IsDone = true;
                        Console.WriteLine("Задача выполнена!");
                    }
                    else
                        Console.WriteLine($"Вводите в качестве параметра число 1..{tasks.Count}");

                }
            }
        }

        static void ReadFromFile(string file, SerializationType type, out List<ToDo> list)
                {
            string path = $"{file}.{(SerializationType)type}";
            list = new List<ToDo>();

            if (!File.Exists(path)) return;
                                
            if (type == SerializationType.JSON)
            {
                string text = File.ReadAllText(path);
                list = JsonSerializer.Deserialize<List<ToDo>>(text);
            }


            if (type == SerializationType.XML)
            {
                string text = File.ReadAllText(path);
                StringReader stringReader = new StringReader(text);
                XmlSerializer serializer = new XmlSerializer(typeof(List<ToDo>));
                list = (List<ToDo>)serializer.Deserialize(stringReader);
            }

            if (type == SerializationType.BIN)
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream fs = new FileStream(path, FileMode.Open);
                list = (List<ToDo>)formatter.Deserialize(fs);
                fs.Close();
            }

        }

        static void WriteToFile(string file, SerializationType type, List<ToDo> list)
        {
            string path = $"{file}.{(SerializationType)type}";

            if (type == SerializationType.JSON)
            {
                string text = JsonSerializer.Serialize<List<ToDo>>(list);
                File.WriteAllText(path, text);
            }
            if (type == SerializationType.XML)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<ToDo>));
                using (StringWriter stringWriter = new StringWriter())
                {
                    serializer.Serialize(stringWriter, list);
                    string text = stringWriter.ToString();
                    File.WriteAllText(path, text);
                }
            }

            if (type == SerializationType.BIN)
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
                formatter.Serialize(fs, list);
                
                fs.Close();
            }
        }

        enum SerializationType { JSON = 1, XML, BIN }
    }
}
