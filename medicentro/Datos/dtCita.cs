using System;
using System.Data;
using MySql.Data;
using System.Text;
using medicentro.Entidades;
using Gtk;
using System.Collections.Generic;


namespace medicentro.Datos
{
    public class dtCita
    {
        Conexion con = new Conexion();
        MessageDialog ms = null;
        StringBuilder sb = new StringBuilder();

        #region metodos
        public bool GuardarCita(Cita cit)
        {
            bool guardado = false; // esto es una bandera
            int x = 0; //variable de control
            sb.Clear();

            //MessageDialog ms = null;
            //StringBuilder sb = new StringBuilder();

            sb.Append("USE ClinicaDental;");
            sb.Append("INSERT INTO ClinicaDental.Cita");
            sb.Append("(idCita, Fecha , HoraInicio ,Doctor_idDoctor, User_idUser, Paciente_idPaciente, Estado)");
            sb.Append("VALUES (NULL,'" + cit.Id_cita + "','" + cit.FechaCita + "','" + cit.Horaini + "','" + cit.Id_doctor + "','" + cit.Id_User + "','" + cit.Id_paciente + "','"  + 1 + "')");

            try
            {
                con.abrirConexion();
                x = con.Ejecutar(CommandType.Text, sb.ToString());

                if (x > 0)
                {
                    guardado = true;
                    ms = new MessageDialog(null, DialogFlags.Modal,
                    MessageType.Info, ButtonsType.Ok, "Se ha realizado la cita");
                    ms.Run();
                    ms.Destroy();
                }
                return guardado;
            }
            catch (Exception e)
            {
                ms = new MessageDialog(null, DialogFlags.Modal,
                     MessageType.Error, ButtonsType.Ok, e.Message);
                ms.Run();
                ms.Destroy();
                throw;
            }


           
        }

        public bool ExisteCita(Cita cit)
        {
            bool existe = false;
            IDataReader idr = null;
            //StringBuilder sb = new StringBuilder();
            sb.Clear();
            sb.Append("USE ClinicaDental;");
            sb.Append("SELECT * FROM `Cita` WHERE `idCita` = " + "'" + cit.Id_cita + "';");

            try
            {
                con.abrirConexion();
                idr = con.Leer(CommandType.Text, sb.ToString());
                if (idr.Read())
                {
                    existe = true;
                }
                return existe;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                throw;
            }
            finally
            {
                idr.Close();
                con.CerrarConexion();
            }
        }//fin del metodo
        public dtCita()
        {
        }


        public ListStore ListarCita()
        {
            ListStore datos = new ListStore(typeof(string),
                typeof(string), typeof(string), typeof(string), typeof(string));


            IDataReader dr = null;
            sb.Clear();
            sb.Append("SELECT idCita, Fecha , HoraInicio ,Doctor_idDoctor, User_idUser, Paciente_idPaciente, Estado FROM Cita WHERE estado<>3;");
            try
            {
                con.abrirConexion();
                dr = con.Leer(CommandType.Text, sb.ToString());
                while (dr.Read())
                {
                    datos.AppendValues(dr[0].ToString(), dr[1].ToString(),
                        dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString());
                    //dr.Close();
                }//fin de while
                return datos;
            }
            catch (Exception e)
            {
                ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Error,
                    ButtonsType.Ok, e.Message);
                ms.Run();
                ms.Destroy();
                throw;
            }
            finally
            {
                dr.Close();
                con.CerrarConexion();
            }
        }//fin del metodo


    }

}

#endregion