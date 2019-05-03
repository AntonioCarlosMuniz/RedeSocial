using Dados;
using Microsoft.AspNet.Identity;
using Negocio.Dominio;
using Servico;
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
    public class PostagensController : Controller
    {
        private PostagemServico servicoPostagem;
        private PerfilServico servicoPerfil;
        private BlobServico servicoBlob;

        public PostagensController()
        {
            servicoPostagem = new PostagemServico(new PostagensEntity());
            servicoPerfil = new PerfilServico(new PerfisEntity());
            servicoBlob = new BlobServico();
        }

        // GET: Postagems
        public ActionResult Index()
        {
            return View(servicoPostagem.RetornaPostagens(10));
        }

        // GET: Postagems/Details/5
        public ActionResult Details(int id)
        {
            Postagem postagem = servicoPostagem.RetornaPostagemUnica(id);
            if (postagem == null)
            {
                return HttpNotFound();
            }
            return View(postagem);
        }

        // GET: Postagems/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Postagems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,PerfilId,DataPostagem,FotoPostagem,TextoPostagem")] Postagem postagem, HttpPostedFileBase imgPostagem)
        {
            // Verificando se a variavel de sessão UserId é está nula
            if (Session["UserId"] == null)
                Session["UserId"] = User.Identity.GetUserId();
            postagem.UserId = Session["UserId"].ToString();

            if (imgPostagem != null) // Caso venha uma foto na postagem
            {
                var imgUrl = await servicoBlob.UploadImageAsync(imgPostagem);//Envia para o blob
                postagem.FotoPostagem = imgUrl;
            }

            var perfil = servicoPerfil.RetornaPerfilUsuario(postagem.UserId);
            postagem.PerfilId = perfil.id;
            postagem.DataPostagem = DateTime.Now;

            if (ModelState.IsValid)
            {
                servicoPostagem.CriaPostagem(postagem);
                return RedirectToAction("Index", "Gerenciador");
            }

            return View(postagem);
        }


        // GET: Postagems/Delete/5
        public ActionResult Delete(int id)
        {
            Postagem postagem = servicoPostagem.RetornaPostagemUnica(id);
            if (postagem == null)
            {
                return HttpNotFound();
            }
            return View(postagem);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                servicoPostagem.dispose();
            }
            base.Dispose(disposing);
        }
    }
}
