using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apisul.Models
{
    public class Counter
    {
        public string Referencia;
        public int Quantidade;

        public Counter[] BuildArray(int size)
        {
            Counter[] counters = new Counter[size];
            for (int i = 0; i < size; i++)
            {
                counters[i] = new Counter { Referencia = i.ToString(), Quantidade = 0 };

            };
            return counters;
        }
    }

}
