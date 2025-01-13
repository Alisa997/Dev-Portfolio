using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.Models
{
    internal class Seller {
        // identifier
        public int Id { get; set; } // Id

        // Seller's first name
        public string Name { get; set; } // Name

        // Seller's last name
        public string Surname { get; set; } // Surname

        // Seller's patronymic
        public string Patronymic { get; set; } // Patronymic

        // commission percentage for sales
        public double Interest { get; set; } // Interest

        // representation of the object as a table row
        public string ToTableRow() =>
            $"  │ {Id,3} │ {Surname, 15} │ {Name,11} │ {Patronymic,15} │ {Interest,20:f2} % │";

        // static method to print the table header
        public static string Header() =>
                $"  ┌─────┬─────────────────┬─────────────┬─────────────────┬────────────────────────┐\n" +
                $"  │ ID  │ Last Name       │ First Name  │ Patronymic      │ Commission Percentage  │\n" +
                $"  ├─────┼─────────────────┼─────────────┼─────────────────┼────────────────────────┤";

        // static method for printing the table footer
        public static string Footer() =>
            $"  └─────┴─────────────────┴─────────────┴─────────────────┴────────────────────────┘\n";
    } // Seller
}
