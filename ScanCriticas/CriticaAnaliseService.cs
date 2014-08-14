﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ScanCriticas
{
    public class CriticaAnaliseService
    {
        public ArrayList listagemDeCriticas;
        private ArrayList ObterLinhasComDescricaoDaRegra()
        {
            DirectoryInfo diretorio = new DirectoryInfo(@"C:\Projeto eSim\proj-implantacao\Mongeral.eSim.Implantacao.CriticaService\Criticas");
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

        public void GerarArquivoTXTComCriticas()
        {

            ObterListagemDeCritica();

            using (FileStream fs = new FileStream(@"C:\Projeto eSim\ListagemDeCriticas.txt", FileMode.Create))
            {
                using (StreamWriter escritor = new StreamWriter(fs, Encoding.GetEncoding("ISO-8859-1")))
                {
                    foreach (var critica in listagemDeCriticas)
                    {
                        escritor.WriteLine(critica);
                    }

                }
            }

            Console.WriteLine("Arquivo Criado com Sucesso em Projeto eSim\\ListagemDeCriticas.txt");
            Console.ReadLine();


        }
    }
}
