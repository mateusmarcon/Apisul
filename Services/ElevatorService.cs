using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apisul.Data;
using Apisul.Models;

namespace Apisul.Services
{
    class ElevatorService:IElevatorService
    {
       public List<int> andarMenosUtilizado()
        {

            List<Viagem> dados = Dados.LoadData();
            Counter c = new Counter();
            Counter[] counters =  c.BuildArray(16);
            foreach(var v in dados)
            {
                counters[v.andar].Quantidade = counters[v.andar].Quantidade+1;
            }
            int menorValor = 0;
            List<int> andaresMenosUtilizados = new List<int>();
            for (int i = 0; i < 16; i++)
            {
                if (i == 0)
                {
                    menorValor = counters[i].Quantidade;
                    andaresMenosUtilizados.Add(int.Parse(counters[i].Referencia));
                }
                else
                {
                    if(menorValor>= counters[i].Quantidade)
                    {
                        if (menorValor > counters[i].Quantidade)
                        {
                            andaresMenosUtilizados.Clear();
                            menorValor = counters[i].Quantidade;
                        }
                        andaresMenosUtilizados.Add(int.Parse(counters[i].Referencia));
                    }
                }
            };

            
            return andaresMenosUtilizados.Distinct().ToList();
        }

        public List<char> elevadorMaisFrequentado()
        {
            List<Viagem> dados = Dados.LoadData();
            Counter c = new Counter();
            Counter[] counters = c.BuildArray(16);
            var viagensAgrupadas = dados.GroupBy(d => d.elevador)
            .Select(
                g => new
                {
                    Name = g.First().elevador,
                    Quantidade = g.Count(),
                }).OrderBy(e => e.Quantidade);

            int maiorValor = 0;
            List<char> elevadoresMaisFrequentados = new List<char>();
            foreach (var v in viagensAgrupadas)
            {
                if (v.Quantidade >= maiorValor)
                {
                    if(v.Quantidade > maiorValor)
                    {
                        elevadoresMaisFrequentados.Clear();
                        maiorValor = v.Quantidade;
                    }
                    elevadoresMaisFrequentados.Add(v.Name);
                }
               
            }
            return elevadoresMaisFrequentados.Distinct().ToList();
        }

        public List<char> periodoMaiorFluxoElevadorMaisFrequentado()
        {
            List<char> periodosMaiorFluxoElevadoresMaisFrequentados = new List<char>();
            List<char> ElevadoresMaisUsados = elevadorMaisFrequentado();
            List<Viagem> dados = Dados.LoadData();
            Counter c = new Counter();
            
            foreach (char e in ElevadoresMaisUsados)
            {
                var tur = dados.Where(d => d.elevador == e).GroupBy(f => f.turno)
                    .Select(
                        g => new
                        {
                            Name = g.First().turno,
                            Quantidade = g.Count(),
                        }).OrderBy(g=>g.Quantidade);
                periodosMaiorFluxoElevadoresMaisFrequentados.Add(tur.Last().Name);
            }
            return periodosMaiorFluxoElevadoresMaisFrequentados.Distinct().ToList();

        }

        public List<char> elevadorMenosFrequentado()
        {
            List<Viagem> dados = Dados.LoadData();
            Elevator e = new Elevator();
            Counter[] counter = e.BuildArrayCouter();

            foreach (Viagem d in dados)
            {
                switch (d.elevador)
                {
                    case 'A':
                        counter[0].Quantidade++;
                        break;
                    case 'B':
                        counter[1].Quantidade++;
                        break;
                    case 'C':
                        counter[2].Quantidade++;
                        break;
                    case 'D':
                        counter[3].Quantidade++;
                        break;
                    case 'E':
                        counter[4].Quantidade++;
                        break;
                };
            }

            int menorValor = 0;
            List<char> elevadoresMenosFrequentados = new List<char>();
            for (int i = 0; i < 5; i++)
            {
                if (i == 0)
                {
                    menorValor = counter[i].Quantidade;
                    elevadoresMenosFrequentados.Add(char.Parse(counter[i].Referencia));
                }
                else
                {
                    if (menorValor >= counter[i].Quantidade)
                    {
                        if (menorValor > counter[i].Quantidade)
                        {
                            elevadoresMenosFrequentados.Clear();
                            menorValor = counter[i].Quantidade;
                        }
                        elevadoresMenosFrequentados.Add(char.Parse(counter[i].Referencia));
                    }
                }
            };
            return elevadoresMenosFrequentados.Distinct().ToList();
        }

