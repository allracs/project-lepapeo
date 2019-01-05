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
            UsuarioCEN usu = new UsuarioCEN();
            int idd = usu.DgetOIDfromEmail(User.Identity.Name);
            UsuarioEN usuen = usu.ReadOID(idd);
            if (usuen != null)
            {
                String[] tipo = usuen.GetType().ToString().Split('.');
                if (!tipo[tipo.Length - 1].Equals("AdminEN")) return RedirectToAction("Index", "Home");

                CiudadCEN ciucen = new CiudadCEN();
                IList<CiudadEN> ciulisten = ciucen.ReadAll(0, -1);
                IEnumerable<CiudadViewModel> ciuenum = new AssemblerCiudad().ConvertListENToModel(ciulisten);
                return View(ciuenum);
            }
            return RedirectToAction("Index", "Home");
        }

        // GET: Ciudad/Details/5
        public ActionResult Details(String id)
        {
            CiudadCEN ciucen = new CiudadCEN();
            CiudadEN ciuen = ciucen.ReadOID(id);
            CiudadViewModel ciuview = new AssemblerCiudad().ConvertENToModelUI(ciuen);
            return View(ciuview);
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
                ciucen.New_(view.id, view.provincia);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Ciudad/Edit/5
        public ActionResult Edit(String id)
        {
            SessionInitialize();
            CiudadEN ciuen = new CiudadCAD(session).ReadOID(id);
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
                ciucen.Modify(view.id, view.provincia);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Ciudad/Delete/5
        public ActionResult Delete(String id)
        {
            SessionInitialize();
            CiudadCAD ciucad = new CiudadCAD(session);
            CiudadCEN ciucen = new CiudadCEN(ciucad);
            CiudadEN ciuen = ciucen.ReadOID(id);
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
                new CiudadCEN().Destroy(view.id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
