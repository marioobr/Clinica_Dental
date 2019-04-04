using System;
namespace medicentro.Entidades.Seguridad
{
    public class Opcion
    {
        //Atributos 

        private int id_opcion;
        private String opciondes;
        private String estadoOP;

        //METODS

        public int Id_opcion { get => id_opcion; set => id_opcion = value; }
        public string Opciondes { get => opciondes; set => opciondes = value; }
        public string EstadoOP { get => estadoOP; set => estadoOP = value; }


        public Opcion()
        {
        }


    }
}
