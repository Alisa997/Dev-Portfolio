using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.Models
{
    // 
    internal class QueryViewModel {
        // identifier
        public int Id { get; set; } // Id

        // seller's surname and initials / product name
        public string Title { get; set; } // Title

        // number of sales
        public int SalesAmount { get; set; } // SalesAmount

        // total sales amount
        public int SalesTotal { get; set; } // SalesTotal

    }
}
