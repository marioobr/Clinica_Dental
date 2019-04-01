using System;
using Gtk;

namespace medicentro
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Application.Init();
            MainWindow win = new MainWindow();
            win.Show();
            Application.Run();

            /*Datos.Conexion contest = new Datos.Conexion();
            contest.abrirConexion();*/

        }
    }
}
