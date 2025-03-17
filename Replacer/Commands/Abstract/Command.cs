namespace Replacer
{
    /// <summary>
    /// Базовая команда для всех типов команд
    /// </summary>
    public abstract class Command
    {
        public string PathToAssembly;

        public Command(string pathToAssembly)
        {
            PathToAssembly = pathToAssembly;
        }

        public abstract void Execute();
    }
}
