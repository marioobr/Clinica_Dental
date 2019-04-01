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
        medicentro.Productos prod = new medicentro.Productos();
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
        medicentro.frmEspecialidad espec = new medicentro.frmEspecialidad();
        espec.Show();
    }
}
