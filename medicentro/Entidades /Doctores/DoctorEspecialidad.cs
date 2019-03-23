using System;
namespace medicentro.Entidades.Doctor
{
   
    public class DoctorEspecialidad
    {
        //Atributos 

        private int id_Doctor;
        private int id_especialidad;

        //Metods


        public int Id_Doctor { get => id_Doctor; set => id_Doctor = value; }
        public int Id_especialidad { get => id_especialidad; set => id_especialidad = value; }

        public DoctorEspecialidad()
        {
        }

    }
}
