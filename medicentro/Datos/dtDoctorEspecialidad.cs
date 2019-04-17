using System;
using System.Data;
using MySql.Data;
using System.Text;
using medicentro.Entidades;
using medicentro.Entidades.Doctores;
using Gtk;
using System.Collections.Generic;
using medicentro.Entidades.Doctor;

namespace medicentro.Datos
{
    public class dtDoctorEspecialidad
    {
        Conexion con = new Conexion();
        MessageDialog ms = null;
        StringBuilder sb = new StringBuilder();

        #region metodos
        public ListStore ListarDoctorEsp()
        {
            ListStore datos = new ListStore(typeof(string),typeof(string), typeof(string), typeof(string), typeof(string), 
                typeof(string), typeof(string), typeof(string), typeof(string));


            IDataReader dr = null;
            sb.Clear();
            sb.Append("USE ClinicaDental;");
            sb.Append("SELECT idDoctor, Cedula, CodMINSA, Nombres, Apellidos, Telefono, CASE Sexo WHEN 1 THEN 'Masculino' WHEN 0 THEN 'Femenino' END, idEspecialidad, Especialidad FROM DoctorEspecialidad;");

            try
            {
                con.abrirConexion();
                dr = con.Leer(CommandType.Text, sb.ToString());
                while (dr.Read())
                {
                    datos.AppendValues(dr[0].ToString(), dr[1].ToString(),
                        dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), dr[8].ToString());

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

        public bool GuardarDoctorEspecialidad(DoctorEspecialidad tde)
        {
            bool guardado = false; //bandera
            int x = 0; //variable de control
            sb.Clear();
            sb.Append("USE ClinicaDental;");
            sb.Append("INSERT INTO Especi_Doctor");
            sb.Append("(Doctor_idDoctor, Especialidad_idEspecialidad)");
            sb.Append(" VALUES('" + tde.Id_Doctor + "','" + tde.Id_especialidad + "');");
            try
            {
                con.abrirConexion();
                x = con.Ejecutar(CommandType.Text, sb.ToString());

                if (x > 0)
                {
                    guardado = true;
                    /* ms = new MessageDialog(null,DialogFlags.Modal,
                     MessageType.Info,ButtonsType.Ok,"Se guardo el usuario con exito!!!");
                     ms.Run();
                     ms.Destroy();*/
                }
                return guardado;
            }
            catch (Exception e)
            {
                ms = new MessageDialog(null, DialogFlags.Modal,
                    MessageType.Error, ButtonsType.Ok, e.Message);
                ms.Run();
                ms.Destroy();
                Console.WriteLine("ERROR: " + e.Message);
                Console.WriteLine("ERROR: " + e.StackTrace);
                throw;
            }
            finally
            {
                con.CerrarConexion();
            }

        }//fin del metodo

        public Int32 delDoctorEsp(DoctorEspecialidad tde)
        {
            int eliminado;
            sb.Clear();
            sb.Append("USE ClinicaDental;");
            sb.Append("DELETE FROM Especi_Doctor WHERE Doctor_idDoctor =" + tde.Id_Doctor + " ");
            sb.Append("AND Especialidad_idEspecialidad =" + tde.Id_especialidad + ";");

            try
            {

                con.abrirConexion();
                eliminado = con.Ejecutar(CommandType.Text, sb.ToString());
                return eliminado;
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
                con.CerrarConexion();
            }

        }//fin del metodo

        public bool existeDocEsp(DoctorEspecialidad tde)
        {
            bool existe = false; //bandera
            IDataReader idr = null;
            sb.Clear();
            sb.Append("USE ClinicaDental;");
            sb.Append("SELECT * FROM Especi_Doctor WHERE Doctor_idDoctor =" + tde.Id_Doctor + " ");
            sb.Append("AND Especialidad_idEspecialidad=" + tde.Id_especialidad + ";");

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



        #endregion
        public dtDoctorEspecialidad()
        {
        }
    }
}
