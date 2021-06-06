using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NBDPrototype.Models
{
    public class BidStaff
    {
        public int ID { get; set; }
        public int BidId { get; set; }
        public Bid Bid { get; set; }

        public int StaffId { get; set; }
        public Staff Staff { get; set; }

        [Required(ErrorMessage = "State estimated hours.")]
        [Display(Name = "Hours")]
        public int BidStaffTotalHours { get; set; }

        [Display(Name = "Markup Cost")]
        [Required(ErrorMessage = "You must enter the amount.")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(9,2)")]//So only 5 bytes to store in SQL Server
        [Range(0, 9999999.99, ErrorMessage = "Invalid Amount.")]
        public decimal BidStaffMarkup { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(9,2)")]
        public decimal? TotalStaffEarnings
        {
            get
            {
                return (BidStaffTotalHours * Staff?.LabourCost) + BidStaffMarkup;
            }
        }
    }
}
