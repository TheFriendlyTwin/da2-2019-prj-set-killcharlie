using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
        public async Task<IActionResult> NovoJogo(string playerName, string playerClass)
        {
            HttpClient client = MyGameHTTPClient.Client;
            string path = "/api/NewGame";

            GameApiRequest req = new GameApiRequest(playerName,playerClass);
            string json = JsonConvert.SerializeObject(req);

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, path);
            request.Content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                return Redirect("NovoJogo");
            }

            string json_r = await response.Content.ReadAsStringAsync();

            GameApiResponse gr = JsonConvert.DeserializeObject<GameApiResponse>(json_r);

            Jogo novoJogo = new Jogo(playerName, playerClass);
            novoJogo.AtualizarJogo(gr);
            Repositorio.AdicionarJogo(novoJogo);

            return View("Jogo", novoJogo);
        }

        [HttpGet]
        public IActionResult Jogo()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Jogo(PlayerAction playerAction, int id)
        {
            HttpClient client = MyGameHTTPClient.Client;
            string path = "/api/Play";

            Jogo jogo = Repositorio.DevolverJogo(id); //Devolve o jogo Atual
            
            PlayApiRequest req = new PlayApiRequest(jogo.ID, playerAction);
            string json = JsonConvert.SerializeObject(req);

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, path);
            request.Content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                return Redirect("/");
            }

            string json_r = await response.Content.ReadAsStringAsync();
            
            if(playerAction != PlayerAction.Quit)
            {
                GameApiResponse resposta = JsonConvert.DeserializeObject<GameApiResponse>(json_r);

                jogo.AtualizarJogo(resposta);

                if (jogo.PontosVida == 0 || resposta.Result == RoundResult.SuccessVictory)
                {
                    jogo.ScoreJogo();
                    Repositorio.AdicionarScore(jogo); //NOVO
                    return View("Score", jogo);
                }
                else
                {
                    return View(jogo);
                }
            }
            else
            {
                jogo.ScoreJogo();
                Repositorio.AdicionarScore(jogo); //NOVO
                return View("Score", jogo);
            }
        }

        public IActionResult HighScore()
        {
            List<HighScore> scores = Repositorio.Scores;
            scores.Sort();
            scores.Reverse();

            List<HighScore> highScores = Repositorio.ListaScores(scores);
            return View(highScores);
        }
    }
}