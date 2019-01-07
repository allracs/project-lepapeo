
/*PROTECTED REGION ID(CreateDB_imports) ENABLED START*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using LePapeoGenNHibernate.EN.LePapeo;
using LePapeoGenNHibernate.CEN.LePapeo;
using LePapeoGenNHibernate.CAD.LePapeo;
using LePapeoGenNHibernate.CP.LePapeo;
using LePapeoGenNHibernate.Enumerated.LePapeo;

/*PROTECTED REGION END*/
namespace InitializeDB
{
public class CreateDB
{
public static void Create (string databaseArg, string userArg, string passArg)
{
        String database = databaseArg;
        String user = userArg;
        String pass = passArg;

        // Conex DB
        SqlConnection cnn = new SqlConnection (@"Server=(local)\sqlexpress; database=master; integrated security=yes");

        // Order T-SQL create user
        String createUser = @"IF NOT EXISTS(SELECT name FROM master.dbo.syslogins WHERE name = '" + user + @"')
            BEGIN
                CREATE LOGIN ["                                                                                                                                     + user + @"] WITH PASSWORD=N'" + pass + @"', DEFAULT_DATABASE=[master], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
            END"                                                                                                                                                                                                                                                                                    ;

        //Order delete user if exist
        String deleteDataBase = @"if exists(select * from sys.databases where name = '" + database + "') DROP DATABASE [" + database + "]";
        //Order create databas
        string createBD = "CREATE DATABASE " + database;
        //Order associate user with database
        String associatedUser = @"USE [" + database + "];CREATE USER [" + user + "] FOR LOGIN [" + user + "];USE [" + database + "];EXEC sp_addrolemember N'db_owner', N'" + user + "'";
        SqlCommand cmd = null;

        try
        {
                // Open conex
                cnn.Open ();

                //Create user in SQLSERVER
                cmd = new SqlCommand (createUser, cnn);
                cmd.ExecuteNonQuery ();

                //DELETE database if exist
                cmd = new SqlCommand (deleteDataBase, cnn);
                cmd.ExecuteNonQuery ();

                //CREATE DB
                cmd = new SqlCommand (createBD, cnn);
                cmd.ExecuteNonQuery ();

                //Associate user with db
                cmd = new SqlCommand (associatedUser, cnn);
                cmd.ExecuteNonQuery ();

                System.Console.WriteLine ("DataBase create sucessfully..");
        }
        catch (Exception ex)
        {
                throw ex;
        }
        finally
        {
                if (cnn.State == ConnectionState.Open) {
                        cnn.Close ();
                }
        }
}

public static void InitializeData ()
{
        /*PROTECTED REGION ID(initializeDataMethod) ENABLED START*/
        try
        {
                // Insert the initilizations of entities using the CEN classes


                // p.e. CustomerCEN customer = new CustomerCEN();
                // customer.New_ (p_user:"user", p_password:"1234");

                //------Creation------//

                //Creamos Registrado
                RegistradoCEN registrado_diegoCEN = new RegistradoCEN ();
                int diegoID = registrado_diegoCEN.New_ ("diego@mail.com", "diego_pass", new DateTime (2001, 1, 1, 9, 0, 0), "Diego", "Carcamo", new DateTime (1900, 6, 1));

                RegistradoCAD x = new RegistradoCAD ();
                RegistradoEN xx = x.ReadOIDDefault (diegoID);



                //Creamos Admin
                AdminCEN admin = new AdminCEN ();
                int davidID = admin.New_ ("aaadmin@mail.com", "aaAdmin1!", new DateTime (2001, 1, 1, 9, 0, 0));

                //Creamos Ciudad
                CiudadCEN ciudadCEN = new CiudadCEN ();
                String ciu = ciudadCEN.New_ ("Alicante", "Alicante");

                //Creamos Direccion
                DireccionCEN direccionCEN = new DireccionCEN ();
                int direccionID = direccionCEN.New_ ("02001", "Calle de los caidos", 3, 1, 2, ciu);

                //Creamos TipoCocina
                TipoCocinaCEN tipoCocinaCEN = new TipoCocinaCEN ();
                String tipo = tipoCocinaCEN.New_ ("Tradicional");

                //Creamos Restaurante
                RestauranteCEN restauranteCEN = new RestauranteCEN ();
                int forkID = restauranteCEN.New_ ("fork@mail.com", "fork_pass", new DateTime (1999, 4, 17), "Fork", new DateTime (1999, 4, 17), tipo, 40, 0, 15.50f, "Descripcio", "Menu");

                //Creamos HorarioSemana
                HorarioSemanaCEN horarioSemanaCEN = new HorarioSemanaCEN ();
                int horarioSem1ID = horarioSemanaCEN.New_ ();

                //Creamos HorarioDia
                HorarioDiaCEN horarioDiaCEN = new HorarioDiaCEN ();
                int horarioDia1ID = horarioDiaCEN.New_ (new DateTime (2001, 1, 1, 9, 0, 0), new DateTime (2001, 1, 1, 15, 0, 0), new DateTime (2001, 1, 1, 17, 0, 0), new DateTime (2001, 1, 2, 1, 0, 0), DiaSemanaEnum.lunes, horarioSem1ID);
                HorarioDiaCEN horarioDia2CEN = new HorarioDiaCEN ();
                int horarioDia2ID = horarioDia2CEN.New_ (new DateTime (2001, 1, 1, 9, 0, 0), new DateTime (2001, 1, 1, 15, 0, 0), new DateTime (2001, 1, 1, 17, 0, 0), new DateTime (2001, 1, 2, 1, 0, 0), DiaSemanaEnum.martes, horarioSem1ID);

                //Creamos Reserva
                ReservaCEN reservaCEN = new ReservaCEN ();
                int reservaID = reservaCEN.New_ (diegoID, forkID, 4, EstadoReservaEnum.pendiente, false, new DateTime (2001, 1, 1, 15, 0, 0), new DateTime (2001, 1, 1, 9, 0, 0));
                ReservaCEN reserva1CEN = new ReservaCEN ();
                int reserva1ID = reserva1CEN.New_ (diegoID, forkID, 3, EstadoReservaEnum.pendiente, false, new DateTime (2001, 2, 1, 15, 0, 0), new DateTime (2001, 1, 1, 9, 0, 0));

                //Creamos Opinion
                OpinionCEN opinionCEN = new OpinionCEN ();
                int opinionID = opinionCEN.New_ (ValoracionEnum.media, "Titulo de la opinion", "contenido de la opinion", diegoID, forkID, new DateTime (2001, 1, 1, 9, 0, 0));
                int Opinion2ID = opinionCEN.New_ (ValoracionEnum.media, "Titulo de la opinion2", "contenido de la opinion2", diegoID, forkID, new DateTime (2001, 1, 1, 9, 0, 0));

                //Creamos NotificacionGenerica
                NotificacionGenericaCEN notificacionGenericaCEN = new NotificacionGenericaCEN ();
                int notificacionGenericaID = notificacionGenericaCEN.New_ (TipoNotificacionEnum.nuevaOpinion, "Texto default de esta notificacion", "titulo default de esta notificacion");

                //Creamos Notificacion
                NotificacionCEN notificacionCEN = new NotificacionCEN ();
                int notificacionID = notificacionCEN.New_ ("contenido", notificacionGenericaID, new DateTime (2001, 1, 1, 15, 0, 0), false);

                //Creamos Usuario
                UsuarioCEN usuarioCEN = new UsuarioCEN ();
                int usuarioID = usuarioCEN.New_ ("gaspar@gmail.com", "gaspar_pass", new DateTime (2001, 1, 1, 9, 0, 0));



                //------Tests------//

                //getReservasFromRegistrado(), getReservasFromRestauranteYRegistrado(), getReservasFromRegistradoFinal();
                IList<ReservaEN> ReservasDelUsuarioRegistrado = new List<ReservaEN>();
                System.Console.WriteLine ();
                System.Console.WriteLine ("----------------ALGUNOS METODOS DE RESERVA----------------");

                ReservaCAD reservaCAD = new ReservaCAD ();


                System.Console.WriteLine ("Reservas del usuario registrado: ");
                ReservasDelUsuarioRegistrado = reservaCAD.GetReservasFromRegistrado (diegoID);
                foreach (var p in ReservasDelUsuarioRegistrado) {
                        System.Console.WriteLine (p.Id);
                }

                System.Console.WriteLine ("-----");

                System.Console.WriteLine ("Reservas del usuario registrado para un restaurante: ");
                IList<ReservaEN> ReservasDelUsuarioRegistradoYRestaurante = new List<ReservaEN>();
                ReservasDelUsuarioRegistradoYRestaurante = reservaCAD.GetReservasFromRestauranteYRegistrado (diegoID, forkID);
                foreach (var p in ReservasDelUsuarioRegistradoYRestaurante) {
                        System.Console.WriteLine (p.Id);
                }

                System.Console.WriteLine ("-----");

                System.Console.WriteLine ("Reservas del usuario registrado no finalizadas: ");
                IList<ReservaEN> ReservasDelUsuarioRegistradoPorFinal = new List<ReservaEN>();
                ReservasDelUsuarioRegistradoPorFinal = reservaCAD.GetReservasFromRegistradoFinal (diegoID, false);
                foreach (var p in ReservasDelUsuarioRegistradoPorFinal) {
                        System.Console.WriteLine (p.Id);
                }

                System.Console.WriteLine ("-----");




                System.Console.WriteLine ("----- Cambiar estado de una reserva----------");

                ReservaEN reservaEN = reserva1CEN.ReadOID (reserva1ID);

                System.Console.WriteLine ("Estado original de la reserva con id: " + reservaEN.Id + " -> " + reservaEN.Estado);
                System.Console.WriteLine ();


                reserva1CEN.CambiarEstado (EstadoReservaEnum.cancelada, reserva1ID);
                reservaEN = reserva1CEN.ReadOID (reserva1ID);

                System.Console.WriteLine ("Estado actual de la reserva con id: " + reservaEN.Id + " -> " + reservaEN.Estado);

                //agregarDireccion(), getDireccion(), agregarHorarioSemana(), getHorarioSemana(), agregarHorarioDia(), GetHorarioDiaFromHorarioSemana();
                System.Console.WriteLine ();
                System.Console.WriteLine ("----------------ALGUNOS METODOS DE RESTAURANTE, HORARIOSEMANA Y HORARIODIA----------------");
                RestauranteCAD restauranteCAD = new RestauranteCAD ();
                RestauranteEN restauranteEN = restauranteCAD.ReadOIDDefault (forkID);

                System.Console.WriteLine ("Le agregamos una direccion");
                restauranteCAD.AgregarDireccion (forkID, direccionID);
                System.Console.WriteLine ("La direccion del restaurante con id: " + restauranteEN.Id + " es: " + restauranteCAD.GetDireccion (forkID).Id);

                System.Console.WriteLine ("-----");
                System.Console.WriteLine ("Le agregamos al HorarioSemana un par de HorariosDia");
                IList<int> HorariosDelDia = new List<int>();
                HorariosDelDia.Add (horarioDia1ID);
                HorariosDelDia.Add (horarioDia2ID);

                HorarioSemanaCAD HorarioSemanaCAD = new HorarioSemanaCAD ();
                HorarioSemanaCAD.AgregarHorarioDia (horarioSem1ID, HorariosDelDia);

                System.Console.WriteLine ("-----");
                System.Console.WriteLine ("Estos son los horarios del dia para el Horario Semana del Restaurante: ");
                IList<HorarioDiaEN> HorariosDia = new List<HorarioDiaEN>();
                HorarioDiaCAD horarioDiaCAD = new HorarioDiaCAD ();
                HorariosDia = horarioDiaCAD.GetHorariosDiaFromHorarioSemana (horarioSem1ID);
                foreach (var p in HorariosDia) {
                        System.Console.WriteLine (p.Dia + ": " + p.Id);
                }

                System.Console.WriteLine ("-----");
                System.Console.WriteLine ("Le agregamos el HorarioSemana al Restaurante");
                restauranteCAD.AgregarHorarioSemana (forkID, horarioSem1ID);
                System.Console.WriteLine ("El HorarioSemana del restaurante con id: " + restauranteEN.Id + " es: " + restauranteCAD.GetHorarioSemana (forkID));


                //getOpinionsFromRegistrado(), getOpinionsFromRestauranteYRegistradoByValoracion();
                System.Console.WriteLine ();
                System.Console.WriteLine ("----------------ALGUNOS METODOS DE OPINION----------------");
                OpinionCAD OpinionCAD = new OpinionCAD ();
                IList<OpinionEN> Opiniones = new List<OpinionEN>();
                System.Console.WriteLine ("Estas son las opiniones del UsuarioRegistrado con Id " + diegoID + ": ");
                Opiniones = OpinionCAD.GetOpinionsFromRegistrado (diegoID);
                foreach (var p in Opiniones) {
                        System.Console.WriteLine (p.Id);
                }

                System.Console.WriteLine ("-----");
                System.Console.WriteLine ("Estas son las opiniones del UsuarioRegistrado con Id " + diegoID + " del restaurante con Id " + forkID + "que tienen una valoracion Media: ");
                Opiniones = new List<OpinionEN>();
                Opiniones = OpinionCAD.GetOpinionsFromRegistradoYRestauranteByValoracion (diegoID, ValoracionEnum.media, forkID);
                foreach (var p in Opiniones) {
                        System.Console.WriteLine (p.Id);
                }

                //agregarUsuario(), agregarReserva(), agregarOpinion(), desvincularOpinion(), getUsuario(), getReserva();
                System.Console.WriteLine ();
                System.Console.WriteLine ("----------------ALGUNOS METODOS DE NOTIFICACION----------------");
                System.Console.WriteLine ("Le agregamos a la Notificacion con id " + notificacionID + " un usuario, una reserva y una opinion");
                NotificacionCAD NotificacionCAD = new NotificacionCAD ();
                NotificacionCAD.AgregarUsuario (notificacionID, diegoID);
                NotificacionCAD.AgregarReserva (notificacionID, reserva1ID);
                NotificacionCAD.AgregarOpinion (notificacionID, opinionID);
                System.Console.WriteLine ();
                System.Console.WriteLine ("-----");
                System.Console.WriteLine ("Le quitamos a la Notificacion con id " + notificacionID + "la opinion que tiene agregada");
                NotificacionCAD.DesvincularOpinion (notificacionID, opinionID);

                System.Console.WriteLine ();
                System.Console.WriteLine ("-----");
                UsuarioEN usu = NotificacionCAD.GetUsuario (notificacionID);
                ReservaEN res = NotificacionCAD.GetReserva (notificacionID);
                System.Console.WriteLine ("Estos son el usuario: " + usu + " y la reserva: " + res + " vinculados a la Notificacion con id " + notificacionID + " : ");

                System.Console.WriteLine ();
                System.Console.WriteLine ("---------Hacemos el Login de Usuario----------");
                UsuarioCEN usu2 = new UsuarioCEN ();


                String res2 = usu2.Login (diegoID, "diego_pass");
                System.Console.WriteLine ("Login " + res2);



                registrado_diegoCEN.AgregarDireccion (diegoID, direccionID);




                System.Console.WriteLine ();
                System.Console.WriteLine ("---------Comprobar la direcci�n del registrado----------");

                DireccionEN direccionEN = registrado_diegoCEN.GetDireccion (diegoID);
                System.Console.WriteLine ();
                System.Console.WriteLine ("Direcci�n del registrado con id: " + diegoID + " es " + direccionEN.Calle + " " + direccionEN.Numero);


                System.Console.WriteLine ();
                System.Console.WriteLine ("---------Modificar direcci�n----------");

                RegistradoCP registradoCP = new RegistradoCP ();

                bool ok = registradoCP.ModificarDireccion (diegoID, "Calle Castilla", "26200", 1, 88, 88);





                if (ok) {
                        System.Console.WriteLine ();
                        System.Console.WriteLine ("Nueva direcci�n del registrado con id: " + diegoID + " es " + registrado_diegoCEN.GetDireccion (diegoID).Calle + " " + registrado_diegoCEN.GetDireccion (diegoID).Numero);
                }
                else{
                        System.Console.WriteLine ();
                        System.Console.WriteLine ("Registrado sin direccion");
                }



                /*PROTECTED REGION END*/
        }
        catch (Exception ex)
        {
                System.Console.WriteLine (ex.InnerException);
                throw ex;
        }
}
}
}
