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
    public partial class frmRealizarCita : Gtk.Window
    {

        Cita ci = new Cita();
        dtCita dci = new dtCita();
        NgCita nci = new NgCita();
        MessageDialog ms = null;


        public frmRealizarCita() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
        }



        public void limpiarCampos()
        {

            this.txtFechaCita.Text = "";
            this.txtHoraCita.Text = "";

        }




        protected void OnBtBuscarDocCitaClicked(object sender, EventArgs e)
        {
        }

        protected void OnBtBuscarPaCitaClicked(object sender, EventArgs e)
        {
        }

        protected void OnBtCancelarCitaClicked(object sender, EventArgs e)
        {
            limpiarCampos();
        }

        protected void OnBtGuardarCitaClicked(object sender, EventArgs e)
        {

            /*
            if (txtHoraCita.Text.Equals("") || txtFechaCita.Text.Equals("") )
            {

                ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Warning, ButtonsType.Ok, "Todos los datos son requeridos");
                ms.Run();
                ms.Destroy();
            }
            else
            {
                ci.Horaini = this.txtHoraCita.Text;
                ci.FechaCita = this.txtFechaCita.Text;
              


                if (nci.NgGuardarCita(ci))
                {

                    ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Info, ButtonsType.Ok, "El paciente se guardo con exito se guardo correctamente");
                    ms.Run();
                    ms.Destroy();
                    limpiarCampos();
                   // tvw.Model = dtCita.ListarCita();
                }
                else
                {

                    ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Warning, ButtonsType.Ok, "Revise los datos e intente nuevamente");
                    ms.Run();
                    ms.Destroy();
                  //  this.txtNombresPa.GrabFocus();
                } */

        }
    }
}
