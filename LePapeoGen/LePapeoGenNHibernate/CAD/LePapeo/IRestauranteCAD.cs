
using System;
using LePapeoGenNHibernate.EN.LePapeo;

namespace LePapeoGenNHibernate.CAD.LePapeo
{
public partial interface IRestauranteCAD
{
RestauranteEN ReadOIDDefault (int id
                              );

void ModifyDefault (RestauranteEN restaurante);

System.Collections.Generic.IList<RestauranteEN> ReadAllDefault (int first, int size);



int New_ (RestauranteEN restaurante);

void Modify (RestauranteEN restaurante);


void Destroy (int id
              );


RestauranteEN ReadOID (int id
                       );


System.Collections.Generic.IList<RestauranteEN> ReadAll (int first, int size);


void AgregarDireccion (int p_Restaurante_OID, int p_direccion_OID);

void DesvincularDireccion (int p_Restaurante_OID, int p_direccion_OID);

System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.RestauranteEN> BuscarRestaurante (string p_cadena);


void AgregarHorarioSemana (int p_Restaurante_OID, int p_horarioSemana_OID);

void DesvincularHorarioSemana (int p_Restaurante_OID, int p_horarioSemana_OID);

LePapeoGenNHibernate.EN.LePapeo.HorarioSemanaEN GetHorarioSemana (int p_restaurante);


LePapeoGenNHibernate.EN.LePapeo.DireccionEN GetDireccion (int p_restaurante);
}
}
