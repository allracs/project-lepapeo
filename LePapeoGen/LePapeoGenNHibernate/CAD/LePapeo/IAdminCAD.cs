
using System;
using LePapeoGenNHibernate.EN.LePapeo;

namespace LePapeoGenNHibernate.CAD.LePapeo
{
public partial interface IAdminCAD
{
AdminEN ReadOIDDefault (int id
                        );

void ModifyDefault (AdminEN admin);

System.Collections.Generic.IList<AdminEN> ReadAllDefault (int first, int size);



int New_ (AdminEN admin);

void Modify (AdminEN admin);


void Destroy (int id
              );


AdminEN ReadOID (int id
                 );


System.Collections.Generic.IList<AdminEN> ReadAll (int first, int size);
}
}
