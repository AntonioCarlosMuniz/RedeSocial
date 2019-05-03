using Dados;
using Negocio.Dominio;
using Servico;
using SocialBarbaWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialBarbaWeb.Controllers
{
    public class BarbaController : Controller
    {
        private BarbaServico servico;


        public BarbaController()
        {
            servico = new BarbaServico(new BarbasEntity());
        }

        // GET: Barbas
        public ActionResult Index()
        {
            var lista = servico.RetornaBarbas();
            var barbaView = BarbaViewModel.GetModel(lista);
            return View(barbaView);
        }

        // GET: Barbas/Details/5
        public ActionResult Details(int id)
        {
            Barba barba = servico.RetornaBarbaUnica(id);
            if (barba == null)
            {
                return HttpNotFound();
            }
            return View(barba);
        }

        // GET: Barbas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Barbas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,PerfilID,UserId,Nome,tipo,capacidade")] Barba barba)
        {
            if (ModelState.IsValid)
            {
                servico.CriaBarba(barba);
                return RedirectToAction("Index");
            }

            return View(barba);
        }

        // GET: Barbas/Edit/5
        public ActionResult Edit(int id)
        {
            Barba barba = servico.RetornaBarbaUnica(id);
            if (barba == null)
            {
                return HttpNotFound();
            }
            return View(barba);
        }

        // POST: Barbas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,PerfilID,UserId,Nome,tipo,capacidade")] Barba barba)
        {
            if (ModelState.IsValid)
            {
                servico.EditaBarba(barba);
                return RedirectToAction("Index");
            }
            return View(barba);
        }

        // GET: Barbas/Delete/5
        public ActionResult Delete(int id)
        {
            Barba barba = servico.RetornaBarbaUnica(id);
            if (barba == null)
            {
                return HttpNotFound();
            }
            return View(barba);
        }

        // POST: Barbas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Barba barba = servico.RetornaBarbaUnica(id);
            servico.ApagaBarba(barba);
            return RedirectToAction("Index");
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
