using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SetepassosPRJ.Models;

namespace SetepassosPRJ.Controllers
{
    public class ModoAutonomoController : Controller
    {
        [HttpGet]
        public IActionResult NovoAutoJogo()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NovoAutoJogo(int rondas)
        {
            return View("Resultados");
        }
    }
}