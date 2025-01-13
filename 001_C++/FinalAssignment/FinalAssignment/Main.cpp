#include "App.h"
#include "pch.h"

#include "Utils.h"
#include "MenuItem.h"
#include "Menu.h"

int main()
{
    // console output setup
    init(L"FinalAssignment");

    // application class
    App* app = new App();

    // application command codes
    enum Commands {
        CMD_TASK1,    // Task 1
        CMD_TASK2,    // Task 2
        CMD_TASK3,    // Task 3
    };
    // application menu items

    const int N_MENU = 4;
    MenuItem items[N_MENU] = {
        MenuItem("  Task 1  ", CMD_TASK1),
        MenuItem("  Task 2  ", CMD_TASK2),
        MenuItem("  Task 3  ", CMD_TASK3),
        MenuItem("  Exit",  Menu::CMD_QUIT)
    };

    const int N_PALETTE = 5;
    //                          header          item            selected item  console
    short palette[N_PALETTE] = { WHITE_ON_BLACK, LTCYAN_ON_BLACK, BLACK_ON_LTCYAN, mainColor };

    Menu mainMenu("Main Menu", items, N_MENU, palette, COORD{ 5, 5 });

    while (true) {
        try {
            cout << color(palette[Menu::PAL_CONSOLE]) << cls;
            int cmd = mainMenu.Navigate();
            cout << color(palette[Menu::PAL_CONSOLE]) << cls;
            if (cmd == Menu::CMD_QUIT) break;

            switch (cmd) {

                // Task 1
            case CMD_TASK1:
                app->getTask1().start();
                break;

                // Task 2
            case CMD_TASK2:
                app->getTask2().start();
                break;

                // Task 3
            case CMD_TASK3:
                app->getTask3().start();
                break;

            } // switch
        }
        catch (exception& ex) {
            cout << color(errColor) << "\n\n\t\t\t                                                                                      \n";
            cout << "\t\t\t ************************************************************************************ \n";
            cout << "\t\t\t                                     Exception.                                       \n";
            cout << "\t\t\t " << setw(80) << ex.what() << "     \n";
            cout << "\t\t\t                                                                                      \n";
            cout << "\t\t\t ************************************************************************************ \n";
            cout << "\t\t\t                                                                                      \n"
                << color(mainColor);
        } // try-catch
        getKey("\n\n\nPress any key to continue...");
    } // while

    cout << cls << pos(0, 24);
    getKey();

    delete app;
    return 0;
} // main
