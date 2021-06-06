using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NBDPrototype.Models;

namespace NBDPrototype.ViewModels
{
    public class BidVM
    {
        public IEnumerable<Bid> Bids { get; set; }
        public IEnumerable<BidItem> BidItems { get; set; }
        public IEnumerable<Item> Items { get; set; }
        public IEnumerable<BidStaff> BidStaffs { get; set; }
        public IEnumerable<Staff> Staffs { get; set; }

        public int ItemId { get; set; }
        public Item Item { get; set; }
        public int BidItemId { get; set; }
        public BidItem BidItem { get; set; }
        public int BidStaffId { get; set; }
        public BidStaff BidStaff { get; set; }


        public decimal? TotalAmount
        {
            get
            {
                return BidStaff.TotalStaffEarnings + BidItem.TotalItemCosts;
            }
        }
    }

}
