using System;
namespace seguridad.entidades
{
    public class Tbl_user
    {
        //Atributos
        private int id_user;
        private String user;
        private String pwd;
        private String nombres;
        private String Apellidos;
        private String email;
        private String pwd_temp;
        private int estado;

      
        // Metodos de la clase
        public int Id_user { get => id_user; set => id_user = value; }
        public string User { get => user; set => user = value; }
        public string Pwd { get => pwd; set => pwd = value; }
        public string Nombres { get => nombres; set => nombres = value; }
        public string Apellidos1 { get => Apellidos; set => Apellidos = value; }
        public string Email { get => email; set => email = value; }
        public string Pwd_temp { get => pwd_temp; set => pwd_temp = value; }
        public int Estado { get => estado; set => estado = value; }

        public Tbl_user()
        {



        }



    }
}
