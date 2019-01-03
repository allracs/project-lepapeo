using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LePapeo.Models;
using LePapeoGenNHibernate.CAD.LePapeo;
using LePapeoGenNHibernate.CEN.LePapeo;
using LePapeoGenNHibernate.EN.LePapeo;



namespace LePapeo.Models
{
    public class AssemblerDireccion
    {
        public DireccionViewModel ConvertENToModelUI(DireccionEN dirEN)
        {
            DireccionViewModel dir = new DireccionViewModel();
            dir.id = dirEN.Id;
            dir.ciudad = dirEN.Ciudad.Nombre;
            dir.provincia = "provincia_test_str";
            dir.calle = dirEN.Calle;
            dir.cod_pos = dirEN.Cod_pos;
            dir.numero_puerta = dirEN.Numero;
            dir.pos_x = dirEN.Pos_x;
            dir.pos_y = dirEN.Pos_y;
            
            return dir;
        }
        public IList<DireccionViewModel> ConvertListENToModel (IList<DireccionEN> dirL){
            IList<DireccionViewModel> dirlist = new List<DireccionViewModel>();
            foreach (DireccionEN dir in dirL)
            {
                dirlist.Add(ConvertENToModelUI(dir));
            }
            return dirlist;
        }
        
    }
}