using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LePapeo.Models;
using LePapeoGenNHibernate.EN.LePapeo;



namespace LePapeo.Models
{
    public class AssemblerUsuario
    {
        public UsuarioViewModel ConvertENToModelUI(UsuarioEN usuEN)
        {
            UsuarioViewModel usu = new UsuarioViewModel();
            usu.id = usuEN.Id;
            usu.Email = usuEN.Email;
            usu.Password = usuEN.Pass;
            usu.FechaInscripcion = (System.DateTime)usuEN.Fecha_inscripcion;

            return usu;


        }
        public IList<UsuarioViewModel> ConvertListENToModel (IList<UsuarioEN> usul){
            IList<UsuarioViewModel> usuVM = new List<UsuarioViewModel>();
            foreach (UsuarioEN en in usul)
            {
                usuVM.Add(ConvertENToModelUI(en));
            }
            return usuVM;
        }
        
    }
}