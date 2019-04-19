using System;
namespace medicentro.Entidades
{
    public class Especialidad
    {
        //Atributos 

        private int id_especialidad;
        private String nomb_especialidad;
        private String descripcion;

        //Metods

        public int Id_especialidad { get => id_especialidad; set => id_especialidad = value; }
        public string Nomb_especialidad { get => nomb_especialidad; set => nomb_especialidad = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }

        public Especialidad()
        {
        }


    }
}
