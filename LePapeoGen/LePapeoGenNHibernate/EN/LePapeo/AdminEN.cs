
using System;
// Definición clase AdminEN
namespace LePapeoGenNHibernate.EN.LePapeo
{
public partial class AdminEN                                                                        : LePapeoGenNHibernate.EN.LePapeo.UsuarioEN


{
public AdminEN() : base ()
{
}



public AdminEN(int id,
               string email, String pass, System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.NotificacionEN> notificacion, Nullable<DateTime> fecha_inscripcion
               )
{
        this.init (Id, email, pass, notificacion, fecha_inscripcion);
}


public AdminEN(AdminEN admin)
{
        this.init (Id, admin.Email, admin.Pass, admin.Notificacion, admin.Fecha_inscripcion);
}

private void init (int id
                   , string email, String pass, System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.NotificacionEN> notificacion, Nullable<DateTime> fecha_inscripcion)
{
        this.Id = id;


        this.Email = email;

        this.Pass = pass;

        this.Notificacion = notificacion;

        this.Fecha_inscripcion = fecha_inscripcion;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        AdminEN t = obj as AdminEN;
        if (t == null)
                return false;
        if (Id.Equals (t.Id))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Id.GetHashCode ();
        return hash;
}
}
}
