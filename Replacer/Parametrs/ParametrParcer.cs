using System;

namespace Replacer.Parametrs
{
    /// <summary>
    /// Производит распознавание параметра из командной строки
    /// </summary>
    internal class ParametrParcer : IParametrParcer
    {
        public string separator = "=";

        public Parametr GetParametr(string rawParametr)
        {
            string key = null;
            string value = null;
            int separatePosition = rawParametr.IndexOf(separator);

            switch (separatePosition)
            {
                case -1:
                    throw new Exception("Передан параметр без значения или ключа. Возможно при передаче отправили пробел? Ошибка 2.");
                case 0:
                    break;
                    throw new Exception("Передан пустой ключ, ключ параметра должен иметь значение. Пробела между ключем и значением бть не должно. Ошибка 3");
                default:
                    try
                    {
                        key = rawParametr.Substring(0, separatePosition);
                        value = rawParametr.Substring(separatePosition + separator.Length, rawParametr.Length - separatePosition - separator.Length);
                    }
                    catch
                    {
                        throw new Exception("Ошибка распознавания ключ значений. Ошибка 4");
                    }
                    break;
            }

            return new Parametr(key, value);
        }
    }
}
