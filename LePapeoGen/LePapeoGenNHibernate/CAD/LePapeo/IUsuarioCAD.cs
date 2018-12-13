
using System;
using LePapeoGenNHibernate.EN.LePapeo;

namespace LePapeoGenNHibernate.CAD.LePapeo
{
public partial interface IUsuarioCAD
{
UsuarioEN ReadOIDDefault (int id
                          );

void ModifyDefault (UsuarioEN usuario);

System.Collections.Generic.IList<UsuarioEN> ReadAllDefault (int first, int size);



int New_ (UsuarioEN usuario);

void Modify (UsuarioEN usuario);


void Destroy (int id
              );


UsuarioEN ReadOID (int id
                   );


System.Collections.Generic.IList<UsuarioEN> ReadAll (int first, int size);



System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.NotificacionEN> GetNotificaciones (int p_usuario);
}
}
