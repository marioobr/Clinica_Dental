using System;
using Gtk;
using medicentro.Entidades.Doctores;
using medicentro.Datos;

namespace medicentro.Negocio
{
    public class ngDoctores
    {
        #region metodos

        //metodo Guardarempleado
        public bool NgGuardarDoctor(Doctor tdoc)
        {
            MessageDialog ms = null;
            bool guardado = false;

            try
            {
                bool existe = false;
                dtDoctor dtdoc = new dtDoctor();
                existe = dtdoc.ExisteDoctor(tdoc);

                if (existe)
                {
                    ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Error, ButtonsType.Ok, "El doctor ya existe");
                    ms.Run();
                    ms.Destroy();
                    return guardado;
                }
                else
                {
                    guardado = dtdoc.GuardarDoctores(tdoc);
                    if (guardado)
                    {
                        Console.WriteLine("Medicentro: EL doctor se guardo correctamente!!");
                        return guardado;
                    }
                    else
                    {
                        Console.WriteLine("Medicentro: Error al guardar el doctor, verificar metodo");
                        return guardado;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Ng: " + e.Message);
                Console.WriteLine("Ng: " + e.StackTrace);
                throw;
            }
        }//fin del metodo

        #endregion
        public ngDoctores()
        {
        }
    }
}
