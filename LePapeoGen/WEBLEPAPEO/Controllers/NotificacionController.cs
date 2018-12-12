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
    public class NotificacionController : BasicController
    {
        // GET: Registrado
        public ActionResult Index()
        {
            NotificacionCEN NotificacionCEN = new NotificacionCEN();
            IList<NotificacionEN> listNotiEN = NotificacionCEN.ReadAll(0, -1);
            IEnumerable<NotificacionViewModel> listreg = new AssemblerNotificacion().ConvertListENToModel(listNotiEN);

            return View(listreg);
        }

        // GET: Registrado/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Registrado/Create
        public ActionResult Create()
        {
            NotificacionViewModel noti = new NotificacionViewModel();
            return View(noti);
        }

        // POST: Registrado/Create
        [HttpPost]
        public ActionResult Create(NotificacionViewModel noti)
        {
            try
            {
                // TODO: Add insert logic here

                NotificacionCEN cen = new NotificacionCEN();
                cen.New_(noti.contenido, noti.notificacionGenerica.Id, noti.fecha, noti.enviada);

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
            NotificacionViewModel noti = null;
            SessionInitialize();
            NotificacionEN notiEN = new NotificacionCAD(session).ReadOIDDefault(id);
            noti = new AssemblerNotificacion().ConvertENToModelUI(notiEN);
            SessionClose();

            return View(noti);
        }

        // POST: Registrado/Edit/5
        [HttpPost]
        public ActionResult Edit(NotificacionViewModel noti)
        {
            try
            {
                // TODO: Add update logic here
                NotificacionCEN cen = new NotificacionCEN();
                cen.Modify(noti.id, noti.contenido, noti.fecha, noti.enviada);

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
                NotificacionCAD notiCAD = new NotificacionCAD(session);
                NotificacionCEN cen = new NotificacionCEN(notiCAD);
                NotificacionEN notiEN = cen.ReadOID(id);
                NotificacionViewModel noti = new AssemblerNotificacion().ConvertENToModelUI(notiEN);

                SessionClose();

               
                return View(noti);
            }
            catch
            {
                //Meter aqui el mensaje de error
                return View();
            }
        }

        // POST: Registrado/Delete/5
        [HttpPost]
        public ActionResult Delete(NotificacionViewModel noti)
        {
            try
            {
                // TODO: Add delete logic here
                new NotificacionCEN().Destroy(noti.id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
