using System;
namespace seguridad.entidades
{
    public class Tbl_UserRol
    {
        //Atributos
        private int id_UserRol;
        private int id_user;
        private int id_rol;

        //Metodos
        public int Id_UserRol { get => id_UserRol; set => id_UserRol = value; }
        public int Id_user { get => id_user; set => id_user = value; }
        public int Id_rol { get => id_rol; set => id_rol = value; }


        public Tbl_UserRol()
        {
        }


    }
}
