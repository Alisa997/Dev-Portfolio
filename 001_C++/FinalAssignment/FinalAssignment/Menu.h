#pragma once
#include "pch.h"
#include "MenuItem.h"
#include "Utils.h"

// application menu
class Menu
{
public:
    static const int MAX_LEN_TITLE = 91;

    // static class member, access via ClassName::memberName
    static const int N_PALETTE = 4;
    static const int PAL_TITLE = 0;
    static const int PAL_ORDINAL = 1;
    static const int PAL_CURRENT = 2;
    static const int PAL_CONSOLE = 3;

    // standard commands
    static const int CMD_QUIT = 100;

private:
    char* title;             // menu title
    MenuItem* items;             // array of menu items
    int      nItems;             // number of items in the array
    short* palette;           // menu color palette
    COORD    position;           // starting position for displaying the menu
    int      currentItem;        // index of the current menu item (for executing a command)
    int      maxLengthItemText;  // maximum length of an item text for forming the pseudo-cursor

public:
    Menu()
        : title(), items(), nItems(), palette(), position(COORD{ 0, 0 }), currentItem()
    {
    }

    Menu(const char* title, MenuItem* items, int nItems, short* palette, COORD position)
        : title(), items(), nItems(nItems), palette(), position(position), currentItem()
    {
        // set the menu title
        this->title = new char[MAX_LEN_TITLE];
        strcpy(this->title, title);

        // set the menu items and determine the length of the longest item name
        // We use a "divine" loop here—justification: we do not change the menu,
        // so there's no need to find a new longest item in any other place in the app
        this->items = new MenuItem[nItems];
        maxLengthItemText = -1;

        for (int i = 0; i < nItems; ++i) {
            this->items[i].command = items[i].command;
            this->items[i].current = items[i].current;

            this->items[i].text = new char[MenuItem::MAX_ITEM_TEXT];
            strcpy(this->items[i].text, items[i].text);

            int lenItem = strlen(items[i].text);
            if (lenItem > maxLengthItemText)
                maxLengthItemText = lenItem;
        } // for i

        // set the 0-th item as current
        this->items[currentItem].current = true;

        // set the menu palette
        this->palette = new short[N_PALETTE];
        memcpy(this->palette, palette, N_PALETTE * sizeof(short));
    } // Menu

    // display the menu
    void Show();

    // menu navigation, choose a command
    int Navigate();
};