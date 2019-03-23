using System;
namespace medicentro.Entidades.Doctores
{
    public class Doctor
    {

        //Atributos 
        private int id_paciente;
        private String cedula;
        private int no_expediente;
        private String Nombres;
        private String Apellidos;
        private int edad;
        private int sexo;
        private int telefono;
        private String direccion;
        private String correo;
        private int estado_doctor;

        //Metods

        public int Id_paciente { get => id_paciente; set => id_paciente = value; }
        public string Cedula { get => cedula; set => cedula = value; }
        public int No_expediente { get => no_expediente; set => no_expediente = value; }
        public string Nombres1 { get => Nombres; set => Nombres = value; }
        public string Apellidos1 { get => Apellidos; set => Apellidos = value; }
        public int Edad { get => edad; set => edad = value; }
        public int Sexo { get => sexo; set => sexo = value; }
        public int Telefono { get => telefono; set => telefono = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Correo { get => correo; set => correo = value; }
        public int Estado_doctor { get => estado_doctor; set => estado_doctor = value; }

        public Doctor()
        {
        }

       
    }
}
