using System;
using System.Data;
using MySql.Data;
using System.Text;
using seguridad.entidades;
using Gtk;
using System.Collections.Generic;

namespace seguridad.datos
{
    public class dtUsuarios
    {
        Conexion con = new Conexion();
        MessageDialog ms = null;
        StringBuilder sb = new StringBuilder();

        #region metodos
        public bool GuardarUsuarios(Tbl_user tus)
        {
            bool guardado = false; // esto es una bandera
            int x = 0; //variable de control
            sb.Clear();

            //MessageDialog ms = null;
            //StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO User");
            sb.Append("(User.User, User.Pws, User.Nombres, User.Apellidos, User.Email, User.Estado)");
            sb.Append("VALUES ('" + tus.User + "','" + tus.Pwd +"','"+tus.Nombres+"','"+tus.Apellidos1+"','"+tus.Email+ "','" +1+ "')");

            try
            {
                con.abrirConexion();
                x = con.Ejecutar(CommandType.Text, sb.ToString());

                if(x>0)
                {
                    guardado = true;
                    ms = new MessageDialog(null, DialogFlags.Modal,
                    MessageType.Info, ButtonsType.Ok, "se guardo el usuario con exito!!!");
                    ms.Run();
                    ms.Destroy();
                }
                return guardado;
            }
            catch(Exception e)
            {
                ms = new MessageDialog(null, DialogFlags.Modal,
                     MessageType.Error, ButtonsType.Ok,e.Message);
                ms.Run();
                ms.Destroy();
                throw;
            }
        }//fin del metodo

        public ListStore ListarUsuarios()
        {
            ListStore datos = new ListStore(typeof(string), typeof(string),
            typeof(string), typeof(string), typeof(string));
            //StringBuilder sb = new StringBuilder();
            //MessageDialog ms = null;
            IDataReader dr = null;
            sb.Clear();
            sb.Append("SELECT User.idUser, User.User, User.Nombres, User.Apellidos, User.Email FROM seguridad.User WHERE User.Estado <> 3");

            try
            {
                con.abrirConexion();
                dr = con.Leer(CommandType.Text, sb.ToString());
                while(dr.Read())
                {
                    datos.AppendValues(dr[0].ToString(), dr[1].ToString(),
                    dr[2].ToString(), dr[3].ToString(), dr[4].ToString());
                    //dr.close();
                }
                return datos;
            }catch(Exception e)
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

        //Metodo para validar si el usuario existe
        public bool ExisteUser(Tbl_user tus)
        {
            bool existe = false;
            IDataReader idr = null;
            //StringBuilder sb = new StringBuilder();
            sb.Clear();
            sb.Append("USE seguridad;");
            sb.Append("SELECT * FROM `seguridad`.`User` WHERE `User`.`User` = "+"'" + tus.User + "';");

            try
            {
                con.abrirConexion();
                idr = con.Leer(CommandType.Text, sb.ToString());
                if(idr.Read())
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

        public Int32 EliminarUsuario(Tbl_user tus)
        {
            int eliminado;
            sb.Clear();
            //MessageDialog ms = null;
            //StringBuilder sb = new StringBuilder();
            sb.Append("USE seguridad;");
            sb.Append("UPDATE seguridad.User set User.Estado = '3' WHERE User.idUser = " + tus.Id_user + ";");

            try
            {
                con.abrirConexion();
                eliminado = con.Ejecutar(CommandType.Text, sb.ToString());
                return eliminado;
            }
            catch(Exception e)
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

        public bool ActualizarUser(Tbl_user tus)
        {
            bool Actualizado = false;
            int x = 0;
            sb.Clear();
            sb.Append("USE seguridad;");
            sb.Append("UPDATE seguridad.User SET User.User = ' " + tus.User+"',");
            sb.Append("User.Nombres = ' " + tus.Nombres + "',");
            sb.Append("User.Apellidos = ' " + tus.Apellidos1 + "',");
            sb.Append("User.Email = ' " + tus.Email + "',");
            sb.Append("User.Estado = ' " + tus.Estado + "'");
            sb.Append("WHERE User.idUser = " + tus.Id_user + ";");

            try
            {
                con.abrirConexion();
                x = con.Ejecutar(CommandType.Text, sb.ToString());

                if(x > 0)
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

        public ListStore BuscarUsuarios(String Cadena)
        {
            ListStore datos = new ListStore(typeof(string), typeof(string),
            typeof(string), typeof(string), typeof(string));
            //StringBuilder sb = new StringBuilder();
            //MessageDialog ms = null;
            IDataReader idr = null;
            sb.Clear();
            sb.Append("USE seguridad;");
            sb.Append("SELECT User.idUser, User.User, User.Nombres, User.Apellidos, User.Email FROM seguridad.User ");
            sb.Append("WHERE User.Estado <> 3 ");
            sb.Append("AND (User.User like '%" + Cadena + "%' ");
            sb.Append("OR User.Nombres like '%" + Cadena + "%' ");
            sb.Append("OR User.Apellidos like '%" + Cadena + "%');");

            try
            {
                con.abrirConexion();
                idr = con.Leer(CommandType.Text, sb.ToString());
                while (idr.Read())
                {
                    datos.AppendValues(idr[0].ToString(), idr[1].ToString(),
                    idr[2].ToString(), idr[3].ToString(), idr[4].ToString());
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

        public List<Tbl_user> cbxUser()
        {
            sb.Clear();
            List<Tbl_user> ListUser = new List<Tbl_user>();
            IDataReader idr = null;
            sb.Append("USE seguridad;");
            sb.Append("SELECT User.idUser, User.User FROM seguridad.User WHERE User.Estado <> 3;");

            try
            {
                con.abrirConexion();
                idr = con.Leer(CommandType.Text, sb.ToString());
                while (idr.Read())
                {
                    Tbl_user tus = new Tbl_user()
                    {
                        Id_user = (Int32)idr["idUser"],
                        User = idr["User"].ToString(),
                    };
                    ListUser.Add(tus);
                }
                idr.Close();
                return ListUser;
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
        #endregion
        public dtUsuarios()
        {
        }
    }
}
