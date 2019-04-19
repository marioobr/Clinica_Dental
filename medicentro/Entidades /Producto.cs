using System;
namespace medicentro.Entidades.Productos
{
    public class Producto
    {
        //Atributos 

        private int id_producto;
        private int id_tipoProducto;
        private String nombre_producto;
        private float precioprod;
        private string descripcion_prod;
        private int stock;
        private int cantini;
        private int estado;

        //METODS

        public int Id_producto { get => id_producto; set => id_producto = value; }
        public string Nombre_producto { get => nombre_producto; set => nombre_producto = value; }
        public float Precioprod { get => precioprod; set => precioprod = value; }
        public string Descripcion_prod { get => descripcion_prod; set => descripcion_prod = value; }
        public int Stock { get => stock; set => stock = value; }
        public int Cantini { get => cantini; set => cantini = value; }
        public int Estado { get => estado; set => estado = value; }
        public int Id_tipoProducto { get => id_tipoProducto; set => id_tipoProducto = value; }

        public Producto()
        {
        }
    }
}
