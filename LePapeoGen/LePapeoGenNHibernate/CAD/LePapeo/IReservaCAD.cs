
using System;
using LePapeoGenNHibernate.EN.LePapeo;

namespace LePapeoGenNHibernate.CAD.LePapeo
{
public partial interface IReservaCAD
{
ReservaEN ReadOIDDefault (int id
                          );

void ModifyDefault (ReservaEN reserva);

System.Collections.Generic.IList<ReservaEN> ReadAllDefault (int first, int size);



int New_ (ReservaEN reserva);

void Modify (ReservaEN reserva);


void Destroy (int id
              );


void CambiarEstado (ReservaEN reserva);


ReservaEN ReadOID (int id
                   );


System.Collections.Generic.IList<ReservaEN> ReadAll (int first, int size);


System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.ReservaEN> GetReservasFromRegistrado (int p_registrado);


System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.ReservaEN> GetReservasFromRestaurante (int p_restaurante);


System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.ReservaEN> GetReservasFromRestauranteYRegistrado (int p_registrado, int p_restaurante);


System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.ReservaEN> GetReservasFromRegistradoFinal (int p_registrado, bool ? p_finalizada);


System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.ReservaEN> GetReservasFromRestauranteFinal (int p_restaurante, bool ? p_finalizada);


System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.ReservaEN> GetReservasFromRegistradoByFechaHora (int p_registrado, Nullable<DateTime> p_fecha_hora);


System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.ReservaEN> GetReservasFromRestauranteByFechaHora (int p_restaurante, Nullable<DateTime> p_fecha_hora);


void CambiarFinalizacion (ReservaEN reserva);
}
}
