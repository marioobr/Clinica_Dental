using System;
namespace medicentro.Entidades
{
    public class Cita
    {
        //Atributos

        private int id_cita;
        private DateTime fechaCita;
        private DateTime horaini;
        private int estadoCita;
        private int id_doctor;
        private int id_User;
        private int id_paciente;


        //METODS

        public int Id_cita { get => id_cita; set => id_cita = value; }
        public DateTime FechaCita { get => fechaCita; set => fechaCita = value; }
        public DateTime Horaini { get => horaini; set => horaini = value; }
        public int EstadoCita { get => estadoCita; set => estadoCita = value; }
        public int Id_doctor { get => id_doctor; set => id_doctor = value; }
        public int Id_User { get => id_User; set => id_User = value; }
        public int Id_paciente { get => id_paciente; set => id_paciente = value; }


        public Cita()
        {
        }


    }
}
