using System;
using System.Data;
using MySql.Data;
using System.Text;
using seguridad.entidades;
using Gtk;
using System.Collections.Generic;

namespace seguridad.datos
{
    public class dtRoles
    {
        Conexion con = new Conexion();
        MessageDialog ms = null;
        StringBuilder sb = new StringBuilder();

        #region metodos
        public bool GuardarRol(Tbl_user tus)
        {
            bool guardado = false; // esto es una bandera
            int x = 0; //variable de control
            sb.Clear();

            //MessageDialog ms = null;
            //StringBuilder sb = new StringBuilder();
            sb.Append("USE seguridad;");
            sb.Append("INSERT INTO User");
            sb.Append("(User.User, User.Pws, User.Nombres, User.Apellidos, User.Email, User.Estado)");
            sb.Append("VALUES ('" + tus.User + "','" + tus.Pwd + "','" + tus.Nombres + "','" + tus.Apellidos1 + "','" + tus.Email + "','" + 1 + "')");

            try
            {
                con.abrirConexion();
                x = con.Ejecutar(CommandType.Text, sb.ToString());

                if (x > 0)
                {
                    guardado = true;
                    ms = new MessageDialog(null, DialogFlags.Modal,
                    MessageType.Info, ButtonsType.Ok, "se guardo el usuario con exito!!!");
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

        public List<Tbl_rol> cbxRol()
        {
            sb.Clear();
            List<Tbl_rol> ListRol = new List<Tbl_rol>();
            IDataReader idr = null;
            sb.Append("USE seguridad;");
            sb.Append("SELECT Rol.idRol, Rol.Rol FROM seguridad.Rol WHERE Rol.Estado <> 3;");

            try
            {
                con.abrirConexion();
                idr = con.Leer(CommandType.Text, sb.ToString());
                while (idr.Read())
                {
                    Tbl_rol trol = new Tbl_rol()
                    {
                        Id_rol = (Int32)idr["idRol"],
                        Rol = idr["Rol"].ToString(),
                    };
                    ListRol.Add(trol);
                }
                idr.Close();
                return ListRol;
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
        public dtRoles()
        {
        }
    }
}
