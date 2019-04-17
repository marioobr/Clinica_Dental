using System;
using System;
using System.Data;
using MySql.Data;
using System.Text;
using medicentro.Entidades;
using medicentro.Datos;
using medicentro.Entidades.Doctores;
using Gtk;
using System.Collections.Generic;
using medicentro.Entidades.Doctor;

namespace medicentro
{
    public partial class frmAsignarEspecialidad : Gtk.Window
    {

        DoctorEspecialidad tde = new DoctorEspecialidad();
        Doctor tdoc = new Doctor();
        Especialidad tEsp = new Especialidad();
        dtDoctor dtdoc = new dtDoctor();
        dtEspecialidad dtEsp = new dtEspecialidad();
        dtDoctorEspecialidad dtDocEsp = new dtDoctorEspecialidad();
        MessageDialog ms = null;

        public frmAsignarEspecialidad() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
            llenarComboDoc();
            llenarComboEsp();
            limpiarCombos();

            this.tvwDoctorEsp.Model = dtDocEsp.ListarDoctorEsp();
            string[] titulos = { "Id Doctor", "Cedula", "Cod MINSA", "Nombres", "Apellidos", "Telefono", "Sexo", "ID Especialidad", "Especialidad" };
            for (int i = 0; i < titulos.Length; i++)
            {
                this.tvwDoctorEsp.AppendColumn(titulos[i], new CellRendererText(), "text", i);
            }

        }

        public void llenarComboDoc()
        {

            List<Doctor> listarDoctores = new List<Doctor>();
            listarDoctores = dtdoc.cbxDoc();

            cbxDoctor.InsertText(0, "Seleccione...");

            foreach (Doctor tdoct in listarDoctores)
            {
                cbxDoctor.InsertText(tdoct.Id_Doctor, tdoct.Nombres1);
            }

        }

        public void llenarComboEsp()
        {

            List<Especialidad> listarEspecialidades = new List<Especialidad>();
            listarEspecialidades = dtEsp.cbxEsp();

            cbxEspecialidad.InsertText(0, "Seleccione...");

            foreach (Especialidad tEspc in listarEspecialidades)
            {
                cbxEspecialidad.InsertText(tEspc.Id_especialidad, tEspc.Nomb_especialidad);
            }

        }

        public void limpiarCombos()
        {
            //POSICIONAMOS EL COMBO EN LA POSICION 0
            this.cbxDoctor.Active = 0;
            this.cbxEspecialidad.Active = 0;
        }

        protected void OnBtnAsignarEspClicked(object sender, EventArgs e)
        {
            if (this.cbxDoctor.Active == 0 || this.cbxEspecialidad.Active == 0)
            {
                ms = new MessageDialog(null, DialogFlags.Modal,
                        MessageType.Error, ButtonsType.Ok, "Todos los campos son requeridos!!!");
                ms.Run();
                ms.Destroy();
            }
            else
            {

                tde.Id_Doctor = dtdoc.getIdDoctor(this.cbxDoctor.ActiveText);
                tde.Id_especialidad = dtEsp.getIdEspecialidad(this.cbxEspecialidad.ActiveText);

                if (dtDocEsp.GuardarDoctorEspecialidad(tde))
                {

                    ms = new MessageDialog(null, DialogFlags.Modal,
                    MessageType.Info, ButtonsType.Ok, "Se asignó la especialidad con exito!!!");
                    ms.Run();
                    ms.Destroy();
                    limpiarCombos();
                    this.tvwDoctorEsp.Model = dtDocEsp.ListarDoctorEsp();
                }
                else
                {

                    ms = new MessageDialog(null, DialogFlags.Modal,
                       MessageType.Error, ButtonsType.Ok, "Selecciones los datos e intente nuevamente!!!");
                    ms.Run();
                    ms.Destroy();

                }


            }

        }
    }
}
