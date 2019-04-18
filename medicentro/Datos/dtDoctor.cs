using System;
using System.Data;
using MySql.Data;
using System.Text;
using medicentro.Entidades;
using medicentro.Entidades.Doctores;
using Gtk;
using System.Collections.Generic;


namespace medicentro.Datos
{
    public class dtDoctor
    {
        Conexion con = new Conexion();
        MessageDialog ms = null;
        StringBuilder sb = new StringBuilder();

        #region metodos

        public bool GuardarDoctores(Doctor tdoc)
        {
            bool guardado = false; // esto es una bandera
            int x = 0; //variable de control
            sb.Clear();

            //MessageDialog ms = null;
            //StringBuilder sb = new StringBuilder();
            sb.Append("USE ClinicaDental;");
            sb.Append("INSERT INTO ClinicaDental.Doctor");
            sb.Append("(idDoctor,Cedula,CodMINSA,Nombres,Apellidos,Telefono,Sexo,Estado)");
            sb.Append("VALUES (NULL,'" + tdoc.Cedula + "','"+ tdoc.Cod_MINSA + "','" + tdoc.Nombres1 + "','" + tdoc.Apellidos1 + "','" + tdoc.Telefono + "','" + tdoc.Sexo + "','" + 1 + "')");

            try
            {
                con.abrirConexion();
                x = con.Ejecutar(CommandType.Text, sb.ToString());

                if (x > 0)
                {
                    guardado = true;
                    ms = new MessageDialog(null, DialogFlags.Modal,
                    MessageType.Info, ButtonsType.Ok, "Se ha guardado el doctor con exito!!!");
                    ms.Run();
                    ms.Destroy();
                }
                return guardado;
            }
            catch (Exception e)
            {
                ms = new MessageDialog(null, DialogFlags.Modal,
                     MessageType.Error, ButtonsType.Ok, e.Message);
                ms.Run();
                ms.Destroy();
                throw;
            }
        }//fin del metodo


        public Int32 EliminarDoctor(Doctor tdoc)
        {
            int eliminado;
            sb.Clear();
            //MessageDialog ms = null;
            //StringBuilder sb = new StringBuilder();
            sb.Append("USE ClinicaDental;");
            sb.Append("UPDATE ClinicaDental.Doctor set Doctor.Estado = '3' WHERE Doctor.idDoctor = " + tdoc.Id_doctor + ";");

            try
            {
                con.abrirConexion();
                eliminado = con.Ejecutar(CommandType.Text, sb.ToString());
                return eliminado;
            }
            catch (Exception e)
            {
                ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Error, ButtonsType.Ok, e.Message);
                ms.Run();
                ms.Destroy();
                throw;
            }
            finally
            {
                con.CerrarConexion();
            }
        }



        public bool ExisteDoctor(Doctor tdoc)
        {
            bool existe = false;
            IDataReader idr = null;
            //StringBuilder sb = new StringBuilder();
            sb.Clear();
            sb.Append("USE ClinicaDental;");
            sb.Append("SELECT * FROM `Doctor` WHERE `idDoctor` = " + "'" + tdoc.Id_doctor + "';");

            try
            {
                con.abrirConexion();
                idr = con.Leer(CommandType.Text, sb.ToString());
                if (idr.Read())
                {
                    existe = true;
                }
                return existe;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                throw;
            }
            finally
            {
                idr.Close();
                con.CerrarConexion();
            }
        }//fin del metodo

