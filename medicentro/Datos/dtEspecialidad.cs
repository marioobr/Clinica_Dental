using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Gtk;
using medicentro.Entidades;


namespace medicentro.Datos
{
    public class dtEspecialidad
    {
        Conexion con = new Conexion();
        MessageDialog ms = null;
        StringBuilder sb = new StringBuilder();


        public bool GuardarEspecialidad(Especialidad dtEsp)
        {
            bool guardado = false; // esto es una bandera
            int x = 0; //variable de control
            sb.Clear();

            //MessageDialog ms = null;
            //StringBuilder sb = new StringBuilder();
            sb.Append("USE ClinicaDental;");
            sb.Append("INSERT INTO ClinicaDental.Especialidad");
            sb.Append("(idEspecialidad, Especialidad, Descripcion, Estado)");
            sb.Append("VALUES (NULL,'" + dtEsp.Nomb_especialidad + "','" + dtEsp.Descripcion + "', 1);");

            try
            {
                con.abrirConexion();
                x = con.Ejecutar(CommandType.Text, sb.ToString());

                if (x > 0)
                {
                    guardado = true;
                    ms = new MessageDialog(null, DialogFlags.Modal,
                    MessageType.Info, ButtonsType.Ok, "Se ha guardado la especialidad con exito!!!");
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
        }//fin del metodo


        public Int32 EliminarEspecialidad(Especialidad dtEsp)
        {
            int eliminado;
            sb.Clear();
            //MessageDialog ms = null;
            //StringBuilder sb = new StringBuilder();
            sb.Append("USE ClinicaDental;");
            sb.Append("UPDATE ClinicaDental.Especialidad set Especialidad.Estado = '3' WHERE Especialidad.idEspecialidad = " + dtEsp.Id_especialidad + ";");

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


        public bool ActualizarEspecialidad(Especialidad dtEsp)
        {
            bool Actualizado = false;
            int x = 0;
            sb.Clear();
            sb.Append("USE ClinicaDental;");
            sb.Append("UPDATE ClinicaDental.Especialidad SET Especialidad.Especialidad = ' " + dtEsp.Nomb_especialidad + "',");
            sb.Append("Especialidad.Descripcion = ' " + dtEsp.Descripcion + "'");
            sb.Append("WHERE Especialidad.idEspecialidad = " + dtEsp.Id_especialidad + ";");

            try
            {
                con.abrirConexion();
                x = con.Ejecutar(CommandType.Text, sb.ToString());

                if (x > 0)
                {
                    Actualizado = true;
                }
                return Actualizado;
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


        }//fin del metodo



        public bool ExisteEspecialidad(Especialidad dtEsp)
        {
            bool existe = false;
            IDataReader idr = null;
            //StringBuilder sb = new StringBuilder();
            sb.Clear();
            sb.Append("USE ClinicaDental;");
            sb.Append("SELECT * FROM `Especialidad` WHERE `idEspecialidad` = " + "'" + dtEsp.Id_especialidad + "';");

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


        public ListStore ListarEspecialidades()
        {
            ListStore datos = new ListStore(typeof(string), typeof(string),
            typeof(string), typeof(string));
            //StringBuilder sb = new StringBuilder();
            //MessageDialog ms = null;
            IDataReader dr = null;
            sb.Clear();
            sb.Append("USE ClinicaDental;");
            sb.Append("SELECT `Especialidad`.`idEspecialidad`, `Especialidad`.`Especialidad`, `Especialidad`.`Descripcion` FROM `ClinicaDental`.`Especialidad` WHERE `Especialidad`.`Estado` <> 3");

            try
            {
                con.abrirConexion();
                dr = con.Leer(CommandType.Text, sb.ToString());
                while (dr.Read())
                {
                    datos.AppendValues(dr[0].ToString(), dr[1].ToString(),
                    dr[2].ToString());
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

        public ListStore BuscarEspecialidad(String Cadena)
        {
            ListStore datos = new ListStore(typeof(string), typeof(string),
            typeof(string), typeof(string));
            //StringBuilder sb = new StringBuilder();
            //MessageDialog ms = null;
            IDataReader idr = null;
            sb.Clear();
            sb.Append("USE ClinicaDental;");
            sb.Append("SELECT `Especialidad`.`idEspecialidad`, `Especialidad`.`Especialidad`, `Especialidad`.`Descripcion` FROM `ClinicaDental`.`Especialidad` ");
            sb.Append("WHERE `Especialidad`.`Estado` <> 3 ");
            sb.Append("AND (`Especialidad`.`Especialidad` like '%" + Cadena + "%' ");
            sb.Append("OR `Especialidad`.`Descripcion` like '%" + Cadena + "%');");

            try
            {
                con.abrirConexion();
                idr = con.Leer(CommandType.Text, sb.ToString());
                while (idr.Read())
                {
                    datos.AppendValues(idr[0].ToString(), idr[1].ToString(),idr[2].ToString());
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

        public int getIdEspecialidad(String especialidad)
        {
            int existe = 0; //bandera
            IDataReader idr = null;
            sb.Clear();
            sb.Append("USE ClinicaDental;");
            sb.Append("SELECT idEspecialidad FROM Especialidad WHERE especialidad=" + "'" + especialidad + "';");

            try
            {
                con.abrirConexion();
                idr = con.Leer(CommandType.Text, sb.ToString());
                if (idr.Read())
                {
                    existe = (Int32)idr["idEspecialidad"];
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



        public List<Especialidad> cbxEsp()
        {
            sb.Clear();
            List<Especialidad> ListEsp = new List<Especialidad>();
            IDataReader idr = null;
            sb.Append("USE ClinicaDental;");
            sb.Append("SELECT Especialidad.idEspecialidad, Especialidad.Especialidad FROM ClinicaDental.Especialidad WHERE Especialidad.Estado <> 3;");

            try
            {
                con.abrirConexion();
                idr = con.Leer(CommandType.Text, sb.ToString());
                while (idr.Read())
                {
                    Especialidad tEsp = new Especialidad()
                    {
                        Id_especialidad = (Int32)idr["idEspecialidad"],
                        Nomb_especialidad = idr["Especialidad"].ToString(),
                    };
                    ListEsp.Add(tEsp);
                }
                idr.Close();
                return ListEsp;
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

        }


        public dtEspecialidad()
        {
        }
    }
}
