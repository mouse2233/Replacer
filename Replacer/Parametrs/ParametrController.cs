using System;
using Replacer.Values;

namespace Replacer.Parametrs
{
    internal class ParametrController
    {
        public string AssemblyPath;
        public string PropirityValue;
        public string PropirityName;
        public string Value;

        private void AddParametr(Parametr parametr)
        {
            if (parametr == null)
                throw new Exception("Передан неопределенный параметр. Ошибка 6.");

            if (parametr.Name == "AssemblyPath")
            {
                AssemblyPath = parametr.Value;
                return;
            }

            if (parametr.Name == "PropirityName")
            {
                PropirityName = parametr.Value;
                return;
            }

            if (parametr.Name == "PropirityValue")
            {
                //сюда надо отдельный класс генератор для команд, но я уже забил...
                if (parametr.Value[0] == '$')//доллар значит команда, в другом случае это текст
                    switch (parametr.Value)
                    {
                        case "$MachineName":
                            PropirityValue = new MachineNameValues().GetValue();
                            break;
                        default:
                            PropirityValue = "...";
                            break;
                    }
                else
                    PropirityValue = parametr.Value;
                return;
            }

            if (parametr.Name == "Value")
            {
                //сюда надо отдельный класс генератор для команд, но я уже забил...
                if (parametr.Value[0] == '$')//доллар значит команда, в другом случае это текст
                    switch (parametr.Value.Trim())
                    {
                        case "$MachineName":
                            Value = new MachineNameValues().GetValue();
                            break;
                        default:
                            Value = "...";
                            break;
                    }
                else
                    Value = parametr.Value;
                return;
            }

            throw new Exception("Передан неизвестынй параметр. Ошибка 7.");
        }

        public bool IsParametrsReady()
        {
            //1. заполнен путь до папки с assemblyInfo
            if (AssemblyPath == null)
                throw new Exception("Не указан путь до AssemblyInfo. Ошибка 5.");

            //2. указана одновременно работа по имени и параметру
            if (PropirityName != null && PropirityValue != null)
                throw new Exception("Одновременное указание PropirityName и PropirityValue," +
                    " нужно указать только один параметр, непонятно по какому параметру следует выполнять замены. Ошибка 8.");

            //3. не указана работа по имени или параметру
            if (PropirityName == null && PropirityValue == null)
                throw new Exception("Не указан ни один из способов подстановки информации. Укажите PropirityName или PropirityValue. Ошибка 9.");

            return true;
        }

        public void ParseParametrs(string[] args)
        {
            ParametrParcer parametrParcer = new ParametrParcer();
            foreach (string arg in args)
            {
                AddParametr(parametrParcer.GetParametr(arg));
            }
        }
    }
}
