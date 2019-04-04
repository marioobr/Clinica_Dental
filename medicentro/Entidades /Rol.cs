using System;
namespace medicentro.Entidades.Seguridad
{
    public class Rol
    {
        //Atributos 

        private int id_rol;
        private String roldes;
        private int estadoRol;

        //METODS

        public int Id_rol { get => id_rol; set => id_rol = value; }
        public string Roldes { get => roldes; set => roldes = value; }
        public int EstadoRol { get => estadoRol; set => estadoRol = value; }

        public Rol()
        {
        }

       
    }
}
