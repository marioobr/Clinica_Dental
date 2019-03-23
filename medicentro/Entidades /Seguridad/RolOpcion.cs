using System;
namespace medicentro.Entidades.Seguridad
{
    public class RolOpcion
    {
        //Atributos 

        private int idRol_opcion;
        private int id_rol;
        private int id_opcion;


        //METODS

        public int IdRol_opcion { get => idRol_opcion; set => idRol_opcion = value; }
        public int Id_rol { get => id_rol; set => id_rol = value; }
        public int Id_opcion { get => id_opcion; set => id_opcion = value; }

        public RolOpcion()
        {
        }
       
    }
}
