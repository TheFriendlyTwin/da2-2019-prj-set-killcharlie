using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SetepassosPRJ.Models
{
    public class Jogo:NovoJogo
    {
        public int PontosVida {
            set
            {
                if (PerfilHeroi == "BlackMamba")
                {
                    PontosVida = 4;
                }
                else
                    PontosVida = 3;
            }
            get
            {
                return PontosVida;
            }
        }

        public int PontosAtaque
        {
            set
            {
                if (PerfilHeroi == "Copperhead")
                {
                    PontosAtaque = 2;
                }
                else
                    PontosVida = 3;
            }
            get
            {
                return PontosAtaque;
            }
        }

        public int PontosSorte
        {
            set
            {
                if(PerfilHeroi == "BlackMamba")
                {
                    PontosSorte = 2;
                }
                if (PerfilHeroi == "Cottonmouth")
                {
                    PontosSorte = 3;
                }
                else
                    PontosSorte = 4;
            }
            get
            {
                return PontosSorte;
            }
        }

        public int PocoesVida
        {
            set
            {
                PocoesVida = 1;
            }
            get
            {
                return PocoesVida;
            }
        }

        public bool Chave
        {
            set
            {
                Chave = false;
            }
            get
            {
                return Chave;
            }
        }

        public int PosicaoHeroi
        {
            set
            {
                PosicaoHeroi = 1;
            }
            get
            {
                return PosicaoHeroi;
            }
        }

        public bool AreaJogo
        {
            set
            {
                AreaJogo = true;
            }
            get
            {
                return AreaJogo;
            }
        }

        public string Controlo { get; set; }
    }
}
