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
    public class OpinionController : BasicController
    {
        // GET: Opinion
        public ActionResult Index()
        {
            OpinionCEN opi = new OpinionCEN();

            IList<OpinionEN> listopiEN;

            UsuarioCEN usu = new UsuarioCEN();
            int idd = usu.DgetOIDfromEmail(User.Identity.Name);
            
            UsuarioEN usuen = usu.ReadOID(idd);
            if (usuen != null)
            {
                //Console.Write("\n"+idd+"\n");
                String[] tipo = usuen.GetType().ToString().Split('.');
                if (tipo[tipo.Length - 1].Equals("RestauranteEN"))
                {
                    listopiEN = opi.GetOpinionsFromRestaurante(idd);
                    IEnumerable<OpinionViewModel> listopi = new AssemblerOpinion().ConvertListENToModel(listopiEN);
                    return View(listopi);
                }
                else if (tipo[tipo.Length - 1].Equals("RegistradoEN"))
                {
                    listopiEN = opi.GetOpinionsFromRegistrado(idd);
                    IEnumerable<OpinionViewModel> listopi = new AssemblerOpinion().ConvertListENToModel(listopiEN);
                    return View(listopi);
                }
                else if (tipo[tipo.Length - 1].Equals("AdminEN"))
                {
                    listopiEN = opi.ReadAll(0, -1);
                    IEnumerable<OpinionViewModel> listopi = new AssemblerOpinion().ConvertListENToModel(listopiEN);
                    return View(listopi);
                }  
            }

            return View();

        }

        // GET: Opinion/Details/5
        public ActionResult Details(int id)
        {
            OpinionViewModel opinion = null;
            SessionInitialize();
            OpinionEN opinionEN = new OpinionCAD(session).ReadOIDDefault(id);
            opinion = new AssemblerOpinion().ConvertENToModelUI(opinionEN);
            SessionClose();
            return View(opinion);
            //return View();
        }

        // GET: Opinion/Create
        public ActionResult Create()
        {
            OpinionViewModel opi = new OpinionViewModel();

            RestauranteCEN restauranteCEN = new RestauranteCEN();
            IList<RestauranteEN> listaRestaurante = restauranteCEN.ReadAll(0, -1);
            ViewData["listaRestaurante"] = listaRestaurante;

            RegistradoCEN registradoCEN = new RegistradoCEN();
            IList<RegistradoEN> listaRegistrado = registradoCEN.ReadAll(0, -1);
            ViewData["listaRegistrado"] = listaRegistrado;


            return View(opi);
        }

        // POST: Opinion/Create
        [HttpPost]
        public ActionResult Create(OpinionViewModel opi)
        {
            try
            {
                // TODO: Add insert logic here

                OpinionCEN cen = new OpinionCEN();

                //crear el registrado y el restaurante y buscar por oid

                cen.New_(opi.Valoracion, opi.Titulo, opi.Comentario, opi.Registrado, opi.Restaurante, opi.Fecha); //32768 32770
                //cen.New_(opi.Valoracion, opi.Titulo, opi.Comentario, 32768, 32770, opi.Fecha);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Opinion/Edit/5
        public ActionResult Edit(int id)
        {
            OpinionViewModel opi = null;
            SessionInitialize();
            OpinionEN opiEN = new OpinionCAD(session).ReadOIDDefault(id);
            opi = new AssemblerOpinion().ConvertENToModelUI(opiEN);
            SessionClose();

            return View(opi);
        }

        // POST: Opinion/Edit/5
        [HttpPost]
        public ActionResult Edit(OpinionViewModel opi)
        {
            try
            {
                // TODO: Add update logic here
                OpinionCEN cen = new OpinionCEN();
                cen.Modify(opi.id, opi.Valoracion, opi.Titulo, opi.Comentario, opi.Fecha);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Opinion/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                SessionInitialize();
                OpinionCAD opiCAD = new OpinionCAD(session);
                OpinionCEN cen = new OpinionCEN(opiCAD);
                OpinionEN opiEN = cen.ReadOID(id);
                OpinionViewModel opi = new AssemblerOpinion().ConvertENToModelUI(opiEN);

                SessionClose();

                return View(opi);
            }
            catch
            {
                return View();
            }
        }

        // POST: Opinion/Delete/5
        [HttpPost]
        public ActionResult Delete(OpinionViewModel opi)
        {
            try
            {
                // TODO: Add delete logic here
                new OpinionCEN().Destroy(opi.id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
