using System;
namespace medicentro.Entidades.Servicio
{
    public class Servicio
    {
        //Atributos 
        private int id_servicio;
        private String nombre_servicio;
        private float precio_servicio;
        private String desc_servicio;
        private int estado_servicio;

        //METODS 

        public int Id_servicio { get => id_servicio; set => id_servicio = value; }
        public string Nombre_servicio { get => nombre_servicio; set => nombre_servicio = value; }
        public float Precio_servicio { get => precio_servicio; set => precio_servicio = value; }
        public string Desc_servicio { get => desc_servicio; set => desc_servicio = value; }
        public int Estado_servicio { get => estado_servicio; set => estado_servicio = value; }


        public Servicio()
        {
        }


    }
}
