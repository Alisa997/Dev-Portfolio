#include "pch.h"
#include "Utils.h"
#include "Palette.h"
#include "Detergent.h"
#include <algorithm> 
#include <vector>


/*
*   Prototype Pattern – Console application (application template, illustration of the pattern).
*   There is a collection of objects describing detergents (name, formula, 
*   manufacturer, price). Implement cloning a specified object from a vector and the entire vector.
*/

// Display the vector of detergents in the console
void Show(vector<Product*> detergents, string title);

// Clone the entire vector.  
vector<Product*> Clone(vector<Product*> detergents);

int main()
{
	// Set up console output
	init(L"Final task on 11.10.2021 - Task 1. Prototype Pattern");

    try {

        // Vector of detergents
        vector<Product*> detergents {
            new Detergent("Solid soap"s, "C17H35COONa"s, "OOO \"HENKEL RUS\""s, 43),
            new Detergent("Shampoo"s, "C12H25(CH2CH2O)"s, "OAO \"Faberlik\""s, 250),
            new Detergent("Liquid soap"s, "C17H35COOK"s, "AO \"ARNEST\""s, 88),
            new Detergent("Bleach"s, "NaBO2*H2O2*3H2O"s, "AO \"AIST\""s, 55),
            new Detergent("Toothpaste"s, "SiO2"s, "AO \"SXZ\""s, 63)
        };

        Show(detergents, "\n  Initial vector of detergents:\n");

        // Clone a random object from the vector
        Product* temp = detergents[getRand(0, detergents.size() - 1)]->Clone();
        cout << "\n  Cloning a random object from the vector:" << *((Detergent*)temp);

        // Clone the entire vector.  
        vector<Product*> copy = Clone(detergents);
        Show(copy, "\n  Cloning the entire vector:\n");

        delete temp;
        getKey();
        }
    catch (exception& ex) {
        setColor(mainColor);
        cls();
        showNavBarMessage(hintColor, "  Application error, press any key to continue...");

        // Add 4 spaces before displaying the error message, the length of the string is 64 characters
        char buf[65];
        sprintf(buf, "    %-60s", ex.what());

        // In this section, control is passed by the throw operator
        const char* msg[] = {
            " ",
            "    [Error]",
            buf,
            " ",
            " ",
            nullptr
        };
        showMessage(8, 4, 64, msg, errColor);
    } // try-catch
    cout << endlm(2);
	return 0;
} // main

// Display the vector of detergents in the console
void Show(vector<Product*> detergents, string title) {
    cout << title << Detergent::Header;

    if (detergents.empty())
        cout << "    |                                 LIST IS EMPTY                                |\n";
    else {
        int row = 1;

        for_each(detergents.begin(), detergents.end(), [row](Product* detergent) mutable
            {	cout << "   " << ((Detergent*)detergent)->ToTableRow(row++) << endl; });
    } // if

    cout << Detergent::Footer;
} // Show

// Clone the entire vector.  
vector<Product*> Clone(vector<Product*> detergents) {
    vector<Product*> temp;

    for (int i = 0; i < detergents.size(); i++) 
        temp.push_back(detergents[i]->Clone());

    return temp;
} // Clone
