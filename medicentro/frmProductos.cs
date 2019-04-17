using System;
using Gtk;
using System.Collections.Generic;
using medicentro.Entidades.Productos;
using medicentro.Datos;
using medicentro.Negocio;

namespace medicentro
{
    public partial class frmProductos : Gtk.Window
    {
        TipoProducto tipoProd = new TipoProducto();
        Producto prod = new Producto();
        dtTipoProducto dttipoProducto = new dtTipoProducto();
        dtProducto dtProducto = new dtProducto();
        ngProductos ngProd = new ngProductos();
        MessageDialog ms = null;


        public frmProductos() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
            llenarComboTipo();
            limpiarCombos();
            txtStock.IsEditable = editable();
            txtCantIni.IsEditable = editable();
            this.tvwProductos.Model = dtProducto.ListarProductos();
            string[] titulos = { "IdProducto", "Nombre", "Tipo", "Precio", "Descripción", "Stock", "Cantidad Inicial" };
            for (int i = 0; i < titulos.Length; i++)
            {
                this.tvwProductos.AppendColumn(titulos[i], new CellRendererText(), "text", i);
            }
        }

        public bool editable()
        {
            bool bloquear = false;
            if (cbxTipoProd.ActiveText.Equals("Servicio") || cbxTipoProd.ActiveText.Equals("Seleccione..."))
            {
                txtStock.Text = "";
                txtCantIni.Text = "";
                return bloquear;
            }
            else
            {
                bloquear = true;
                return bloquear;
            }
        }

        public void limpiarCampos()
        {
            this.txtStock.Text = "";
            this.txtPrecio.Text = "";
            this.txtNombreProd.Text = "";
            this.txtCantIni.Text = "";
            this.txtBuscar.Text = "";
            this.txtDescripcion.Text = "";
        }

        public void llenarComboTipo()
        {

            List<TipoProducto> listarTipos = new List<TipoProducto>();
            listarTipos = dttipoProducto.cbxTipoProd();

            cbxTipoProd.InsertText(0, "Seleccione...");

            foreach (TipoProducto tipoprod in listarTipos)
            {
                cbxTipoProd.InsertText(tipoprod.IdTipoProducto, tipoprod.Descripción1);
            }

        }
        public void limpiarCombos()
        {
            //POSICIONAMOS EL COMBO EN LA POSICION 0
            this.cbxTipoProd.Active = 0;
        }

        protected void OnCbxTipoProdChanged(object sender, EventArgs e)
        {
            txtStock.IsEditable = editable();
            txtCantIni.IsEditable = editable();
        }

        protected void OnBtnGuardarClicked(object sender, EventArgs e)
        {


            prod.Nombre_producto = this.txtNombreProd.Text;
            prod.Precioprod = (float)Convert.ToInt32(txtPrecio.Text);
            prod.Descripcion_prod = this.txtDescripcion.Text;
            prod.Cantini = Convert.ToInt32(txtCantIni.Text);
            prod.Stock = Convert.ToInt32(txtStock.Text);
            prod.Id_tipoProducto = this.cbxTipoProd.Active;

            if (cbxTipoProd.Active == 0)
            {

                ms = new MessageDialog(null, DialogFlags.Modal,
                    MessageType.Error, ButtonsType.Ok, "Todos los campos son requeridos!!!");
                ms.Run();
                ms.Destroy();

            }
            else
            {
                if (cbxTipoProd.Active == 1)
                {
                    if (prod.Nombre_producto.Equals("") || prod.Precioprod.Equals("") || prod.Descripcion_prod.Equals(""))
                    {

                        ms = new MessageDialog(null, DialogFlags.Modal,
                            MessageType.Error, ButtonsType.Ok, "Llene los campos aceptables!!!");
                        ms.Run();
                        ms.Destroy();
                    }
                    else
                    {
                        if (ngProd.NgGuardarProductos(prod))
                        {


                            ms = new MessageDialog(null, DialogFlags.Modal,
                                MessageType.Info, ButtonsType.Ok, "El producto fue guardado con exito!!!");
                            ms.Run();
                            ms.Destroy();
                            limpiarCampos();
                            tvwProductos.Model = dtProducto.ListarProductos();
                        }
                    }

                }
                else
                {

                    if (cbxTipoProd.Active == 2)
                    {
                        if (prod.Nombre_producto.Equals("") || prod.Stock.Equals("") || prod.Precioprod.Equals("") || prod.Descripcion_prod.Equals("") || prod.Cantini.Equals(""))
                        {

                            ms = new MessageDialog(null, DialogFlags.Modal,
                                MessageType.Error, ButtonsType.Ok, "Todos los campos son requeridos!!!");
                            ms.Run();
                            ms.Destroy();
                        }
                        else
                        {
                            if (ngProd.NgGuardarProductos(prod))
                            {


                                ms = new MessageDialog(null, DialogFlags.Modal,
                                    MessageType.Info, ButtonsType.Ok, "El producto fue guardado con exito!!!");
                                ms.Run();
                                ms.Destroy();
                                limpiarCampos();
                                tvwProductos.Model = dtProducto.ListarProductos();
                            }
                        }

                    }

                }

            }
        }//fin de metodo

