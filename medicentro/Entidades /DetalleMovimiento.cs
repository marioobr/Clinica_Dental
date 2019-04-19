using System;
namespace medicentro.Entidades.Producto
{
    public class DetalleMovimiento
    {
        //ATRIBUTOS 

        private int id_detallemovimiento;
        private int id_producto;
        private String Descripcion_movimienteo;
        private int id_movimiento;
        private int cantmovimiento;
        private DateTime fechamov;
        private int id_user;

        //METODS

        public int Id_detallemovimiento { get => id_detallemovimiento; set => id_detallemovimiento = value; }
        public int Id_producto { get => id_producto; set => id_producto = value; }
        public int Id_movimiento { get => id_movimiento; set => id_movimiento = value; }
        public int Cantmovimiento { get => cantmovimiento; set => cantmovimiento = value; }
        public DateTime Fechamov { get => fechamov; set => fechamov = value; }
        public int Id_user { get => id_user; set => id_user = value; }
        public string Descripcion_movimienteo1 { get => Descripcion_movimienteo; set => Descripcion_movimienteo = value; }

        public DetalleMovimiento()
        {
        }

    }
}
