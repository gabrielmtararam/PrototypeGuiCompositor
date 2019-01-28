using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeGuiCompositor30
{
    public static class CurrencyExtensions
    {
        public static string ToReal(this int valor)
        {
            return $"${valor}";
        }
    }
}