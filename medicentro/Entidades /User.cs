using System;
namespace medicentro.Entidades.Seguridad
{
    public class User
    {
        //Atributos 

        private int id_user;
        private String userdes;
        private String pwd;
        private String nombre;
        private String apellidos;
        private string email;
        private String pwd_temp;
        private int estado_user;

        //Metods 

        public int Id_user { get => id_user; set => id_user = value; }
        public string Userdes { get => userdes; set => userdes = value; }
        public string Pwd { get => pwd; set => pwd = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
        public string Pwd_temp { get => pwd_temp; set => pwd_temp = value; }
        public int Estado_user { get => estado_user; set => estado_user = value; }
        public string Email { get => email; set => email = value; }

        public User()
        {
        }


    }
}
