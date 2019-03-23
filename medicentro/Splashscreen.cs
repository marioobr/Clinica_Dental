using System;
namespace medicentro
{
    public partial class Splashscreen : Gtk.Window
    {
        public Splashscreen() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
        }
    }
}
