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
                Jogo primeiroJogo = new Jogo(jogo.Utilizador, jogo.PerfilHeroi);
                Repositorio.AdicionarJogo(primeiroJogo);
                return View("Jogo", primeiroJogo);
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