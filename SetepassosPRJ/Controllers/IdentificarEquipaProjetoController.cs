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
    public class IdentificarEquipaProjetoController : Controller
    {

        // GET: api/<controller>
        [HttpGet]
        public List<TeamMember> Get()
        {
            if (Repositorio.Members.Count == 0)
                Repositorio.AdicionarMembro();

            return Repositorio.Members;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

       
    }
}
