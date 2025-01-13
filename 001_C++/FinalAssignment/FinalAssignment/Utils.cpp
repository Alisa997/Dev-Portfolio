#include "pch.h"
#include "Utils.h"
#include "Colors.h"

// local global variable - static variable
// exists in a single instance (singleton),
// scope: this source file
static HANDLE h = GetStdHandle(STD_OUTPUT_HANDLE);

void init(const wchar_t title[])
{
    SetConsoleTitle(title);

    SetConsoleOutputCP(CODE_PAGE);
    SetConsoleCP(CODE_PAGE);
    srand(GetTickCount());
    cout << fixed << setprecision(2);
    
    setColor(GRAY_ON_LTBLACK);
    cls();
} // init

// get the code of the pressed key
int getKey(const char* prompt)
{
    cout << prompt;

    int key = _getch();
    if (key == 0 || key == 224) key = _getch();

    return key;
} // getKey

// generate a random integer
int getRand(int low, int high)
{
    return low + rand() % (high - low + 1);
} // getRand

// generate a random double
double getRand(double low, double high)
{
    double x = low + (high - low) * rand() / RAND_MAX;
    // if you want to generate 0:
    // return abs(x) < 0.8?0:x;
    return x;
} // getRand

// set the console text color
void setColor(short color)
{
    SetConsoleTextAttribute(h, color);
} // setColor

// input an integer number, with prompt[],
// and a valid range from 'from' to 'to'
int getInt(const char prompt[], int from, int to)
{
    int value;
    do {
        // actual input
        cout << prompt;
        cin >> value;

        // if a valid number was entered, exit the loop and the function
        if (!cin.fail()) break;

        // if it was not a valid number, clear the error flag,
        // and clear the input buffer
        cin.clear();
        cin.ignore(cin.rdbuf()->in_avail(), '\n');
    } while (value < from || value > to);

    return value;
} // getInt

// input a double number, with prompt[],
// and a valid range from 'from' to 'to'
double getDouble(const char* prompt, double from, double to)
{
    double value;
    do {
        // actual input
        cout << prompt;
        cin >> value;

        // if not a valid number, clear the error flag,
        // and clear the input buffer
        if (cin.fail()) {
            cin.clear();
            cin.ignore(cin.rdbuf()->in_avail(), '\n');
            value = from - 1; // remain in the loop
        }
    } while (value < from || value > to);

    return value;
} // getDouble

/// output a message in the top line of the console window - the navigation line used by tasks
void showNavBarMessage(short hintColor, const char* message)
{
    // save the current console color
    short oldColor = getColor();

    // new color and position for displaying the message
    setColor(hintColor);
    gotoXY(0, 0);

    // output the message with alignment
    // 138 - the width of the console window
    cout << setw(138) << left << message << right;

    // restore the previous color
    setColor(oldColor);
} // showNavBarMessage

// Output the "Function under development" message
void showUnderConstruction(short width, short infoColor)
{
    const char* msg[] = {
        " ", // symbol with code 255, without it, the left vertical border is not entirely vertical...
        "    [Information]",
        "    Function under development",
        " ", // symbol with code 255
        "    Press any key to continue...",
        " ", // symbol with code 255
        " ", // symbol with code 255
        nullptr // end of text marker
    };
    showMessage(8, 4, width, msg, infoColor);
    gotoXY(8, 30);
} // showUnderConstruction

// output the msg message in the screen area starting at position x, y
// output width is 'width', text color is msgColor
// output lines until a line equals nullptr
void showMessage(short x, short y, short width, const char* msg[], short msgColor)
{
    // save current console color
    short oldColor = getColor();
    setColor(msgColor);

    // output the message lines in a field width of 'width' characters
    // output is performed until a line equals nullptr
    // lines are left-aligned to automatically fill the output rectangle
    cout << left;
    for (short i = 0, row = y; msg[i] != nullptr; i++, row++) {
        cout << pos(x, row) << setw(width) << msg[i];
    }

    // restore right alignment and the previous color
    cout << right;
    setColor(oldColor);
} // showMessage

