using System;
using System.Data;
using MySql.Data;
using Gtk;
using System.Text;
using System.Collections.Generic;
using medicentro.Entidades.Productos;
using medicentro.Entidades;
using medicentro.Entidades.Producto;

namespace medicentro.Datos
{
    public class dtDetalleMovimiento
    {
        Conexion con = new Conexion();
        MessageDialog ms = null;
        StringBuilder sb = new StringBuilder();

        public bool RealizarMovimiento(DetalleMovimiento dtm)
        {
            bool guardado = false; // esto es una bandera
            int x = 0; //variable de control
            sb.Clear();
            sb.Append("USE ClinicaDental;");
            //MessageDialog ms = null;
            //StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO Detalle_Movimiento");
            sb.Append("`Producto_idProducto`, `Descripcion`, `Movimiento_idMovimiento`," +
            	      "`CantMovimiento`, `FechaMovim`, `User_idUser`))");
            sb.Append("VALUES ('" + dtm.Id_producto + "','" + dtm.Descripcion_movimienteo1 +
            "','" + dtm.Id_movimiento + "','" + dtm.Cantmovimiento + "','" + dtm.Cantmovimiento + "','"+ 1 + "');");

            try
            {
                con.abrirConexion();
                x = con.Ejecutar(CommandType.Text, sb.ToString());

                if (x > 0)
                {
                    guardado = true;
                    ms = new MessageDialog(null, DialogFlags.Modal,
                    MessageType.Info, ButtonsType.Ok, "Movimiento realizado con exito");
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
        public dtDetalleMovimiento()
        {
        }
    }
}
