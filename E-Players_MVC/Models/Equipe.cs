using System;
using System.Collections.Generic;
using System.IO;
using E_Players_MVC.Interfaces;

namespace E_Players_MVC.Models
{
    public class Equipe :EplayerBase, IEquipe
    {
        public int IdEquipe { get; set; }
        
        public string Nome { get; set; }
        
        public string Imagem { get; set; }

        private const string CAMINHO = "Datebase/equipe.csv";

        // Método construtor que cria os arquivos e pastas caso não existam
        public Equipe(){
            CriarPastaEArquivo(CAMINHO);
        }

        private string Preparar(Equipe e ){
            return $"{e.IdEquipe};{e.Nome};{e.Imagem}";
        }

        public void Alterar(Equipe e)
        {
            List<string> linhas = LerTodasLinhasCSV(CAMINHO);
            // 1;nome;Caminho da imagem 
            linhas.RemoveAll(x => x.Split(";")[0] == e.IdEquipe.ToString());
            linhas.Add(Preparar(e));
            ReescreverCSV(CAMINHO,linhas);
        }

        public void Criar(Equipe e)
        {
            string[] linha = {Preparar(e)};
            File.AppendAllLines(CAMINHO, linha);
        }

        public void Deletar(int id)
        {
            List<string> linhas = LerTodasLinhasCSV(CAMINHO);
            // 1;nome;Caminho da imagem 
            linhas.RemoveAll(x => x.Split(";")[0] == id.ToString());
            ReescreverCSV(CAMINHO,linhas);
        }

        public List<Equipe> LerTodas()
        {
            List<Equipe> equipes =new List<Equipe>();

            // 1;Nome da equipe;caminho da imagem 
            string[] linhas = File.ReadAllLines(CAMINHO);

            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");

                Equipe equipe = new Equipe();
                // 1
                equipe.IdEquipe = Int32.Parse(linha[0]);
                // Nome da equipe
                equipe.Nome = linha[1];
                // Caminho da imagem
                equipe.Imagem = linha[2];

                equipes.Add(equipe);
            }
            return equipes;
        }
    }
}