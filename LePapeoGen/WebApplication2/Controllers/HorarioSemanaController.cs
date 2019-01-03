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
    public class HorarioSemanaController : BasicController
    {
        // GET: HorarioSemana
        public ActionResult Index()
        {
            HorarioSemanaCEN semCEN = new HorarioSemanaCEN();
            IList<HorarioSemanaEN> listsemEN = semCEN.ReadAll(0, -1);
            IEnumerable<HorarioSemanaViewModel> listsem = new AssemblerHorarioSemana().ConvertListENToModel(listsemEN);

            return View(listsem);
        }

        // GET: HorarioSemana/Details/5
        public ActionResult Details(int id)
        {
            HorarioSemanaCEN HorarioSemanaCEN = new HorarioSemanaCEN();
            HorarioSemanaEN notiEN = HorarioSemanaCEN.ReadOID(id);
            HorarioSemanaViewModel notiVM = new AssemblerHorarioSemana().ConvertENToModelUI(notiEN);
            return View(notiVM);
        }

        // GET: HorarioSemana/Create
        public ActionResult Create()
        {
            HorarioSemanaViewModel sem = new HorarioSemanaViewModel();
            return View(sem);
        }

        // POST: HorarioSemana/Create
        [HttpPost]
        public ActionResult Create(HorarioSemanaViewModel sem)
        {
            try
            {
                // TODO: Add insert logic here

                HorarioSemanaCEN cen = new HorarioSemanaCEN();
                cen.New_();
                
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
            HorarioSemanaViewModel sem = null;
            SessionInitialize();
            HorarioSemanaEN semEN = new HorarioSemanaCAD(session).ReadOIDDefault(id);
            sem = new AssemblerHorarioSemana().ConvertENToModelUI(semEN);
            SessionClose();

            return View(sem);
        }

        // POST: HorarioSemana/Edit/5
        [HttpPost]
        public ActionResult Edit(HorarioSemanaViewModel sem)
        {
            try
            {
                // TODO: Add update logic here
                HorarioSemanaCEN cen = new HorarioSemanaCEN();
                cen.Modify(sem.Id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: HorarioSemana/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                SessionInitialize();
                HorarioSemanaCAD semCAD = new HorarioSemanaCAD(session);
                HorarioSemanaCEN cen = new HorarioSemanaCEN(semCAD);
                HorarioSemanaEN semEN = cen.ReadOID(id);
                HorarioSemanaViewModel sem = new AssemblerHorarioSemana().ConvertENToModelUI(semEN);

                SessionClose();

               
                return View(sem);
            }
            catch
            {
                //Meter aqui el mensaje de error
                return View();
            }
        }

        // POST: HorarioSemana/Delete/5
        [HttpPost]
        public ActionResult Delete(HorarioSemanaViewModel sem)
        {
            try
            {
                // TODO: Add delete logic here
                new HorarioSemanaCEN().Destroy(sem.Id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        // GET: HorarioDia/AgregarHorarioDia/5
        public ActionResult AgregarHorarioDia(int id)
        {
            //return View();
            //return RedirectToAction("Index");
            return Redirect("../../HorarioDia/Create2/" + id);
            //return RedirectToRoute(new RouteAreaAttribute("HorarioDia/Create"));
        }

    }
}
