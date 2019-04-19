using System;
using System.Data;
using MySql.Data;
using Gtk;
using System.Text;
using System.Collections.Generic;
using medicentro.Entidades.Productos;
using medicentro.Entidades;

namespace medicentro.Datos
{
    public class dtMovimiento
    {
        Conexion con = new Conexion();
        //MessageDialog ms = null;
        StringBuilder sb = new StringBuilder();


        public List<Movimiento> cbxMovimiento()
        {
            List <Movimiento> listMovimiento = new List<Movimiento>();
            IDataReader idr = null;
            sb.Clear();
            sb.Append("USE ClinicaDental;");
            sb.Append("SELECT idMovimiento, Descripcion FROM Movimiento;");

            try
            {
                con.abrirConexion();
                idr = con.Leer(CommandType.Text, sb.ToString());
                while (idr.Read())
                {
                    Movimiento movi = new Movimiento()
                    //Tbl_usuarios tus = new Tbl_usuarios()
                    {
                        Id_movimiento = (Int32)idr["idMovimiento"],
                        Desc_movimiento = idr["Descripcion"].ToString()

                    };
                    listMovimiento.Add(movi);

                }
                idr.Close();
                return listMovimiento;

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

        public int getidMovimiento(String movimiento)
        {
            int existe = 0; //bandera
            IDataReader idr = null;
            sb.Clear();
            sb.Append("USE ClinicaDental;");
            sb.Append("SELECT idMovimiento FROM Movimiento WHERE Descripcion =" + "'" + movimiento + "';");

            try
            {
                con.abrirConexion();
                idr = con.Leer(CommandType.Text, sb.ToString());
                if (idr.Read())
                {
                    existe = (Int32)idr["idMovimiento"];
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



        public dtMovimiento()
        {
        }
    }
}
