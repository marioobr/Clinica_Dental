using System;
namespace medicentro.Entidades.Productos
{
    public class TipoProducto
    {
        //Atributos
        private int idTipoProducto;
        private string Descripción;

        //Metods

        public int IdTipoProducto { get => idTipoProducto; set => idTipoProducto = value; }
        public string Descripción1 { get => Descripción; set => Descripción = value; }

        public TipoProducto()
        {
        }
    }
}
