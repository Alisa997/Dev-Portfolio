#pragma once
#include "pch.h"
#include "Product.h"

/*
 * Concrete subclass of Product class - Detergent (Cleaning Agent)
 */
class Detergent : public Product {
    string title_;         // title
    string formula_;       // formula
    string manufacturer_;  // manufacturer
    int    price_;         // price
public:
    // constructors
    Detergent() :Detergent("No information", "No information", "No information", 1) {
        setName("Detergent"); }

    Detergent(const string& title, const string& formula, const string& manufacturer, int price) {
        setName("Detergent");

        SetTitle(title);
        SetFormula(formula);
        SetManufacturer(manufacturer);
        SetPrice(price);
    } // Detergent

    const string& GetTitle()const { return title_; }
    void   SetTitle(const string& title) { title_ = title; }

    const string& GetFormula()const { return formula_; }
    void   SetFormula(const string& formula) { formula_ = formula; }

    const string& GetManufacturer()const { return manufacturer_; }
    void   SetManufacturer(const string& manufacturer) { manufacturer_ = manufacturer; }

    int GetPrice()const { return price_; }
    void SetPrice(int price) {
        if (price <= 0) throw exception("Detergent: Incorrect price value!");
        price_ = price;
    } // SetPrice

    // Implementing the virtual function in the subclass
    Product* Clone()const {
        return  new Detergent(*this);
    } // Clone

    // Print table header
    static ostream& Header(ostream& os);

    // Print table footer
    static ostream& Footer(ostream& os);

    // Print table row
    string ToTableRow(int row) const;

    friend ostream& operator<<(ostream& os, const Detergent& bus);
};

// Print table header
ostream& Detergent::Header(ostream& os) {
    os  << "    +—————+——————————————————+—————————————————————+———————————————————+——————————+\n"
        << "    |  N  |   Title   |       Formula       |   Manufacturer   |   Price,  |\n"
        << "    | No. | cleaning agent |                     |                   |   rub.   |\n"
        << "    +—————+——————————————————+—————————————————————+———————————————————+——————————+\n";
    return os;
} // Detergent::Header

// Print table footer
inline ostream& Detergent::Footer(ostream& os) {
    os << "    +—————+——————————————————+—————————————————————+———————————————————+——————————+\n";
    return os;
} // Detergent::Footer

// Print table row
string Detergent::ToTableRow(int row) const {
    ostringstream oss;
    oss << " | " << setw(3) << row
        << " | " << setw(16) << left << title_
        << " | " << setw(19) << formula_ 
        << " | " << setw(17) << manufacturer_ << right
        << " | " << setw(8) << price_ << " |";
    return oss.str();
} // Detergent::ToTableRow

// Overloaded output operator
ostream& operator<<(ostream& os, const Detergent& detergent) {
    os  << "\n    =====================================================\n"
        << "    Cleaning Agent Title: " << detergent.title_ << "\n"
        << "    Formula             : " << detergent.formula_ << "\n"
        << "    Manufacturer        : " << detergent.manufacturer_ << "\n"
        << "    Price               : " << detergent.price_ << " rub.\n"
        << "    =====================================================\n\n";
    return os;
}