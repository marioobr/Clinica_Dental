using System;
namespace medicentro.Entidades.Doctores
{
    public class VwDoctorEsp
    {

        private int id_doctor;
        private String cod_MINSA;
        private String cedula;
        private String Nombres;
        private String Apellidos;
        private int sexo;
        private int telefono;
        private int idEspecialidad;
        private String Especialidad;
        private int estado; 


        public VwDoctorEsp()
        {
      
        }

        public int Id_doctor { get => id_doctor; set => id_doctor = value; }
        public string Cod_MINSA { get => cod_MINSA; set => cod_MINSA = value; }
        public string Cedula { get => cedula; set => cedula = value; }
        public string Nombres1 { get => Nombres; set => Nombres = value; }
        public string Apellidos1 { get => Apellidos; set => Apellidos = value; }
        public int Sexo { get => sexo; set => sexo = value; }
        public int Telefono { get => telefono; set => telefono = value; }
        public int IdEspecialidad { get => idEspecialidad; set => idEspecialidad = value; }
        public string Especialidad1 { get => Especialidad; set => Especialidad = value; }
        public int Estado { get => estado; set => estado = value; }
    }
}
