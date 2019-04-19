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
    public partial class frmEspecialidad : Gtk.Window
    {
        dtEspecialidad dtEsp = new dtEspecialidad();
        Negocio.ngEspecialidad nEsp = new Negocio.ngEspecialidad();
        Especialidad tEsp = new Especialidad();

        public frmEspecialidad() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
            tvwEspecialidades.Model = dtEsp.ListarEspecialidades();
            string[] titulos = { "Id Especialidad", "Nombre", "Descripcion" };

            for(int i= 0; i < titulos.Length; i++)
            {
                tvwEspecialidades.AppendColumn(titulos[i], new CellRendererText(), "text", i);
            }
        }

        public void LimpiarCuadrosdeTexto()
        {
            txtNombreEsp.Text = "";
            txtDesEsp.Text = "";
            txtBuscarEsp.Text = "";
        }

        protected void OnBtnGuardarEspClicked(object sender, EventArgs e)
        {
            if (txtNombreEsp.Text.Equals("") || txtDesEsp.Text.Equals(""))
            {
                MessageDialog ms = null;
                ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Warning, ButtonsType.Ok, "Todos los datos son requeridos");
                ms.Run();
                ms.Destroy();
            }
            else
            {
                tEsp.Nomb_especialidad = this.txtNombreEsp.Text;
                tEsp.Descripcion = this.txtDesEsp.Text;


                if (nEsp.NgGuardarEspecialidad(tEsp))
                {
                    MessageDialog ms = null;
                    ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Info, ButtonsType.Ok, "La especialidad se guardo correctamente");
                    ms.Run();
                    ms.Destroy();
                    LimpiarCuadrosdeTexto();
                    tvwEspecialidades.Model = dtEsp.ListarEspecialidades();
                }
                else
                {
                    MessageDialog ms = null;
                    ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Warning, ButtonsType.Ok, "Revise los datos e intente nuevamente");
                    ms.Run();
                    ms.Destroy();
                    this.txtNombreEsp.GrabFocus();
                }

            }
        }//fin del metodo

        protected void OnBtnCancelarClicked(object sender, EventArgs e)
        {
            LimpiarCuadrosdeTexto();
        }

        protected void OnBtnBuscarEspClicked(object sender, EventArgs e)
        {
            String Busqueda = "";
            Busqueda = this.txtBuscarEsp.Text.Trim();
            tvwEspecialidades.Model = dtEsp.BuscarEspecialidad(Busqueda);
        }

        protected void OnTvwEspecialidadesCursorChanged(object sender, EventArgs e)
        {
            TreeSelection seleccion = (sender as TreeView).Selection;
            TreeIter iter;
            TreeModel model;

            if (seleccion.GetSelected(out model, out iter))
            {
                tEsp.Id_especialidad = Convert.ToInt32(model.GetValue(iter, 0).ToString());
                this.txtNombreEsp.Text = model.GetValue(iter, 1).ToString();
                this.txtDesEsp.Text = model.GetValue(iter, 2).ToString();
            }
        }

        protected void OnBtnActualizarEspClicked(object sender, EventArgs e)
        {
            if (txtNombreEsp.Text.Equals("") || txtDesEsp.Text.Equals(""))
            {
                MessageDialog ms = null;
                ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Warning, ButtonsType.Ok, "Todos los datos son requeridos");
                ms.Run();
                ms.Destroy();
            }
            else
            {
                tEsp.Nomb_especialidad = this.txtNombreEsp.Text;
                tEsp.Descripcion = this.txtDesEsp.Text;

                if (dtEsp.ActualizarEspecialidad(tEsp))
                {
                    MessageDialog ms = null;
                    ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Info, ButtonsType.Ok, "Se actualizo la especialidad");
                    ms.Run();
                    ms.Destroy();
                    LimpiarCuadrosdeTexto();
                    tvwEspecialidades.Model = dtEsp.ListarEspecialidades();
                }
                else
                {
                    MessageDialog ms = null;
                    ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Warning, ButtonsType.Ok, "Revise los datos e intente nuevamente");
                    ms.Run();
                    ms.Destroy();
                    this.txtNombreEsp.GrabFocus();
                }
            }
        }

        protected void OnBtnEliminarEspClicked(object sender, EventArgs e)
        {
            int Eliminado = 0;
            Eliminado = dtEsp.EliminarEspecialidad(tEsp);
            if (Eliminado != 0)
            {
                MessageDialog ms = null;
                ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Info, ButtonsType.Ok, "Especialidad eliminada con exito!!");
                ms.Run();
                ms.Destroy();
                LimpiarCuadrosdeTexto();
                tvwEspecialidades.Model = dtEsp.ListarEspecialidades();
            }
            else
            {
                MessageDialog ms = null;
                ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Warning, ButtonsType.Ok, "Por favor seleccione una especialidad");
                ms.Run();
                ms.Destroy();
            }
        }
    }
}
