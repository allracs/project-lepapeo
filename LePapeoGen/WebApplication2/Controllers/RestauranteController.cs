using WEBLEPAPEO.Models;
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
    public class RestauranteController : BasicController
    {
        // GET: Restaurante
       
        public ActionResult Index()
        {
            UsuarioCEN usu = new UsuarioCEN();
            int idd = usu.DgetOIDfromEmail(User.Identity.Name);
            UsuarioEN usuen = usu.ReadOID(idd);
            if (usuen != null)
            {
                String[] tipo = usuen.GetType().ToString().Split('.');
                if (!tipo[tipo.Length - 1].Equals("AdminEN")) return RedirectToAction("Index", "Home");

                RestauranteCEN restauranteCEN = new RestauranteCEN();
                IList<RestauranteEN> listresEN = restauranteCEN.ReadAll(0, -1);
                IEnumerable<RestauranteViewModel> listres = new AssemblerRestaurante().ConvertListENToModel(listresEN);
                return View(listres);
            }
            return RedirectToAction("Index", "Home");
        }

        // GET: Restaurante/Details/5
        public ActionResult Details(int id)
        {
            RestauranteViewModel res = null;
            SessionInitialize();
            RestauranteEN resEN = new RestauranteCAD(session).ReadOIDDefault(id);
            res = new AssemblerRestaurante().ConvertENToModelUI(resEN);
            SessionClose();
            return View(res);
        }

        public ActionResult Details2(int id)
        {
            RestauranteViewModel res = null;
            SessionInitialize();
            RestauranteEN resEN = new RestauranteCAD(session).ReadOIDDefault(id);
            res = new AssemblerRestaurante().ConvertENToModelUI(resEN);
            SessionClose();
            return View(res);
        }

        // GET: Restaurante/Create
        public ActionResult Create()
        {
            RestauranteViewModel res = new RestauranteViewModel();

            TipoCocinaCEN tipoCocinaCEN = new TipoCocinaCEN();
            IList<TipoCocinaEN> listaTipoCocina = tipoCocinaCEN.ReadAll(0, -1);
            ViewData["listaTipoCocina"] = listaTipoCocina;

            
            return View(res);
        }

        // POST: Restaurante/Create
        [HttpPost]
        public ActionResult Create(RestauranteViewModel res) //RestauranteEN resEN
        {
            try
            {
                RestauranteCEN cen = new RestauranteCEN();
                cen.New_(res.Email, res.Pass, res.Fecha_inscripcion, res.Nombre, res.Fecha_apertura, res.Tipo, res.Max_comen, res.Current_comen, res.Precio_medio, res.Descripcion, res.Menu);

                return RedirectToAction("RegisterRestaurant", "Account",res);
               // return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Restaurante/Edit/5
        public ActionResult Edit(int id)
        {
            RestauranteViewModel res = null;
            SessionInitialize();

            TipoCocinaCEN tipoCocinaCEN = new TipoCocinaCEN();
            IList<TipoCocinaEN> listaTipoCocina = tipoCocinaCEN.ReadAll(0, -1);
            ViewData["listaTipoCocina"] = listaTipoCocina;

            RestauranteEN resEN = new RestauranteCAD(session).ReadOIDDefault(id);
            res = new AssemblerRestaurante().ConvertENToModelUI(resEN);
            SessionClose();

            return View(res);
        }

        // POST: Restaurante/Edit/5
        [HttpPost]
        public ActionResult Edit(RestauranteViewModel res) //Restaurante res
        {
            try
            {
                // TODO: Add update logic here

                RestauranteCEN resCEN = new RestauranteCEN();
                RestauranteEN resEN = resCEN.ReadOID(res.Id);

                RestauranteCEN cen = new RestauranteCEN();
                cen.Modify(res.Id, res.Email, resEN.Pass, res.Fecha_inscripcion, res.Nombre, res.Fecha_apertura, res.Max_comen, res.Current_comen, res.Precio_medio, res.Descripcion, res.Menu); //parametros restaurante
                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Restaurante/Edit/5
        public ActionResult EditarDatos()
        {
            RestauranteViewModel res = null;
            SessionInitialize();

            TipoCocinaCEN tipoCocinaCEN = new TipoCocinaCEN();
            IList<TipoCocinaEN> listaTipoCocina = tipoCocinaCEN.ReadAll(0, -1);
            ViewData["listaTipoCocina"] = listaTipoCocina;

            UsuarioCEN usu = new UsuarioCEN();
            int idd = usu.DgetOIDfromEmail(User.Identity.Name);

            RestauranteEN resEN = new RestauranteCAD(session).ReadOIDDefault(idd);
            res = new AssemblerRestaurante().ConvertENToModelUI(resEN);
            SessionClose();

            return View(res);
        }

        // POST: Restaurante/Edit/5
        [HttpPost]
        public ActionResult EditarDatos(RestauranteViewModel res) //Restaurante res
        {
            try
            {
                // TODO: Add update logic here

                RestauranteCEN resCEN = new RestauranteCEN();
                RestauranteEN resEN = resCEN.ReadOID(res.Id);

                RestauranteCEN cen = new RestauranteCEN();
                cen.Modify(res.Id, res.Email, resEN.Pass, res.Fecha_inscripcion, res.Nombre, res.Fecha_apertura, res.Max_comen, res.Current_comen, res.Precio_medio, res.Descripcion, res.Menu); //parametros restaurante

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Restaurante/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                SessionInitialize();
                RestauranteCAD resCAD = new RestauranteCAD(session);
                RestauranteCEN resCEN = new RestauranteCEN(resCAD);
                RestauranteEN resEN = resCEN.ReadOID(id);
                RestauranteViewModel res = new AssemblerRestaurante().ConvertENToModelUI(resEN);

                SessionClose();

                return View(res);
            }
            catch
            {
                return View();
            }

                
        }

        // POST: Restaurante/Delete/5
        [HttpPost]
        public ActionResult Delete(RestauranteViewModel res)
        {
            try
            {
                // TODO: Add delete logic here
                new RestauranteCEN().Destroy(res.Id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
