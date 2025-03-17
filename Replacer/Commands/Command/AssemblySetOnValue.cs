using Replacer.Parametrs;

namespace Replacer
{
    //конкретная реализация команды установки нового значения по значению параметра
    internal class AssemblySetOnValue : SetCommand
    {
        public string valuePropirity;

        public AssemblySetOnValue(ParametrController parametrController) : base(pathToAssembly: parametrController.AssemblyPath,
            value: parametrController.Value)
        {
            valuePropirity = parametrController.PropirityValue;
        }

        public override void Execute()
        {
            string assemblyText = new AssemblyReader().Read(PathToAssembly);

            assemblyText = assemblyText.Replace(valuePropirity, Value);
            
            AssemblyWriter assemblyWriter = new AssemblyWriter();

            assemblyWriter.Write(PathToAssembly, assemblyText);
        }
    }
}
