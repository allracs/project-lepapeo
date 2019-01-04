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
    public class DireccionController : BasicController
    {
        // GET: Direccion
        [Authorize(Users = "Admin@mail.com")]
        public ActionResult Index()
        {
            DireccionCEN dirCEN = new DireccionCEN();
            IList<DireccionEN> listDirEN = dirCEN.ReadAll(0, -1);
            IEnumerable<DireccionViewModel> listd = new AssemblerDireccion().ConvertListENToModel(listDirEN);
            return View(listd);
        }

        // GET: Direccion/Details/5
        public ActionResult Details(int id)
        {
            SessionInitialize();
            DireccionCAD dircad = new DireccionCAD(session);
            DireccionCEN dircen = new DireccionCEN(dircad);
            DireccionEN diren = dircen.ReadOID(id);
            DireccionViewModel vi = new AssemblerDireccion().ConvertENToModelUI(diren);
            ViewData["ciudad"] = diren.Ciudad.Nombre;
            SessionClose();
            return View(vi);
        }

        // GET: Direccion/Create
        public ActionResult Create()
        {
            DireccionViewModel dir = new DireccionViewModel();

            CiudadCEN ciudadCEN = new CiudadCEN();
            IList<CiudadEN> listaCiudad = ciudadCEN.ReadAll(0, -1);
            ViewData["listaCiudad"] = listaCiudad;

            return View(dir);
        }

        // POST: Direccion/Create
        [HttpPost]
        public ActionResult Create(DireccionViewModel dir)
        {
            try
            {
                // TODO: Add insert logic here

                CiudadCEN ciudadCEN = new CiudadCEN();
                CiudadEN ciudadEN = ciudadCEN.ReadOID(dir.ciudad);
                CiudadCEN c = new CiudadCEN();
                if(ciudadEN == null)
                {
                    c.New_(dir.ciudad, dir.provincia);
                } else if(ciudadEN.Provincia == null)
                {
                    c.Modify(ciudadEN.Nombre, dir.provincia);
                }

                DireccionCEN dircen = new DireccionCEN();
                dircen.New_(dir.cod_pos, dir.calle, dir.numero_puerta, dir.pos_x, dir.pos_y, dir.ciudad);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Direccion/Edit/5
        public ActionResult Edit(int id)
        {
            SessionInitialize();
            DireccionCAD dircad = new DireccionCAD(session);
            DireccionCEN dircen = new DireccionCEN(dircad);
            DireccionEN diren = dircen.ReadOID(id);
            DireccionViewModel dirview = new AssemblerDireccion().ConvertENToModelUI(diren);
            SessionClose();
            return View(dirview);
        }

        // POST: Direccion/Edit/5
        [HttpPost]
        public ActionResult Edit(DireccionViewModel view)
        {
            try
            {
                // TODO: Add update logic here
                DireccionCEN dircen = new DireccionCEN();
                dircen.Modify(view.id, view.cod_pos, view.calle, view.numero_puerta, view.pos_x, view.pos_y);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Direccion/Delete/5
        public ActionResult Delete(int id)
        {
            SessionInitialize();
            DireccionCAD dircad = new DireccionCAD(session);
            DireccionCEN dircen = new DireccionCEN(dircad);
            DireccionEN diren = dircen.ReadOID(id);
            DireccionViewModel dirview = new AssemblerDireccion().ConvertENToModelUI(diren);
            SessionClose();
            return View(dirview);
        }

        // POST: Direccion/Delete/5
        [HttpPost]
        public ActionResult Delete(DireccionViewModel view)
        {
            try
            {
                // TODO: Add delete logic here
                new DireccionCEN().Destroy(view.id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
