using System;
namespace medicentro.Entidades
{
    public class Alergia
    {
        //Atributos

        private int id_alergia;
        private String nomb_alergia;
        private String descripcionalg;
        private int id_paciente;

        //Metods 

        public int Id_alergia { get => id_alergia; set => id_alergia = value; }
        public string Nomb_alergia { get => nomb_alergia; set => nomb_alergia = value; }
        public string Descripcionalg { get => descripcionalg; set => descripcionalg = value; }
        public int Id_paciente { get => id_paciente; set => id_paciente = value; }
        

        public Alergia()
        {
        }


    }
}
