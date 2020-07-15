using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EPlayersFim.Models;
using Microsoft.AspNetCore.Http;

namespace EPlayersFim.Controllers
{
    public class NoticiasController : Controller
    {
        
        Noticias noticiasModel = new Noticias();

        public IActionResult Index()
        {
            ViewBag.noticiaBag = noticiasModel.ReadAll();
            return View();
        }

        public  IActionResult Cadastrar(IFormCollection form)
        {
            Noticias novaNoticia = new Noticias();

            novaNoticia.IdNoticia = Int32.Parse(form["IdNoticia"]);
            novaNoticia.Titulo = form ["Titulo"];
            novaNoticia.Texto = form ["Texto"];
            novaNoticia.Imagem = form["Imagem"];


            noticiasModel.Create(novaNoticia);

            ViewBag.noticiaBag = noticiasModel.ReadAll();
            return LocalRedirect("~/noticias");
        }

    
    }
}
