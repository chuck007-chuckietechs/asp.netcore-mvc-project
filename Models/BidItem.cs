using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NBDPrototype.Models
{
    public class BidItem
    {
        public int ID { get; set; }
        public int BidId { get; set; }
        public Bid Bid { get; set; }

        public int ItemId { get; set; }
        public Item Item { get; set; }

        [Required(ErrorMessage = "Please enter the amount needed.")]
        [Display(Name = "Quantity")]
        public int BidItemQuantity { get; set; }


        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(9,2)")]
        public decimal? TotalItemCosts
        {
            get
            {
                {
                    return Item?.Price * BidItemQuantity;
                }
            }
        }

    }
}
