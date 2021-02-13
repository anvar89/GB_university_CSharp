using System;
using System.Configuration;

namespace GB_homeWork
{
    class Program
    {
        static void Main(string[] args)
        {
       
            Console.WriteLine("Сохранёные настройки:");
            ReadAllSettings();
            Console.WriteLine();

            Greeting();

            Console.WriteLine("Как вас зовут?");
            WriteToAppProperty("UserName", Console.ReadLine());

            Console.WriteLine("Какая у вас профессия?");
            WriteToAppProperty("Job", Console.ReadLine());

            Console.WriteLine("Сколько вам лет?");
            WriteToAppProperty("Age", Console.ReadLine());

            Console.ReadKey();
        }
        static void ReadAllSettings()
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;

                if (appSettings.Count == 0)
                {
                    Console.WriteLine("AppSettings is empty.");
                }
                else
                {
                    foreach (var key in appSettings.AllKeys)
                    {
                        Console.WriteLine("{0} : {1}", key, appSettings[key]);
                    }
                }
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Ошибка при чтении свойств");
            }
        }
        static void Greeting()
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;

                if (appSettings.Count == 0)
                {
                    Console.WriteLine("Настройки приложения не найдены");
                }
                else
                {
                    Console.WriteLine(appSettings["Greeting"]);
                }
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Ошибка при чтении настроек приложения");
            }
        }

        static void WriteToAppProperty(string propertyName, string newValue)
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                if (settings[propertyName] == null)
                {
                    settings.Add(propertyName, newValue);
                }
                else
                {
                    settings[propertyName].Value = newValue;
                }
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Ошибка записи настроек");
            }
        }
    }
}
