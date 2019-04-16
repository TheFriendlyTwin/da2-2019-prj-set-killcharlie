using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SetepassosPRJ.Models
{
    public class Jogo:NovoJogo
    {
        public int PontosVida { get; set; }

        public int PontosAtaque { get; set; }

        public int PontosSorte { get; set; }

        public int PocoesVida { get; set; }

        public bool Chave { get; set; }

        public int PosicaoHeroi { get; set; }

        public string Controlo { get; set; }

        public bool Inimigo { get; set; }

        public Jogo(string utilizador, string perfilHeroi)
        {
            PerfilHeroi = perfilHeroi;
            Utilizador = utilizador;
            if(perfilHeroi == "BlackMamba")
            {
                PontosVida = 4;
                PontosAtaque = 3;
                PontosSorte = 2;
            }
            else if(perfilHeroi == "Cottonmouth")
            {
                PontosVida = 3;
                PontosAtaque = 3;
                PontosSorte = 3;
            }
            else
            {
                PontosVida = 3;
                PontosAtaque = 2;
                PontosSorte = 4;
            }

            PocoesVida = 1;
            Chave = false;
            PosicaoHeroi = 1;

            Random inimigo = new Random();

        }
    }
}
