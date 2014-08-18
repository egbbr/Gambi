using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScanCriticas
{
    class Program
    {
        static void Main(string[] args)
        {

            var service = new CriticaAnaliseService();

            service.GerarArquivoTXTComCriticas(@"C:\Projeto eSim\proj-implantacao\Mongeral.eSim.Implantacao.CriticaService\Criticas");
        }
    }
}
