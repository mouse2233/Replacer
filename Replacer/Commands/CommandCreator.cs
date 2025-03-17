using System;
using Replacer.Parametrs;

namespace Replacer
{
    /// <summary>
    /// Блок отвечает за создание команды
    /// </summary>
    internal class CommandCreator
    {
        private CommandCreator() { }//Заглушка чтобы нельзя было создать экземплят класса

        public static Command CreateCommand(ParametrController parametrController) 
        {
            if (parametrController.IsParametrsReady())
            {
                //логика выбора команды
                //1. Задано по имени
                if(parametrController.PropirityName != null)
                    return new AssemblySetOnName(parametrController);
                //2. Задано по Значению
                if (parametrController.PropirityValue != null)
                    return new AssemblySetOnValue(parametrController);

                throw new Exception("Не распознал команду. Ошибка 10");
            }
            else
            {
                throw new Exception("Получена не полная коллекция параметров, дальнейшая работа невозмжна. Ошибка 1");
            }
        }
    }
}
