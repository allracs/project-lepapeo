using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LePapeo.Models;
using LePapeoGenNHibernate.CAD.LePapeo;
using LePapeoGenNHibernate.CEN.LePapeo;
using LePapeoGenNHibernate.EN.LePapeo;


namespace WEBLEPAPEO.Controllers
{
    public class AdminController : BasicController
    {
        // GET: Admin
        public ActionResult Index()
        {
            /*AdminCEN adminCEN = new AdminCEN();
            IEnumerable<AdminEN> listaAdminEN = adminCEN.ReadAll(0, -1).ToList(); //0 posicion inicial y -1 todos los elementos/infinito
            return View(listaAdminEN);
            */

            //return View();

            AdminCEN adminCEN = new AdminCEN();
            IList<AdminEN> listadminEN = adminCEN.ReadAll(0, -1);
            IEnumerable<AdminViewModel> listadmin = new AssemblerAdmin().ConvertListENToModel(listadminEN);
            return View(listadmin);
        }

        // GET: Admin/Details/5
        public ActionResult Details(int id)
        {
            AdminViewModel admin = null;
            SessionInitialize();
            AdminEN adminEN = new AdminCAD(session).ReadOIDDefault(id);
            admin = new AssemblerAdmin().ConvertENToModelUI(adminEN);
            SessionClose();
            return View(adminEN); //supuestamente deberia de ser return View(admin);
            //return View();
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            //AdminEN adminEN = new AdminEN();

            //return View(adminEN);

            AdminViewModel admin = new AdminViewModel();

            return View(admin);

        }

        // POST: Admin/Create
        [HttpPost]
        public ActionResult Create(AdminViewModel admin)//FormCollection collection || AdminEN adminEN
        {
            try
            {
                // TODO: Add insert logic here
                /*SessionInitialize();
                AdminCAD adminCAD = new AdminCAD();
                adminCAD.New_(adminEN);
                SessionClose();*/

                AdminCEN cen = new AdminCEN();
                cen.New_(admin.Email, admin.Password, admin.FechaInscripcion);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
            AdminViewModel admin = null;
            SessionInitialize();
            AdminEN adminEN = new AdminCAD(session).ReadOIDDefault(id);
            admin = new AssemblerAdmin().ConvertENToModelUI(adminEN);

            SessionClose();
            return View(admin); //supuestamente deberia de ser return View(admin);
            //return View();
        }

        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult Edit(AdminViewModel admin)//int id, FormCollection collection || AdminViewModel admin || AdminEN adminEN
        {
            try
            {
                /*
                AdminViewModel admin = new AssemblerAdmin().ConvertENToModelUI(adminEN);
                AdminCEN adminCEN = new AdminCEN();
                adminCEN.Modify(admin.id, admin.Email, admin.Password, admin.FechaInscripcion); //Utils.Util.GetEncondeMD5 (p_pass); || LePapeoGenNHibernate.Utils.Util.GetEncondeMD5(admin.p_pass)
                //return View();
                return RedirectToAction("Index");
                */

                AdminCEN pre = new AdminCEN();
                AdminEN preEN = pre.ReadOID(admin.id);

                // TODO: Add update logic here
                AdminCEN cen = new AdminCEN();
                cen.Modify(admin.id, admin.Email, preEN.Pass, admin.FechaInscripcion);

                return RedirectToAction("Index");



                /*
                SessionInitialize();
                AdminCAD adminCAD = new AdminCAD(session);
                AdminCEN adminCEN = new AdminCEN();
                adminCEN.Modify(admin.id, admin.email, admin.p_pass, admin.p_fecha_inscripcion);
                SessionClose();
                return View();
                */

                //return RedirectToAction("PorCategoria", new { id = art.IdCategoria });
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {

            try
            {
                // TODO: Add delete logic here
                //int idCategoria = -1;
                SessionInitialize();
                AdminCAD adminCAD = new AdminCAD(session);
                AdminCEN adminCEN = new AdminCEN(adminCAD);
                AdminEN adminEN = adminCEN.ReadOID(id);
                AdminViewModel art = new AssemblerAdmin().ConvertENToModelUI(adminEN);
                //idCategoria = art.IdCategoria;
                SessionClose();

                new AdminCEN().Destroy(id);


                //return RedirectToAction("PorCategoria", new { id = idCategoria });
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

            //return View();
        }

        // POST: Admin/Delete/5
        [HttpPost]
        public ActionResult Delete(AdminViewModel admin)
        {
            try
            {
                // TODO: Add delete logic here
                new AdminCEN().Destroy(admin.id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
