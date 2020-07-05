using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrderDetailApp.Models
{
    public class Suplidores
    {

        [Key]
        public int SuplidorId { get; set; }
        [Required(ErrorMessage = "Se requiere el nombre del suplidor")]
        public string Nombre { get; set; }

        public Suplidores()
        {
        }

        public Suplidores(int suplidorId, string nombre)
        {
            SuplidorId = suplidorId;
            Nombre = nombre;
        }
    }
}

