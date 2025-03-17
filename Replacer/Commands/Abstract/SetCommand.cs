namespace Replacer
{
    /// <summary>
    /// Базовая команда для всех устанавливающих значения команд
    /// </summary>
    public abstract class SetCommand : Command
    {
        public string Value;

        protected SetCommand(string pathToAssembly, string value) : base(pathToAssembly)
        {
            Value = value;
        }
    }
}
