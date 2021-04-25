using System;
using Apisul.Services;

namespace Apisul
{
    class Program
    {

        static void Main(string[] args)
        {

            Console.WriteLine("Olá!");
            bool finalizarPrograma = false;

            do
            {

                Console.WriteLine();
                ElevatorController elevador = new ElevatorController(new ElevatorService());
                bool baseDados = elevador.GetValidaBaseDeDados();
                if (baseDados)
                {

                    Console.WriteLine("Abaixo serão apresentados os resultados da pesquisa!");

                    var andares = elevador.GetAndaresMenosUsados();
                    var elevadores = elevador.GetElevadoresMaisUsados();
                    var turnosElevMais = elevador.GetperiodoMaiorFluxoElevadorMaisFrequentado();
                    var elevadoresmenos = elevador.GetelevadorMenosFrequentado();
                    var turnosElevMenos = elevador.GetperiodoMenorFluxoElevadorMenosFrequentado();
                    var turnosmaior = elevador.GetperiodoMaiorUtilizacaoConjuntoElevadores();
                    var percentualA = elevador.GetpercentualDeUsoElevadorA();
                    var percentualB = elevador.GetpercentualDeUsoElevadorB();
                    var percentualC = elevador.GetpercentualDeUsoElevadorC();
                    var percentualD = elevador.GetpercentualDeUsoElevadorD();
                    var percentualE = elevador.GetpercentualDeUsoElevadorE();

                    Console.WriteLine();
                    Console.WriteLine("a.Qual é o andar menos utilizado pelos usuários?");
                    Console.WriteLine("Andar(es): " + String.Join(", ", andares));
                    Console.WriteLine();
                    Console.WriteLine("b.Qual é o elevador mais frequentado e o período que se encontra maior fluxo?");
                    Console.WriteLine("Elevador(s): " + String.Join(", ", elevadores));
                    Console.WriteLine("Periodo(s): " + string.Join(", ", turnosElevMais));
                    Console.WriteLine();
                    Console.WriteLine("c.Qual é o elevador menos frequentado e o período que se encontra menor fluxo?");
                    Console.WriteLine("Elevador(s): " + String.Join(", ", elevadoresmenos));
                    Console.WriteLine("Periodo(s): " + string.Join(", ", turnosElevMenos));
                    Console.WriteLine();
                    Console.WriteLine("d.Qual o período de maior utilização do conjunto de elevadores");
                    Console.WriteLine(String.Join(", ", turnosmaior));
                    Console.WriteLine();
                    Console.WriteLine("e.Qual o percentual de uso de cada elevador com relação a todos os serviços prestados");
                    Console.WriteLine("Percentual Elevador A:" + percentualA);
                    Console.WriteLine("Percentual Elevador B:" + percentualB);
                    Console.WriteLine("Percentual Elevador C:" + percentualC);
                    Console.WriteLine("Percentual Elevador D:" + percentualD);
                    Console.WriteLine("Percentual Elevador E:" + percentualE);


                }
                else
                {
                    Console.WriteLine("Não foi possível carregar a base de dados!");
                    Console.WriteLine("OBS: o arquivo input deve estar na mesma pasta do arquivo executavel do programa.");
                }
                
                Console.WriteLine();
                Console.WriteLine("Deseja Executar o programa novamente?(S/N)");
                string resposta = Console.ReadLine();
                if (resposta.ToUpper() == "N")
                {
                    finalizarPrograma = true;
                }
                else
                {
                    Console.Clear();
                }


            } while (!finalizarPrograma);

            Console.WriteLine("Fim!");
        }

    }
}
