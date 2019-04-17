using System;
using Gtk;
using System.Collections.Generic;
using medicentro.Entidades.Productos;
using medicentro.Datos;
using medicentro.Negocio;
using medicentro.Entidades.Producto;

namespace medicentro
{
    public partial class frmHistorialMovimiento : Gtk.Window
    {
        dtHistorialMov dtm = new dtHistorialMov();
        MessageDialog ms = null;

        public frmHistorialMovimiento() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
            this.tvwMovimientos.Model = dtm.ListarMovimientos();
            string[] titulos = { "idProducto", "Nombre", "Cantidad_inicial", "Stock", "idMovimiento", "Movimiento" };
            for (int i = 0; i < titulos.Length; i++)
            {
                this.tvwMovimientos.AppendColumn(titulos[i], new CellRendererText(), "text", i);
            }
        }

        protected void OnTxtBuscarChanged(object sender, EventArgs e)
        {
            String busqueda = "";
            String tipo = "";
            busqueda = this.txtBusqueda.Text.Trim();
            tipo = this.cmbEleccion.ActiveText;
            tvwMovimientos.Model = dtm.buscarMovimi(busqueda,tipo);
        }


    }
}
