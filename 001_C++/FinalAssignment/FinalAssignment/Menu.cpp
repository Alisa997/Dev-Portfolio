#include "pch.h"
#include "MenuItem.h"
#include "Menu.h"

// Display the menu. To prevent flickering, we do not clear the screen each time,
// but for every menu item we print using a "pseudo-cursor" of fixed width.
// The current menu item is highlighted in color, creating the effect
// of a moving pseudo-cursor.
void Menu::Show()
{
    // output the title, taking into account the left indent of the pseudo-cursor at position 4
    cout << cursor_off
        << pos(position.X + 4, position.Y)
        << color(palette[PAL_TITLE])
        << title;

    ostringstream oss;

    for (int i = 0; i < nItems; ++i) {
        // force the pseudo-cursor
        oss.str("");
        oss << "    " << left << setw(maxLengthItemText) << items[i].text << "    ";

        // display the menu item; highlight the current item in color
        cout << pos(position.X, position.Y + i + 1)
            << color(palette[items[i].current ? PAL_CURRENT : PAL_ORDINAL])
            << oss.str();
    } // for i

    cout << color(palette[PAL_CONSOLE]);
} // Menu::Show

// Menu navigation - handle keystrokes and choose a command
int Menu::Navigate()
{
    while (true) {
        // display the menu
        Show();

        // read the key code
        int key = _getch();
        if (key == 0 || key == 224) key = _getch();

        // handle the key
        switch (key)
        {
        case K_UP: // up arrow key
            items[currentItem].current = false;
            --currentItem;
            if (currentItem < 0) currentItem = nItems - 1;
            items[currentItem].current = true;
            break;

        case K_DOWN: // down arrow key
            items[currentItem].current = false;
            ++currentItem;
            if (currentItem >= nItems) currentItem = 0;
            items[currentItem].current = true;
            break;

        case K_ENTER: // return the code of the selected command
            return items[currentItem].command;

        case K_ESC:   // return the code for the standard 'exit' command
            return CMD_QUIT;
        } // switch
    } // while
} // Menu::Navigate