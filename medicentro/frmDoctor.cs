using System;
using System.Data;
using MySql.Data;
using System.Text;
using medicentro.Datos;
using medicentro.Entidades;
using medicentro.Entidades.Doctores;
using medicentro.Negocio;
using Gtk;
using System.Collections.Generic;
namespace medicentro
{
    public partial class frmDoctor : Gtk.Window
    {
        Doctor tdoc = new Doctor();
        Especialidad tEsp = new Especialidad();
        dtDoctor dtDoc = new dtDoctor();
        dtEspecialidad dtEsp = new dtEspecialidad();
        Negocio.ngDoctores nDoc = new Negocio.ngDoctores();

        public frmDoctor() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
            //AGREGAR EN DOCTORESP LLenarComboEsp();
            tvwDoctor.Model = dtDoc.ListarDoctores();
            string[] titulos = { "Id Doctor", "Cedula", "Cod MINSA", "Nombres", "Apellidos", "Telefono", "Sexo" };

            for (int i = 0; i < titulos.Length; i++)
            {
                tvwDoctor.AppendColumn(titulos[i], new CellRendererText(), "text", i);
            }
        }

        public void LimpiarCuadrosdeTexto()
        {
            txtNombreDoc.Text = "";
            txtApellidoDoc.Text = "";
            txtCedula.Text = "";
            txtMINSA.Text = "";
            txtTelefonoDoc.Text = "";
        }

        protected void OnBtnGuardarDocClicked(object sender, EventArgs e)
        {
            if (txtNombreDoc.Text.Equals("") || txtApellidoDoc.Text.Equals("") || txtCedula.Text.Equals("") || txtTelefonoDoc.Text.Equals("") || txtMINSA.Text.Equals(""))
            {
                MessageDialog ms = null;
                ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Warning, ButtonsType.Ok, "Todos los datos son requeridos");
                ms.Run();
                ms.Destroy();
            }
            else
            {
                tdoc.Nombres1 = this.txtNombreDoc.Text;
                tdoc.Apellidos1 = this.txtApellidoDoc.Text;
                tdoc.Cedula = this.txtCedula.Text;
                tdoc.Cod_Minsa1 = this.txtMINSA.Text;
                tdoc.Telefono = int.Parse(txtTelefonoDoc.Text);

                //IF DEL RADIO BUTTON 

                if (rbMas.Active)
                {
                    tdoc.Sexo = 1;
                }
                else
                {
                    if (rbFemenino.Active)
                    {
                        tdoc.Sexo = 0;
                    }
                }

                if (nDoc.NgGuardarDoctor(tdoc))
                {
                    MessageDialog ms = null;
                    ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Info, ButtonsType.Ok, "El Doctor se guardo con exito se guardo correctamente");
                    ms.Run();
                    ms.Destroy();
                    LimpiarCuadrosdeTexto();
                    tvwDoctor.Model = dtDoc.ListarDoctores();
                }
                else
                {
                    MessageDialog ms = null;
                    ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Warning, ButtonsType.Ok, "Revise los datos e intente nuevamente");
                    ms.Run();
                    ms.Destroy();
                    this.txtNombreDoc.GrabFocus();
                }

            }

        }//fin del metodo

        protected void OnBuscarDoctorClicked(object sender, EventArgs e)
        {
            String Busqueda = "";
            Busqueda = this.txtBuscarDoctor.Text.Trim();
            tvwDoctor.Model = dtDoc.BuscarDoctor(Busqueda);

        }

        protected void OnTvwDoctorCursorChanged(object sender, EventArgs e)
        {
            TreeSelection seleccion = (sender as TreeView).Selection;
            TreeIter iter;
            TreeModel model;

            if (seleccion.GetSelected(out model, out iter))
            {
                tdoc.Id_Doctor = Convert.ToInt32(model.GetValue(iter, 0).ToString());
                this.txtCedula.Text = model.GetValue(iter, 1).ToString();
                this.txtMINSA.Text = model.GetValue(iter, 2).ToString();
                this.txtNombreDoc.Text = model.GetValue(iter, 3).ToString();
                this.txtApellidoDoc.Text = model.GetValue(iter, 4).ToString();
                this.txtTelefonoDoc.Text = model.GetValue(iter, 5).ToString();

            }
        }//fin del metodo

        protected void OnBtnActualizarDocClicked(object sender, EventArgs e)
        {
            if (txtCedula.Text.Equals("") || txtMINSA.Text.Equals("") || txtNombreDoc.Text.Equals("") || txtApellidoDoc.Text.Equals("") || txtTelefonoDoc.Text.Equals(""))
            {
                MessageDialog ms = null;
                ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Warning, ButtonsType.Ok, "Todos los datos son requeridos");
                ms.Run();
                ms.Destroy();
            }
            else
            {
                tdoc.Cedula = this.txtCedula.Text;
                tdoc.Cod_Minsa1 = this.txtMINSA.Text;
                tdoc.Nombres1 = this.txtNombreDoc.Text;
                tdoc.Apellidos1 = this.txtApellidoDoc.Text;
                tdoc.Telefono = Convert.ToInt32(this.txtTelefonoDoc.Text);


                if (dtDoc.ActualizarDoctor(tdoc))
                {
                    MessageDialog ms = null;
                    ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Info, ButtonsType.Ok, "Se actualizo el paciente");
                    ms.Run();
                    ms.Destroy();
                    LimpiarCuadrosdeTexto();
                    tvwDoctor.Model = dtDoc.ListarDoctores();
                }
                else
                {
                    MessageDialog ms = null;
                    ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Warning, ButtonsType.Ok, "Revise los datos e intente nuevamente");
                    ms.Run();
                    ms.Destroy();
                    this.txtNombreDoc.GrabFocus();
                }

            }

        }

        protected void OnBtnEliminarDoctorClicked(object sender, EventArgs e)
        {
            int Eliminado = 0;
            Eliminado = dtDoc.EliminarDoctor(tdoc);
            if (Eliminado != 0)
            {
                MessageDialog ms = null;
                ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Info, ButtonsType.Ok, "Paciente eliminado con exito!!");
                ms.Run();
                ms.Destroy();
                LimpiarCuadrosdeTexto();
                tvwDoctor.Model = dtDoc.ListarDoctores();
            }
            else
            {
                MessageDialog ms = null;
                ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Warning, ButtonsType.Ok, "Por favor seleccione un doctor");
                ms.Run();
                ms.Destroy();
            }

        }

        protected void OnBtnCancelarDocClicked(object sender, EventArgs e)
        {
            LimpiarCuadrosdeTexto();
        }


    }
}
