using System;
using Gtk;
using medicentro.Datos;
using medicentro.Entidades.Seguridad;
using medicentro.Negocio;

namespace medicentro
{
    public partial class frmUsuario : Gtk.Dialog
    {
        User tus = new User();
        DtsUser dtu = new DtsUser();
        ngUsuario ngu = new ngUsuario();
        MessageDialog ms = null;

        public frmUsuario()
        {
            this.Build();
            tvwUser.Model = dtu.ListarUsuarios();
            string[] titulos = { "IdUser", "User", "Nombres", "Apellidos", "Email" };
            for (int i = 0; i < titulos.Length; i++)
            {
                tvwUser.AppendColumn(titulos[i], new CellRendererText(), "text", i);
            }
        }

        public void limpiarCampos()
        {
            txtNombresUsuario.Text = "";
            txtApellidos.Text = "";
            txtemail.Text = "";
            txtclave1.Text = "";
            txtclave2.Text = "";
            txtUsuario.Text = "";
        }

        protected void OnBtnGuardarClicked(object sender, EventArgs e)
        {
            tus.Nombre = this.txtNombresUsuario.Text;
            tus.Apellidos = this.txtApellidos.Text;
            tus.Email = this.txtemail.Text;
            tus.Userdes = this.txtUsuario.Text;
            if (this.txtclave1.Text.Trim().Equals(this.txtclave2.Text.Trim()))
            {
                tus.Pwd = this.txtclave1.Text;
                if (tus.Nombre.Equals("") || tus.Apellidos.Equals("") || tus.Email.Equals("") || tus.Pwd.Equals("") || tus.Userdes.Equals(""))
                {

                    ms = new MessageDialog(null, DialogFlags.Modal,
                        MessageType.Error, ButtonsType.Ok, "Todos los campos son requeridos!!!");
                    ms.Run();
                    ms.Destroy();
                }
                else
                {
                    if (ngu.ngGuardarUser(tus))
                    {


                        ms = new MessageDialog(null, DialogFlags.Modal,
                            MessageType.Info, ButtonsType.Ok, "El usuario fue guardado con exito!!!");
                        ms.Run();
                        ms.Destroy();
                        limpiarCampos();
                        tvwUser.Model = dtu.ListarUsuarios();
                    }
                }
            }
            else
            {

                ms = new MessageDialog(null, DialogFlags.Modal,
                    MessageType.Warning, ButtonsType.Ok, "Las contraseñas deben coincidir...");
                ms.Run();
                ms.Destroy();
            }
        }
    }
}
