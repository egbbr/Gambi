using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ScanCriticas
{
    public class CriticaAnaliseDTO
    {
        public string CodigoCritica { get; set; }
        public string DescricaoCritica { get; set; }
        public GrupoCritica GrupoGriticaCritica { get; set; }
    }
}
