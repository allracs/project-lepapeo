using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WEBLoginLePAPEO.Models;
using LePapeoGenNHibernate.EN.LePapeo;


namespace WEBLoginLePAPEO.Models
{
    public class AssemblerRestaurante
    {
        public RestauranteViewModel ConvertENToModelUI(RestauranteEN en)
        {
            RestauranteViewModel res = new RestauranteViewModel();
            res.Id = en.Id;
            res.Email = en.Email;
            res.Pass = en.Pass;
            res.Fecha_inscripcion = (System.DateTime)en.Fecha_inscripcion;
            res.Nombre = en.Nombre;
            res.Fecha_apertura = (System.DateTime)en.Fecha_apertura;
            res.Max_comen = en.Max_comen;
            res.Current_comen = en.Current_comen;
            res.Precio_medio = en.Precio_medio;
            res.Descripcion = en.Descripcion;
            res.Menu = en.Menu;
            res.Tipo = en.TipoCocina.Tipo;
            return res;
        }
        public IList<RestauranteViewModel> ConvertListENToModel(IList<RestauranteEN> res)
        {
            IList<RestauranteViewModel> rests = new List<RestauranteViewModel>();
            foreach (RestauranteEN en in res)
            {
                rests.Add(ConvertENToModelUI(en));
            }
            return rests;
        }
    }
}