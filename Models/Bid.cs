using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NBDPrototype.Models
{
    public class Bid
    {
        public Bid()
        {
            this.Bids = new HashSet<Bid>();
            this.BidItems = new HashSet<BidItem>();
            this.BidStaffs = new HashSet<BidStaff>();
            this.Amount = 0;
        }
        public int ID { get; set; }

        [Required(ErrorMessage = "A client is required to begin a bid")]
        [Display(Name = "Project Name")]
        public int ProjectID { get; set; }
        public Project Projects { get; set; }

        [Display(Name = "Submission Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Display(Name = "Estimated Starting Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? StartDate { get; set; }

        [Display(Name = "Estimated Closing Date")]
        [Required(ErrorMessage = "You cannot leave closing date blank.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ClosingDate { get; set; }

        [Display(Name = "Bid Amount")]
        [Required(ErrorMessage = "You must enter the amount.")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(9,2)")]//So only 5 bytes to store in SQL Server
        [Range(0, 9999999.99, ErrorMessage = "Invalid Amount.")]
        public decimal Amount { get; set; }

        [Display(Name = "Status")]
        public int StatusId { get; set; }
        public Status Statuses { get; set; }

        [Display(Name = "Approved")]
        public bool IsApproved { get; set; }

        public ICollection<Bid> Bids { get; set; }
        public ICollection<BidItem> BidItems { get; set; }
        public ICollection<BidStaff> BidStaffs { get; set; }
    }


}
