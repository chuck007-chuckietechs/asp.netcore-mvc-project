using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NBDPrototype.Models
{
    public class Contact
    {
        public int ID { get; set; }

        [Display(Name = "contact")]
        public string FullName
        {
            get
            {
                return FirstName+" "+ LastName+",Mgr.";
            }
        }


        [Display(Name = "First Name")]
        [Required(ErrorMessage = "You cannot leave the first name blank.")]
        [StringLength(50, ErrorMessage = "First name cannot be more than 50 characters long.")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [StringLength(50, ErrorMessage = "Last name cannot be more than 50 characters long.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [RegularExpression("^\\d{10}$", ErrorMessage = "Please enter a valid 10-digit phone number (no spaces).")]
        [DataType(DataType.PhoneNumber)]
        [DisplayFormat(DataFormatString = "{0:(###) ###-####}", ApplyFormatInEditMode = false)]
        public Int64 Phone { get; set; }

        [Display(Name = "Clients")]
        public int? ClientID { get; set; }
        public Client Client { get; set; }

    }
}