        protected void OnTvwProductosCursorChanged(object sender, EventArgs e)
        {

            TreeSelection seleccion = (sender as TreeView).Selection;
            TreeIter iter;
            TreeModel model;
            this.txtStock.IsEditable = false;
            this.txtCantIni.IsEditable = false;
            if (seleccion.GetSelected(out model, out iter))
            {
                prod.Id_producto = Convert.ToInt32(model.GetValue(iter, 0).ToString());
                this.txtNombreProd.Text = model.GetValue(iter, 1).ToString();
                this.txtPrecio.Text = model.GetValue(iter, 3).ToString();
                this.txtDescripcion.Text = model.GetValue(iter, 4).ToString();
                this.txtStock.Text = model.GetValue(iter, 5).ToString();
                this.txtCantIni.Text = model.GetValue(iter, 6).ToString();
            }
        }

        protected void OnBtnActualizarClicked(object sender, EventArgs e)
        {
            prod.Nombre_producto = this.txtNombreProd.Text;
            prod.Precioprod = (float)Convert.ToDecimal(this.txtPrecio.Text);
            prod.Descripcion_prod = this.txtDescripcion.Text;
            //prod.Cantini = Convert.ToInt32(txtCantIni.Text);
            //prod.Stock = Convert.ToInt32(txtStock.Text);

            if (prod.Nombre_producto.Equals("") || prod.Descripcion_prod.Equals("") || prod.Precioprod.Equals(""))
            {

                ms = new MessageDialog(null, DialogFlags.Modal,
                    MessageType.Error, ButtonsType.Ok, "Todos los campos son requeridos!!!");
                ms.Run();
                ms.Destroy();
            }
            else
            {
                prod.Estado = 2;

                if (dtProducto.ActualizarProducto(prod))
                {

                    ms = new MessageDialog(null, DialogFlags.Modal,
                        MessageType.Info, ButtonsType.Ok, "El producto fue actualizado con éxito!!!");
                    ms.Run();
                    ms.Destroy();
                    limpiarCampos();
                    tvwProductos.Model = dtProducto.ListarProductos();
                }
                else
                {
                    ms = new MessageDialog(null, DialogFlags.Modal,
                        MessageType.Error, ButtonsType.Ok, "Error selecione el producto, revise los datos e intente nuevamente!!!");
                    ms.Run();
                    ms.Destroy();
                }
            }

        }

        protected void OnBtnCancelarClicked(object sender, EventArgs e)
        {
            limpiarCampos();
        }

        protected void OnTxtBuscarChanged(object sender, EventArgs e)
        {
            String busqueda = "";
            busqueda = this.txtBuscar.Text.Trim();
            tvwProductos.Model = dtProducto.buscarProducto(busqueda);
        }

        protected void OnBtnEliminarClicked(object sender, EventArgs e)
        {

            int eliminado = 0;
            eliminado = dtProducto.EliminarProducto(prod);
            if (eliminado != 0)
            {
                ms = new MessageDialog(null, DialogFlags.Modal,
                            MessageType.Info, ButtonsType.Ok, "El producto fue eliminado con exito!!!");
                ms.Run();
                ms.Destroy();
                limpiarCampos();
                tvwProductos.Model = dtProducto.ListarProductos();
                prod.Id_producto = 0;
            }
            else
            {
                ms = new MessageDialog(null, DialogFlags.Modal,
                            MessageType.Error, ButtonsType.Ok, "Debe seleccionar el producto primero e intente nuevamente!!!");
                ms.Run();
                ms.Destroy();
            }
        }
    }
}
