


using System;
using System.Collections.Generic;
using System.IO;
using EPlayersFim.Interfaces;

namespace EPlayersFim.Models
{
    public class Noticias : EplayersBase , INoticias
    {
        public int IdNoticia { get; set; }
        public string Titulo { get; set; }
        public string Texto { get; set; }
        public string Imagem { get; set; }

        private const string PATH = "Database/Noticias.csv";

        
        /// <summary>
        /// Criar Pasta e caminho PATH
        /// </summary>
        public Noticias()
        {
            CreateFolderAndFile(PATH);
        }
        
        /// <summary>
        /// Criar e preparar linha csv
        /// </summary>
        /// <param name="noticias"></param>
        public void Create(Noticias noticias)
        {
            string[] linhas = {PrepararLinha(noticias)};
            File.AppendAllLines(PATH , linhas);
        }

        /// <summary>
        /// Organizar linha segundo os atributos
        /// </summary>
        /// <param name="noticias"></param>
        /// <returns></returns>

        
        private string PrepararLinha(Noticias noticias)
        {
            return $"{noticias.IdNoticia};{noticias.Imagem};{noticias.Titulo};{noticias.Texto}";
        }

        /// <summary>
        /// Deletar determinada noticia
        /// </summary>
        /// <param name="IdNoticia"></param>
        public void Delete(int IdNoticia)
        {
            
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(y => y.Split(";")[0] == IdNoticia.ToString());
            RewriteCSV(PATH,linhas);
        }

        
        /// <summary>
        /// retornar e ler as noticias com atributos dados
        /// </summary>
        /// <returns></returns>
        public List<Noticias> ReadAll()
        {
             List<Noticias> news = new List<Noticias>();
            string[] linhas = File.ReadAllLines(PATH);
            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");
                Noticias report = new Noticias();
                report .IdNoticia = Int32.Parse(linha[0]);
                report.Titulo = linha[1];
                report.Texto = linha[2];
                report.Imagem = linha[3];
                

               news.Add(report);
            }
            return news;
        }

        /// <summary>
        /// reescever e atualizar linha
        /// </summary>
        /// <param name="noticias"></param>
        public void Update(Noticias noticias)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(y => y.Split(";")[0] == noticias.IdNoticia.ToString());
            linhas.Add(PrepararLinha (noticias));
            RewriteCSV(PATH,linhas);
        }
    }
}