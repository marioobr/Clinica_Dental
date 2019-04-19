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

    protected void OnGestionarProductosActionActivated(object sender, EventArgs e)
    {
        medicentro.frmProductos prod = new medicentro.frmProductos();
        prod.Show();
    }

    protected void OnSalirActionActivated(object sender, EventArgs e)
    {
        Application.Quit();
    }

    protected void OnRealizarMovimientoActionActivated(object sender, EventArgs e)
    {
        medicentro.frmMovimientos mov = new medicentro.frmMovimientos();
        mov.Show();
    }

    protected void OnHistorialActionActivated(object sender, EventArgs e)
    {
        medicentro.frmHistorialMovimiento Hmov = new medicentro.frmHistorialMovimiento();
        Hmov.Show();
    }

    protected void OnRealizarFacturaActionActivated(object sender, EventArgs e)
    {
        medicentro.Factura fac = new medicentro.Factura();
        fac.Show();
    }

    protected void OnHistorialAction1Activated(object sender, EventArgs e)
    {
        medicentro.frmHistoralFactura hfac = new medicentro.frmHistoralFactura();
        hfac.Show();
    }

    protected void OnGestionarDoctoresActionActivated(object sender, EventArgs e)
    {
        medicentro.frmDoctor doctor = new medicentro.frmDoctor();
        doctor.Show();
    }

    protected void OnGestionarEspecialidadesActionActivated(object sender, EventArgs e)
    {
    }

    protected void OnGestionarEspecialidadesAction1Activated(object sender, EventArgs e)
    {
        medicentro.frmEspecialidad espec = new medicentro.frmEspecialidad();
        espec.Show();
    }

    protected void OnAsignarEspecialidadActionActivated(object sender, EventArgs e)
    {
        medicentro.frmAsignarEspecialidad asg = new medicentro.frmAsignarEspecialidad();
        asg.Show();
    }

    protected void OnGestionarPacientesActionActivated(object sender, EventArgs e)
    {
        medicentro.frmGestionPaciente pa = new medicentro.frmGestionPaciente();
        pa.Show();
    }

    protected void OnRealizarCitaAction1Activated(object sender, EventArgs e)
    {
        medicentro.frmRealizarCita cita = new medicentro.frmRealizarCita();
        cita.Show();
    }

    protected void OnGestionarCitasAction1Activated(object sender, EventArgs e)
    {
        medicentro.frmGestionCita gcita = new medicentro.frmGestionCita();
        gcita.Show();
    }

    protected void OnGestionDeUsuariosActionActivated(object sender, EventArgs e)
    {
        medicentro.frmUser user = new medicentro.frmUser();
        user.Show();
    }

    protected void OnAsignarRolesActionActivated(object sender, EventArgs e)
    {
        medicentro.frmUserRol userRol = new medicentro.frmUserRol();
        userRol.Show();
    }

    protected void OnGestionDeOpcionesActionActivated(object sender, EventArgs e)
    {
        medicentro.frmopcion opcion = new medicentro.frmopcion();
        opcion.Show();
    }
}
