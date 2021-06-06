using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NBDPrototype.Models
{
    public class Project
    {
        public Project()
        {
            this.Bids = new HashSet<Bid>();
        }
        public int ID { get; set; }

        [Display(Name = "Project Name")]
        public string Name { get; set; }

        [Display(Name = "Project Site")]
        public string Location { get; set; }

        [Required(ErrorMessage = "A client is required to begin a project")]
        [Display(Name = "Client Name")]
        public int ClientID { get; set; }
        public Client Client { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        [Display(Name = "Starting Date")]
        [DataType(DataType.Date)]
        public DateTime? DateStart { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        [Display(Name = "Completion Date")]
        [DataType(DataType.Date)]
        public DateTime DateComplete { get; set; }
        public ICollection<Bid> Bids { get; set; }

    }
}
