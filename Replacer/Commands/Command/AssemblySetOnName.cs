using System;
using Replacer.Parametrs;

namespace Replacer
{
    //конкретная реализация команды установки нового значения по имени параметра
    internal class AssemblySetOnName : SetCommand
    {
        public string NamePropirity;

        public AssemblySetOnName(ParametrController parametrController) : base(pathToAssembly: parametrController.AssemblyPath
            , value: parametrController.Value)
        {
            NamePropirity = parametrController.PropirityName;
        }

        public override void Execute()
        {
            string assemblyText = new AssemblyReader().Read(PathToAssembly);
            //т.к. программа смотрит по имени то нужно сместить место замены на област между скобками от начала строки (" и от конца строки ")

            int startFindPosition = assemblyText.IndexOf(NamePropirity);

            if (startFindPosition < 0)
                throw new Exception("Не найден заданный атрибут в файле. Ошибка 11");

            int startPosition = assemblyText.IndexOf("(\"", startFindPosition);

            if (startPosition < 0)
                throw new Exception("Не найдно место подстановки значения. Ошибка 12");

            int endPosition = assemblyText.IndexOf("\")", startFindPosition) + 2;

            if (endPosition < 0)
                throw new Exception("Не найдно место подстановки значения. Ошибка 13");

            string replaceValue = assemblyText.Substring(startPosition, endPosition - startPosition);

            assemblyText = assemblyText.Replace(replaceValue, "(\"" + Value + "\")");

            AssemblyWriter assemblyWriter = new AssemblyWriter();

            assemblyWriter.Write(PathToAssembly, assemblyText);
        }
    }
}
