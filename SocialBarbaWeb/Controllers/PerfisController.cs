﻿using Dados;
using Microsoft.AspNet.Identity;
using Negocio.Dominio;
using Servico;
using SocialBarbaWeb.Models;
using SocialBarbaWeb.ServicoWeb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SocialBarbaWeb.Controllers
{
    [Authorize]
    public class PerfisController : Controller
    {

        private PerfilServico servico;
        private PostagemServico servicoPostagem;
        private SeguirServico servicoSeguir;
        private string IdUsuario;
        private BlobServico servicoBlob;



        public PerfisController()
        {
            servico = new PerfilServico(new PerfisEntity());
            servicoPostagem = new PostagemServico(new PostagensEntity());
            servicoSeguir = new SeguirServico(new SeguirEntity());
            servicoBlob = new BlobServico();
        }

        // Action que busca um perfil para o usuario ou cria um novo perfil
        public ActionResult CheckIn()
        {
            var userId = User.Identity.GetUserId(); // Obtém o id do user logado
            var PerfilUser = servico.RetornaPerfilUsuario(userId); // Busca um perfil existente para o user logado
            if (PerfilUser != null) // Manda para o perfil existente caso seja true
                return RedirectToAction("Index", "Gerenciador");

            CriaPerfilPadrao.Criar(userId); // Cria um perfil padrão caso a condição acima seja false
            return RedirectToAction("Index", "Gerenciador");
        }

        // Action que registra o Seguir para perfil
        public ActionResult Seguir(int id)
        {
            return RedirectToAction("SeguirPerfil", "Seguirs", new { Id = id });
        }

        // GET: Perfils
        public ActionResult Index()
        {
            var lista = servico.RetornaPerfis(8);
            return View(lista);
        }

        // GET: Perfils/Details/5
        public ActionResult Details(int id)
        {
            var perfil = servico.RetornaPerfilUnico(id);
            if (perfil == null)
            {
                return HttpNotFound();
            }
            return View(perfil);
        }

        // GET: Perfils/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: Perfils/Edit/5
        public ActionResult Edit(int id)
        {
            if (Session["UserId"] == null)
                Session["UserId"] = User.Identity.GetUserId();

            Perfil perfil = servico.RetornaPerfilUnico(id);
            if (perfil.UserID == Session["UserId"].ToString())
            {
                var perfilView = PerfilViewModel.ConvertToViewModel(perfil);//Convertendo para PerfilViewModel
                Session["FotoPerfil"] = perfilView.FotoPerfil; // Guarda foto do perfil na sessão
                return View(perfilView);
            }
            return RedirectToAction("Index", "Gerenciador");
        }

        // POST: Perfils/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,UserID,NomeExibicao,FotoPerfil")] PerfilViewModel perfil, HttpPostedFileBase imgPerfil)
        {
            if (ModelState.IsValid)
            {
                if (imgPerfil != null)// Se a foto vindo da view não for nula 
                {
                    // Envia a foto para o blob
                    var imgUri = await servicoBlob.UploadImageAsync(imgPerfil);
                    // Guarda a Uri da foto salva no blob
                    perfil.FotoPerfil = imgUri.ToString();
                }
                else
                {   // Se for nula, atribui a foto que foi guardada na sessão             
                    perfil.FotoPerfil = Session["FotoPerfil"].ToString();
                }
                var perfilModel = PerfilViewModel.ConvertToModel(perfil);

                if (Session["UserId"] == null)
                    Session["UserId"] = User.Identity.GetUserId();
                perfilModel.UserID = Session["UserId"].ToString();
                servico.EditaPerfil(perfilModel);
                return RedirectToAction("Index", "Gerenciador");
            }
            return View(perfil);
        }

        // GET: Perfils/Delete/5
        public ActionResult Delete(int id)
        {
            Perfil perfil = servico.RetornaPerfilUnico(id);
            if (perfil == null)
            {
                return HttpNotFound();
            }
            return View(perfil);
        }

        // Action que apaga um perfil
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var IdUsuario = User.Identity.GetUserId();
            // Realiza a ação em todos os serviços
            servicoPostagem.ExecutaExclusao(IdUsuario, id);
            servicoSeguir.ExecutaExclusao(IdUsuario, id);
            servico.ExecutaExclusao(IdUsuario, id);

            return RedirectToAction("Register", "Account");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                servico.dispose();
            }
            base.Dispose(disposing);
        }
    }
}
