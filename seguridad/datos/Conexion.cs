using System;
using System.Data;
using MySql.Data.MySqlClient;
using Gtk;


namespace seguridad.datos
{
    public class Conexion
    {

        #region atributos
        private string cadena = String.Empty;
        private MySqlConnection con { get; set; }
        private MySqlCommand sqlcommand { get; set; }
        private IDataReader idr { get; set; }
        #endregion

        #region metodos
        public string CadenaConexion()
        {
            MySqlConnectionStringBuilder sb = new MySqlConnectionStringBuilder();
            sb.Server = "localhost";
            sb.UserID = "root";
            sb.Database = "seguridad";
            sb.Password = "L@bDes19";
            return sb.ConnectionString;
        }/* fin del metodo*/

        public void abrirConexion()
        {
            MessageDialog ms = null;
            if (con.State == ConnectionState.Open)
            {
                return;
            }
            else
            {
                con.ConnectionString = cadena;
                try
                {
                    con.Open();
                    Console.WriteLine("Conexion exitosa");
                    //ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Info, ButtonsType.Ok, "Se abrio la conexion");
                    //ms.Run();
                    //ms.Destroy();
                }
                catch (Exception e)
                {
                    ms = new MessageDialog(null, DialogFlags.Modal,
                    MessageType.Error, ButtonsType.Ok, e.Message);
                    ms.Run();
                    ms.Destroy();
                }// fin del try-catch
            }//fin del if-else
        }//fin del metodo

        public void CerrarConexion()
        {
            if (con.State == ConnectionState.Closed)
            {
                return;
            }
            else
            {
                con.Close();
            }
        }//fin del metodo


        public Int32 Ejecutar(CommandType ct, string consulta)
        {
            int retorno = 0;
            sqlcommand.Connection = con;
            sqlcommand.CommandType = ct;
            sqlcommand.CommandText = consulta;
            try
            {
                retorno = sqlcommand.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }//fin try-catch
            return retorno;
        }// fin metodo

        public IDataReader Leer(CommandType ct, string consulta)
        {
            idr = null;
            sqlcommand.Connection = con;
            sqlcommand.CommandType = ct;
            sqlcommand.CommandText = consulta;
            try
            {
                idr = sqlcommand.ExecuteReader();
            }
            catch
            {
                throw;
            }
            return idr;
        }//fin del metodo
        #endregion

        #region constructor
        public Conexion()
        {
            cadena = CadenaConexion();
            con = new MySqlConnection();
            sqlcommand = new MySqlCommand();
        }
        #endregion
    }
}
