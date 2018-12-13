
using System;
using LePapeoGenNHibernate.EN.LePapeo;

namespace LePapeoGenNHibernate.CAD.LePapeo
{
public partial interface IRegistradoCAD
{
RegistradoEN ReadOIDDefault (int id
                             );

void ModifyDefault (RegistradoEN registrado);

System.Collections.Generic.IList<RegistradoEN> ReadAllDefault (int first, int size);



int New_ (RegistradoEN registrado);

void Modify (RegistradoEN registrado);


void Destroy (int id
              );


RegistradoEN ReadOID (int id
                      );


System.Collections.Generic.IList<RegistradoEN> ReadAll (int first, int size);


void AgregarDireccion (int p_Registrado_OID, int p_direccion_0_OID);

void DesvincularDireccion (int p_Registrado_OID, int p_direccion_0_OID);

LePapeoGenNHibernate.EN.LePapeo.DireccionEN GetDireccion (int p_registrado);
}
}
