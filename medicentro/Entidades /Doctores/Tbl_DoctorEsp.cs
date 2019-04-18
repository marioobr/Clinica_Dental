using System;
namespace medicentro.Entidades.Doctores
{
    public class Tbl_DoctorEsp
    {

        private int id_DocEsp;
        private int id_Doctor;
        private int id_especialidad;


        public int Id_DocEsp { get => id_DocEsp; set => id_DocEsp = value; }
        public int Id_Doctor { get => id_Doctor; set => id_Doctor = value; }
        public int Id_especialidad { get => id_especialidad; set => id_especialidad = value; }

        public Tbl_DoctorEsp()
        {
        }


    }
}
