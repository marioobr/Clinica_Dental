using System;
using Gtk;
using medicentro.Entidades;
using medicentro.Datos;
using medicentro.Negocio;


namespace medicentro.Negocio
{
    public class NgPaciente
    {

        #region metodos

        //metodo GuardarPaciente

        public bool NgGuardarPaciente(Paciente pa)
        {
            MessageDialog ms = null;
            bool guardado = false;

            try
            {
                bool existe = false;
                dtPaciente dtpac = new dtPaciente();
                existe = dtpac.ExistePaciente(pa);

                if (existe)
                {
                    ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Error, ButtonsType.Ok, "El paciente ya existe");
                    ms.Run();
                    ms.Destroy();
                    return guardado;
                }
                else
                {
                    guardado = dtpac.GuardarPaciente(pa);
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

        #endregion

        public NgPaciente()
        {
        }
    }
}
