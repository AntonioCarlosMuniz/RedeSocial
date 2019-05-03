using Dados;
using Negocio.Dominio;
using Servico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SocialBarbaWeb.Controllers
{
    public class BigodeController : Controller
    {
        private BigodeServico servico;

        public BigodeController()
        {
            servico = new BigodeServico(new BigodeEntity());
        }

        // GET: Bigodes
        public ActionResult Index()
        {
            var lista = servico.RetornaBigodes();
            return View(lista);
        }

        // GET: Bigodes/Details/5
        public ActionResult Details(int id)
        {
            Bigode bigode = servico.RetornaBigodeUnico(id);
            if (bigode == null)
            {
                return HttpNotFound();
            }
            return View(bigode);
        }

        // GET: Bigodes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bigodes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,BigodeId,Nome")] Bigode bigode)
        {
            if (ModelState.IsValid)
            {
                servico.CriaBigode(bigode);
                return RedirectToAction("Index");
            }

            return View(bigode);
        }

        // GET: Bigodes/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bigode bigode = servico.RetornaBigodeUnico(id);
            if (bigode == null)
            {
                return HttpNotFound();
            }
            return View(bigode);
        }

        // POST: Bigodes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,BigodeId,Nome")] Bigode bigode)
        {
            if (ModelState.IsValid)
            {
                servico.EditaBigode(bigode);
                return RedirectToAction("Index");
            }
            return View(bigode);
        }

        // GET: Bigodes/Delete/5
        public ActionResult Delete(int id)
        {
            Bigode bigode = servico.RetornaBigodeUnico(id);
            if (bigode == null)
            {
                return HttpNotFound();
            }
            return View(bigode);
        }

        // POST: Bigodes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bigode bigode = servico.RetornaBigodeUnico(id);
            servico.ApagaBigode(bigode);
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
