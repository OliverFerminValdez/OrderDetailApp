using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OrderDetailApp.Models
{
    public class Ordenes
    {
        [Key]
        public int OrderId { get; set; }
        [Required(ErrorMessage = "El campo fecha es obligatorio")]
        public DateTime Fecha { get; set; } = DateTime.Now;
        [Required(ErrorMessage = "Es obligatorio asignar un suplidor")]
        public int SuplidorId { get; set; }
        public double Monto { get; set; }
        [ForeignKey("OrderId")]
        public virtual List<OrdenesDetalle> OrderDetail { get; set; } = new List<OrdenesDetalle>();

        public Ordenes()
        {
        }
    }
}
