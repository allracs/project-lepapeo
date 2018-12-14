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
        public ActionResult Index()
        {
            /*
            AdminCEN adminCEN = new AdminCEN();
            IList<AdminEN> listadminEN = adminCEN.ReadAll(0, -1);
            IEnumerable<AdminViewModel> listadmin = new AssemblerAdmin().ConvertListENToModel(listadminEN);
            return View(listadmin);
             */
            DireccionCEN dirCEN = new DireccionCEN();
            IList<DireccionEN> listDirEN = dirCEN.ReadAll(0, -1);
            IEnumerable<DireccionViewModel> listd = new AssemblerDireccion().ConvertListENToModel(listDirEN);
            return View(listDirEN);
        }

        // GET: Direccion/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Direccion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Direccion/Create
        [HttpPost]
        public ActionResult Create(DireccionViewModel dirvm)
        {
            try
            {
                // TODO: Add insert logic here
                //  SessionInitialize();
                //  UsuarioCAD usuCAD = new UsuarioCAD(/*session*/);
                //  usuCAD.New_(usuEN);
                //  SessionClose(); 
                DireccionCEN dircen = new DireccionCEN();
                dircen.New_(dirvm.cod_pos, dirvm.calle, dirvm.numero_puerta, dirvm.pos_x, dirvm.pos_y, dirvm.ciudad.Nombre);
                
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
            return View();
        }

        // POST: Direccion/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

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
            return View();
        }

        // POST: Direccion/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
