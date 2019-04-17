using System;
using System.Data;
using MySql.Data;
using Gtk;
using System.Text;
using medicentro.Entidades;
using System.Collections.Generic;
using medicentro.Datos;
using medicentro.Entidades.Seguridad;

namespace Genesis.Datos
{
    public class DtUser
    {
        Conexion con = new Conexion();
        MessageDialog ms = null;
        StringBuilder sb = new StringBuilder();

        #region metodos
        public bool GuardarUsuario(User tus)
        {
            bool guardado = false; // bandera
            int x = 0; // variable de control
            sb.Clear();
            sb.Append("INSERT INTO User");
            sb.Append("(User, pwd, Nombre, Apellidos, Email, Estado)");
            sb.Append(" VALUES('" + tus.Userdes + "','" + tus.Pwd + "','" + tus.Nombre + "','" + tus.Apellidos + "','" + tus.Email + "','" + 1 + "')");
            try
            {
                con.abrirConexion();
                x = con.Ejecutar(CommandType.Text, sb.ToString());
                //ms = new MessageDialog(null,DialogFlags.Modal,
                //  MessageType.Info,ButtonsType.Ok,"Se guarda la categoria con existo!!!");
                //ms.Run();
                //ms.Destroy();
                if (x > 0)
                {
                    guardado = true;
                }
                return guardado;
            }
            catch (Exception e)
            {
                ms = new MessageDialog(null, DialogFlags.Modal,
                    MessageType.Error, ButtonsType.Ok, e.Message);
                ms.Run();
                ms.Destroy();
                Console.WriteLine("DT: ERROR=" + e.Message);
                Console.WriteLine("DT: ERROR=" + e.StackTrace);
                throw;
            }
            finally
            {
                con.CerrarConexion();
            }

        }//fin del metodo

        public ListStore ListarUsuarios()
        {
            ListStore datos = new ListStore(typeof(string),
                typeof(string), typeof(string), typeof(string), typeof(string));


            IDataReader dr = null;
            sb.Clear();
            sb.Append("SELECT idUser, User, Nombre, Apellidos, Email FROM User WHERE Estado<>3;");
            try
            {
                con.abrirConexion();
                dr = con.Leer(CommandType.Text, sb.ToString());
                while (dr.Read())
                {
                    datos.AppendValues(dr[0].ToString(), dr[1].ToString(),
                        dr[2].ToString(), dr[3].ToString(), dr[4].ToString());
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


        public bool existeUser(User tus)
        {
            bool existe = false; //bandera
            IDataReader idr = null;
            sb.Clear();
            sb.Append("USE ClinicaDental;");
            sb.Append("SELECT * FROM User WHERE User=" + "'" + tus.Userdes + "';");

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

        public int getIdUser(String user)
        {
            int existe = 0; //bandera
            IDataReader idr = null;
            sb.Clear();
            sb.Append("USE ClinicaDental;");
            sb.Append("SELECT IdUser FROM User WHERE User=" + "'" + user + "';");

            try
            {
                con.abrirConexion();
                idr = con.Leer(CommandType.Text, sb.ToString());
                if (idr.Read())
                {
                    existe = (Int32)idr["IdUser"];
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

        public bool existeEmail(User tus)
        {
            bool existe = false; //bandera
            IDataReader idr = null;
            sb.Clear();
            sb.Append("USE Seguridad;");
            sb.Append("SELECT * FROM User WHERE Email=" + "'" + tus.Email + "';");

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


        public Int32 EliminarUser(User tus)
        {
            int eliminado;
            sb.Clear();
            sb.Append("UPDATE User SET Estado = 3 WHERE idUser=" + tus.Id_user + "");

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

        public bool ActualizarUser(User tus)
        {
            bool actualizado = false;
            int x = 0;
            sb.Clear();
            sb.Append("UPDATE User SET User = '" + tus.Userdes + "',");
            sb.Append("pwd = '" + tus.Pwd + "',");
            sb.Append("Nombre = '" + tus.Nombre + "',");
            sb.Append("Apellidos = '" + tus.Apellidos + "',");
            sb.Append("Email = '" + tus.Email + "',");
            sb.Append("Estado = '" + tus.Estado_user + "'");
            sb.Append("WHERE idUser = " + tus.Id_user + ";");

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


        public ListStore buscarUsuarios(String cadena)
        {
            ListStore datos = new ListStore(typeof(string),
                typeof(string), typeof(string), typeof(string), typeof(string));
            IDataReader dr = null;
            sb.Clear();
            sb.Append("USE ClinicaDental;");
            sb.Append("SELECT idUser, User, Nombre, Apellidos, Email FROM User ");
            sb.Append("WHERE (estado <>3) ");
            sb.Append("AND (User like '%" + cadena + "%' ");
            sb.Append("OR Nombre like '%" + cadena + "%' ");
            sb.Append("OR Apellidos like '%" + cadena + "%'); ");
            try
            {
                con.abrirConexion();
                dr = con.Leer(CommandType.Text, sb.ToString());
                while (dr.Read())
                {
                    datos.AppendValues(dr[0].ToString(), dr[1].ToString(),
                        dr[2].ToString(), dr[3].ToString(), dr[4].ToString());
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
                Console.WriteLine("Error: " + e.Message);
                Console.WriteLine("Error: " + e.StackTrace);
                throw;
            }
            finally
            {
                dr.Close();
                con.CerrarConexion();
            }
        }//fin del metodo


        public List<User> cbxUsuarios()
        {
            List<User> listUser = new List<User>();
            IDataReader idr = null;
            sb.Clear();
            sb.Append("USE ClinicaDental;");
            sb.Append("SELECT idUser, User FROM User WHERE Estado <> '3';");

            try
            {
                con.abrirConexion();
                idr = con.Leer(CommandType.Text, sb.ToString());
                while (idr.Read())
                {
                    User tus = new User()
                    //Tbl_usuarios tus = new Tbl_usuarios()
                    {
                        Id_user = (Int32)idr["idUser"],
                        Userdes = idr["User"].ToString(),

                    };
                    listUser.Add(tus);

                }
                idr.Close();
                return listUser;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                throw;
            }
            finally
            {
                con.CerrarConexion();
            }
        }








        #endregion



        public DtUser()
        {
        }
    }
}
