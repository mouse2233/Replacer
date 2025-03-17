using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Replacer.Parametrs
{
    internal interface IParametrParcer
    {
        Parametr GetParametr(string rawParametr);
    }
}
