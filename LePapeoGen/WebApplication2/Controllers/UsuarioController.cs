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
    public class UsuarioController : BasicController
    {
        // GET: Usuario
      
        public ActionResult Index()
        {

            UsuarioCEN usu2 = new UsuarioCEN();
            int idd = usu2.DgetOIDfromEmail(User.Identity.Name);
            UsuarioEN usuen = usu2.ReadOID(idd);
            if (usuen != null)
            {
                String[] tipo = usuen.GetType().ToString().Split('.');
                if (!tipo[tipo.Length - 1].Equals("AdminEN")) return RedirectToAction("Index", "Home");
                UsuarioCEN usu = new UsuarioCEN();
                IList<UsuarioEN> listusuEN = usu.ReadAll(0, -1);
                IEnumerable<UsuarioViewModel> listusu = new AssemblerUsuario().ConvertListENToModel(listusuEN);
                return View(listusu);
            }
            return RedirectToAction("Index", "Home");
        }

        // GET: Usuario/Details/5
        public ActionResult Details(int id)
        {
            UsuarioCEN UsuarioCEN = new UsuarioCEN();
            UsuarioEN uEN = UsuarioCEN.ReadOID(id);
            UsuarioViewModel uVM = new AssemblerUsuario().ConvertENToModelUI(uEN);
            return View(uVM);
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
           UsuarioViewModel usu = new UsuarioViewModel();

            return View(usu);
        }

        // POST: Usuario/Create
        [HttpPost]
        public ActionResult Create(UsuarioViewModel usu)
        {
            try
            {
                // TODO: Add insert logic here
                //  SessionInitialize();
                // UsuarioCAD usuCAD = new UsuarioCAD(/*session*/);
                //  usuCAD.New_(usuEN);
                //  SessionClose(); 
                UsuarioCEN cen = new UsuarioCEN();
                cen.New_(usu.Email, usu.Password, usu.FechaInscripcion);
                return RedirectToAction("RegisterUsuario", "Account", usu);
                //return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int id)
        {
            UsuarioViewModel usu = null;
            SessionInitialize();
            UsuarioEN usuEN = new UsuarioCAD(session).ReadOIDDefault(id);
            usu = new AssemblerUsuario().ConvertENToModelUI(usuEN);
            SessionClose();

            return View(usu);
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        public ActionResult Edit(UsuarioViewModel usu)
        {
            try
            {
                // TODO: Add update logic here
                UsuarioCEN cen = new UsuarioCEN();
                cen.Modify(usu.id, usu.Email, usu.Password, usu.FechaInscripcion);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                SessionInitialize();
                UsuarioCAD usuCAD = new UsuarioCAD(session);
                UsuarioCEN cen = new UsuarioCEN(usuCAD);
                UsuarioEN usuEN = cen.ReadOID(id);
                UsuarioViewModel usu = new AssemblerUsuario().ConvertENToModelUI(usuEN);

                SessionClose();

                return View(usu);
            }
            catch{
                return View();
            }
        }

        // POST: Usuario/Delete/5
        [HttpPost]
        public ActionResult Delete(UsuarioViewModel usu)
        {
            try
            {
                // TODO: Add delete logic here
                new UsuarioCEN().Destroy(usu.id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
