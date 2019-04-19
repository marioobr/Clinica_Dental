using System;
<<<<<<< HEAD
=======
using System;
>>>>>>> master
using System.Data;
using MySql.Data;
using System.Text;
using medicentro.Entidades;
using medicentro.Datos;
using medicentro.Entidades.Doctores;
using Gtk;
using System.Collections.Generic;
<<<<<<< HEAD

=======
using medicentro.Entidades.Doctor;
>>>>>>> master

namespace medicentro
{
    public partial class frmAsignarEspecialidad : Gtk.Window
    {

<<<<<<< HEAD
        Tbl_DoctorEsp tde = new Tbl_DoctorEsp();
=======
        DoctorEspecialidad tde = new DoctorEspecialidad();
>>>>>>> master
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
<<<<<<< HEAD
            string[] titulos = { "Id Doctor", "Cedula", "Cod MINSA", "Nombres", "Apellidos", "Telefono","Sexo", "ID Especialidad", "Especialidad" };
=======
            string[] titulos = { "Id Doctor", "Cedula", "Cod MINSA", "Nombres", "Apellidos", "Telefono", "Sexo", "ID Especialidad", "Especialidad" };
>>>>>>> master
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

<<<<<<< HEAD
            foreach (Doctor tdoc in listarDoctores)
            {
                cbxDoctor.InsertText(tdoc.Id_doctor, tdoc.Nombres1);
=======
            foreach (Doctor tdoct in listarDoctores)
            {
                cbxDoctor.InsertText(tdoct.Id_Doctor, tdoct.Nombres1);
>>>>>>> master
            }

        }

        public void llenarComboEsp()
        {

            List<Especialidad> listarEspecialidades = new List<Especialidad>();
            listarEspecialidades = dtEsp.cbxEsp();

            cbxEspecialidad.InsertText(0, "Seleccione...");

<<<<<<< HEAD
            foreach (Especialidad tEsp in listarEspecialidades)
            {
                cbxEspecialidad.InsertText(tEsp.Id_especialidad, tEsp.Nomb_especialidad);
=======
            foreach (Especialidad tEspc in listarEspecialidades)
            {
                cbxEspecialidad.InsertText(tEspc.Id_especialidad, tEspc.Nomb_especialidad);
>>>>>>> master
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

<<<<<<< HEAD
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
=======
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
>>>>>>> master


            }

        }
    }
}
