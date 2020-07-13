using System;
using System.Collections.Generic;
using System.IO;
using EPlayersFim.Interfaces;

namespace EPlayersFim.Models
{
    public class Equipe : EplayersBase , IEquipe
    {
        public int IdEquipe { get; set; }
        public string Nome { get; set; }
        public string Imagem { get; set; }

        private const string PATH = "Database/equipe.csv";

        
        /// <summary>
        /// Criar pasta e caminho(PATH)
        /// </summary>
        public Equipe(){
            CreateFolderAndFile(PATH);
        }

       /// <summary>
       /// Criar e adicionar equipe
       /// </summary>
       /// <param name="e"></param>
        public void Create(Equipe e)
        {
            string[]linhas = {PrepararLinha(e)};
            File.AppendAllLines(PATH,linhas);
        }

        /// <summary>
        /// Organizar linha segundo atributos
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        private string PrepararLinha(Equipe e)
        {
            return $"{e.IdEquipe};{e.Nome} ;{e.Imagem}";
        }

        
        /// <summary>
        /// Excluir determinada equipe
        /// </summary>
        /// <param name="IdEquipe"></param>
        public void Delete(int IdEquipe)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(y => y.Split(";")[0] == IdEquipe.ToString());
            RewriteCSV(PATH,linhas);
        }

        /// <summary>
        /// listar, ler as equipes,dado os atributos
        /// </summary>
        /// <returns></returns>
        public List<Equipe> ReadAll()
        {
            List<Equipe> equipes = new List<Equipe>();
            string[] linhas = File.ReadAllLines(PATH);
            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");
                Equipe equipe = new Equipe();
                equipe.IdEquipe = Int32.Parse(linha[0]);
                equipe.Nome = linha[1];
                equipe.Imagem = linha[2];

                equipes.Add(equipe);
            }
            return equipes;
        }

       /// <summary>
       /// Atualizar lista de equipes
       /// </summary>
       /// <param name="e"></param>
        public void Update(Equipe e)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(y => y.Split(";")[0] == e.IdEquipe.ToString());
            linhas.Add(PrepararLinha (e));
            RewriteCSV(PATH,linhas);
        }
    }
}