using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apisul.Services;

namespace Apisul.Models
{
    class Elevator
    {
        public char Nome { get; set; }
        //  public string Predio { get; set; }

        public char[] BuildArray()
        {
            char[] a = new char[5] { 'A', 'B', 'C', 'D', 'E' };
            return a;
        }

        public Counter[] BuildArrayCouter()
        {
            Counter[] counters = new Counter[5];
            char[] a = new char[5] { 'A', 'B', 'C', 'D', 'E' };
            for (int i=0; i<5;i++)
            {
                counters[i] = new Counter { Referencia = a[i].ToString(), Quantidade = 0 };
            }
            return counters;
        }
    }
}
