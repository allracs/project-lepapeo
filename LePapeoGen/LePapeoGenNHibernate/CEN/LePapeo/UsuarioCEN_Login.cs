
using System;
using System.Text;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using LePapeoGenNHibernate.Exceptions;
using LePapeoGenNHibernate.EN.LePapeo;
using LePapeoGenNHibernate.CAD.LePapeo;


/*PROTECTED REGION ID(usingLePapeoGenNHibernate.CEN.LePapeo_Usuario_login) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace LePapeoGenNHibernate.CEN.LePapeo
{
public partial class UsuarioCEN
{
public string Login (int p_Usuario_OID, string p_pass)
{
        /*PROTECTED REGION ID(LePapeoGenNHibernate.CEN.LePapeo_Usuario_login) ENABLED START*/
        string result = null;
        UsuarioEN en = _IUsuarioCAD.ReadOIDDefault (p_Usuario_OID);

        if (en.Pass.Equals (Utils.Util.GetEncondeMD5 (p_pass)))
                result = en.GetType ().Name;



        //FALTA CREAR SESION

        return result;
        /*PROTECTED REGION END*/
}
}
}
