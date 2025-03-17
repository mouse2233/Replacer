using System;

namespace Replacer.Values
{
    /// <summary>
    /// Возвращает имя машины
    /// </summary>
    internal class MachineNameValues : IValue
    {
        public string GetValue()
        {
            return Environment.MachineName;
        }
    }
}
