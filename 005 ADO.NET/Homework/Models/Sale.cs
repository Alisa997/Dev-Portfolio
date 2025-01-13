using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.Models
{
    internal class Sale
    {
        // identifier
        public int Id { get; set; } // Id

        // product name
        public string Good { get; set; } // Good

        // short unit name
        public string Unit { get; set; } // Unit

        // seller's full name
        public string Seller { get; set; } // Seller

        // sale date
        public DateTime SaleDate { get; set; } // SaleDate

        // sale price per unit
        public int SalePrice { get; set; } // SalePrice

        // purchase price per unit
        public int PurchasePrice { get; set; } // PurchasePrice

        // amount of goods sold
        public int Amount { get; set; } // Amount

        // representation of the object as a table row string
        public string ToTableRow() =>
            $"  │ {Id,3} │ {Good,-19} │ {Unit,-11} │  {SaleDate,10:dd.MM.yyyy}  │ {PurchasePrice,12:f2} │ {SalePrice,12:f2} │ {Seller,-16}│ {Amount,6} │";

        // static method to print the table header
        public static string Header() =>
                $"  ┌─────┬─────────────────────┬─────────────┬──────────────┬──────────────┬──────────────┬─────────────────┬────────┐\n" +
                $"  │ ID  │ Product Name        │ Unit        │ Sale Date    │Purchase Price│  Sale Price  │ Seller          │Quantity│\n" +
                $"  ├─────┼─────────────────────┼─────────────┼──────────────┼──────────────┼──────────────┼─────────────────┼────────┤";

        // static method for printing the table footer
        public static string Footer() =>
            $"  └─────┴─────────────────────┴─────────────┴──────────────┴──────────────┴──────────────┴─────────────────┴────────┘\n";
    } // Sale
}
