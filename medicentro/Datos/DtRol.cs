using System;
using medicentro.Datos;
using medicentro.Entidades;
using Gtk;
using System.Collections.Generic;
using System.Text;
using System.Data;
using medicentro.Entidades.Seguridad;

namespace Genesis.Datos
{
    public class DtRol
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
            sb.Append("USE CLinicaDental;");
            sb.Append("SELECT idRol, Rol FROM Rol WHERE Estado <> '3';");

            try
            {
                con.abrirConexion();
                idr = con.Leer(CommandType.Text, sb.ToString());
                while (idr.Read())
                {
                    Rol tr = new Rol()
                    //Tbl_usuarios tus = new Tbl_usuarios()
                    {
                        Id_rol = (Int32)idr["idRol"],
                        Roldes = idr["Rol"].ToString(),

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
            sb.Append("USE ClinicaDental;");
            sb.Append("SELECT idRol FROM Rol WHERE Rol =" + "'" + rol + "';");

            try
            {
                con.abrirConexion();
                idr = con.Leer(CommandType.Text, sb.ToString());
                if (idr.Read())
                {
                    existe = (Int32)idr["idRol"];
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


        public DtRol()
        {
        }
    }
}
