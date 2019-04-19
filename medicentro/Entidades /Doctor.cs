using System;
namespace medicentro.Entidades.Doctores
{
    public class Doctor
    {

        //Atributos 
        private int id_Doctor;
        private String cedula;
        private String Cod_MINSA;
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

        public int Id_Doctor { get => id_Doctor; set => id_Doctor = value; }
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
        public String Cod_Minsa1 { get => Cod_MINSA; set => Cod_MINSA = value; }

        public Doctor()
        {
        }

       
    }
}
