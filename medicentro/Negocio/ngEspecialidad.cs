using System;
using Gtk;
using medicentro.Negocio;
using medicentro.Entidades;
using medicentro.Entidades.Doctores;
using medicentro.Datos;


namespace medicentro.Negocio
{
    public class ngEspecialidad
    {
        public bool NgGuardarEspecialidad(Especialidad tEsp)
        {
            MessageDialog ms = null;
            bool guardado = false;

            try
            {
                bool existe = false;
                dtEspecialidad dtEsp = new dtEspecialidad();
                existe = dtEsp.ExisteEspecialidad(tEsp);

                if (existe)
                {
                    ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Error, ButtonsType.Ok, "La especialidad ya existe");
                    ms.Run();
                    ms.Destroy();
                    return guardado;
                }
                else
                {
                    guardado = dtEsp.GuardarEspecialidad(tEsp);
                    if (guardado)
                    {
                        Console.WriteLine("Medicentro: La especialidad se guardo correctamente!!");
                        return guardado;
                    }
                    else
                    {
                        Console.WriteLine("Medicentro: Error al guardar la especialidad, verificar metodo");
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



        public ngEspecialidad()
        {
        }
    }
}
