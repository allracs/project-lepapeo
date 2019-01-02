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
    public class HorarioDiaController : BasicController
    {
        // GET: HorarioDia
        public ActionResult Index()
        {
            HorarioDiaCEN diaCEN = new HorarioDiaCEN();
            IList<HorarioDiaEN> listdiaEN = diaCEN.ReadAll(0, -1); 
            IEnumerable<HorarioDiaViewModel> listdia = new AssemblerHorarioDia().ConvertListENToModel(listdiaEN);

            return View(listdia);
        }

        // GET: Registrado/Details/5
        public ActionResult Details(int id) 
        {
            HorarioDiaCEN HorarioDiaCEN = new HorarioDiaCEN();
            HorarioDiaEN hdEN = HorarioDiaCEN.ReadOID(id);
            HorarioDiaViewModel hdVM = new AssemblerHorarioDia().ConvertENToModelUI(hdEN);
            return View(hdVM);
        }

        // GET: Registrado/Create
        public ActionResult Create() 
        {
            HorarioDiaViewModel dia = new HorarioDiaViewModel();
            return View(dia);
        }

        // POST: Registrado/Create
        [HttpPost]
        public ActionResult Create(HorarioDiaViewModel dia)
        {
            try
            {
                // TODO: Add insert logic here

                HorarioDiaCEN cen = new HorarioDiaCEN();
                cen.New_(dia.Hora_ini_am, dia.Hora_fin_am, dia.Hora_ini_pm, dia.Hora_fin_pm, dia.Dia, dia.HorarioSemana);
                
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
            HorarioDiaViewModel dia = null;
            SessionInitialize();
            HorarioDiaEN diaEN = new HorarioDiaCAD(session).ReadOIDDefault(id);
            dia = new AssemblerHorarioDia().ConvertENToModelUI(diaEN);
            SessionClose();

            return View(dia);
        }

        // POST: Registrado/Edit/5
        [HttpPost]
        public ActionResult Edit(HorarioDiaViewModel dia) 
        {
            try
            {
                // TODO: Add update logic here
                HorarioDiaCEN cen = new HorarioDiaCEN();
                cen.Modify(dia.id, dia.Hora_ini_am, dia.Hora_fin_am, dia.Hora_ini_pm, dia.Hora_fin_pm, dia.Dia);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: HorarioDia/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                SessionInitialize();
                HorarioDiaCAD diaCAD = new HorarioDiaCAD(session);
                HorarioDiaCEN cen = new HorarioDiaCEN(diaCAD);
                HorarioDiaEN diaEN = cen.ReadOID(id);
                HorarioDiaViewModel dia = new AssemblerHorarioDia().ConvertENToModelUI(diaEN);

                SessionClose();

               
                return View(dia);
            }
            catch
            {
                //Meter aqui el mensaje de error
                return View();
            }
        }

        // POST: HorarioDia/Delete/5
        [HttpPost]
        public ActionResult Delete(HorarioDiaViewModel dia)
        {
            try
            {
                // TODO: Add delete logic here
                new HorarioDiaCEN().Destroy(dia.id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
