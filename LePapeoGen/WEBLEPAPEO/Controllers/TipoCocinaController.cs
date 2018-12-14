using WEBLEPAPEO.Models;
using LePapeoGenNHibernate.CAD.LePapeo;
using LePapeoGenNHibernate.CEN.LePapeo;
using LePapeoGenNHibernate.EN.LePapeo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WEBLEPAPEO.Controllers
{
    public class TipoCocinaController : BasicController
    {
        // GET: TipoCocina
        public ActionResult Index()
        {
            TipoCocinaCEN tipoCocinaCEN = new TipoCocinaCEN();
            IList<TipoCocinaEN> listtipEN = tipoCocinaCEN.ReadAll(0, -1);
            IEnumerable<TipoCocinaViewModel> listtip = new AssemblerTipoCocina().ConvertListENToModel(listtipEN);
            return View(listtip);
        }

        // GET: TipoCocina/Details/5
        public ActionResult Details(string id)
        {
            TipoCocinaViewModel tip = null;
            SessionInitialize();
            TipoCocinaEN tipEN = new TipoCocinaCAD(session).ReadOIDDefault(id);
            tip = new AssemblerTipoCocina().ConvertENToModelUI(tipEN);
            SessionClose();
            return View(tip);
        }

        // GET: TipoCocina/Create
        public ActionResult Create()
        {
            TipoCocinaViewModel tip = new TipoCocinaViewModel();
            return View(tip);
        }

        // POST: TipoCocina/Create
        [HttpPost]
        public ActionResult Create(TipoCocinaViewModel tip)
        {
            try
            {
                // TODO: Add insert logic here
                TipoCocinaCEN tipCEN = new TipoCocinaCEN();
                tipCEN.New_(tip.Tipo);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TipoCocina/Edit/5
        public ActionResult Edit(string id)
        {
            TipoCocinaViewModel tip = null;
            SessionInitialize();
            TipoCocinaEN tipEN = new TipoCocinaCAD(session).ReadOIDDefault(id);
            tip = new AssemblerTipoCocina().ConvertENToModelUI(tipEN);
            SessionClose();
            return View(tip); 
        }

        // POST: TipoCocina/Edit/5
        [HttpPost]
        public ActionResult Edit(TipoCocinaViewModel tip)
        {
            try
            {
                // TODO: Add update logic here
                TipoCocinaCEN cen = new TipoCocinaCEN();
                cen.Modify(tip.Tipo);
                

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TipoCocina/Delete/5
        public ActionResult Delete(string id)
        {
            try
            {
                SessionInitialize();
                TipoCocinaCAD tipCAD = new TipoCocinaCAD(session);
                TipoCocinaCEN tipCEN = new TipoCocinaCEN(tipCAD);
                TipoCocinaEN tipEN = tipCEN.ReadOID(id);
                TipoCocinaViewModel tip = new AssemblerTipoCocina().ConvertENToModelUI(tipEN);

                SessionClose();

                return View(tip);
            }
            catch
            {
                return View();
            }
        }

        // POST: TipoCocina/Delete/5
        [HttpPost]
        public ActionResult Delete(TipoCocinaViewModel tip)
        {
            try
            {
                // TODO: Add delete logic here
                new TipoCocinaCEN().Destroy(tip.Tipo);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
