using System;
namespace medicentro
{
    public partial class Productos : Gtk.Window
    {
        #region metodos
        public bool editable()
        {
            if (cmbTipoProd.ActiveText.Equals("Servicio"))
            {
                return false;
            }
            return true;
        }
        #endregion

        public Productos() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
            txtStock.IsEditable = editable();
            txtCantIni.IsEditable = editable();
        }

        protected void OnCmbTipoProdChanged(object sender, EventArgs e)
        {
            txtStock.IsEditable = editable();
            txtCantIni.IsEditable = editable();
            txtStock.Text = "";
            txtCantIni.Text= "";
        }
    }
}