// output a prompt for input, show an input line, switch to the given color
void showInputLine(const char* prompt, int n, short color)
{
    cout << prompt;
    setColor(color);

    // output a line in the specified color, then move
    // the cursor back to the start of that line minus 1 symbol
    for (int i = 0; i < n; ++i) cout << " ";
    for (int i = 0; i < n - 1; ++i) cout << "\b";
} // showInputLine

// ------------------------------- WinAPI structures usage -------------------------------

// move the cursor to the specified position in the console
void gotoXY(short x, short y) {
    SetConsoleCursorPosition(h, COORD{ x, y });
} // gotoXY

// show or hide the console cursor
// mode: true  - show cursor
//       false - hide cursor
void setCursorVisible(bool mode)
{
    // another WinAPI structure
    CONSOLE_CURSOR_INFO info;

    // get current data for this structure
    GetConsoleCursorInfo(h, &info);

    info.bVisible = mode;
    SetConsoleCursorInfo(h, &info);
} // setCursorVisible

// clear the console screen
void cls()
{
    COORD coordScreen = { 0, 0 }; // initial cursor position
    DWORD cCharsWritten;
    CONSOLE_SCREEN_BUFFER_INFO csbi;
    DWORD dwConSize;

    // get the number of character cells in the current buffer
    if (!GetConsoleScreenBufferInfo(h, &csbi)) return;

    // size of the console window in characters
    dwConSize = csbi.dwSize.X * csbi.dwSize.Y;
   
    // fill the entire screen with spaces - this is the clearing
    if (!FillConsoleOutputCharacter(h, (TCHAR)' ', dwConSize, coordScreen, &cCharsWritten))
        return;

    // set the buffer attributes
    if (!FillConsoleOutputAttribute(h, csbi.wAttributes, dwConSize, coordScreen, &cCharsWritten))
        return;
    
    // move the cursor to the upper-left corner after clearing
    SetConsoleCursorPosition(h, coordScreen);
} // cls

// output a string in the specified color
void cputs(const char* str, short color)
{
    // save the current color
    short oldColor = getColor();

    // set the given color and output the string
    setColor(color);
    cout << str;

    // restore the previous color
    setColor(oldColor);
} // cputs

// output a string at the specified console coordinates with the given color
void writeXY(short x, short y, const char* str, short color)
{
    // set the color and output the string
    // at the specified screen position
    gotoXY(x, y);
    cputs(str, color);
} // writeXY

// get the current console text color
short getColor()
{
    // system structure - console buffer info, including text color
    CONSOLE_SCREEN_BUFFER_INFO csbi;

    // if we fail to get console data, return default color (gray on black)
    if (!GetConsoleScreenBufferInfo(h, &csbi)) return GRAY_ON_BLACK;

    // return the color attribute from the console buffer
    return csbi.wAttributes;
} // getColor

// -------------------------------------------

// the actual implementation of the manipulator without parameters
ostream &tab(ostream &os)
{
    os << "\t";
    return os;
} // tab

ostream &cls(ostream &os)
{
    cls();
    return os;
} // cls

// implementation of the manipulator for hiding the cursor
ostream& cursor_off(ostream& os)
{
    setCursorVisible(false);
    return os;
} // cursor_off

// implementation of the manipulator for showing the cursor
ostream& cursor_on(ostream& os)
{
    setCursorVisible(true);
    return os;
} // cursor_on

// the actual implementation of the manipulator with parameter endlm(n)
ostream &operator<<(ostream &os, const endlm &object)
{
    for (int i = 0; i < object.n_; ++i)
        os << endl;
    return os;
} // operator<<

// the actual implementation of the manipulator with parameter color(c)
ostream &operator<<(ostream &os, const color &color)
{
    setColor(color.color_);
    return os;
} // operator<<

// implementation of the manipulator with parameter pos(x, y)
ostream &operator<<(ostream &os, const pos &object)
{
    SetConsoleCursorPosition(h, COORD{object.x_, object.y_});
    return os;
}