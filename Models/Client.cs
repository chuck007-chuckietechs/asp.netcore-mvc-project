using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NBDPrototype.Models
{
    public class Client
    {
        public Client()
        {
            this.Projects = new HashSet<Project>();
        }
        public int ID { get; set; }

        //[Display(Name = "Contact")]
        //public string ContactFullName
        //{
        //    get
        //    {
        //        return ContactName + " - " + ContactRole;
        //    }
        //}

        [Display(Name = "Client Name")]
        [Required(ErrorMessage = "You cannot leave the first name blank.")]
        [StringLength(50, ErrorMessage = "First name cannot be more than 50 characters long.")]
        public string ClientName { get; set; }

        [Display(Name = "Client Address")]
        [Required(ErrorMessage = "You must include an address")]
        [StringLength(50, ErrorMessage = "First name cannot be more than 50 characters long.")]
        public string ClientAddress { get; set; }

        [Display(Name = "Contact Name")]
        [Required(ErrorMessage = "You cannot leave the first name blank.")]
        [StringLength(50, ErrorMessage = "First name cannot be more than 50 characters long.")]
        public string ContactName { get; set; }

        //[Display(Name = "Contact Role")]
        //[Required(ErrorMessage = "You cannot leave the first name blank.")]
        //[StringLength(50, ErrorMessage = "Cannot be more than 50 characters long.")]
        //public string ContactRole { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [RegularExpression("^\\d{10}$", ErrorMessage = "Please enter a valid 10-digit phone number (no spaces).")]
        [DataType(DataType.PhoneNumber)]
        [DisplayFormat(DataFormatString = "{0:(###) ###-####}", ApplyFormatInEditMode = false)]
        [Display(Name = "Contact Phone")]
        public Int64 ContactPhone { get; set; }
        public ICollection<Project> Projects { get; set; }

        //one-to-one relationship(i.e only one contact per client
        //public Contact Contact { get; set; }


    }
}
