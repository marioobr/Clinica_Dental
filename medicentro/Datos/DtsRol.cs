using System;
using System.Data;
using MySql.Data;
using System.Text;
using medicentro.Entidades.Seguridad;
using Gtk;
using medicentro.Datos;
using System.Collections.Generic;

namespace medicentro.Datos
{
    public class DtsRol
    {

        Conexion con = new Conexion();
        MessageDialog ms = null;
        StringBuilder sb = new StringBuilder();

        #region metodos

        public List<Rol> cbxRoles()
        {
            List<Rol> listRoles = new List<Rol>();
            IDataReader idr = null;
            sb.Clear();
            sb.Append("USE Seguridad;");
            sb.Append("SELECT id_rol,rol FROM tbl_rol WHERE estado <> '3';");

            try
            {
                con.abrirConexion();
                idr = con.Leer(CommandType.Text, sb.ToString());
                while (idr.Read())
                {
                    Rol tr = new Rol()
                    //Tbl_usuarios tus = new Tbl_usuarios()
                    {
                        Id_rol = (Int32)idr["id_rol"],
                        Roldes = idr["rol"].ToString(),

                    };
                    listRoles.Add(tr);

                }
                idr.Close();
                return listRoles;

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
        }//fin del metodo

        public int getIdRol(String rol)
        {
            int existe = 0; //bandera
            IDataReader idr = null;
            sb.Clear();
            sb.Append("USE Seguridad;");
            sb.Append("SELECT id_rol FROM tbl_rol WHERE rol=" + "'" + rol + "';");

            try
            {
                con.abrirConexion();
                idr = con.Leer(CommandType.Text, sb.ToString());
                if (idr.Read())
                {
                    existe = (Int32)idr["id_rol"];
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

        public DtsRol()
        {

        }

    }


}
#endregion
