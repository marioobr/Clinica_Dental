using System;
using Gtk;

public partial class MainWindow : Gtk.Window
{
    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        Build();
    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        Application.Quit();
        a.RetVal = true;
    }

    protected void OnSalirActionActivated(object sender, EventArgs e)
    {
        Application.Quit();
    }

    protected void OnControlDeUsuariosActionActivated(object sender, EventArgs e)
    {
        seguridad.Frm_Usuarios user = new seguridad.Frm_Usuarios();
        user.Show();
    }

    protected void OnAsignarRolesActionActivated(object sender, EventArgs e)
    {
        seguridad.frmUserRol UserRol = new seguridad.frmUserRol();
        UserRol.Show();
    }
}
