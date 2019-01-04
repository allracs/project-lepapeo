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
    public class RegistradoController : BasicController
    {
        // GET: Registrado
        [Authorize(Users = "Admin@mail.com")]
        public ActionResult Index()
        {
            RegistradoCEN registradoCEN = new RegistradoCEN();
            IList<RegistradoEN> listregEN = registradoCEN.ReadAll(0, -1);
            IEnumerable<RegistradoViewModel> listreg = new AssemblerRegistrado().ConvertListENToModel(listregEN);

            return View(listreg);
        }

        // GET: Registrado/Details/5
        public ActionResult Details(int id)
        {
            RegistradoCEN RegistradoCEN = new RegistradoCEN();
            RegistradoEN reEN = RegistradoCEN.ReadOID(id);
            RegistradoViewModel reVM = new AssemblerRegistrado().ConvertENToModelUI(reEN);
            return View(reVM);
        }

        // GET: Registrado/Create
        public ActionResult Create()
        {
            RegistradoViewModel reg = new RegistradoViewModel();
            return View(reg);
        }

        // POST: Registrado/Create
        [HttpPost]
        public ActionResult Create(RegistradoViewModel reg)
        {
            try
            {
                // TODO: Add insert logic here

                RegistradoCEN cen = new RegistradoCEN();
                cen.New_(reg.Email, reg.Password, reg.FechaInscripcion, reg.Nombre, reg.Apellidos, reg.Fecha_nacimiento);
                
            

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Registrado/Edit/5
        public ActionResult Edit(int id)
        {
            RegistradoViewModel reg = null;
            SessionInitialize();
            RegistradoEN regEN = new RegistradoCAD(session).ReadOIDDefault(id);
            reg = new AssemblerRegistrado().ConvertENToModelUI(regEN);
            SessionClose();

            return View(reg);
        }

        // POST: Registrado/Edit/5
        [HttpPost]
        public ActionResult Edit(RegistradoViewModel reg)
        {
            try
            {
                // TODO: Add update logic here
                RegistradoCEN cen = new RegistradoCEN();
                cen.Modify(reg.id, reg.Email, reg.Password, reg.FechaInscripcion, reg.Nombre, reg.Apellidos, reg.Fecha_nacimiento);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Registrado/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                SessionInitialize();
                RegistradoCAD regCAD = new RegistradoCAD(session);
                RegistradoCEN cen = new RegistradoCEN(regCAD);
                RegistradoEN regEN = cen.ReadOID(id);
                RegistradoViewModel reg = new AssemblerRegistrado().ConvertENToModelUI(regEN);

                SessionClose();

               
                return View(reg);
            }
            catch
            {
                //Meter aqui el mensaje de error
                return View();
            }
        }

        // POST: Registrado/Delete/5
        [HttpPost]
        public ActionResult Delete(RegistradoViewModel reg)
        {
            try
            {
                // TODO: Add delete logic here
                new RegistradoCEN().Destroy(reg.id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
