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
            return View(listd);
        }

        // GET: Direccion/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Direccion/Create
        public ActionResult Create()
        {
            DireccionCEN dir = new DireccionCEN();
            return View(dir);
        }

        // POST: Direccion/Create
        [HttpPost]
        public ActionResult Create(DireccionViewModel dir)
        {
            try
            {
                // TODO: Add insert logic here
                //  SessionInitialize();
                //  UsuarioCAD usuCAD = new UsuarioCAD(/*session*/);
                //  usuCAD.New_(usuEN);
                //  SessionClose(); 
                /*
                DireccionCEN dircen = new DireccionCEN();
                CiudadCAD ciudad = new CiudadCAD();
                IList<CiudadEN> listciu = ciudad.ReadAll(0, -1);
                
                dircen.New_(dirvm.cod_pos, dirvm.calle, dirvm.numero_puerta, dirvm.pos_x, dirvm.pos_y, dirvm.ciudad.Nombre);

                bool exist = false;
                foreach (CiudadEN ciu in listciu)
                {
                    if (ciu.Nombre.Equals(dirvm.ciudad))
                    {
                        exist = true;
                        break;
                    }
                }
                CiudadCEN ciucen;
                if (!exist)
                {
                    ciucen = new CiudadCEN();
                    ciucen.New_(dirvm.ciudad.Nombre, dirvm.ciudad.Provincia);
                }
                */

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
