using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SetepassosPRJ.Models;

namespace SetepassosPRJ.Controllers
{
    public class JogoController : Controller
    {
        public IActionResult NovoJogo()
        {
            return View();
        }
        
        public IActionResult HighScore()
        {
            return View();
        }
    }
}