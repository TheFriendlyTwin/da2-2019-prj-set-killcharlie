using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SetepassosPRJ.Models
{
    public class Jogo : NovoJogo
    {
        #region Propriedades
        public int PontosVida { get; set; }
        public int PontosAtaque { get; set; }
        public int PontosSorte { get; set; }
        public int PocoesVida { get; set; }
        public bool Chave { get; set; }
        public int PosicaoHeroi { get; set; }
        public int DistanciaPorta { get; set; } //propriedade acrescentada, que retorna os número de passos restantes para alcançar a porta
        public bool Inimigo { get; set; }
        public bool PocaoEncontrada { get; set; }
        public int MoedasOuro { get; set; }
        public GameResponse EstadoJogo { get; set; }
        #endregion

        #region Construtor
        public Jogo(string utilizador, string perfilHeroi)
        {
            PerfilHeroi = perfilHeroi;
            Utilizador = utilizador;
            if (perfilHeroi == "S")
            {
                PontosVida = 4;
                PontosAtaque = 3;
                PontosSorte = 2;
            }
            else if (perfilHeroi == "W")
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
            PosicaoHeroi = 1;
            DistanciaPorta = 7 - PosicaoHeroi;
            MoedasOuro = 0;

            //Apenas para a milestone 1
            Random inimigoEncontrado = new Random();
            int numeroAleatorio = inimigoEncontrado.Next(0, 2);
            if (numeroAleatorio == 0)
            {
                Inimigo = true;
            }
            else
            {
                Inimigo = false;
            }

            //Apenas para a milestone 1
            Random pocaoEncontrada = new Random();
            int num = pocaoEncontrada.Next(0, 2);
            if (num == 0)
            {
                PocaoEncontrada = true;
            }
            else
            {
                PocaoEncontrada = false;
            }

            //Apenas para a milestone 1
            Random posseChave = new Random();
            int numero = posseChave.Next(0, 2);
            if (numero == 0)
            {
                Chave = true;
            }
            else
            {
                Chave = false;
            }
        }
        #endregion
    }
}