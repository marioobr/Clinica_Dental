using System;
namespace seguridad.entidades
{
    public class Tbl_rol
    {
        //Atributos
        private int id_rol;
        private String rol;
        private int estado;


        //Metodos
        public int Id_rol { get => id_rol; set => id_rol = value; }
        public string Rol { get => rol; set => rol = value; }
        public int Estado { get => estado; set => estado = value; }

        public Tbl_rol()
        {
        }


    }
}
