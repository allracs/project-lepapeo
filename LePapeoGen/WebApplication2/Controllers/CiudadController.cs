using LePapeo.Models;
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
    public class CiudadController : BasicController
    {
        // GET: Ciudad
        public ActionResult Index()
        {
            CiudadCEN ciucen = new CiudadCEN();
            IList<CiudadEN> ciulisten = ciucen.ReadAll(0, -1);
            IEnumerable<CiudadViewModel> ciuenum = new AssemblerCiudad().ConvertListENToModel(ciulisten);
            return View(ciuenum);
        }

        // GET: Ciudad/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Ciudad/Create
        public ActionResult Create()
        {
            CiudadViewModel view = new CiudadViewModel();
            return View(view);
        }

        // POST: Ciudad/Create
        [HttpPost]
        public ActionResult Create(CiudadViewModel view)
        {
            try
            {
                // TODO: Add insert logic here
                CiudadCEN ciucen = new CiudadCEN();
                ciucen.New_(view.nombre, view.provincia);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Ciudad/Edit/5
        public ActionResult Edit(String nombre)
        {
            SessionInitialize();
            CiudadEN ciuen = new CiudadCAD(session).ReadOID(nombre);
            CiudadViewModel ciuview = new AssemblerCiudad().ConvertENToModelUI(ciuen);
            SessionClose();
            return View(ciuview);
        }

        // POST: Ciudad/Edit/5
        [HttpPost]
        public ActionResult Edit(CiudadViewModel view)
        {
            try
            {
                // TODO: Add update logic here
                CiudadCEN ciucen = new CiudadCEN();
                ciucen.Modify(view.nombre, view.provincia);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Ciudad/Delete/5
        public ActionResult Delete(String nombre)
        {
            SessionInitialize();
            CiudadCAD ciucad = new CiudadCAD(session);
            CiudadCEN ciucen = new CiudadCEN(ciucad);
            CiudadEN ciuen = ciucen.ReadOID(nombre);
            CiudadViewModel ciuview = new AssemblerCiudad().ConvertENToModelUI(ciuen);
            SessionClose();
            return View(ciuview);
        }

        // POST: Ciudad/Delete/5
        [HttpPost]
        public ActionResult Delete(CiudadViewModel view)
        {
            try
            {
                // TODO: Add delete logic here
                new CiudadCEN().Destroy(view.nombre);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
