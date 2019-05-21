using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SetepassosPRJ.Models
{
    public class NovoJogo
    {
        #region Propriedades
        [Required(ErrorMessage ="Por favor introduza um nome para o seu utilizador!")]
        public string Utilizador { get; set; }

        [Required(ErrorMessage ="Por favor introduza um perfil de herói!")]
        public string PerfilHeroi { get; set; }
        #endregion
    }
}
