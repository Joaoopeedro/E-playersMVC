using System;
using System.Collections.Generic;
using System.IO;
using E_Players_MVC.Interfaces;

namespace E_Players_MVC.Models
{
    public class Jogador : EplayerBase, IJogador
    {
        public int Idjogador { get; set; }
        public int IdEquipe { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }
        
        public string Senha { get; set; }
        
        

        private const string CAMINHO = "Datebase/Jogador.csv";

        // Método construtor que cria os arquivos e pastas caso não existam

        public Jogador()
        {
            CriarPastaEArquivo(CAMINHO);
        }

        private string Preparar(Jogador j)
        {
            return $"{j.Idjogador};{j.Nome};{j.Email};{j.Senha};{j.IdEquipe}";
        }

        public void Criar(Jogador j)
        {
            string[] linha = { Preparar(j) };
            File.AppendAllLines(CAMINHO, linha);
        }

        public List<Jogador> LerTodas()
        {
            List<Jogador> jogadores = new List<Jogador>();
            string[] linhas = File.ReadAllLines(CAMINHO);

            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");
                Jogador jogador = new Jogador();
                // id jogador 
                jogador.Idjogador = Int32.Parse(linha[0]);
                // nome
                jogador.Nome = linha[1];
                // email jogador
                jogador.Email = linha[2];
                // senha jogador
                jogador.Senha = linha[3];
                // id equipe
                jogador.IdEquipe = Int32.Parse(linha[4]) ;

                jogadores.Add(jogador);
            }
            return jogadores;
        }

        public void Alterar(Jogador j)
        {
            List<string> linhas = LerTodasLinhasCSV(CAMINHO);
            linhas.RemoveAll(x => x.Split(";")[0] == j.Idjogador.ToString());
            linhas.Add(Preparar(j));
            ReescreverCSV(CAMINHO, linhas);
        }

        public void Deletar(int id)
        {
            List<string> linhas = LerTodasLinhasCSV(CAMINHO);
            linhas.RemoveAll(x => x.Split(";")[0] == Idjogador.ToString());
            ReescreverCSV(CAMINHO, linhas);
        }
    }
}