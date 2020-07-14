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
    public class EquipeController : Controller
    {
        Equipe equipeModel = new Equipe (); 
       
        public IActionResult Index()
        {
            ViewBag.Equipes = equipeModel.ReadAll();
            return View();
        }

        public IActionResult Cadastrar(IFormCollection form)
        {
            Equipe newEquipe   = new Equipe();
            newEquipe.IdEquipe = Int32.Parse(form["IdEquipe"]);
            newEquipe.Nome     = form["Nome"];
            newEquipe.Imagem   = form["Imagem"];

            equipeModel.Create(newEquipe);            
            ViewBag.Equipes = equipeModel.ReadAll();

            return LocalRedirect("~/Equipe");
        }

        
    }
}
