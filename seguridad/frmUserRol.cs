using System;
using seguridad.datos;
using seguridad.entidades;
using System.Collections.Generic;

namespace seguridad
{
    public partial class frmUserRol : Gtk.Window
    {
        Tbl_user tus = new Tbl_user();
        Tbl_UserRol tur = new Tbl_UserRol();
        dtUsuarios dtus = new dtUsuarios();
        dtRoles dtRoles = new dtRoles();

        public frmUserRol() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
            //Llenar comboboxes
            LLenarComboUser();
            LLenarComboRol();
        }

        #region
        public void LLenarComboUser()
        {
            List<Tbl_user> ListarUsuarios = new List<Tbl_user>();
            ListarUsuarios = dtus.cbxUser();

            cbxUsuario.InsertText(0, "Seleccione...");

            foreach(Tbl_user tuser in ListarUsuarios)
            {
                cbxUsuario.InsertText(tuser.Id_user, tuser.User);
                cbxUsuario.Active = 0;
            }

        }//fin de metodo

        public void LLenarComboRol()
        {
            List<Tbl_rol> ListarRol = new List<Tbl_rol>();
            ListarRol = dtRoles.cbxRol();

            cbxRol.InsertText(0, "Seleccione...");

            foreach (Tbl_rol trol in ListarRol)
            {
                cbxRol.InsertText(trol.Id_rol, trol.Rol);
                cbxRol.Active = 0;
            }

        }//fin de metodo

        protected void OnBtnAsignarClicked(object sender, EventArgs e)
        {
            tur.Id_user = Convert.ToInt32(this.cbxUsuario.ActiveText);
            tur.Id_rol = Convert.ToInt32(this.cbxRol.ActiveText);

        }
        #endregion
    }
}
