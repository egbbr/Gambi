using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScanCriticas
{
    public class GrupoCriticaRepository : IRepositoryBase<GrupoCritica>
    {
        public List<GrupoCritica>GetAll()
        {
            var listaCompleta = new List<GrupoCritica>();
            listaCompleta.Add(new GrupoCritica(1,"G1", "Identificação do Cliente"));
            listaCompleta.Add(new GrupoCritica(2,"G4", "Estado Civil do Cliente"));
            listaCompleta.Add(new GrupoCritica(3,"G5", "Sexo do Cliente"));
            listaCompleta.Add(new GrupoCritica(4,"G7", "Documento de Identificação do Cliente"));
            listaCompleta.Add(new GrupoCritica(5,"G9", "País de Residência do Cliente"));
            listaCompleta.Add(new GrupoCritica(6,"G10", "Dados Profissionais do Cliente"));
            listaCompleta.Add(new GrupoCritica(7,"G11", "Endereço Residencial do Cliente"));
            listaCompleta.Add(new GrupoCritica(8,"G13", "Endereço de Correspondência do Cliente"));
            listaCompleta.Add(new GrupoCritica(9,"G14", "Telefone Residencial do Cliente"));
            listaCompleta.Add(new GrupoCritica(10,"G15", "Telefone Comercial do Cliente"));
            listaCompleta.Add(new GrupoCritica(11,"G16", "Telefone Celular do Cliente"));
            listaCompleta.Add(new GrupoCritica(12,"G17", "Produtos"));
            listaCompleta.Add(new GrupoCritica(13,"G18", "Beneficiários"));
            listaCompleta.Add(new GrupoCritica(14,"G19", "Opções para Forma de Cobrança"));
            listaCompleta.Add(new GrupoCritica(15,"G20", "Valor Total de Contribuição da Proposta"));
            listaCompleta.Add(new GrupoCritica(16,"G21", "Primeiro Pagamento"));
            listaCompleta.Add(new GrupoCritica(17,"G23", "Declarações"));
            listaCompleta.Add(new GrupoCritica(18,"G25", "Assinatura e Protocolo da Proposta"));
            listaCompleta.Add(new GrupoCritica(19,"G26", "Informações Complementares"));
            listaCompleta.Add(new GrupoCritica(20,"G27", "Informações de Produção e Bateria de Vendas"));
            listaCompleta.Add(new GrupoCritica(21,"G28", "Dados do Cônjuge"));
            listaCompleta.Add(new GrupoCritica(22,"G29", "Resumo de Venda"));
            listaCompleta.Add(new GrupoCritica(23, "G8", "Endereço Eletrônico do Cliente"));

            return listaCompleta;

        }

        public GrupoCritica GetForIdentificador(int identificador)
        {
            var todos = GetAll();
            return (from grupo in todos where grupo.GrupoCriticaID == identificador select grupo).FirstOrDefault();
        }

        public GrupoCritica ObterGrupoCriticaPor(string codigoDoGrupo)
        {
            var todos = GetAll();
            foreach (GrupoCritica grupoCritica in todos)
            {
                if (grupoCritica.CodigoGrupo.Contains(codigoDoGrupo)) return grupoCritica;
            }
            return null;
        }


    }
}
