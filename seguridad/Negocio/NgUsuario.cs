using System;
using Gtk;
using seguridad.entidades;
using seguridad.datos;

namespace seguridad.Negocio
{
    public class NgUsuario
    {
        #region metodos

        //metodo Guardarempleado
        public bool NgGuardarUser(Tbl_user tus)
        {
            MessageDialog ms = null;
            bool guardado = false;

            try
            {
                bool existe = false;
                dtUsuarios dtus = new dtUsuarios();
                existe = dtus.ExisteUser(tus);

                if(existe)
                {
                    ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Error, ButtonsType.Ok, "El usuario ya existe");
                    ms.Run();
                    ms.Destroy();
                    return guardado;
                }
                else
                {
                    guardado = dtus.GuardarUsuarios(tus);
                    if(guardado)
                    {
                        Console.WriteLine("NG: El usuario se guardo correctamente!!");
                        return guardado;
                    }
                    else
                    {
                        Console.WriteLine("NG: Error al guardar el usuario, verificar metodo");
                        return guardado;
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Ng: "+e.Message);
                Console.WriteLine("Ng: "+e.StackTrace);
                throw;
            }
        }//fin del metodo

        #endregion
        public NgUsuario()
        {
        }
    }
}
