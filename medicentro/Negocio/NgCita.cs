using System;
using Gtk;
using medicentro.Entidades;
using medicentro.Datos;
using medicentro.Negocio;

namespace medicentro.Negocio
{
    public class NgCita
    {

        public bool NgGuardarCita(Cita cit)
        {
            MessageDialog ms = null;
            bool guardado = false;

            try
            {
                bool existe = false;
                dtCita dtCita = new dtCita();
                existe = dtCita.ExisteCita(cit);

                if (existe)
                {
                    ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Error, ButtonsType.Ok, "La cita ya existe");
                    ms.Run();
                    ms.Destroy();
                    return guardado;
                }
                else
                {
                    guardado = dtCita.GuardarCita(cit);
                    if (guardado)
                    {
                        Console.WriteLine("Medicentro: EL paciente se guardo correctamente!!");
                        return guardado;
                    }
                    else
                    {
                        Console.WriteLine("Medicentro: Error al guardar el paciente, verificar metodo");
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









        public NgCita()
        {
        }
    }
}
