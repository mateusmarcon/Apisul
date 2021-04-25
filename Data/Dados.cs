using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Apisul.Models;
using Newtonsoft.Json;

namespace Apisul.Data
{
    public class Dados
    {
        public static List<Viagem> LoadData()
        {
            List<Viagem> jorneys = new List<Viagem>();
            string filePath = Path.Combine(
                Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "input.json");
            using (StreamReader r = new StreamReader(filePath))
            {
                string json = r.ReadToEnd();
                jorneys = JsonConvert.DeserializeObject<List<Viagem>>(json);
            }
            return jorneys;
        }
    }
}
