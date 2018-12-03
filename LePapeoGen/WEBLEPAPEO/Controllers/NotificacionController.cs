using LePapeoGenNHibernate.CAD.LePapeo;
using LePapeoGenNHibernate.CEN.LePapeo;
using LePapeoGenNHibernate.EN.LePapeo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LePapeo.Models;

namespace WEBLEPAPEO.Controllers
{
    public class NotificacionController : BasicController
    {
        // GET: Notificacion
        public ActionResult Index()
        {
            NotificacionCEN noti = new NotificacionCEN();
            IEnumerable<NotificacionEN> listnotiEN = noti.ReadAll(0, -1).ToList();
            return View(listnotiEN);
        }

        // GET: Notificacion/Details/5
        public ActionResult Details(int id)
        {
            NotificacionViewModel noti = null;
            SessionInitialize();
            NotificacionEN notiEN = new NotificacionCAD(session).ReadOIDDefault(id);
            noti = new AssemblerNotificacion().ConvertENToModelUI(notiEN);
            SessionClose();
            return View(notiEN); //supuestamente deberia de ser return View(admin);
            //return View();
        }

        // GET: Notificacion/Create
        public ActionResult Create()
        {
            NotificacionCEN notiEN = new NotificacionCEN();
            return View(notiEN);
        }

        // POST: Notificacion/Create
        [HttpPost]
        public ActionResult Create(NotificacionEN notiEN)
        {
            try
            {
                // TODO: Add insert logic here
                //SessionInitialize();
                NotificacionCAD notiCAD = new NotificacionCAD(/*session*/);
                notiCAD.New_(notiEN);
                //SessionClose();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Notificacion/Edit/5
        public ActionResult Edit(int id)
        {
            NotificacionViewModel noti = null;
            SessionInitialize();
            NotificacionEN notiEN = new NotificacionCAD(session).ReadOIDDefault(id);
            noti = new AssemblerNotificacion().ConvertENToModelUI(notiEN);
            SessionClose();
            return View(notiEN); //supuestamente deberia de ser return View(admin);
            //return View();
        }

        // POST: Notificacion/Edit/5
        [HttpPost]
        public ActionResult Edit(NotificacionEN notiEN)
        {
            try
            {
                // TODO: Add update logic here

                NotificacionViewModel noti = new AssemblerNotificacion().ConvertENToModelUI(notiEN);
                NotificacionCEN notiCEN = new NotificacionCEN();
                notiCEN.Modify(noti.id, noti.contenido, noti.fecha, noti.enviada); //Utils.Util.GetEncondeMD5 (p_pass); || LePapeoGenNHibernate.Utils.Util.GetEncondeMD5(admin.p_pass)
                //return View();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Notificacion/Delete/5
        public ActionResult Delete(int id)
        {
            //int idCategoria = -1;
            SessionInitialize();
            NotificacionCAD notiCAD = new NotificacionCAD(session);
            NotificacionCEN notiCEN = new NotificacionCEN(notiCAD);
            NotificacionEN notiEN = notiCEN.ReadOID(id);
            NotificacionViewModel notiVM = new AssemblerNotificacion().ConvertENToModelUI(notiEN);
            //idCategoria = art.IdCategoria;
            SessionClose();

            new AdminCEN().Destroy(id);


            //return RedirectToAction("PorCategoria", new { id = idCategoria });
            return RedirectToAction("Index");
        }

        // POST: Notificacion/Delete/5
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
