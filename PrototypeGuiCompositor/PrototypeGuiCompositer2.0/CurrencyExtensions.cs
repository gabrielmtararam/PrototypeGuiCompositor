using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveNoCopyAdorner
{
    public static class CurrencyExtensions
    {
        public static string ToReal(this int valor)
        {
            return $"${valor}";
        }
    }
}