


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

        private const string PATH = "Database/equipe.csv";

        public Noticias()
        {
            CreateFolderAndFile(PATH);
        }
        public void Create(Noticias noticias)
        {
            string[] linhas = {PrepararLinha(noticias)};
            File.AppendAllLines(PATH , linhas);
        }

        private string PrepararLinha(Noticias noticias)
        {
            return $"{noticias.IdNoticia};{noticias.Imagem};{noticias.Titulo};{noticias.Texto}";
        }

        public void Delete(int IdNoticia)
        {
            
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(y => y.Split(";")[0] == IdNoticia.ToString());
            RewriteCSV(PATH,linhas);
        }

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
                report.Imagem = linha[2];
                report.Texto = linha[3];

               news.Add(report);
            }
            return news;
        }

        public void Update(Noticias noticias)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(y => y.Split(";")[0] == noticias.IdNoticia.ToString());
            linhas.Add(PrepararLinha (noticias));
            RewriteCSV(PATH,linhas);
        }
    }
}