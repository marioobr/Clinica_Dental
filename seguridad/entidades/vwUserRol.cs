using System;
namespace seguridad.entidades
{
    public class vwUserRol
    {
        //Atributos
        private int id_user;
        private String user;
        private String nombres;
        private String Apellidos;
        private String email;
        private int id_rol;
        private String rol;

     
        //Metodos
        public int Id_user { get => id_user; set => id_user = value; }
        public string User { get => user; set => user = value; }
        public string Nombres { get => nombres; set => nombres = value; }
        public string Apellidos1 { get => Apellidos; set => Apellidos = value; }
        public string Email { get => email; set => email = value; }
        public int Id_rol { get => id_rol; set => id_rol = value; }
        public string Rol { get => rol; set => rol = value; }

        public vwUserRol()
        {
        }
    }
}
