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
    public class ReservaController : BasicController
    {
        // GET: Reserva
        /*public ActionResult Index()
        {
            ReservaCEN rescen = new ReservaCEN();
            IList<ReservaEN> resenlist = rescen.ReadAll(0, -1);
            IEnumerable<ReservaViewModel> resv = new AssemblerReserva().ConvertListENToModel(resenlist);
            return View(resv);
        }*/


        public ActionResult Index()
        {
            //ReservaCEN rescen = new ReservaCEN();

            //IList<ReservaEN> listresFinalizadasEN;
            //IList<ReservaEN> listresNoFinalizadasEN;

            //UsuarioCEN usu = new UsuarioCEN();
            //int idd = usu.DgetOIDfromEmail(User.Identity.Name);
            //UsuarioEN usuen = usu.ReadOID(idd);
            ////Console.Write("\n"+idd+"\n");
            //if(usuen != null)
            //{
            //    String[] tipo = usuen.GetType().ToString().Split('.');

            //    if (tipo[tipo.Length - 1].Equals("RestauranteEN"))
            //    {
            //        listresFinalizadasEN = rescen.GetReservasFromRestauranteFinal(idd, true);
            //        listresNoFinalizadasEN = rescen.GetReservasFromRestauranteFinal(idd, false);
            //        //IEnumerable<ReservaViewModel> listres = new AssemblerReserva().ConvertListENToModel(listresFinalizadasEN);
            //        //IEnumerable<ReservaViewModel> listres2 = new AssemblerReserva().ConvertListENToModel(listresNoFinalizadasEN);


            //        ViewData["listaReservaFinalizadas"] = listresFinalizadasEN;
            //        ViewData["listaReservaNoFinalizadas"] = listresFinalizadasEN;

            //    }
            //    else if (tipo[tipo.Length - 1].Equals("RegistradoEN"))
            //    {
            //        listresFinalizadasEN = rescen.GetReservasFromRestauranteFinal(idd, true);
            //        listresNoFinalizadasEN = rescen.GetReservasFromRestauranteFinal(idd, false);

            //        ViewData["listaReservaFinalizadas"] = listresFinalizadasEN;
            //        ViewData["listaReservaNoFinalizadas"] = listresFinalizadasEN;
            //    }
            //    else if (tipo[tipo.Length - 1].Equals("AdminEN"))
            //    {
            //        listresFinalizadasEN = rescen.GetReservasFromRestauranteFinal(idd, true);
            //        listresNoFinalizadasEN = rescen.GetReservasFromRestauranteFinal(idd, false);

            //        ViewData["listaReservaFinalizadas"] = listresFinalizadasEN;
            //        ViewData["listaReservaNoFinalizadas"] = listresFinalizadasEN;
            //    }
            //}
            //else
            //{
            //    IList<ReservaEN> resenlist = rescen.ReadAll(0, -1);
            //    IEnumerable<ReservaViewModel> resv = new AssemblerReserva().ConvertListENToModel(resenlist);
            //    return View(resv);
            //}


            ReservaCEN ReservaCEN = new ReservaCEN();
            IList<ReservaEN> listResEN = ReservaCEN.ReadAll(0, -1);
            IEnumerable<ReservaViewModel> listres = new AssemblerReserva().ConvertListENToModel(listResEN);

            return View(listres);
            //return View(listres);
        }




        // GET: Reserva/Details/5
        public ActionResult Details(int id)
        {
            ReservaCEN rescen = new ReservaCEN();
            ReservaEN resen = rescen.ReadOID(id);
            ReservaViewModel vi = new AssemblerReserva().ConvertENToModelUI(resen);
            return View(vi);
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
            return View(resview);
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


        public ActionResult ReservasNoFinalizadas()
        {
            ReservaCEN rescen = new ReservaCEN();
            IList<ReservaEN> listresNoFinalizadasEN;
            UsuarioCEN usu = new UsuarioCEN();
            int idd = usu.DgetOIDfromEmail(User.Identity.Name);
            UsuarioEN usuen = usu.ReadOID(idd);
            //Console.Write("\n"+idd+"\n");
            if (usuen != null)
            {
                String[] tipo = usuen.GetType().ToString().Split('.');

                if (tipo[tipo.Length - 1].Equals("RestauranteEN"))
                {
                    listresNoFinalizadasEN = rescen.GetReservasFromRestauranteFinal(idd, false);
                    IEnumerable<ReservaViewModel> listresNoFinalizadas = new AssemblerReserva().ConvertListENToModel(listresNoFinalizadasEN);

                    return View(listresNoFinalizadas);

                }
                else if (tipo[tipo.Length - 1].Equals("RegistradoEN"))
                {
                    listresNoFinalizadasEN = rescen.GetReservasFromRegistradoFinal(idd, false);
                    IEnumerable<ReservaViewModel> listresNoFinalizadas = new AssemblerReserva().ConvertListENToModel(listresNoFinalizadasEN);

                    return View(listresNoFinalizadas);
                }
                else if (tipo[tipo.Length - 1].Equals("AdminEN"))
                {
                    IList<ReservaEN> resenlist = rescen.ReadAll(0, -1);
                    IEnumerable<ReservaViewModel> resv = new AssemblerReserva().ConvertListENToModel(resenlist);
                    return View(resv);
                }
            }
            else
            {
                IList<ReservaEN> resenlist = rescen.ReadAll(0, -1);
                IEnumerable<ReservaViewModel> resv = new AssemblerReserva().ConvertListENToModel(resenlist);
                return View(resv);
            }

            return View();
        }

        public ActionResult ReservasFinalizadas()
        {
            ReservaCEN rescen = new ReservaCEN();
            IList<ReservaEN> listresFinalizadasEN;
            UsuarioCEN usu = new UsuarioCEN();
            int idd = usu.DgetOIDfromEmail(User.Identity.Name);
            UsuarioEN usuen = usu.ReadOID(idd);
            //Console.Write("\n"+idd+"\n");
            if (usuen != null)
            {
                String[] tipo = usuen.GetType().ToString().Split('.');

                if (tipo[tipo.Length - 1].Equals("RestauranteEN"))
                {
                    listresFinalizadasEN = rescen.GetReservasFromRestauranteFinal(idd, true);
                    IEnumerable<ReservaViewModel> listres = new AssemblerReserva().ConvertListENToModel(listresFinalizadasEN);

                    return View(listres);

                }
                else if (tipo[tipo.Length - 1].Equals("RegistradoEN"))
                {
                    listresFinalizadasEN = rescen.GetReservasFromRegistradoFinal(idd, true);
                    IEnumerable<ReservaViewModel> listres = new AssemblerReserva().ConvertListENToModel(listresFinalizadasEN);

                    return View(listres);
                }
                else if (tipo[tipo.Length - 1].Equals("AdminEN"))
                {
                    IList<ReservaEN> resenlist = rescen.ReadAll(0, -1);
                    IEnumerable<ReservaViewModel> resv = new AssemblerReserva().ConvertListENToModel(resenlist);
                    return View(resv);
                }
            }
            else
            {
                IList<ReservaEN> resenlist = rescen.ReadAll(0, -1);
                IEnumerable<ReservaViewModel> resv = new AssemblerReserva().ConvertListENToModel(resenlist);
                return View(resv);
            }

            return View();

        }

    }
}
