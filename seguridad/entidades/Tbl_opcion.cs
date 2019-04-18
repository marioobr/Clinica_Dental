using System;
namespace seguridad.entidades
{
    public class Tbl_opcion
    {
        //Metodos
        private int id_opcion;
        private String opcion;
        private int estado;


        //Metodos
        public int Id_opcion { get => id_opcion; set => id_opcion = value; }
        public string Opcion { get => opcion; set => opcion = value; }
        public int Estado { get => estado; set => estado = value; }

        public Tbl_opcion()
        {
        }


    }
}
