
using System;
using E_Players_MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Players_MVC.Controllers
{
    [Route("Jogador")]
    public class JogadorController : Controller
    {
        Jogador jogadorModel = new Jogador();

        [Route("Listar")]
        public IActionResult Index(){
            ViewBag.Jogador = jogadorModel.LerTodas();
            return View();
        }

        [Route("Cadastrar")]
        public IActionResult Cadastrar(IFormCollection form){
            Jogador novoJogador = new Jogador();
            novoJogador.Idjogador = Int32.Parse(form["IdJogador"]);
            novoJogador.IdEquipe  = Int32.Parse(form["IdEquipe"]);
            novoJogador.Nome      = form["Nome"];
            novoJogador.Email     = form["Email"];
            novoJogador.Senha     = form["Senha"];

            jogadorModel.Criar(novoJogador);

            ViewBag.Jogador = jogadorModel.LerTodas();

            return LocalRedirect("~/Jogador/Listar");
        }

        [Route("Deletar/{id}")]
        public IActionResult Deletar(int id){
            jogadorModel.Deletar(id);
            ViewBag.Jogadores = jogadorModel.LerTodas();
            return LocalRedirect("~/Jogador/Listar");
        }
    }
}