using System;
using System.Data;
using MySql.Data;
using Gtk;
using System.Text;
using System.Collections.Generic;
using medicentro.Entidades.Productos;

namespace medicentro.Datos
{
    public class dtTipoProducto
    {
        Conexion con = new Conexion();
        //MessageDialog ms = null;
        StringBuilder sb = new StringBuilder();


        public List<TipoProducto> cbxTipoProd()
        {
            List<TipoProducto> listTipoProd = new List<TipoProducto>();
            IDataReader idr = null;
            sb.Clear();
            sb.Append("USE ClinicaDental;");
            sb.Append("SELECT idTipo_Producto, Descripcion FROM ClinicaDental.Tipo_Producto;");

            try
            {
                con.abrirConexion();
                idr = con.Leer(CommandType.Text, sb.ToString());
                while (idr.Read())
                {
                    TipoProducto tipoProd = new TipoProducto()
                    //Tbl_usuarios tus = new Tbl_usuarios()
                    {
                        IdTipoProducto = (Int32)idr["idTipo_Producto"],
                        Descripción1 = idr["Descripcion"].ToString()

                    };
                    listTipoProd.Add(tipoProd);

                }
                idr.Close();
                return listTipoProd;

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

        public int getIdTipoProd(String tipo)
        {
            int existe = 0; //bandera
            IDataReader idr = null;
            sb.Clear();
            sb.Append("USE ClinicaDental;");
            sb.Append("SELECT idTipo_Producto FROM Tipo_Producto WHERE Descripcion =" + "'" + tipo + "';");

            try
            {
                con.abrirConexion();
                idr = con.Leer(CommandType.Text, sb.ToString());
                if (idr.Read())
                {
                    existe = (Int32)idr["idTipo_Producto"];
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

        public dtTipoProducto()
            {
            }
        }
}
