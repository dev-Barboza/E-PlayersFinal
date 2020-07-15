using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EPlayersFim.Models;
using Microsoft.AspNetCore.Http;
using System.IO;

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
           
           
            var file    = form.Files[0];
            var folder  = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Equipes");

            if(file != null)
            {
                if(!Directory.Exists(folder)){
                    Directory.CreateDirectory(folder);
                }

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/", folder, file.FileName);
                using (var stream = new FileStream(path, FileMode.Create))  
                {  
                    file.CopyTo(stream);  
                }
                newEquipe.Imagem   = file.FileName;
            }
            else
            {
                newEquipe.Imagem   = "padrao.png";
            }

            equipeModel.Create(newEquipe);            
            
            ViewBag.Equipes = equipeModel.ReadAll();

            return LocalRedirect("~/Equipe");
        }

        
    }
}
