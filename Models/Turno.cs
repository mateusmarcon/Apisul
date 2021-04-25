using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apisul.Models
{
    public class Turno
    {
        public char Nome;

        public Counter[] BuildArrayCounter()
        {
            Counter[] counters = new Counter[3];
            char[] a = new char[3] { 'M', 'V', 'N'};
            for (int i = 0; i < 3; i++)
            {
                counters[i] = new Counter { Referencia = a[i].ToString(), Quantidade = 0 };
            }
            return counters;
        }
    }
}
