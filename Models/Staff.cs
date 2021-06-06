using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace NBDPrototype.Models
{
    public class Staff
    {
        public Staff()
        {
            this.BidStaffs = new HashSet<BidStaff>();
        }
        public int ID { get; set; }

        [Display(Name = "Staff Name")]
        public string StaffFullName
        {
            get
            {
                return StaffFirstName + " " + StaffLastName;
            }
        }

        public string StaffFullNameAndJob
        {
            get
            {
                return StaffFirstName + " " + StaffLastName + " - " + Labour.Description;
            }
        }

        public decimal? LabourCost
        {
            get
            {
                return Labour.PriceHour;
            }
        }

        [Display(Name = "Staff Role")]
        [Required(ErrorMessage = "Please select a role")]
        public int LabourId { get; set; }

        public Labour Labour { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "You cannot leave the first name blank.")]
        [StringLength(50, ErrorMessage = "First name cannot be more than 50 characters long.")]
        public string StaffFirstName { get; set; }

        [Display(Name = "Last Name")]
        [StringLength(50, ErrorMessage = "Last name cannot be more than 50 characters long.")]
        public string StaffLastName { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [RegularExpression("^\\d{10}$", ErrorMessage = "Please enter a valid 10-digit phone number (no spaces).")]
        [DataType(DataType.PhoneNumber)]
        [DisplayFormat(DataFormatString = "{0:(###) ###-####}", ApplyFormatInEditMode = false)]
        public Int64 StaffPhone { get; set; }

        public ICollection<BidStaff> BidStaffs { get; set; }
        //public ICollection<Bid> Bids { get; set; }

    }
}
