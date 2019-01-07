using LePapeoGenNHibernate.CEN.LePapeo;
using LePapeoGenNHibernate.EN.LePapeo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEBLEPAPEO.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //if(User.Identity.Name == "Admin@mail.com") return RedirectToAction("Admin", "Home");

            UsuarioCEN usu = new UsuarioCEN();
            int idd = usu.DgetOIDfromEmail(User.Identity.Name);

            UsuarioEN usuen = usu.ReadOID(idd);
            if (usuen != null)
            {
                String[] tipo = usuen.GetType().ToString().Split('.');
                if (tipo[tipo.Length - 1].Equals("AdminEN")) return RedirectToAction("Admin", "Home");
                if (tipo[tipo.Length - 1].Equals("RestauranteEN")) return RedirectToAction("Restaurante", "Home");

            }

            TipoCocinaCEN tipoCocinaCEN = new TipoCocinaCEN();
            IList<TipoCocinaEN> listaTipoCocina = tipoCocinaCEN.ReadAll(0, -1);
            ViewData["listaTipoCocina"] = listaTipoCocina;

            /*
             * Es de tipo restauranteEN?
             * return RedirectToAction
             */
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
       
        public ActionResult Admin()
        {
            UsuarioCEN usu = new UsuarioCEN();
            int idd = usu.DgetOIDfromEmail(User.Identity.Name);
            UsuarioEN usuen = usu.ReadOID(idd);
            if (usuen != null)
            {
                String[] tipo = usuen.GetType().ToString().Split('.');
                if (!tipo[tipo.Length - 1].Equals("AdminEN")) return RedirectToAction("Index", "Home");
                return View();
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Restaurante()
        {
            UsuarioCEN usu = new UsuarioCEN();
            int idd = usu.DgetOIDfromEmail(User.Identity.Name);
            UsuarioEN usuen = usu.ReadOID(idd);
            if (usuen != null)
            {
                String[] tipo = usuen.GetType().ToString().Split('.');
                if (!tipo[tipo.Length - 1].Equals("RestauranteEN")) return RedirectToAction("Index", "Home");
                return View();
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost] 
        public ActionResult ResultadosDeBusqueda(FormCollection parametros)
        {
            HorarioDiaCEN HorarioDiaCEN = new HorarioDiaCEN();
            RestauranteCEN RestauranteCEN = new RestauranteCEN();
            IList<RestauranteEN> listResEN = RestauranteCEN.ReadAll(0, -1);
            IList<RestauranteEN> auxResEN = RestauranteCEN.ReadAll(0, -1);
            Console.WriteLine(parametros["tipococina"]);
            if (parametros["tipococina"] != null && parametros["tipococina"] != "")
            {
                foreach (RestauranteEN e in listResEN)
                {
                    if (e.TipoCocina.Tipo != parametros["tipococina"])
                    {
                        auxResEN.Remove(e);
                    }
                }
            }

            if (parametros["nombre"] != null && parametros["nombre"] != "")
            {
                String name = parametros["nombre"];
                String[] names = name.Split(' ');
                foreach (RestauranteEN e in listResEN)
                {
                    String[] namesOficial = e.Nombre.Split(' ');
                    Boolean admitido = false;
                    for (int j = 0; j < names.Length; j++)
                    {
                        for (int k = 0; k < namesOficial.Length; k++)
                        {
                            if (namesOficial[k] == names[j])
                            {
                                admitido = true;
                            }
                        }
                    }
                    if (admitido == false)
                    {
                        auxResEN.Remove(e);
                    }
                }
            }

            if (parametros["comensales"] != null && parametros["comensales"] != "0")
            {
                foreach (RestauranteEN e in listResEN)
                {
                    if (e.Max_comen < Int32.Parse(parametros["comensales"]))
                    {
                        auxResEN.Remove(e);
                    }
                }
            }

            if (parametros["ciudad-provincia"] != null && parametros["ciudad-provincia"] != "")
            {
                foreach (RestauranteEN e in listResEN)
                {
                    try
                    {
                        if (RestauranteCEN.GetDireccion(e.Id) != null)
                        {
                            if (RestauranteCEN.GetDireccion(e.Id).Ciudad.Nombre != parametros["ciudad-provincia"] || RestauranteCEN.GetDireccion(e.Id).Ciudad.Provincia != parametros["ciudad-provincia"])
                            {
                                auxResEN.Remove(e);
                            }
                        }
                    }
                    catch
                    {

                    }

                }
            }

            if (parametros["codpos"] != null && parametros["codpos"] != "")
            {
                foreach (RestauranteEN e in listResEN)
                {
                    try
                    {
                        if (RestauranteCEN.GetDireccion(e.Id) != null)
                        {
                            if (RestauranteCEN.GetDireccion(e.Id).Cod_pos != parametros["codpos"])
                            {
                                auxResEN.Remove(e);
                            }
                        }
                    }
                    catch
                    {

                    }
                }
            }

            if (parametros["diabusqueda"] != null && parametros["diabusqueda"] != "vacio")
            {
                foreach (RestauranteEN e in listResEN)
                {
                    Boolean admitido = false;
                    try
                    {
                        IList<HorarioDiaEN> listaHD = HorarioDiaCEN.GetHorariosDiaFromHorarioSemana(RestauranteCEN.GetHorarioSemana(e.Id).Id);
                        if (listaHD != null)
                        {
                            foreach (HorarioDiaEN hd in listaHD)
                            {
                                if (hd.Dia.ToString() == parametros["diabusqueda"])
                                {
                                    admitido = true;
                                }
                            }

                            if (admitido == false)
                            {
                                auxResEN.Remove(e);
                            }
                        }
                    }
                    catch
                    {

                    }
                }
            }

            IEnumerable<RestauranteViewModel> listres = new AssemblerRestaurante().ConvertListENToModel(auxResEN);

            ViewData["resview"] = RestauranteCEN;
            ViewData["hdview"] = HorarioDiaCEN;

            return View(listres);
        }
    }
}