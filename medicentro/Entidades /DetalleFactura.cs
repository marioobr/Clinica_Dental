using System;
namespace medicentro.Entidades
{
    public class DetalleFactura
    {
        //Atributos

        private int idDetalle_factura;
        private int id_factura;
        private int cantidad;
        private int id_producto;

        //METODS

        public int IdDetalle_factura { get => idDetalle_factura; set => idDetalle_factura = value; }
        public int Id_factura { get => id_factura; set => id_factura = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public int Id_producto { get => id_producto; set => id_producto = value; }

        public DetalleFactura()
        {
        }


    }
}
