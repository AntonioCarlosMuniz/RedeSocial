using Dados;
using Microsoft.AspNet.Identity;
using Servico;
using SocialBarbaWeb.Models;
using SocialBarbaWeb.ServicoWeb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialBarbaWeb.Controllers
{
    // Controller responsável por montar e interagir com a tela principal
    [Authorize]
    public class GerenciadorController : Controller
    {
        private PerfilServico servicoPerfil;
        private PostagemServico servicoPostagem;
        private SeguirServico servicoSeguir;

        public GerenciadorController()
        {
            servicoPerfil = new PerfilServico(new PerfisEntity());
            servicoPostagem = new PostagemServico(new PostagensEntity());
            servicoSeguir = new SeguirServico(new SeguirEntity());
        }

        // Action da pagina do usuario logado
        public ActionResult Index()
        {
            var UserSessionId = User.Identity.GetUserId();
            if (Session["UserId"] == null)
                Session["UserId"] = UserSessionId;

            var perfilTmp = servicoPerfil.RetornaPerfilUsuario(UserSessionId);
            if (perfilTmp != null)
            {
                FabricaDashboard fabricaDash = new FabricaDashboard();
                var dashBoard = fabricaDash.MontaPerfil(UserSessionId);
                if (dashBoard != null)
                    return View(dashBoard);
            }
            return RedirectToAction("CheckIn", "Perfis");
        }

        // Action que localiza o usuario a partir do id de perfil e chama a action PerfilTerceiro
        public ActionResult PerfilPorUserId(int perfilId)
        {
            var perfil = servicoPerfil.RetornaPerfilUnico(perfilId);
            return RedirectToAction("PerfilVisitado", new { userId = perfil.UserID });
        }

        // Action que monta a view de um usuario visitado
        public ActionResult PerfilVisitado(string userId)
        {
            var UserSessionId = User.Identity.GetUserId();
            if (Session["UserId"] == null)
                Session["UserId"] = UserSessionId;
            // Instanciando o DashBoard e recebendo o perfil
            FabricaDashboard fabricaDash = new FabricaDashboard();
            var dashBoard = fabricaDash.MontaPerfil(userId);

            // Busca perfil e verifica se o usuário atual está seguindo
            var VisitanteId = UserSessionId;
            var Visitado = servicoPerfil.RetornaPerfilUsuario(userId);
            dashBoard.ChecaSeSeguePerfil = servicoSeguir.checarSeguido(VisitanteId, Visitado.id);

            return View(dashBoard);
        }

        // Action da pagina inicial do usuario
        public ActionResult Inicio()
        {
            // Verifica se a variavel de sessão UserId é nula
            var UserSessionId = User.Identity.GetUserId();
            if (Session["UserId"] == null)
                Session["UserId"] = UserSessionId;

            FabricaDashboard fabricaDash = new FabricaDashboard();
            var dashBoard = fabricaDash.MontaPerfil(UserSessionId);

            return View(dashBoard);
        }

        // Retorna os dados contidos na entidade 'RedeModel' para exibir a página 'Toda a Rede'
        public ActionResult TodaRede()
        {
            RedeModel todaARede = new RedeModel();
            FabricaPaginaGeral fabricaPagina = new FabricaPaginaGeral();
            todaARede = fabricaPagina.MontaPaginaTodaRede();
            return View(todaARede);
        }
    }
}