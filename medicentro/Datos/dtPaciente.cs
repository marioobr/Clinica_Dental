using System;
using System.Data;
using MySql.Data;
using System.Text;
using medicentro.Entidades;
using medicentro.Datos;
using Gtk;
using System.Collections.Generic;



namespace medicentro.Datos
{
    public class dtPaciente
    {


        Conexion con = new Conexion();
        MessageDialog ms = null;
        StringBuilder sb = new StringBuilder();

        #region metodos
        public bool GuardarPaciente(Paciente pa)
        {
            bool guardado = false; // esto es una bandera
            int x = 0; //variable de control
            sb.Clear();

            //MessageDialog ms = null;
            //StringBuilder sb = new StringBuilder();

            sb.Append("USE ClinicaDental;");
            sb.Append("INSERT INTO ClinicaDental.Paciente");
            sb.Append("(idPaciente,Cedula,NoExpediente,Nombres,Apellidos,Edad,Sexo, Telefono, Direccion, Correo, Estado)");
            sb.Append("VALUES (NULL,'" + pa.Cedula + "','" + pa.No_expediente + "','" + pa.Nombre_paciente + "','" + pa.Apellido_paciente + "','" + pa.Edad_paciente + "','" + pa.Sexo_paciente + "','" + pa.Telefono_pacientes + "','" + pa.Direccion_paciente + "','" + pa.Correo_paciente + "','" + 1 + "')");

            try
            {
                con.abrirConexion();
                x = con.Ejecutar(CommandType.Text, sb.ToString());

                if (x > 0)
                {
                    guardado = true;
                    ms = new MessageDialog(null, DialogFlags.Modal,
                    MessageType.Info, ButtonsType.Ok, "El Paciente se ha guardado con exito!!!");
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

        public bool ExistePaciente(Paciente pa)
        {
            bool existe = false;
            IDataReader idr = null;
            //StringBuilder sb = new StringBuilder();
            sb.Clear();
            sb.Append("USE ClinicaDental;");
            sb.Append("SELECT * FROM `Paciente` WHERE `idPaciente` = " + "'" + pa.Id_paciente + "';");

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

        public ListStore ListarPaciente()
        {
            ListStore datos = new ListStore(typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string));
            //StringBuilder sb = new StringBuilder();
            //MessageDialog ms = null;
            IDataReader dr = null;
            sb.Clear();
            sb.Append("USE ClinicaDental;");
            sb.Append("SELECT `Paciente`.`idPaciente`, `Paciente`.`Cedula`, `Paciente`.`NoExpediente`, `Paciente`.`Nombres`,`Paciente`.`Apellidos`,`Paciente`.`Edad`, CASE Paciente.Sexo WHEN 1 THEN 'Masculino' WHEN 0 THEN 'Femenino' END , `Paciente`.`Telefono`, `Paciente`.`Direccion`, `Paciente`.`Correo` FROM `ClinicaDental`.`Paciente` WHERE `Paciente`.`Estado` <> 3;");

            try
            {
                con.abrirConexion();
                dr = con.Leer(CommandType.Text, sb.ToString());
                while (dr.Read())
                {
                    datos.AppendValues(dr[0].ToString(), dr[1].ToString(),
                    dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), dr[8].ToString(), dr[9].ToString());
                    //dr.close();
                }
                return datos;
            }
            catch (Exception e)
            {
                ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Error, ButtonsType.Ok, e.Message);
                ms.Run();
                ms.Destroy();
                throw;
            }
            finally
            {
                dr.Close();
                con.CerrarConexion();
            }
        }//fin de metodo
        #endregion

       
        public int getIdPaciente(String pa)
        {
            int existe = 0; //bandera
            IDataReader idr = null;
            sb.Clear();
            sb.Append("USE ClinicaDental;");
            sb.Append("SELECT idPaciente FROM Paciente WHERE Paciente =" + "'" + pa + "';");

            

            try
            {
                con.abrirConexion();
                idr = con.Leer(CommandType.Text, sb.ToString());
                if (idr.Read())
                {
                    existe = (Int32)idr["idPaciente"];
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




        public bool ActualizarPaciente(Paciente pa)
        {
            bool actualizado = false;
            int x = 0;

            sb.Clear();
            sb.Append("USE ClinicaDental;");
            sb.Append("UPDATE ClinicaDental.Paciente SET Paciente.Cedula = '" + pa.Cedula + "',");
            sb.Append("Nombres = '" + pa.Nombre_paciente + "',");
            sb.Append("Paciente.Apellidos = '" + pa.Apellido_paciente+ "',");
            sb.Append("Paciente.Edad = '" + pa.Edad_paciente + "',");
            sb.Append("Paciente.Telefono = '" + pa.Telefono_pacientes + "'");
            sb.Append("Paciente.Direccion = '" + pa.Direccion_paciente + "'");
            sb.Append("Paciente.Correo = '" + pa.Correo_paciente + "'");
            sb.Append("WHERE Paciente.idPaciente = " + pa.Id_paciente + ";");


            try
            {
                con.abrirConexion();
                x = con.Ejecutar(CommandType.Text, sb.ToString());

                if (x > 0)
                {
                    actualizado = true;
                }
                //actualizado = cone.Ejecutar(CommandType.Text,sb.ToString());
                return actualizado;
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


        public Int32 EliminarPaciente(Paciente pa)
        {
            int eliminado;
            sb.Clear();
            //MessageDialog ms = null;
            //StringBuilder sb = new StringBuilder();
            sb.Append("USE ClinicaDental;");
            sb.Append("UPDATE ClinicaDental.Paciente set Paciente.Estado = '3' WHERE Paciente.idPaciente = " + pa.Id_paciente + ";");

            try
            {
                con.abrirConexion();
                eliminado = con.Ejecutar(CommandType.Text, sb.ToString());
                return eliminado;
            }
            catch (Exception e)
            {
                ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Error, ButtonsType.Ok, e.Message);
                ms.Run();
                ms.Destroy();
                throw;
            }
            finally
            {
                con.CerrarConexion();
            }
        }

        public ListStore BuscarPaciente(String Cadena)
        {
            ListStore datos = new ListStore(typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string));

            //StringBuilder sb = new StringBuilder();
            //MessageDialog ms = null;

            IDataReader idr = null;
            sb.Clear();
            sb.Append("USE ClinicaDental;");
            sb.Append("SELECT `idPaciente`, `Cedula`, `NoExpediente`, `Nombres`,`Apellidos`,`Edad`,`Sexo`,`Telefono`, `Direccion`, `Correo` FROM Paciente");
            sb.Append("WHERE (estado <>3) ");
            sb.Append("AND (`Nombres` like '%" + Cadena + "%')");
            sb.Append("OR `Apellidos` like '%" + Cadena + "%');");


            try
            {
                con.abrirConexion();
                idr = con.Leer(CommandType.Text, sb.ToString());
                while (idr.Read())
                {
                    datos.AppendValues(idr[0].ToString(), idr[1].ToString(),
                    idr[2].ToString(), idr[3].ToString(), idr[4].ToString(), idr[5].ToString(), idr[6].ToString(), idr[7].ToString(), idr[8].ToString(), idr[9].ToString());
                    //dr.close();
                }
                return datos;
            }
            catch (Exception e)
            {
                ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Error, ButtonsType.Ok, e.Message);
                ms.Run();
                ms.Destroy();
                //Console.WriteLine("Error> " + e);
                throw;
            }
            finally
            {
                idr.Close();
                con.CerrarConexion();
            }
        }//fin de metodo


    }
}

