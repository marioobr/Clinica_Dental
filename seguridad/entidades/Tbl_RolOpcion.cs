using System;
namespace seguridad.entidades
{
    public class Tbl_RolOpcion
    {
        //Atributos
        private int id_RolOpcion;
        private int id_rol;
        private int id_opcion;

        //metodos
        public int Id_RolOpcion { get => id_RolOpcion; set => id_RolOpcion = value; }
        public int Id_rol { get => id_rol; set => id_rol = value; }
        public int Id_opcion { get => id_opcion; set => id_opcion = value; }


        public Tbl_RolOpcion()
        {
        }


    }
}
