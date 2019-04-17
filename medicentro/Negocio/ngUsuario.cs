using System;
using Gtk;
using medicentro.Entidades.Seguridad;
using medicentro.Datos;
using Genesis.Datos;

namespace medicentro.Negocio
{
    public class ngUsuario
    {
        #region metodos

        public bool ngGuardarUser(User tus)
        {
            MessageDialog ms = null;
            bool guardado = false;
            try
            {
                //bool existe = false;
                DtUser dtus = new DtUser();
                //existe = dtus.existeUser(tus);
                if (dtus.existeUser(tus))
                {
                    ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Error,
                        ButtonsType.Ok, "El Usuario ya existe!!! por favor intente con otro usuario.");
                    ms.Run();
                    ms.Destroy();
                    return guardado;
                }
                if (dtus.existeEmail(tus))
                {
                    ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Error,
                        ButtonsType.Ok, "El correo electrónico ya existe!!! por favor intente con otro correo.");
                    ms.Run();
                    ms.Destroy();
                    return guardado;
                }
                else
                {
                    guardado = dtus.GuardarUsuario(tus);
                    if (guardado)
                    {
                        Console.WriteLine("NG: El Usuario se guardo exitosamente!!!");
                        return guardado;
                    }
                    else
                    {
                        ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Error,
                        ButtonsType.Ok, "Por favor verifique sus datos e intente nuevamente!!!");
                        ms.Run();
                        ms.Destroy();
                        Console.WriteLine("NG: ERROR AL GUARDAR, VERIFICAR EL METODO");
                        return guardado;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("NG: ERROR=" + e.Message);
                Console.WriteLine("NG: ERROR=" + e.StackTrace);
                throw;
                //return guardado;
            }

        }
        #endregion




        public ngUsuario()
        {
        }
    }
}
