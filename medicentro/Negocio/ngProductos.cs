using System;
using medicentro.Entidades;
using Gtk;
using medicentro.Datos;
using medicentro.Entidades.Productos;

namespace medicentro.Negocio
{
    public class ngProductos
    {
        dtProducto dtprod = new dtProducto();
        MessageDialog ms = null;
        #region metodos

        //metodo Guardarempleado
        public bool NgGuardarProductos(Producto prod)
        {
            bool guardado = false;
            try
            {
                //bool existe = false;
                //existe = dtus.existeUser(tus);
                if (dtprod.existeProducto(prod))
                {
                    ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Error,
                        ButtonsType.Ok, "El producto ya existe!!! por favor intente con otro producto.");
                    ms.Run();
                    ms.Destroy();
                    return guardado;
                }
                else
                {
                    guardado = dtprod.GuardarProductos(prod);
                    if (guardado)
                    {
                        Console.WriteLine("NG: El producto se guardo exitosamente!!!");
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
        }//fin del metodo

        #endregion
        public ngProductos()
        {
        }
    }
}
