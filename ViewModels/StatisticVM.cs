using NBDPrototype.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBDPrototype.ViewModels
{
    public class StatisticVM
    {
        public int TotalAmountOfProjects { get; set; }
        public int TotalAmountOfBids { get; set; }
        public int TotalAprovedProjects { get; set; }
        public int TotalNotApprovedProjects { get; set; }
        public int TotalClients { get; set; }
        public int TotalStaffs { get; set; }

        public PaginatedList<Tuple<string, int>> ItemCount { get; set; }
        public PaginatedList<Tuple<string, decimal>> TopBidPerProject { get; set; }

        public PaginatedList<Tuple<string, decimal>> DesignersPerProject { get; set; }



    }
}
