using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Replacer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string textValue = System.Environment.MachineName;
            if (args.Length == 0)
            {
                string str = string.Empty;
                using (System.IO.StreamReader reader = System.IO.File.OpenText(@"C:\Users\Andrey\source\repos\FrameworkForms\ClassLibrary\Properties\AssemblyInfo.cs"))
                {
                    str = reader.ReadToEnd();
                }
                str = str.Replace("{TargetText}", textValue);

                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\Andrey\source\repos\FrameworkForms\ClassLibrary\Properties\AssemblyInfo.cs"))
                {
                    file.Write(str);
                }
            }
            else
            {
                string str = string.Empty;
                using (System.IO.StreamReader reader = System.IO.File.OpenText(@"C:\Users\Andrey\source\repos\FrameworkForms\ClassLibrary\Properties\AssemblyInfo.cs"))
                {
                    str = reader.ReadToEnd();
                }
                str = str.Replace(textValue, "{TargetText}");

                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\Andrey\source\repos\FrameworkForms\ClassLibrary\Properties\AssemblyInfo.cs"))
                {
                    file.Write(str);
                }
            }
        }
    }
}
