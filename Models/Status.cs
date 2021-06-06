using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NBDPrototype.Models
{
    public class Status
    {
        public int ID { get; set; }

        [Display(Name = "Status")]
        public string BidStatus { get; set; }

        public ICollection<Bid> Bids { get; set; }
    }
}
