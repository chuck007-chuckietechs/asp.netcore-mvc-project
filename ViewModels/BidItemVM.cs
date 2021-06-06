using NBDPrototype.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBDPrototype.ViewModels
{
    public class BidItemVM
    {
        public IEnumerable<Bid> Bids { get; set; }
        public IEnumerable<BidItem> BidItems { get; set; }
        public IEnumerable<Item> Items { get; set; }


    }
}
