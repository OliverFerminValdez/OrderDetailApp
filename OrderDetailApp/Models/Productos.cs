using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrderDetailApp.Models
{
    public class Productos
    {
        [Key]
        public int ProductoId { get; set; }
        [Required(ErrorMessage = "La descripcion del producto es obligatoria")]
        public string Descripcion { get; set; }
        [Range(minimum: 1, maximum: 1000000, ErrorMessage = "Eliga un rango de 1 a 1000000")]
        public double Costo { get; set; }
        [Range(minimum: 1, maximum: 1000000, ErrorMessage = "Eliga un rango de 1 a 1000000")]
        public double Inventario { get; set; }

        public Productos(int productoId, string descripcion, double costo, double inventario)
        {
            ProductoId = productoId;
            Descripcion = descripcion;
            Costo = costo;
            Inventario = inventario;
        }

        public Productos()
        {
        }
    }
}
