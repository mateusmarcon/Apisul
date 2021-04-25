using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apisul.Services;

namespace Apisul
{
    class ElevatorController
    {
        private IElevatorService _elevatorService;
        public ElevatorController(IElevatorService elevatorService)
        {
            _elevatorService = elevatorService;
        }

        public List<int> GetAndaresMenosUsados()
        {
            var andares = _elevatorService.andarMenosUtilizado();
            return andares;
        }

        public List<char> GetElevadoresMaisUsados()
        {
            var elevadores = _elevatorService.elevadorMaisFrequentado();
            return elevadores;
        }

        public List<char> GetperiodoMaiorFluxoElevadorMaisFrequentado()
        {
            var turno = _elevatorService.periodoMaiorFluxoElevadorMaisFrequentado();
            return turno;
        }

        public List<char> GetelevadorMenosFrequentado()
        {
            var elevadores = _elevatorService.elevadorMenosFrequentado();
            return elevadores;
        }

        public List<char> GetperiodoMenorFluxoElevadorMenosFrequentado()
        {
            var turnos = _elevatorService.periodoMenorFluxoElevadorMenosFrequentado();
            return turnos;
        }

        public List<char> GetperiodoMaiorUtilizacaoConjuntoElevadores()
        {
            var turno = _elevatorService.periodoMaiorUtilizacaoConjuntoElevadores();
            return turno;
        }
        
        public float GetpercentualDeUsoElevadorA()
        {
            var percentual = _elevatorService.percentualDeUsoElevadorA();
            return percentual;
        }
        public float GetpercentualDeUsoElevadorB()
        {
            var percentual = _elevatorService.percentualDeUsoElevadorB();
            return percentual;
        }
        public float GetpercentualDeUsoElevadorC()
        {
            var percentual = _elevatorService.percentualDeUsoElevadorC();
            return percentual;
        }
        public float GetpercentualDeUsoElevadorD()
        {
            var percentual = _elevatorService.percentualDeUsoElevadorD();
            return percentual;
        }
        public float GetpercentualDeUsoElevadorE()
        {
            var percentual = _elevatorService.percentualDeUsoElevadorE();
            return percentual;
        }

        public bool GetValidaBaseDeDados()
        {
            var result = _elevatorService.validaBaseDeDados();
            return result;
        }
    }
}
