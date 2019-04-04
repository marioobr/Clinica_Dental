using System;
using Gtk;
using seguridad.datos;
using seguridad.entidades;
using seguridad.Negocio;


namespace seguridad
{
    public partial class Frm_Usuarios : Gtk.Window
    {

        dtUsuarios dtus = new dtUsuarios();
        Negocio.NgUsuario ntus = new Negocio.NgUsuario();
        Tbl_user tus = new Tbl_user();

        public Frm_Usuarios() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
            tvwUsuarios.Model = dtus.ListarUsuarios();
            string[] titulos = { "id Usuario", "Usuario", "Nombres", "Apellidos", "Email"};

            for (int i = 0; i < titulos.Length; i++)
            {
                tvwUsuarios.AppendColumn(titulos[i], new CellRendererText(), "text", i);
            }
        }

        public void LimpiarCuadrosdeTexto()
        {
            txtNombres.Text = "";
            txtApellidos.Text = "";
            txtCorreo.Text = "";
            txtClave1.Text = "";
            txtClave2.Text = "";
            txtUsuarios.Text = "";
        }

        protected void OnSalirActionActivated(object sender, EventArgs e)
        {
            Application.Quit();
        }

        protected void OnBtnGuardarClicked(object sender, EventArgs e)
        {
            if (txtNombres.Text.Equals("") || txtApellidos.Text.Equals("") || txtUsuarios.Text.Equals("")
            || txtCorreo.Text.Equals(""))
            {
                MessageDialog ms = null;
                ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Warning, ButtonsType.Ok, "Todos los datos son requeridos");
                ms.Run();
                ms.Destroy();
            }
            else
            {
                tus.User = this.txtUsuarios.Text;
                tus.Nombres = this.txtNombres.Text;
                tus.Apellidos1 = this.txtApellidos.Text;
                tus.Email = this.txtCorreo.Text;
                /*tus.Pwd = this.txtClave1.Text;
                tus.Pwd_temp = this.txtClave2.Text;*/

                if (this.txtClave1.Text.Trim().Equals(this.txtClave2.Text.Trim()))
                {
                    tus.Pwd = this.txtClave1.Text;
                    //dtUsuarios dtus = new dtUsuarios();

                    if (ntus.NgGuardarUser(tus))
                    {
                        MessageDialog ms = null;
                        ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Info, ButtonsType.Ok, "El usuario se guardo correctamente");
                        ms.Run();
                        ms.Destroy();
                        LimpiarCuadrosdeTexto();
                        tvwUsuarios.Model = dtus.ListarUsuarios();
                    }

                    /*if (dtus.GuardarUsuarios(tus))
                    {
                        MessageDialog ms = null;
                        ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Info, ButtonsType.Ok, "El usuario se guardo correctamente");
                        ms.Run();
                        ms.Destroy();
                        LimpiarCuadrosdeTexto();
                        tvwUsuarios.Model = dtus.ListarUsuarios();
                    }*/
                    else
                    {
                        MessageDialog ms = null;
                        ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Warning, ButtonsType.Ok, "Revise los datos e intente nuevamente");
                        ms.Run();
                        ms.Destroy();
                        this.txtUsuarios.GrabFocus();
                    }
                }
                else
                {
                    MessageDialog ms = null;
                    ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Warning, ButtonsType.Ok, "las contrasenias no coinciden");
                    ms.Run();
                    ms.Destroy();

                }
            }


        }

        protected void OnBtnEliminarClicked(object sender, EventArgs e)
        {
            int Eliminado = 0;
            Eliminado = dtus.EliminarUsuario(tus);
            if(Eliminado != 0)
            {
                MessageDialog ms = null;
                ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Info, ButtonsType.Ok, "Usuario eliminado con exito!!");
                ms.Run();
                ms.Destroy();
                LimpiarCuadrosdeTexto();
                tvwUsuarios.Model = dtus.ListarUsuarios();
            }
            else
            {
                MessageDialog ms = null;
                ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Warning, ButtonsType.Ok, "Por favor seleccione un usuario");
                ms.Run();
                ms.Destroy();
            }
        }

        protected void OnBtnCancelarClicked(object sender, EventArgs e)
        {
            LimpiarCuadrosdeTexto();
        }

        protected void OnTvwUsuariosCursorChanged(object sender, EventArgs e)
        {
            TreeSelection seleccion = (sender as TreeView).Selection;
            TreeIter iter;
            TreeModel model;

            if(seleccion.GetSelected(out model, out iter))
            {
                tus.Id_user = Convert.ToInt32(model.GetValue(iter, 0).ToString());
                this.txtUsuarios.Text = model.GetValue(iter, 1).ToString();
                this.txtNombres.Text = model.GetValue(iter, 2).ToString();
                this.txtApellidos.Text = model.GetValue(iter, 3).ToString();
                this.txtCorreo.Text = model.GetValue(iter, 4).ToString();
            }
        }

        protected void OnBtnBuscarClicked(object sender, EventArgs e)
        {
            String Busqueda = "";
            Busqueda = this.txtBusqueda.Text.Trim();
            tvwUsuarios.Model = dtus.BuscarUsuarios(Busqueda);
        }

        protected void OnBtnActualizarClicked(object sender, EventArgs e)
        {
            if (txtNombres.Text.Equals("") || txtApellidos.Text.Equals("") || txtUsuarios.Text.Equals("")
            || txtCorreo.Text.Equals(""))
            {
                MessageDialog ms = null;
                ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Warning, ButtonsType.Ok, "Todos los datos son requeridos");
                ms.Run();
                ms.Destroy();
            }
            else
            {
                tus.User = this.txtUsuarios.Text;
                tus.Nombres = this.txtNombres.Text;
                tus.Apellidos1 = this.txtApellidos.Text;
                tus.Email = this.txtCorreo.Text;
                /*tus.Pwd = this.txtClave1.Text;
                tus.Pwd_temp = this.txtClave2.Text;*/

                if (this.txtClave1.Text.Trim().Equals(this.txtClave2.Text.Trim()))
                {
                    tus.Pwd = this.txtClave1.Text;
                    //dtUsuarios dtus = new dtUsuarios();

                    if (dtus.ActualizarUser(tus))
                    {
                        MessageDialog ms = null;
                        ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Info, ButtonsType.Ok, "Se actualizo el usuario");
                        ms.Run();
                        ms.Destroy();
                        LimpiarCuadrosdeTexto();
                        tvwUsuarios.Model = dtus.ListarUsuarios();
                    }

                    /*if (dtus.GuardarUsuarios(tus))
                    {
                        MessageDialog ms = null;
                        ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Info, ButtonsType.Ok, "El usuario se guardo correctamente");
                        ms.Run();
                        ms.Destroy();
                        LimpiarCuadrosdeTexto();
                        tvwUsuarios.Model = dtus.ListarUsuarios();
                    }*/
                    else
                    {
                        MessageDialog ms = null;
                        ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Warning, ButtonsType.Ok, "Seleccione un usuario, revise los datos e intente nuevamente");
                        ms.Run();
                        ms.Destroy();
                        this.txtUsuarios.GrabFocus();
                    }
                }
                else
                {
                    MessageDialog ms = null;
                    ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Warning, ButtonsType.Ok, "las contrasenias no coinciden");
                    ms.Run();
                    ms.Destroy();

                }
            }

        }
    }
}
