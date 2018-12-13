﻿using LePapeo.Models;
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
    public class ReservaController : BasicController
    {
        // GET: Reserva
        public ActionResult Index()
        {
            ReservaCEN rescen = new ReservaCEN();
            IList<ReservaEN> resenlist = rescen.ReadAll(0, -1);
            IEnumerable<ReservaViewModel> resv = new AssemblerReserva().ConvertListENToModel(resenlist);
            return View(resv);
        }

        // GET: Reserva/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Reserva/Create
        public ActionResult Create()
        {
            ReservaViewModel v = new ReservaViewModel();
            return View(v);
        }

        // POST: Reserva/Create
        [HttpPost]
        public ActionResult Create(ReservaViewModel v)
        {
            try
            {
                // TODO: Add insert logic here
                ReservaCEN rescen = new ReservaCEN();
                rescen.New_(v.idusuario, v.idrestaurante, v.comensales, v.estado, v.finalizada, v.fecha_hora, v.fecha_solicitud);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Reserva/Edit/5
        public ActionResult Edit(int id)
        {
            SessionInitialize();
            ReservaEN resen = new ReservaCAD(session).ReadOID(id);
            ReservaViewModel resvi = new AssemblerReserva().ConvertENToModelUI(resen);
            SessionClose();
            return View(resvi);
        }

        // POST: Reserva/Edit/5
        [HttpPost]
        public ActionResult Edit(ReservaViewModel v)
        {
            try
            {
                // TODO: Add update logic here
                ReservaCEN rescen = new ReservaCEN();
                rescen.Modify(v.id, v.comensales, v.estado, v.finalizada, v.fecha_hora, v.fecha_solicitud);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Reserva/Delete/5
        public ActionResult Delete(int id)
        {
            SessionInitialize();
            ReservaCAD rescad = new ReservaCAD(session);
            ReservaCEN rescen = new ReservaCEN(rescad);
            ReservaEN resen = rescen.ReadOID(id);
            ReservaViewModel resview = new AssemblerReserva().ConvertENToModelUI(resen);
            SessionClose();
            return View(resen);
        }

        // POST: Reserva/Delete/5
        [HttpPost]
        public ActionResult Delete(ReservaViewModel view)
        {
            try
            {
                // TODO: Add delete logic here
                new ReservaCEN().Destroy(view.id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}