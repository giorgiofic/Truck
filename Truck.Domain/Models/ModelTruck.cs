using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Truck.Domain.Models
{
    public class ModelTruck
    {
        [Key]
        public int IdModel { get; set; }
        
        [Required]
        [StringLength(10)]
        public string Model { get; set; }

        //Fk
        public virtual List<Truck> Trucks { get; set; }
    }
}
