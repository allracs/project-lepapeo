using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LePapeo.Models;
using LePapeoGenNHibernate.EN.LePapeo;



namespace LePapeo.Models
{
    public class AssemblerAdmin
    {
        public AdminViewModel ConvertENToModelUI(AdminEN adminEN)
        {
            AdminViewModel admin = new AdminViewModel();
            admin.id = adminEN.Id;
            admin.email = adminEN.Email;
            admin.p_pass = adminEN.Pass; //LePapeoGenNHibernate.Utils.Util.GetEncondeMD5(adminEN.Pass)
            admin.p_fecha_inscripcion = adminEN.Fecha_inscripcion;

            return admin;


        }
        public IList<AdminViewModel> ConvertListENToModel (IList<AdminEN> ens){
            IList<AdminViewModel> arts = new List<AdminViewModel>();
            foreach (AdminEN en in ens)
            {
                arts.Add(ConvertENToModelUI(en));
            }
            return arts;
        }
        
    }
}