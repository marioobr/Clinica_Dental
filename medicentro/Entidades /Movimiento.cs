using System;
namespace medicentro.Entidades
{
    public class Movimiento
    {
        //Atributos

        private int id_movimiento;
        private String desc_movimiento;

        //Metods

        public int Id_movimiento { get => id_movimiento; set => id_movimiento = value; }
        public string Desc_movimiento { get => desc_movimiento; set => desc_movimiento = value; }

        public Movimiento()
        {
        }


    }
}
