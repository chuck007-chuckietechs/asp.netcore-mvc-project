using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NBDPrototype.Models
{
    public class ItemType
    {
        //public ItemType()
        //{
        //    this.ItemTypes = new HashSet<ItemType>();
        //}
        public int ID { get; set; }
        
        [Display(Name = "Item Type")]
        [Required(ErrorMessage = "Cannot leave blank.")]
        [StringLength(50, ErrorMessage = "Cannot be more than 50 characters long.")]
        public string Type { get; set; }


        //public ICollection<ItemType> ItemTypes { get; set; }
    }
}
