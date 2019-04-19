using System;
namespace medicentro.Entidades.Seguridad
{
    public class UserRol
    {
        //Atributos 

        private int idUser_rol;
        private int idUser;
        private int idRol;

        //Metods

        public int IdUser_rol { get => idUser_rol; set => idUser_rol = value; }
        public int IdUser { get => idUser; set => idUser = value; }
        public int IdRol { get => idRol; set => idRol = value; }

        public UserRol()
        {
        }


    }
}