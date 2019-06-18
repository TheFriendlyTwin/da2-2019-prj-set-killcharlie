using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SetepassosPRJ.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SetepassosPRJ.Controllers
{
    [Route("api/[controller]")]
    public class HiscoresController : Controller
    {
        // POST api/<controller>
        [HttpPost]
        public List<HighScore> Post([FromBody]ScoreJogador jogador)
        {
            return Repositorio.TopScoreJogador(jogador);
        }
    }
}
