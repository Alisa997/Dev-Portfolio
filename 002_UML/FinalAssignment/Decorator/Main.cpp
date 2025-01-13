#include "pch.h"
#include "Utils.h"
#include "Palette.h"
#include "ItalianPizza.h"
#include "BulgarianPizza.h"
#include "SeafoodPizza.h"
#include "AddIngredient.h"


/*
*   Decorator Pattern – console application (application template, pattern illustration).
*   There is a pizzeria that prepares various types of pizzas with different toppings. 
*   There are Italian, Bulgarian pizzas, and seafood pizza. Toppings like 
*   tomatoes, cheese, anchovies, etc., can be added. Depending on the type of pizza 
*   and the combination of toppings, the pizza can have different prices.
*/

int main()
{
	// setup console output
	init(L"Final task for 11.10.2021 - Task 3. Decorator Pattern");

    try {
        ItalianPizza* ip = new ItalianPizza();
        BulgarianPizza* bp = new BulgarianPizza();
        SeafoodPizza* sp = new SeafoodPizza();
        cout << "  Types of pizzas:";
        ip->Show();
        bp->Show();
        sp->Show();

        cout << "\n\n------------------------------\nAdding ingredients:";
        AddIngredient* addToIp = new AddIngredient(ip);
        addToIp->AddItem("Tomatoes", 20);
        addToIp->AddItem("Cheese", 30);
        addToIp->Show();

        // remove the added ingredient
        cout << "\n\n------------------------------\nTomatoes removed:";
        addToIp->RemoveItem("Tomatoes", 20);
        addToIp->Show();

        delete addToIp;
        delete ip;
        delete bp;
        delete sp;
        getKey();
    }
    catch (exception& ex) {
        setColor(mainColor);
        cls();
        showNavBarMessage(hintColor, "  Application error, press any key to continue...");

        // add 4 spaces before the error message, line length is 64 characters
        char buf[65];
        sprintf(buf, "    %-60s", ex.what());

        // control is passed here by the throw operator
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
