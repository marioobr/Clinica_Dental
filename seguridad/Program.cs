using System;
using Gtk;


namespace seguridad
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            /*entidades.Tbl_user tu = new entidades.Tbl_user();
            tu.Nombres = "Mario";
            tu.Apellidos1 = "Obregon";*/



            Application.Init();
            MainWindow win = new MainWindow();
            win.Show();
            Application.Run();
            /*Console.WriteLine("Nombres: " + tu.Nombres, tu.Apellidos1);
            Console.WriteLine("Apellidos: " +  tu.Apellidos1);
            Application.Run();*/

            /*datos.Conexion contest = new datos.Conexion();
            contest.abrirConexion();*/

            /*seguridad.Frm_Usuarios frm_u = new Frm_Usuarios();
            frm_u.Show();*/

        }
    }
}
