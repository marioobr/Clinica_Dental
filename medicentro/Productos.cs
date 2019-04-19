using System;
using medicentro.Datos;
using medicentro.Entidades.Productos;
using System.Collections.Generic;
namespace medicentro
{
    public partial class Productos : Gtk.Window
    {
        dtTipoProducto dtTipo = new dtTipoProducto();
        #region metodos
        public bool editable()
        {
            if (cbxTipoProd.ActiveText.Equals("Servicio"))
            {
                return false;
            }
            return true;
        }

        public void llenarComboTipo()
        {

            List<TipoProducto> listarTipoProd = new List<TipoProducto>();
            listarTipoProd = dtTipo.cbxTipoProd();

            cbxTipoProd.InsertText(0, "Seleccione...");

            foreach (TipoProducto tprod in listarTipoProd)
            {
                cbxTipoProd.InsertText(tprod.IdTipoProducto, tprod.Descripción1);
            }

        }
        #endregion

        public Productos() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
            //llenarComboTipo();
            txtStock.IsEditable = editable();
            txtCantIni.IsEditable = editable();
        }

        protected void OnCbxTipoProdChanged(object sender, EventArgs e)
        {
            txtStock.IsEditable = editable();
            txtCantIni.IsEditable = editable();
            txtStock.Text = "";
            txtCantIni.Text = "";
        }
    }
}
