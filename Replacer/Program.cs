//TODO:
//  Заменить пути файла
//  добавить вывод данных
//  добавить считывание пути файла из командной сторки

using System;
using Replacer.Parametrs;

namespace Replacer
{
    /// <summary>
    /// Основное приложение для замены параметров в файле AssemblyInfo
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            ParametrController parametrController = new ParametrController();
            parametrController.ParseParametrs(args);

            try
            {
                Command command = CommandCreator.CreateCommand(parametrController);
                command.Execute();
            }
            catch(Exception ex)//Можно прикрутить логгер, но эт уже явный перебор 
            {
                Console.WriteLine(ex.ToString());
                throw ex;
            }
        }
    }
}
