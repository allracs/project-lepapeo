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
    public class NotificacionGenericaController : BasicController
    {
        // GET: Registrado
       
        public ActionResult Index()
        {
            UsuarioCEN usu = new UsuarioCEN();
            int idd = usu.DgetOIDfromEmail(User.Identity.Name);
            UsuarioEN usuen = usu.ReadOID(idd);
            if (usuen != null)
            {
                String[] tipo = usuen.GetType().ToString().Split('.');
                if (!tipo[tipo.Length - 1].Equals("AdminEN")) return RedirectToAction("Index", "Home");


                NotificacionGenericaCEN NotificacionGenericaCEN = new NotificacionGenericaCEN();
                IList<NotificacionGenericaEN> listNotigeEN = NotificacionGenericaCEN.ReadAll(0, -1);
                IEnumerable<NotificacionGenericaViewModel> listreg = new AssemblerNotificacionGenerica().ConvertListENToModel(listNotigeEN);

                return View(listreg);
            }

            return RedirectToAction("Index", "Home");
        }

        // GET: Registrado/Details/5
        public ActionResult Details(int id)
        {
            NotificacionGenericaCEN NotificacionGenericaCEN = new NotificacionGenericaCEN();
            NotificacionGenericaEN notiEN = NotificacionGenericaCEN.ReadOID(id);
            NotificacionGenericaViewModel notiVM = new AssemblerNotificacionGenerica().ConvertENToModelUI(notiEN);
            return View(notiVM);
        }

        // GET: Registrado/Create
        public ActionResult Create()
        {
            NotificacionGenericaViewModel notige = new NotificacionGenericaViewModel();
            return View(notige);
        }

        // POST: Registrado/Create
        [HttpPost]
        public ActionResult Create(NotificacionGenericaViewModel notige)
        {
            try
            {
                // TODO: Add insert logic here

                NotificacionGenericaCEN cen = new NotificacionGenericaCEN();
                cen.New_(notige.Tipo, notige.Texto, notige.Nombre); 

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
            NotificacionGenericaViewModel notige = null;
            SessionInitialize();
            NotificacionGenericaEN notiEN = new NotificacionGenericaCAD(session).ReadOIDDefault(id);
            notige = new AssemblerNotificacionGenerica().ConvertENToModelUI(notiEN);
            SessionClose();

            return View(notige);
        }

        // POST: Registrado/Edit/5
        [HttpPost]
        public ActionResult Edit(NotificacionGenericaViewModel notige)
        {
            try
            {
                // TODO: Add update logic here
                NotificacionGenericaCEN cen = new NotificacionGenericaCEN();
                cen.Modify(notige.Id, notige.Tipo, notige.Texto, notige.Nombre);

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
                NotificacionGenericaCAD notigeCAD = new NotificacionGenericaCAD(session);
                NotificacionGenericaCEN cen = new NotificacionGenericaCEN(notigeCAD);
                NotificacionGenericaEN notigeEN = cen.ReadOID(id);
                NotificacionGenericaViewModel notige = new AssemblerNotificacionGenerica().ConvertENToModelUI(notigeEN);

                SessionClose();


                return View(notige);
            }
            catch
            {
                //Meter aqui el mensaje de error
                return View();
            }
        }

        // POST: Registrado/Delete/5
        [HttpPost]
        public ActionResult Delete(NotificacionGenericaViewModel notige)
        {
            try
            {
                // TODO: Add delete logic here
                new NotificacionGenericaCEN().Destroy(notige.Id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
