using System;
namespace medicentro.Entidades
{
    public class Factura
    {
        private int id_factura;
        private String no_rucImp;
        private String no_ruc;
        private int id_paciente;
        private int id_user;
        private DateTime fecha;
        private float subtotal;
        private float iva;
        private float total;
        private float descuento;
        private float efectivo;
        private float cambio;

        //Metods

        public int Id_factura { get => id_factura; set => id_factura = value; }
        public string No_rucImp { get => no_rucImp; set => no_rucImp = value; }
        public string No_ruc { get => no_ruc; set => no_ruc = value; }
        public int Id_paciente { get => id_paciente; set => id_paciente = value; }
        public int Id_user { get => id_user; set => id_user = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public float Subtotal { get => subtotal; set => subtotal = value; }
        public float Iva { get => iva; set => iva = value; }
        public float Total { get => total; set => total = value; }
        public float Descuento { get => descuento; set => descuento = value; }
        public float Efectivo { get => efectivo; set => efectivo = value; }
        public float Cambio { get => cambio; set => cambio = value; }

        public Factura()
        {
        }
       

    }
}
