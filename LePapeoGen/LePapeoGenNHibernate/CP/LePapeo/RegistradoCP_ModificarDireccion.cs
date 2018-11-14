
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using System.Collections.Generic;
using LePapeoGenNHibernate.EN.LePapeo;
using LePapeoGenNHibernate.CAD.LePapeo;
using LePapeoGenNHibernate.CEN.LePapeo;



/*PROTECTED REGION ID(usingLePapeoGenNHibernate.CP.LePapeo_Registrado_ModificarDireccion) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace LePapeoGenNHibernate.CP.LePapeo
{
public partial class RegistradoCP : BasicCP
{
public bool ModificarDireccion (int p_oid, string p_calle, string p_cod_pos, int p_numero, int posX, int posY)
{
        /*PROTECTED REGION ID(LePapeoGenNHibernate.CP.LePapeo_Registrado_ModificarDireccion) ENABLED START*/

        IRegistradoCAD registradoCAD = null;
        RegistradoCEN registradoCEN = null;

        DireccionCEN direccionCEN = null;
        DireccionCAD direccionCAD = null;

        bool result = false;


        try
        {
                SessionInitializeTransaction ();
                registradoCAD = new RegistradoCAD (session);
                registradoCEN = new  RegistradoCEN (registradoCAD);


                DireccionEN direccionEN = registradoCEN.GetDireccion (p_oid);

                if (direccionEN != null) {
                        direccionCAD = new DireccionCAD (session);
                        direccionCEN = new DireccionCEN (direccionCAD);

                        direccionCEN.Modify (direccionEN.Id, p_cod_pos, p_calle, p_numero, posX, posY);



                        registradoCEN.AgregarDireccion (p_oid, direccionEN.Id);
                        result = true;
                }






                SessionCommit ();
        }
        catch (Exception ex)
        {
                SessionRollBack ();
                throw ex;
        }
        finally
        {
                SessionClose ();
        }
        return result;


        /*PROTECTED REGION END*/
}
}
}
