using System;
using System.Data;
using MySql.Data;
using System.Text;
using System.Collections.Generic;
using Gtk;
using medicentro.Entidades;
using medicentro.Datos;
using medicentro.Negocio;

namespace medicentro
{
    public partial class frmGestionPaciente : Gtk.Window
    {
        dtPaciente dtpac = new dtPaciente();
        Negocio.NgPaciente nPac = new Negocio.NgPaciente();
        Paciente pa = new Paciente();
        MessageDialog ms = null;

        public frmGestionPaciente() :
             base(Gtk.WindowType.Toplevel)
        {
            this.Build();

            tvwGestionPa1.Model = dtpac.ListarPaciente();
            string[] titulos = { "Id Paciente", "Cedula", "No Expediente", "Nombres", "Apellidos", "Edad", "Sexo", "Telefono", "Direccion", "Correo" };

            for (int i = 0; i < titulos.Length; i++)
            {
                tvwGestionPa1.AppendColumn(titulos[i], new CellRendererText(), "text", i);
            }
        }


        public void limpiarCampos()
        {
            this.txtNombresPa.Text = "";
            this.txtApellidosPa.Text = "";
            this.txtCorreoPa.Text = "";
            this.txtTelefonoPa.Text = "";
            this.txtDireccionPa.Text = "";
            this.txtEdadPa.Text = "";
            this.txtCedulaPa.Text = "";

        }


        protected void OnBtGuardarPaActivated(object sender, EventArgs e)
        {

        }

        protected void OnBtCancelarPaActivated(object sender, EventArgs e)
        {


        }

        protected void OnBtCancelarPaClicked(object sender, EventArgs e)
        {
            limpiarCampos();
        }

        protected void OnBtGuardarPaClicked(object sender, EventArgs e)
        {
            if (txtNombresPa.Text.Equals("") || txtApellidosPa.Text.Equals("") || txtCedulaPa.Text.Equals("") || txtTelefonoPa.Text.Equals("") || txtDireccionPa.Text.Equals("") || txtEdadPa.Text.Equals("") || txtCorreoPa.Text.Equals(""))
            {

                ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Warning, ButtonsType.Ok, "Todos los datos son requeridos");
                ms.Run();
                ms.Destroy();
            }
            else
            {
                pa.Nombre_paciente = this.txtNombresPa.Text;
                pa.Apellido_paciente = this.txtApellidosPa.Text;
                pa.Cedula = this.txtCedulaPa.Text;
                pa.Telefono_pacientes = int.Parse(txtTelefonoPa.Text);
                pa.Edad_paciente = int.Parse(txtEdadPa.Text);
                pa.Correo_paciente = this.txtCorreoPa.Text;
                pa.Direccion_paciente = this.txtDireccionPa.Text;

                //IF DEL RADIO BUTTON 

                if (rbMasculinoPa.Active)
                {
                    pa.Sexo_paciente = 1;
                }
                else
                {
                    if (rbFemeninoPa.Active)
                    {
                        pa.Sexo_paciente = 0;
                    }
                }

                if (nPac.NgGuardarPaciente(pa))
                {

                    ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Info, ButtonsType.Ok, "El paciente se guardo con exito se guardo correctamente");
                    ms.Run();
                    ms.Destroy();
                    limpiarCampos();
                    tvwGestionPa1.Model = dtpac.ListarPaciente();
                }
                else
                {

                    ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Warning, ButtonsType.Ok, "Revise los datos e intente nuevamente");
                    ms.Run();
                    ms.Destroy();
                    this.txtNombresPa.GrabFocus();
                }

            }

        }

        protected void OnBtActualizarPaClicked(object sender, EventArgs e)
        {
            if (txtNombresPa.Text.Equals("") || txtApellidosPa.Text.Equals("") || txtCedulaPa.Text.Equals("") || txtTelefonoPa.Text.Equals("") || txtDireccionPa.Text.Equals("") || txtEdadPa.Text.Equals("") || txtCorreoPa.Text.Equals(""))
            {

                ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Warning, ButtonsType.Ok, "Todos los datos son requeridos");
                ms.Run();
                ms.Destroy();
            }
            else
            {
                pa.Nombre_paciente = this.txtNombresPa.Text;
                pa.Apellido_paciente = this.txtApellidosPa.Text;
                pa.Cedula = this.txtCedulaPa.Text;
                pa.Telefono_pacientes = int.Parse(txtTelefonoPa.Text);
                pa.Edad_paciente = int.Parse(txtEdadPa.Text);
                pa.Correo_paciente = this.txtCorreoPa.Text;
                pa.Direccion_paciente = this.txtDireccionPa.Text;

                if (dtpac.ActualizarPaciente(pa))
                {

                    ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Info, ButtonsType.Ok, "Se actualizo el paciente");
                    ms.Run();
                    ms.Destroy();
                    limpiarCampos();
                    tvwGestionPa1.Model = dtpac.ListarPaciente();
                }
                else
                {

                    ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Warning, ButtonsType.Ok, "Revise los datos e intente nuevamente");
                    ms.Run();
                    ms.Destroy();
                    this.txtNombresPa.GrabFocus();
                }

            }

        }


        protected void OnBtEliminarPaClicked(object sender, EventArgs e)
        {
            int Eliminado = 0;
            Eliminado = dtpac.EliminarPaciente(pa);
            if (Eliminado != 0)
            {

                ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Info, ButtonsType.Ok, "Paciente eliminado con exito!!");
                ms.Run();
                ms.Destroy();
                limpiarCampos();
                tvwGestionPa1.Model = dtpac.ListarPaciente();
            }
            else
            {

                ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Warning, ButtonsType.Ok, "Por favor seleccione un paciente");
                ms.Run();
                ms.Destroy();
            }


        }

        protected void OnTvwGestionPa1CursorChanged(object sender, EventArgs e)
        {

            TreeSelection seleccion = (sender as TreeView).Selection;
            TreeIter iter;
            TreeModel model;
            if (seleccion.GetSelected(out model, out iter))
            {


                pa.Id_paciente = Convert.ToInt32(model.GetValue(iter, 0).ToString());
                this.txtCedulaPa.Text = model.GetValue(iter, 1).ToString();
                this.txtTelefonoPa.Text = model.GetValue(iter, 7).ToString();
                this.txtNombresPa.Text = model.GetValue(iter, 3).ToString();
                this.txtApellidosPa.Text = model.GetValue(iter, 4).ToString();
                this.txtDireccionPa.Text = model.GetValue(iter, 8).ToString();
                this.txtCorreoPa.Text = model.GetValue(iter, 9).ToString();
                this.txtEdadPa.Text = model.GetValue(iter, 5).ToString();



            }

        }

        protected void OnBtBuscarPaClicked(object sender, EventArgs e)
        {
            String Busqueda = "";
            Busqueda = this.txtBuscarPa.Text.Trim();
            tvwGestionPa1.Model = dtpac.BuscarPaciente(Busqueda);

        }
    }
}
