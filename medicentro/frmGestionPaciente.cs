using System;
namespace medicentro
{
    public partial class frmGestionPaciente : Gtk.Window
    {
        public frmGestionPaciente() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
        }
    }
}
