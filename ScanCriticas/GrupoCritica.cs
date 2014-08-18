using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ScanCriticas
{
    public class GrupoCritica
    {
        public GrupoCritica(int identificador,string codigo, string descricao)
        {
            GrupoCriticaID = identificador; 
            CodigoGrupo = codigo;
            Descricao = descricao;
        }

        public int GrupoCriticaID { get; set; }
        public string CodigoGrupo { get; set; }
        public string Descricao { get; set; }
    }
}
