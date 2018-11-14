

using System;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using LePapeoGenNHibernate.Exceptions;

using LePapeoGenNHibernate.EN.LePapeo;
using LePapeoGenNHibernate.CAD.LePapeo;


namespace LePapeoGenNHibernate.CEN.LePapeo
{
/*
 *      Definition of the class OpinionCEN
 *
 */
public partial class OpinionCEN
{
private IOpinionCAD _IOpinionCAD;

public OpinionCEN()
{
        this._IOpinionCAD = new OpinionCAD ();
}

public OpinionCEN(IOpinionCAD _IOpinionCAD)
{
        this._IOpinionCAD = _IOpinionCAD;
}

public IOpinionCAD get_IOpinionCAD ()
{
        return this._IOpinionCAD;
}

public int New_ (LePapeoGenNHibernate.Enumerated.LePapeo.ValoracionEnum p_valoracion, string p_titulo, string p_comentario, int p_registrado, int p_restaurante)
{
        OpinionEN opinionEN = null;
        int oid;

        //Initialized OpinionEN
        opinionEN = new OpinionEN ();
        opinionEN.Valoracion = p_valoracion;

        opinionEN.Titulo = p_titulo;

        opinionEN.Comentario = p_comentario;


        if (p_registrado != -1) {
                // El argumento p_registrado -> Property registrado es oid = false
                // Lista de oids id
                opinionEN.Registrado = new LePapeoGenNHibernate.EN.LePapeo.RegistradoEN ();
                opinionEN.Registrado.Id = p_registrado;
        }


        if (p_restaurante != -1) {
                // El argumento p_restaurante -> Property restaurante es oid = false
                // Lista de oids id
                opinionEN.Restaurante = new LePapeoGenNHibernate.EN.LePapeo.RestauranteEN ();
                opinionEN.Restaurante.Id = p_restaurante;
        }

        //Call to OpinionCAD

        oid = _IOpinionCAD.New_ (opinionEN);
        return oid;
}

public void Modify (int p_Opinion_OID, LePapeoGenNHibernate.Enumerated.LePapeo.ValoracionEnum p_valoracion, string p_titulo, string p_comentario)
{
        OpinionEN opinionEN = null;

        //Initialized OpinionEN
        opinionEN = new OpinionEN ();
        opinionEN.Id = p_Opinion_OID;
        opinionEN.Valoracion = p_valoracion;
        opinionEN.Titulo = p_titulo;
        opinionEN.Comentario = p_comentario;
        //Call to OpinionCAD

        _IOpinionCAD.Modify (opinionEN);
}

public void Destroy (int id
                     )
{
        _IOpinionCAD.Destroy (id);
}

public OpinionEN ReadOID (int id
                          )
{
        OpinionEN opinionEN = null;

        opinionEN = _IOpinionCAD.ReadOID (id);
        return opinionEN;
}

public System.Collections.Generic.IList<OpinionEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<OpinionEN> list = null;

        list = _IOpinionCAD.ReadAll (first, size);
        return list;
}
public System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.OpinionEN> GetOpinionsFromRegistrado (int p_registrado)
{
        return _IOpinionCAD.GetOpinionsFromRegistrado (p_registrado);
}
public System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.OpinionEN> GetOpinionsFromRestaurante (int p_restaurante)
{
        return _IOpinionCAD.GetOpinionsFromRestaurante (p_restaurante);
}
public System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.OpinionEN> GetOpinionsFromRegistradoByValoracion (int p_registrado, LePapeoGenNHibernate.Enumerated.LePapeo.ValoracionEnum ? p_valoracion)
{
        return _IOpinionCAD.GetOpinionsFromRegistradoByValoracion (p_registrado, p_valoracion);
}
public System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.OpinionEN> GetOpinionsFromRestauranteByValoracion (int p_restaurante, LePapeoGenNHibernate.Enumerated.LePapeo.ValoracionEnum ? p_valoracion)
{
        return _IOpinionCAD.GetOpinionsFromRestauranteByValoracion (p_restaurante, p_valoracion);
}
public System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.OpinionEN> GetOpinionsFromRegistradoYRestaurante (int p_restaurante, int p_registrado)
{
        return _IOpinionCAD.GetOpinionsFromRegistradoYRestaurante (p_restaurante, p_registrado);
}
public System.Collections.Generic.IList<LePapeoGenNHibernate.EN.LePapeo.OpinionEN> GetOpinionsFromRegistradoYRestauranteByValoracion (int p_registrado, LePapeoGenNHibernate.Enumerated.LePapeo.ValoracionEnum? p_valoracion, int p_restaurante)
{
        return _IOpinionCAD.GetOpinionsFromRegistradoYRestauranteByValoracion (p_registrado, p_valoracion, p_restaurante);
}
}
}
