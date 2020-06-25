using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace OrderDetailApp.Models
{
    public class OrdenesDetalle
    {
        [Key]
        public int Id { get; set; }
        public int ProductoId { get; set; }
        public int OrderId { get; set; }
        public double Cantidad { get; set; }
        public double Costo { get; set; }

        public OrdenesDetalle(int id, int productoId, int orderId, double cantidad, double costo)
        {
            Id = id;
            ProductoId = productoId;
            OrderId = orderId;
            Cantidad = cantidad;
            Costo = costo;
        }
    }
}