        public ListStore ListarDoctores()
        {
            ListStore datos = new ListStore(typeof(string), typeof(string),
            typeof(string), typeof(string), typeof(string), typeof(string), typeof(string));
            //StringBuilder sb = new StringBuilder();
            //MessageDialog ms = null;
            IDataReader dr = null;
            sb.Clear();
            sb.Append("USE ClinicaDental;");
            sb.Append("SELECT `Doctor`.`idDoctor`, `Doctor`.`Cedula`, `Doctor`.`CodMINSA`, `Doctor`.`Nombres`,`Doctor`.`Apellidos`, `Doctor`.`Telefono`, CASE Doctor.Sexo WHEN 1 THEN 'Masculino' WHEN 0 THEN 'Femenino' END FROM `ClinicaDental`.`Doctor` WHERE `Doctor`.`Estado` <> 3;");

            try
            {
                con.abrirConexion();
                dr = con.Leer(CommandType.Text, sb.ToString());
                while (dr.Read())
                {
                    datos.AppendValues(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString());
                    //dr.close();
                }
                return datos;
            }
            catch (Exception e)
            {
                ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Error, ButtonsType.Ok, e.Message);
                System.Console.WriteLine("" + e.Message);  
                ms.Run();
                ms.Destroy();
                throw;
            }
            finally
            {
                dr.Close();
                con.CerrarConexion();
            }
        }//fin de metodo


        public ListStore BuscarDoctor(String Cadena)
        {
            ListStore datos = new ListStore(typeof(string), typeof(string),
            typeof(string), typeof(string), typeof(string), typeof(string), typeof(string));
            //StringBuilder sb = new StringBuilder();
            //MessageDialog ms = null;
            IDataReader idr = null;
            sb.Clear();
            sb.Append("USE ClinicaDental;");
            sb.Append("SELECT `Doctor`.`idDoctor`,`Doctor`.`Cedula`,`Doctor`.`CodMINSA`,`Doctor`.`Nombres`,`Doctor`.`Apellidos`,`Doctor`.`Telefono`,CASE Doctor.Sexo WHEN 1 THEN 'Masculino' WHEN 0 THEN 'Femenino' END  FROM `ClinicaDental`.`Doctor` ");
            sb.Append("WHERE `Doctor`.`Estado` <> 3 ");
            sb.Append("AND (`Doctor`.`Nombres` like '%" + Cadena + "%'");
            sb.Append("OR `Doctor`.`Apellidos` like '%" + Cadena + "%' );");
            //sb.Append("OR `Doctor`.`CodMINSA` like '%" + Cadena + "%' )");
            /* sb.Append("OR `Doctor`.`Nombres` like '%" + Cadena + "%' ");
             sb.Append("OR `Doctor`.`Telefono` like '%" + Cadena + "%');");
             */

            try
            {
                con.abrirConexion();
                idr = con.Leer(CommandType.Text, sb.ToString());
                while (idr.Read())
                {
                    datos.AppendValues(idr[0].ToString(), idr[1].ToString(), idr[2].ToString(), idr[3].ToString(), 
                    idr[4].ToString(), idr[5].ToString(), idr[6].ToString());
                    //dr.close();
                }
                return datos;
            }
            catch (Exception e)
            {
                ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Error, ButtonsType.Ok, e.Message);
                ms.Run();
                ms.Destroy();
                Console.WriteLine("Error> " + e);
                throw;
            }
            finally
            {
                idr.Close();
                con.CerrarConexion();
            }
        }//fin de metodo

        public bool ActualizarDoctor(Doctor tdoc)
        {
            bool Actualizado = false;
            int x = 0;
            sb.Clear();
            sb.Append("USE ClinicaDental;");
            sb.Append("UPDATE ClinicaDental.Doctor SET Nombres = '" + tdoc.Nombres1 + "',");
            sb.Append("Apellidos = '" + tdoc.Apellidos1 + "',");
            sb.Append("Cedula = '" + tdoc.Cedula + "',");
            sb.Append("CodMINSA = '" + tdoc.Cod_MINSA + "',");
            sb.Append("Telefono = '" + tdoc.Telefono + "'");
            sb.Append("WHERE idDoctor = " + tdoc.Id_doctor + ";");

            try
            {
                con.abrirConexion();
                x = con.Ejecutar(CommandType.Text, sb.ToString());

                if (x > 0)
                {
                    Actualizado = true;
                }
                return Actualizado;
            }
            catch (Exception e)
            {
                ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Error, ButtonsType.Ok, e.Message);
                ms.Run();
                ms.Destroy();
                throw;
            }
            finally
            {
                con.CerrarConexion();
            }


        }//fin del metodo

        public int getIdDoctor(String doctor)
        {
            int existe = 0; //bandera
            IDataReader idr = null;
            sb.Clear();
            sb.Append("USE ClinicaDental;");
            sb.Append("SELECT idDoctor FROM Doctor WHERE doctor=" + "'" + doctor + "';");

            try
            {
                con.abrirConexion();
                idr = con.Leer(CommandType.Text, sb.ToString());
                if (idr.Read())
                {
                    existe = (Int32)idr["idDoctor"];
                }
                return existe;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                throw;
            }
            finally
            {
                idr.Close();
                con.CerrarConexion();
            }
        }//fin del metodo



        public List<Doctor> cbxDoc()
        {
            sb.Clear();
            List<Doctor> ListDoc = new List<Doctor>();
            IDataReader idr = null;
            sb.Append("USE ClinicaDental;");
            sb.Append("SELECT Doctor.idDoctor, Doctor.Nombres, Doctor.Apellidos FROM ClinicaDental.Doctor WHERE Doctor.Estado <> 3;");

            try
            {
                con.abrirConexion();
                idr = con.Leer(CommandType.Text, sb.ToString());
                while (idr.Read())
                {
                    Doctor tdoc = new Doctor()
                    {
                        Id_doctor = (Int32)idr["idDoctor"],
                        Nombres1 = idr["Nombres"].ToString(),
                        Apellidos1 = idr["Apellidos"].ToString(),

                    };
                    ListDoc.Add(tdoc);
                }
                idr.Close();
                return ListDoc;
            }
            catch (Exception e)
            {
                ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Error, ButtonsType.Ok, e.Message);
                ms.Run();
                ms.Destroy();
                //Console.WriteLine("Error> " + e);
                throw;
            }
            finally
            {
                idr.Close();
                con.CerrarConexion();
            }

        }


        #endregion
        public dtDoctor()
        {
        }
    }
}
