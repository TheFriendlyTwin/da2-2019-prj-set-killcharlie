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
        [HttpGet]
        public IActionResult NovoJogo()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NovoJogo(NovoJogo jogo)
        {
            if (ModelState.IsValid)
            {
                return View("Jogo", jogo);
            }
            else
                return View();
        }

        public IActionResult HighScore()
        {
            return View();
        }
    }
}