using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.Models
{
    internal class Purchase
    {
        // identifier
        public int Id { get; set; } // Id

        // product name
        public string Good { get; set; } // Good

        // short name of the unit of measurement
        public string Unit { get; set; } // Unit

        // purchase date
        public DateTime PurchaseDate { get; set; } // PurchaseDate

        // purchase price per unit of the product
        public int Price { get; set; } // Price

        // quantity of the product being purchased
        public int Amount { get; set; } // Amount

        // represents the object as a table row
        public string ToTableRow() =>
            $"  │ {Id,3} │ {(Good.Length > 31 ? $"{Good.Substring(0, 28)}..." : $"{Good,-31}")} │ {Unit,-11} │  {PurchaseDate,10:dd.MM.yyyy}  │ {Price,15:f2} │ {Amount,6} │";

        // static method for printing the table header
        public static string Header() {
            return
                $"  ┌─────┬─────────────────────────────────┬─────────────┬──────────────┬─────────────────┬────────┐\n" +
                $"  │ ID  │ Product Name                    │ Unit        │Purchase Date │ Price per Unit  │Quantity│\n" +
                $"  ├─────┼─────────────────────────────────┼─────────────┼──────────────┼─────────────────┼────────┤";
        } // Header

        // static method for printing the table footer
        public static string Footer() =>
            $"  └─────┴─────────────────────────────────┴─────────────┴──────────────┴─────────────────┴────────┘\n";
    }
}
