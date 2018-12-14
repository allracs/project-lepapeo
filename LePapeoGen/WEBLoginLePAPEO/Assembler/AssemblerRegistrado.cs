using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LePapeo.Models;
using LePapeoGenNHibernate.EN.LePapeo;



namespace LePapeo.Models
{
    public class AssemblerRegistrado
    {
        public RegistradoViewModel ConvertENToModelUI(RegistradoEN regEN)
        {
            RegistradoViewModel reg = new RegistradoViewModel();
            reg.id = regEN.Id;
            reg.Email = regEN.Email;
            reg.Password = regEN.Pass;
            reg.FechaInscripcion = (System.DateTime)regEN.Fecha_inscripcion;
            reg.Nombre = regEN.Nombre;
            reg.Apellidos = regEN.Apellidos;
            reg.Fecha_nacimiento = (System.DateTime)regEN.Fecha_nac;
            


            return reg;


        }
        public IList<RegistradoViewModel> ConvertListENToModel (IList<RegistradoEN> regl){
            IList<RegistradoViewModel>regVM = new List<RegistradoViewModel>();
            foreach (RegistradoEN en in regl)
            {
               regVM.Add(ConvertENToModelUI(en));
            }
            return regVM;
        }
        
    }
}