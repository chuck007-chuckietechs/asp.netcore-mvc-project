using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NBDPrototype.Models
{
    public class Item
    {
        public Item()
        {
            this.Items = new HashSet<Item>();
            this.BidItems = new HashSet<BidItem>();
        }

        public string? ItemTypeMethod
        {
            get
            {
                return ItemType?.Type;
            }
        }

        public int ID { get; set; }

        [Required(ErrorMessage = "Please select the item type")]
        [Display(Name = "Code")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Please select the item type")]
        [Display(Name = "Type")]
        public int ItemTypeId { get; set; }
        public ItemType ItemType { get; set; }

        [Required(ErrorMessage = "Please enter a description")]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please enter the size")]
        [Display(Name = "Size")]
        public string Size { get; set; }

        [Display(Name = "Price")]
        [Required(ErrorMessage = "You must enter the amount.")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(9,2)")]
        [Range(0, 9999999.99, ErrorMessage = "Invalid Amount.")]
        public decimal Price { get; set; }
        public ICollection<Item> Items { get; set; }
        public ICollection<BidItem> BidItems { get; set; }
    }
}
