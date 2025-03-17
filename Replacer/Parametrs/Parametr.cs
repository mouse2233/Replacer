namespace Replacer.Parametrs
{
    /// <summary>
    /// Обработанные значения распознанные из командной строки
    /// </summary>
    internal class Parametr
    {
        /// <summary>
        /// Имя параметра
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Значение параметра
        /// </summary>
        public string Value { get; set; }

        public Parametr(string name, string value) 
        {
            Name = name;
            Value = value;
        }
    }
}
