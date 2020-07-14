using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EPlayersFim.Models;

namespace EPlayersFim.Controllers
{
    public class EquipeController : Controller
    {
        Equipe equipeModel = new Equipe (); 
       
        public IActionResult Index()
        {
            return View();
        }

        
    }
}
