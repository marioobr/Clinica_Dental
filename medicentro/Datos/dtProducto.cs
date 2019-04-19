using System;
using System.Data;
using MySql.Data;
using System.Text;
using medicentro.Entidades;
using Gtk;
using System.Collections.Generic;
using medicentro.Entidades.Productos;

namespace medicentro.Datos
{
    public class dtProducto
    {
        Conexion con = new Conexion();
        MessageDialog ms = null;
        StringBuilder sb = new StringBuilder();

        #region metodos


        public bool existeProducto(Producto prod)
        {
            bool existe = false; //bandera
            IDataReader idr = null;
            sb.Clear();
            sb.Append("USE ClinicaDental;");
            sb.Append("SELECT * FROM Producto WHERE Nombre =" + "'" + prod.Nombre_producto + "';");

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

        public bool GuardarProductos(Producto prod)
        {
            bool guardado = false; // esto es una bandera
            int x = 0; //variable de control
            sb.Clear();
            sb.Append("USE ClinicaDental;");
            //MessageDialog ms = null;
            //StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO Producto");
            sb.Append("(Tipo_Producto_idTipo_Producto,Nombre,Precio,Descripcion,Stock,CantIni,Estado)");
            sb.Append("VALUES ('" + prod.Id_tipoProducto + "','" + prod.Nombre_producto +
            "','" + prod.Precioprod + "','" + prod.Descripcion_prod + "','" + prod.Stock + "','" + prod.Cantini + "','" + 1 + "');");

            try
            {
                con.abrirConexion();
                x = con.Ejecutar(CommandType.Text, sb.ToString());

                if (x > 0)
                {
                    guardado = true;
                    ms = new MessageDialog(null, DialogFlags.Modal,
                    MessageType.Info, ButtonsType.Ok, "se guardo el producto con exito");
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


        public ListStore buscarProducto(String cadena)
        {
            ListStore datos = new ListStore(typeof(string),
                typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string));
            IDataReader dr = null;
            sb.Clear();
            sb.Append("USE ClinicaDental;");
            sb.Append("SELECT idProducto, `Producto/Servicio`, Tipo, Precio, Descripcion, Stock, CantIni FROM vwTipoProducto ");
            sb.Append("WHERE Estado <>3 ");
            sb.Append("AND `Producto/Servicio` like '%" + cadena + "%' ;");
            //sb.Append("OR nombres like '%" + cadena + "%' ");
            //sb.Append("OR apellidos like '%" + cadena + "%'); ");
            try
            {
                con.abrirConexion();
                dr = con.Leer(CommandType.Text, sb.ToString());
                while (dr.Read())
                {
                    datos.AppendValues(dr[0].ToString(), dr[1].ToString(),
                        dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString());
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

        public ListStore ListarProductos()
        {
            ListStore datos = new ListStore(typeof(string),
                typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string));


            IDataReader dr = null;
            sb.Clear();
            sb.Append("USE ClinicaDental;");
            sb.Append("SELECT idProducto, `Producto/Servicio`, Tipo, Precio, Descripcion, Stock, CantIni FROM vwTipoProducto WHERE Estado <> 3;");
            try
            {
                con.abrirConexion();
                dr = con.Leer(CommandType.Text, sb.ToString());
                while (dr.Read())
                {
                    datos.AppendValues(dr[0].ToString(), dr[1].ToString(),
                        dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString());
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
        }//fin de metodo

        public bool ActualizarProducto(Producto prod)
        {
            bool actualizado = false;
            int x = 0;
            sb.Clear();
            sb.Append("USE ClinicaDental;");
            sb.Append("UPDATE Producto SET Nombre = '" + prod.Nombre_producto + "',");
            sb.Append("Precio = '" + prod.Precioprod + "',");
            sb.Append("Descripcion = '" + prod.Descripcion_prod + "',");
            //sb.Append("CantIni = '" + prod.Cantini + "',");
            //sb.Append("Stock = '" + prod.Stock + "',");
            sb.Append("Estado = '" + prod.Estado + "' ");
            sb.Append("WHERE idProducto = " + prod.Id_producto + ";");

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


        public Int32 EliminarProducto(Producto prod)
        {
            int eliminado;
            sb.Clear();
            sb.Append("USE ClinicaDental;");
            sb.Append("UPDATE Producto SET Estado = 3 WHERE idProducto = " + prod.Id_producto + ";");

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

        #endregion
        public dtProducto()
        {
        }
    }
}
