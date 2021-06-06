using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NBDPrototype.Models
{
    public class Labour
    {
        public int ID { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Please enter a description")]
        [StringLength(50, ErrorMessage = "Cannot be more than 50 characters long.")]
        public string Description { get; set; }

        [Display(Name = "Hourly Wage")]
        [Required(ErrorMessage = "You must enter the amount.")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(9,2)")]
        [Range(0, 9999999.99, ErrorMessage = "Invalid Amount.")]
        public decimal PriceHour { get; set; }

        public ICollection<Staff> Staffs { get; set; }

    }
}
