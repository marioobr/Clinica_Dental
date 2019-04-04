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
        public bool GuardarProductos(Producto prod)
        {
            bool guardado = false; // esto es una bandera
            int x = 0; //variable de control
            sb.Clear();
            sb.Append("USE ClinicaDental;");
            //MessageDialog ms = null;
            //StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO ClinicaDental.Producto");
            sb.Append("(idProducto,Tipo_Producto_idTipo_Producto,Nombre,Precio,Descripcion,Stock,CantIni,Estado)");
            sb.Append("VALUES ('" + prod.Id_producto + "','" + prod.Id_tipoProducto + "','" + prod.Nombre_producto + 
            "','" + prod.Precioprod + "','" + prod.Descripcion_prod + "','" + prod.Stock + "','" + prod.Cantini + "','" + 1 + "')");

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
        public dtProducto()
        {
        }
    }
}