        public List<char> periodoMenorFluxoElevadorMenosFrequentado()
        {
            List<char> periodosMenorFluxoElevadoresMenosFrequentado = new List<char>();
            List<char> elevadoresMenosUsados = elevadorMenosFrequentado();
            List<Viagem> dados = Dados.LoadData();
            Turno t = new Turno();
           
            foreach (char e in elevadoresMenosUsados)
            {
                Counter[] turnos = t.BuildArrayCounter();
                var turEle = dados.Where(d => d.elevador == e).GroupBy(f => f.turno)
                   .Select(
                       g => new
                       {
                           Name = g.First().turno,
                           Quantidade = g.Count(),
                       }).OrderBy(g => g.Quantidade);
                foreach(var tur in turEle)
                {
                    switch (tur.Name)
                    {
                        case 'M':
                            turnos[0].Quantidade++;
                            break;
                        case 'V':
                            turnos[1].Quantidade++;
                            break;
                        case 'N':
                            turnos[2].Quantidade++;
                            break;
                    }
                }
                periodosMenorFluxoElevadoresMenosFrequentado.Add(char.Parse(turnos.ToList().OrderBy(d => d.Quantidade).First().Referencia));
            }
            return periodosMenorFluxoElevadoresMenosFrequentado.Distinct().ToList();
        }

        public List<char> periodoMaiorUtilizacaoConjuntoElevadores()
        {
            List<Viagem> dados = Dados.LoadData();
            List<char> turnoMaisFluxo = new List<char>();
            Turno t = new Turno();
            Counter[] turnos = t.BuildArrayCounter();
            foreach(Viagem v in dados)
            {
                switch (v.turno)
                {
                    case 'M':
                        turnos[0].Quantidade++;
                        break;
                    case 'V':
                        turnos[1].Quantidade++;
                        break;
                    case 'N':
                        turnos[2].Quantidade++;
                        break;
                }
            }
            int maiorValor = 0;
            for(int i=0; i<3; i++)
            {
                if (turnos[i].Quantidade >= maiorValor)
                {
                    if (turnos[i].Quantidade > maiorValor)
                    {
                        turnoMaisFluxo.Clear();
                        maiorValor = turnos[i].Quantidade;
                    }
                    turnoMaisFluxo.Add(char.Parse(turnos[i].Referencia));
                }
            }
            return turnoMaisFluxo;
        }

        public float percentualDeUsoElevadorA()
        {
            return PercentualPorElevador("A");
        }
        public float percentualDeUsoElevadorB()
        {
            return PercentualPorElevador("B");
        }
        public float percentualDeUsoElevadorC()
        {
            return PercentualPorElevador("C");
        }
        public float percentualDeUsoElevadorD()
        {
            return PercentualPorElevador("D");
        }
        public float percentualDeUsoElevadorE()
        {
            return PercentualPorElevador("E");
        }

        public float PercentualPorElevador(string E)
        {
            Counter[] viagensPEle = ViagensPorElevador();
            var viagensEleA = viagensPEle.ToList().Where(d => d.Referencia == E).First();
            int totalViagens = QuantidadeViagens();

            Double x = Math.Round((((double)viagensEleA.Quantidade * 100) / totalViagens), 2);
            //double percentual = Math.Round(x, 2);
            
            return (float)x;
        }

        public int QuantidadeViagens()
        {
            List<Viagem> dados = Dados.LoadData();

            return dados.Count();
        }

        public Counter[] ViagensPorElevador()
        {
            List<Viagem> dados = Dados.LoadData();
            Elevator e = new Elevator();
            Counter[] counter = e.BuildArrayCouter();

            foreach (Viagem d in dados)
            {
                switch (d.elevador)
                {
                    case 'A':
                        counter[0].Quantidade++;
                        break;
                    case 'B':
                        counter[1].Quantidade++;
                        break;
                    case 'C':
                        counter[2].Quantidade++;
                        break;
                    case 'D':
                        counter[3].Quantidade++;
                        break;
                    case 'E':
                        counter[4].Quantidade++;
                        break;
                };
            }
            return counter;
        }

        public bool validaBaseDeDados()
        {
            try
            {
                List<Viagem> dados = Dados.LoadData();
                return true;
            }catch(Exception e)
            {
                return false;
            }
        }

    }
}
