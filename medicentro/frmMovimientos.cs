using System;
using Gtk;
using System.Collections.Generic;
using medicentro.Entidades.Productos;
using medicentro.Datos;
using medicentro.Negocio;
using medicentro.Entidades;
using medicentro.Entidades.Producto;

namespace medicentro
{
    public partial class frmMovimientos : Gtk.Window
    {
        Movimiento movi = new Movimiento();
        dtMovimiento dtmovi = new dtMovimiento();
        DetalleMovimiento dtm = new DetalleMovimiento();
        dtDetalleMovimiento dtDetalle = new dtDetalleMovimiento();
        ngProductos ngProd = new ngProductos();
        Producto prod = new Producto();
        dtProducto dtProducto = new dtProducto();
        MessageDialog ms = null;
        public frmMovimientos() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
            llenarComboMovimiento();
            limpiarCombos();
            this.tvwProductos.Model = dtProducto.ListarProductos();
            string[] titulos = { "IdProducto", "Nombre", "Tipo", "Precio", "Descripción", "Stock", "Cantidad Inicial" };
            for (int i = 0; i < titulos.Length; i++)
            {
                this.tvwProductos.AppendColumn(titulos[i], new CellRendererText(), "text", i);
            }
        }

        public void llenarComboMovimiento()
        {

            List<Movimiento> listarMovi = new List<Movimiento>();
            listarMovi = dtmovi.cbxMovimiento();

            cbxSeleccion.InsertText(0, "Seleccione...");

            foreach (Movimiento movim in listarMovi)
            {
                cbxSeleccion.InsertText(movim.Id_movimiento, movim.Desc_movimiento);
            }

        }
        public void limpiarCombos()
        {
            //POSICIONAMOS EL COMBO EN LA POSICION 0
            this.cbxSeleccion.Active = 0;
        }

        protected void OnTxtBuscarProdChanged(object sender, EventArgs e)
        {
            String busqueda = "";
            busqueda = this.txtBuscarProd.Text.Trim();
            tvwProductos.Model = dtProducto.buscarProducto(busqueda);

        }

        protected void OnTvwProductosCursorChanged(object sender, EventArgs e)
        {

            TreeSelection seleccion = (sender as TreeView).Selection;
            TreeIter iter;
            TreeModel model;
            if (seleccion.GetSelected(out model, out iter))
            {
                prod.Id_producto = Convert.ToInt32(model.GetValue(iter, 0).ToString());
                this.txtNombreProd.Text = model.GetValue(iter, 1).ToString();
            }

        }

        protected void OnBtnRealizarMovClicked(object sender, EventArgs e)
        {
            if(cbxSeleccion.Active == 0)
            {

                ms = new MessageDialog(null, DialogFlags.Modal,
                    MessageType.Error, ButtonsType.Ok, "Todos los campos son requeridos!!!");
                ms.Run();
                ms.Destroy();

            }
            else
            {
                TreeSelection seleccion = (sender as TreeView).Selection;
                TreeIter iter;
                TreeModel model;
                if (seleccion.GetSelected(out model, out iter))
                {
                    dtm.Id_producto = Convert.ToInt32(model.GetValue(iter, 0).ToString());
                }

                dtm.Cantmovimiento = Convert.ToInt32(txtCantidad.Text);
                dtm.Id_movimiento = dtmovi.getidMovimiento(this.cbxSeleccion.ActiveText);
                dtm.Descripcion_movimienteo1 = this.txtDescripcion.Text;
                dtm.Fechamov = Convert.ToDateTime(this.txtFecha.Text);

                if (dtm.Cantmovimiento.Equals("") || dtm.Descripcion_movimienteo1.Equals("") || dtm.Fechamov.Equals(""))
                {

                    ms = new MessageDialog(null, DialogFlags.Modal,
                        MessageType.Error, ButtonsType.Ok, "Todos los campos son requeridos!!!");
                    ms.Run();
                    ms.Destroy();

                }
                else
                {
                    if (dtDetalle.RealizarMovimiento(dtm))
                    {


                        ms = new MessageDialog(null, DialogFlags.Modal,
                            MessageType.Info, ButtonsType.Ok, "Movimiento realizado con exito!!!");
                        ms.Run();
                        ms.Destroy();
                        limpiarCampos();
                        //tvwusuarios.Model = dtu.ListarUsuarios();
                    }

                }

            }
            
        }// fin del metodo

        public void limpiarCampos()
        {
            this.txtFecha.Text = "";
            this.txtNombreProd.Text = "";
            this.txtDescripcion.Text = "";
            this.txtBuscarProd.Text = "";
            this.txtCantidad.Text = "";
        }
    }
}
