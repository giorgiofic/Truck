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
        [Display(Name = "Model")]
        public int IdModel { get; set; }

        [Required]
        [Display(Name ="Year Fabrication")]
        public int YearFabrication { get; set; }

        [Required]
        [Display(Name = "Year Model")]
        [Range(2000, 9999, ErrorMessage = "Year invalid")]
        public int YearModel { get; set; }

        //Fk
        public virtual ModelTruck? ModelTruck { get; set; }
    }
}
