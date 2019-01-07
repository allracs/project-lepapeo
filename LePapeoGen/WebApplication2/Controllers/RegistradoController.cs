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
        
        public ActionResult Index()
        {

            UsuarioCEN usu = new UsuarioCEN();
            int idd = usu.DgetOIDfromEmail(User.Identity.Name);
            UsuarioEN usuen = usu.ReadOID(idd);
            if (usuen != null)
            {
                String[] tipo = usuen.GetType().ToString().Split('.');
                if (!tipo[tipo.Length - 1].Equals("AdminEN")) return RedirectToAction("Index", "Home");

                RegistradoCEN registradoCEN = new RegistradoCEN();
                IList<RegistradoEN> listregEN = registradoCEN.ReadAll(0, -1);
                IEnumerable<RegistradoViewModel> listreg = new AssemblerRegistrado().ConvertListENToModel(listregEN);

                return View(listreg);
            }
            return RedirectToAction("Index", "Home");
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


                return RedirectToAction("RegisterRegistrado", "Account", reg);
                //return RedirectToAction("Index");
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


        // GET: Registrado/MiPerfil
        public ActionResult MiPerfil()
        {
            UsuarioCEN usu = new UsuarioCEN();
            int idd = usu.DgetOIDfromEmail(User.Identity.Name);
            RegistradoEN regEN = new RegistradoCAD(session).ReadOIDDefault(idd);

            ViewData["regEN"] = regEN;

            return View();
        }

        // GET: Registrado/MisDatos
        public ActionResult MisDatos()
        {
            UsuarioCEN usu = new UsuarioCEN();
            int idd = usu.DgetOIDfromEmail(User.Identity.Name);

            RegistradoViewModel reg = null;
            SessionInitialize();
            RegistradoEN regEN = new RegistradoCAD(session).ReadOIDDefault(idd);
            reg = new AssemblerRegistrado().ConvertENToModelUI(regEN);
            SessionClose();

            return View(reg);
        }

        // POST: Registrado/Misdatos
        [HttpPost]
        public ActionResult MisDatos(RegistradoViewModel reg)
        {
            try
            {

                UsuarioCEN usu = new UsuarioCEN();
                int idd = usu.DgetOIDfromEmail(User.Identity.Name);

                RegistradoCEN pre = new RegistradoCEN();
                RegistradoEN preEN = pre.ReadOID(idd);


                // TODO: Add update logic here
                RegistradoCEN cen = new RegistradoCEN();
                //cen.Modify(reg.id, reg.Email, reg.Password, reg.FechaInscripcion, reg.Nombre, reg.Apellidos, reg.Fecha_nacimiento);
                cen.Modify(idd, reg.Email, preEN.Pass, reg.FechaInscripcion, reg.Nombre, reg.Apellidos, reg.Fecha_nacimiento);

                return RedirectToAction("MisDatos");
            }
            catch
            {
                return View();
            }
        }

        // GET: Registrado/CambioPass
        public ActionResult CambioPass()
        {
            return View();
        }

        // GET: Registrado/ReservasProximas
        public ActionResult ReservasProximas()
        {
            ReservaCEN rescen = new ReservaCEN();

            //IList<ReservaEN> listresFinalizadasEN;
            IList<ReservaEN> listresNoFinalizadasEN;

            UsuarioCEN usu = new UsuarioCEN();
            int idd = usu.DgetOIDfromEmail(User.Identity.Name);
            UsuarioEN usuen = usu.ReadOID(idd);

            RestauranteCEN resview = new RestauranteCEN();
            ViewData["resview"] = resview;

            //Console.Write("\n"+idd+"\n");
            String[] tipo = usuen.GetType().ToString().Split('.');
            if (tipo[tipo.Length - 1].Equals("RestauranteEN"))
            {
                //listresFinalizadasEN = rescen.GetReservasFromRestauranteFinal(1048576, true);
                listresNoFinalizadasEN = rescen.GetReservasFromRestauranteFinal(idd, false);
                //IEnumerable<ReservaViewModel> listres = new AssemblerReserva().ConvertListENToModel(listresFinalizadasEN);
                IEnumerable<ReservaViewModel> listres2 = new AssemblerReserva().ConvertListENToModel(listresNoFinalizadasEN);
                return View(listres2);
            }
            else if (tipo[tipo.Length - 1].Equals("RegistradoEN"))
            {
                //listresFinalizadasEN = rescen.GetReservasFromRestauranteFinal(1048576, true);
                listresNoFinalizadasEN = rescen.GetReservasFromRegistradoFinal(idd, false);
                //IEnumerable<ReservaViewModel> listres = new AssemblerReserva().ConvertListENToModel(listresFinalizadasEN);
                IEnumerable<ReservaViewModel> listres2 = new AssemblerReserva().ConvertListENToModel(listresNoFinalizadasEN);
                return View(listres2);
            }

            return View();
            //return View(listres);
        }

        // GET: Registrado/ReservasAnteriores
        public ActionResult ReservasAnteriores()
        {
            ReservaCEN rescen = new ReservaCEN();

            IList<ReservaEN> listresFinalizadasEN;
            IList<ReservaEN> listresNoFinalizadasEN;

            UsuarioCEN usu = new UsuarioCEN();
            int idd = usu.DgetOIDfromEmail(User.Identity.Name);
            UsuarioEN usuen = usu.ReadOID(idd);
            //Console.Write("\n" + idd + "\n");
            String[] tipo = usuen.GetType().ToString().Split('.');

            RestauranteCEN resview = new RestauranteCEN();
            ViewData["resview"] = resview;

            if (tipo[tipo.Length - 1].Equals("RestauranteEN"))
            {
                listresFinalizadasEN = rescen.GetReservasFromRestauranteFinal(idd, true);
                listresNoFinalizadasEN = rescen.GetReservasFromRestauranteFinal(idd, false);
                IEnumerable<ReservaViewModel> listres = new AssemblerReserva().ConvertListENToModel(listresFinalizadasEN);
                //IEnumerable<ReservaViewModel> listres2 = new AssemblerReserva().ConvertListENToModel(listresNoFinalizadasEN);
                return View(listres);
            }
            else if (tipo[tipo.Length - 1].Equals("RegistradoEN"))
            {
                listresFinalizadasEN = rescen.GetReservasFromRegistradoFinal(idd, true);
                listresNoFinalizadasEN = rescen.GetReservasFromRegistradoFinal(idd, false);
                IEnumerable<ReservaViewModel> listres = new AssemblerReserva().ConvertListENToModel(listresFinalizadasEN);
                //IEnumerable<ReservaViewModel> listres2 = new AssemblerReserva().ConvertListENToModel(listresNoFinalizadasEN);
                //ViewData["listEN"] = listres;
                return View(listres);
            }

            return View();
            //return View(listres);
        }

        // GET: Registrado/MisOpiniones
        public ActionResult MisOpiniones()
        {
            OpinionCEN opicen = new OpinionCEN();

            IList<OpinionEN> listresOpinionEN;

            UsuarioCEN usu = new UsuarioCEN();
            int idd = usu.DgetOIDfromEmail(User.Identity.Name);
            UsuarioEN usuen = usu.ReadOID(idd);
            //Console.Write("\n"+idd+"\n");

            RestauranteCEN resview = new RestauranteCEN();
            ViewData["resview"] = resview;

            String[] tipo = usuen.GetType().ToString().Split('.');
            if (tipo[tipo.Length - 1].Equals("RestauranteEN"))
            {
                listresOpinionEN = opicen.GetOpinionsFromRestaurante(idd);
                //listresNoFinalizadasEN = rescen.GetReservasFromRestauranteFinal(1048576, false);
                IEnumerable<OpinionViewModel> listres = new AssemblerOpinion().ConvertListENToModel(listresOpinionEN);
                //IEnumerable<ReservaViewModel> listres2 = new AssemblerReserva().ConvertListENToModel(listresNoFinalizadasEN);
                return View(listres);
            }
            else if (tipo[tipo.Length - 1].Equals("RegistradoEN"))
            {
                listresOpinionEN = opicen.GetOpinionsFromRegistrado(idd);
                //listresNoFinalizadasEN = rescen.GetReservasFromRegistradoFinal(1048576, false);
                IEnumerable<OpinionViewModel> listres = new AssemblerOpinion().ConvertListENToModel(listresOpinionEN);
                //IEnumerable<ReservaViewModel> listres2 = new AssemblerReserva().ConvertListENToModel(listresNoFinalizadasEN);
                return View(listres);
            }

            return View();
            //return View(listres);
        }

        // GET: Registrado/EliminarCuenta
        public ActionResult EliminarCuenta()
        {
            try
            {

                UsuarioCEN usu = new UsuarioCEN();
                int idd = usu.DgetOIDfromEmail(User.Identity.Name);

                SessionInitialize();
                RegistradoCAD regCAD = new RegistradoCAD(session);
                RegistradoCEN cen = new RegistradoCEN(regCAD);
                RegistradoEN regEN = cen.ReadOID(idd);
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

        // POST: Registrado/EliminarCuenta
        [HttpPost]
        public ActionResult EliminarCuenta(RegistradoViewModel reg)
        {
            try
            {

                UsuarioCEN usu = new UsuarioCEN();
                int idd = usu.DgetOIDfromEmail(User.Identity.Name);

                // TODO: Add delete logic here
                new RegistradoCEN().Destroy(idd);

                //Cerrar la sesion y borrar en la base de ASP.NET tambien (?)

                return RedirectToAction("../");
            }
            catch
            {
                return View();
            }
        }


        // GET: Registrado/MisNotificaciones
        public ActionResult MisNotificaciones()
        {
            NotificacionCEN notcen = new NotificacionCEN();

            //IList<ReservaEN> listresFinalizadasEN;
            IList<NotificacionEN> listresNoFinalizadasEN;

            UsuarioCEN usu = new UsuarioCEN();
            int idd = usu.DgetOIDfromEmail(User.Identity.Name);
            UsuarioEN usuen = usu.ReadOID(idd);

            RestauranteCEN resview = new RestauranteCEN();
            ViewData["resview"] = resview;

            //Console.Write("\n"+idd+"\n");
            String[] tipo = usuen.GetType().ToString().Split('.');
            if (tipo[tipo.Length - 1].Equals("RestauranteEN"))
            {
                //listresFinalizadasEN = rescen.GetReservasFromRestauranteFinal(1048576, true);
                listresNoFinalizadasEN = notcen.ReadAll(0, -1);

                IList<NotificacionEN> auxNotEN = notcen.ReadAll(0, -1);
                foreach (NotificacionEN e in listresNoFinalizadasEN)
                {
                    try
                    {
                        if (e.Usuario.Id != idd)
                        {
                            auxNotEN.Remove(e);
                        }
                    }
                    catch { }
                }

                //IEnumerable<ReservaViewModel> listres = new AssemblerReserva().ConvertListENToModel(listresFinalizadasEN);
                IEnumerable<NotificacionViewModel> listres2 = new AssemblerNotificacion().ConvertListENToModel(auxNotEN);
                return View(listres2);
            }
            else if (tipo[tipo.Length - 1].Equals("RegistradoEN"))
            {
                //listresFinalizadasEN = rescen.GetReservasFromRestauranteFinal(1048576, true);
                listresNoFinalizadasEN = notcen.ReadAll(0, -1);

                IList<NotificacionEN> auxNotEN = notcen.ReadAll(0, -1);
                foreach (NotificacionEN e in listresNoFinalizadasEN)
                {
                    try
                    {
                        if (e.Usuario.Id != idd)
                        {
                            auxNotEN.Remove(e);
                        }
                    }
                    catch { }
                }

                //IEnumerable<ReservaViewModel> listres = new AssemblerReserva().ConvertListENToModel(listresFinalizadasEN);
                IEnumerable<NotificacionViewModel> listres2 = new AssemblerNotificacion().ConvertListENToModel(auxNotEN);
                return View(listres2);
            }

            return View();
            //return View(listres);
        }

        // GET: Registrado/VistoNotificacion/5
        public ActionResult VistoNotificacion(int id)
        {
            NotificacionCEN notCEN = new NotificacionCEN();

            NotificacionEN notEN = notCEN.ReadOID(id);

            bool env = !notEN.Enviada;

            notCEN.Modify(notEN.Id, notEN.Contenido, notEN.Fecha, env);

            return RedirectToAction("MisNotificaciones");
        }

        // GET: Registrado/AccionNotificacion/5
        public ActionResult AccionNotificacion(int id)
        {
            NotificacionCEN notCEN = new NotificacionCEN();

            NotificacionEN notEN = notCEN.ReadOID(id);

            NotificacionGenericaCEN notgenCEN = new NotificacionGenericaCEN();

            //if (notEN.NotificacionGenerica.Tipo.ToString.Equals("1") || notEN.NotificacionGenerica.Tipo.ToString == "ReservaAceptada") 1 = 1; //Dependiendo del tipo de notificacion te lleva a un sitio o a otro
            if (notEN.NotificacionGenerica.Tipo.ToString() == "8") return RedirectToAction("EliminarCuenta");
            //notgenCEN.ReadOID(notEN.NotificacionGenerica);
            if (notEN.NotificacionGenerica.Tipo.ToString() == "nuevaOpinion") return RedirectToAction("MisOpiniones");
            return View();
        }

    }
}
