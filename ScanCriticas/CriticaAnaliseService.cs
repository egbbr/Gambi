using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace ScanCriticas
{
    public class CriticaAnaliseService
    {
        private GrupoCriticaRepository _grupoCriticaRepository;
        public GrupoCriticaRepository GrupoCriticaRepository
        {
            private get { return _grupoCriticaRepository ?? (_grupoCriticaRepository = new GrupoCriticaRepository()); }
            set { _grupoCriticaRepository = value; }
        }

        public ArrayList listagemDeCriticas;
        private string localizacaoDoProjetoDeCriticas;

        private ArrayList ObterLinhasComDescricaoDaRegra()
        {
            DirectoryInfo diretorio = new DirectoryInfo(localizacaoDoProjetoDeCriticas);
            FileInfo[] Arquivos = diretorio.GetFiles();
            var listaDeArquivosobtidos = new List<string>();
            string sLine = "";
            ArrayList LinhasDasCriticas = new ArrayList();

            foreach (var arquivo in Arquivos)
            {
                listaDeArquivosobtidos.Add(arquivo.FullName.Replace(diretorio.FullName,"").Remove(0,1).Replace(".cs",""));
                
                StreamReader leitor = new StreamReader(arquivo.FullName);

                while ((sLine = leitor.ReadLine()) != null)
                {
                   if (sLine.Contains("[DescricaoRegra"))
                    {
                        LinhasDasCriticas.Add(sLine);
                    }
                }
            }

            return LinhasDasCriticas;
        }

        private void ObterListagemDeCritica()
        {
            var LinhasComRegrasLidas = ObterLinhasComDescricaoDaRegra();
    
            listagemDeCriticas = new ArrayList();
            foreach (var linha in LinhasComRegrasLidas)
            {
                listagemDeCriticas.Add(linha.ToString().Replace("    [DescricaoRegra(\"", "").Replace("\", \""," - ").Replace("\")]",""));
            }
        }

        public void GerarArquivoTXTComCriticas(string localizacaoDoprojeto)
        {
            localizacaoDoProjetoDeCriticas = localizacaoDoprojeto;

            ObterListagemDeCritica();
            Console.WriteLine("INICIANDO SCAN DAS CRÍTICAS");
            short todalDeCriticas = 0;

            using (FileStream fs = new FileStream(@"C:\Projeto eSim\ListagemDeCriticas.txt", FileMode.Create))
            {
                using (StreamWriter escritor = new StreamWriter(fs, Encoding.GetEncoding("ISO-8859-1")))
                {
                    foreach (var critica in listagemDeCriticas)
                    {
                        var criticaDTO = new CriticaAnaliseDTO();
                        criticaDTO.DescricaoCritica = critica.ToString();

                        var descricaoSplit = Regex.Split(critica.ToString(), "_");

                        criticaDTO.CodigoCritica = descricaoSplit[1];
                        criticaDTO.DescricaoCritica = descricaoSplit[2];
                        criticaDTO.GrupoGriticaCritica =
                            GrupoCriticaRepository.ObterGrupoCriticaPor(criticaDTO.CodigoCritica);
         
                        escritor.WriteLine(criticaDTO.CodigoCritica + " - " + criticaDTO.DescricaoCritica + " GRUPO DE CRITICA:" + criticaDTO.GrupoGriticaCritica.Descricao);
                        todalDeCriticas++;
                    }

                }
            }

            Console.WriteLine("Total de Críticas Identificadas pelo Sistema: {0}",todalDeCriticas);
            Console.WriteLine("Arquivo Criado com Sucesso em Projeto eSim\\ListagemDeCriticas.txt");
            Console.WriteLine("Abrir arquivo? S/N");
            var respostausuario = Console.ReadLine();
            if (respostausuario == "s" || respostausuario == "S")
            {
                System.Diagnostics.Process.Start("notepad", @"C:\Projeto eSim\ListagemDeCriticas.txt");
                return;
            }
            Console.ReadLine();

        }
    }
}
