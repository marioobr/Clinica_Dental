using System;
using System.Data;
using MySql.Data;
using System.Text;
using medicentro.Entidades.Seguridad;
using medicentro.Datos;
using Gtk;
using System.Collections.Generic;

namespace medicentro.Datos
{
    public class DtsUser
    {

        Conexion con = new Conexion();
        MessageDialog ms = null;
        StringBuilder sb = new StringBuilder();
        User us = new User();
        UserRol rus = new UserRol();
        Rol rol = new Rol();
        DtsRol dtRoles = new DtsRol();
        DtsUser dtUser = new DtsUser();

        public bool ExisteEmail(User tus)
        {
            bool existe = false; //bandera
            IDataReader idr = null;
            sb.Clear();
            sb.Append("USE ClinicaDental;");
            sb.Append("SELECT * FROM  User WHERE Email=" + "'" + tus.Email + "';");

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
            sb.Append("SELECT idUser FROM User WHERE user=" + "'" + user + "';");

            try
            {
                con.abrirConexion();
                idr = con.Leer(CommandType.Text, sb.ToString());
                if (idr.Read())
                {
                    existe = (Int32)idr["idUser"];
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

        public bool GuardarUsuario(User us)
        {
            bool guardado = false; // bandera
            int x = 0; // variable de control
            sb.Clear();
            sb.Append("USE ClinicaDental;");
            sb.Append("INSERT INTO User");
            sb.Append("(User, Pwd, Nombre, Apellidos, Email, Estado)");
            sb.Append(" VALUES('" + us.Userdes + "','" + us.Pwd + "','" + us.Nombre + "','" + us.Apellidos + "','" + us.Email + "','" + 1 + "')");
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

        public List<User> cbxUsuarios()
        {
            List<User> listUser = new List<User>();
            IDataReader idr = null;
            sb.Clear();
            sb.Append("USE ClinicaDental;");
            sb.Append("SELECT idUser, User FROM User WHERE estado <> '3';");

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



        public ListStore ListarUsuarios()
        {
            ListStore datos = new ListStore(typeof(string),
                typeof(string), typeof(string), typeof(string), typeof(string));


            IDataReader dr = null;
            sb.Clear();
            sb.Append("SELECT idUser, User, Nombre, Apellidos, Email FROM User WHERE estado <> 3;");
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



        public bool ExisteUser(User tus)
        {
            bool existe = false;
            IDataReader idr = null;
           // StringBuilder sb = new StringBuilder();
            sb.Clear();
            sb.Append("USE ClinicaDental;");
            sb.Append("SELECT * FROM User WHERE User = " + "'" + us.Userdes + "';");

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
        }

        internal static int EliminarRoles()
        {
            throw new NotImplementedException();
        }

        public Int32 EliminarUsuario(User us)
        {


            int eliminado;
            sb.Clear();
            //MessageDialog ms = null;
            //StringBuilder sb = new StringBuilder();
            sb.Append("USE ClinicaDental;");
            sb.Append("UPDATE User set Estado = '3' WHERE idUser = " + us.Id_user + ";");

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

        public bool ActualizarUser(User tus)
        {
            bool actualizado = false;
            int x = 0;
            sb.Clear();
            sb.Append("USE ClinicaDental");
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

        public DtsUser()
        {
        }

    }
}



