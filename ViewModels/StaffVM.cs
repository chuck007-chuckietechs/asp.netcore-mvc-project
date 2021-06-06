using NBDPrototype.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBDPrototype.ViewModels
{
    public class StaffVM
    {
        public int ID { get; set; }

        [Display(Name = "Staff Role")]
        [Required(ErrorMessage = "Please select a role")]
        public int LabourId { get; set; }

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

        public Staff Convert()
        {
            return new Staff
            {
                ID = this.ID,
                LabourId = this.LabourId,
                StaffFirstName = this.StaffFirstName,
                StaffLastName = this.StaffLastName,
                StaffPhone = this.StaffPhone
            };
        }
    }
}
