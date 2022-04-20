using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Truck.Domain.Models
{
    public class Truck
    {
        [Key]
        public int IdTruck { get; set; }
        
        [StringLength(100)]
        public string? Description { get; set; }

        [Required]
        public int IdModel { get; set; }

        [Required]
        public int YearFabrication { get; set; }

        [Required]
        public int YearModel { get; set; }

        //Fk
        public virtual ModelTruck ModelTruck { get; set; }
    }
}
