using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LePapeo.Models;
using LePapeoGenNHibernate.EN.LePapeo;



namespace LePapeo.Models
{
    public class AssemblerCiudad
    {
        public CiudadViewModel ConvertENToModelUI(CiudadEN ciuEN)
        {
            CiudadViewModel ciu = new CiudadViewModel();
            ciu.direcciones = ciuEN.Direccion;
            ciu.nombre = ciuEN.Nombre;
            ciu.provincia = ciuEN.Provincia;
            
            return ciu;
        }
        public IList<CiudadViewModel> ConvertListENToModel (IList<CiudadEN> ciuL){
            IList<CiudadViewModel> ciulist = new List<CiudadViewModel>();
            foreach (CiudadEN ciu in ciuL)
            {
                ciulist.Add(ConvertENToModelUI(ciu));
            }
            return ciulist;
        }
        
    }
}