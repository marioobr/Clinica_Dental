using System;
namespace medicentro.Entidades
{
    public class Paciente
    {
        //Atributos

        private int id_paciente;
        private String cedula;
        private int no_expediente;
        private String nombre_paciente;
        private String apellido_paciente;
        private int edad_paciente;
        private int sexo_paciente;
        private int telefono_pacientes;
        private String direccion_paciente;
        private String correo_paciente;
        private int estado_paciente;

        //Metods 

        public int Id_paciente { get => id_paciente; set => id_paciente = value; }
        public string Cedula { get => cedula; set => cedula = value; }
        public int No_expediente { get => no_expediente; set => no_expediente = value; }
        public string Nombre_paciente { get => nombre_paciente; set => nombre_paciente = value; }
        public string Apellido_paciente { get => apellido_paciente; set => apellido_paciente = value; }
        public int Edad_paciente { get => edad_paciente; set => edad_paciente = value; }
        public int Sexo_paciente { get => sexo_paciente; set => sexo_paciente = value; }
        public int Telefono_pacientes { get => telefono_pacientes; set => telefono_pacientes = value; }
        public string Direccion_paciente { get => direccion_paciente; set => direccion_paciente = value; }
        public string Correo_paciente { get => correo_paciente; set => correo_paciente = value; }
        public int Estado_paciente { get => estado_paciente; set => estado_paciente = value; }

        public Paciente()
        {
        }


    }
}
