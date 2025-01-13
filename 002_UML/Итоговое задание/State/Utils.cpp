#include "pch.h"
#include "Utils.h"
#include "Colors.h"

// Local global variable - static variable
// Exists as a single instance (singleton),
// scope - this source file
static HANDLE h = GetStdHandle(STD_OUTPUT_HANDLE);

void init(const wchar_t title[])
{
    SetConsoleTitle(title);

    SetConsoleOutputCP(CODE_PAGE);
    SetConsoleCP(CODE_PAGE);
    srand(GetTickCount());
    cout << fixed << setprecision(2) << boolalpha;
    
    setColor(GRAY_ON_LTBLACK);
    cls();
} // init

// Get the code of the key pressed
int getKey(const char *prompt)
{
    cout << prompt;

    int key = _getch();
    if (key == 0 || key == 224) key = _getch();

    return key;
} // getKey

// Generate a random integer
int getRand(int low, int high)
{
    return low + rand() % (high - low + 1);
} // getRand

// Generate a random floating-point number  
double getRand(double low, double high)
{
    double x = low + (high - low) * rand() / RAND_MAX;
    return x;
} // getRand

// Set console text color
void setColor(short color)
{
    SetConsoleTextAttribute(h, color);
} // setColor

// Get an integer input, with a prompt and a valid range [from, to]
int getInt(const char prompt[], int from, int to)
{
    int value;
    do {
        // User input
        cout << prompt;
        cin >> value;

        // If a valid number is entered, exit the loop and function
        if (!cin.fail()) break;

        // If it's not a number - reset the error state,
        // clear the input buffer
        cin.clear();
        cin.ignore(cin.rdbuf()->in_avail(), '\n');
    } while(value < from || value > to);

    return value;
} // getInt

// Get a floating-point input, with a prompt and a valid range [from, to]
double getDouble(const char *prompt, double from, double to)
{
    double value;
    do {
        // User input
        cout << prompt;
        cin >> value;

        // If not a number - reset error state,
        // clear input buffer
        if (cin.fail()) {
            cin.clear();
            cin.ignore(cin.rdbuf()->in_avail(), '\n');
            value = from - 1; // Keep in the loop
        } // if
    } while(value < from || value > to);

    return value;
} // getDouble

/// Output a message to the top of the window - navigation bar during task execution
void showNavBarMessage(short hintColor, const char* message)
{
    // Save the console color
    short oldColor = getColor();

    // Set new color and position for the message
    setColor(hintColor);
    gotoXY(0, 0);

    // Output message with alignment control
    // 138 - console window width
    cout << setw(138) << left << message << right;

    // Restore the color 
    setColor(oldColor);
} // showNavBarMessage

// Output message "Function under construction"
void showUnderConstruction(short width, short infoColor)
{
    const char* msg[] = {
        " ", // character with code 255, left border would not be quite vertical without it...
        "    [Information]",
        "    Function under construction",
        " ", // character with code 255, left border would not be quite vertical without it...
        "    Press any key to continue...",
        " ", // character with code 255, left border would not be quite vertical without it...
        " ", // character with code 255, left border would not be quite vertical without it...
        nullptr // End of text
    };
    showMessage(8, 4, width, msg, infoColor);
    gotoXY(8, 30);
} // showUnderConstruction

// Output the message in the screen area, starting from position x, y
// Message width is `width`, text color is `msgColor`
// Output lines until a nullptr string is encountered
void showMessage(short x, short y, short width, const char* msg[], short msgColor)
{
    // Save current console color
    short oldColor = getColor();
    setColor(msgColor);

    // Output message lines in the field with the specified width
    // Output until a nullptr string is encountered
    cout << left;
    for (short i = 0, row = y; msg[i] != nullptr; i++, row++) {
        cout << pos(x, row) << setw(width) << msg[i];
    } // for i

    // Restore default output alignment and color
    cout << right;
    setColor(oldColor);
} // showMessage

// Output input prompt, input string, color toggles to the specified color
void showInputLine(const char* prompt, int n, short color)
{
    cout << prompt;
    setColor(color);

    // Output the input line in the highlighted color, then return
    // the cursor to the start of the line, 1 symbol from the start
    for (int i = 0; i < n; ++i) cout << " ";
    for (int i = 0; i < n - 1; ++i) cout << "\b";
} // showInputLine

// --- WinAPI structures usage for manipulation -------------------------

// Position cursor at given coordinates in the console
void gotoXY(short x, short y) {
    SetConsoleCursorPosition(h, COORD{ x, y });
} // gotoXY

// Turn console cursor on or off
// mode: true  - turn on cursor
//       false - turn off cursor
void setCursorVisible(bool mode)
{
    // Another WinAPI structure
    CONSOLE_CURSOR_INFO info;

    // Get data into this structure
    GetConsoleCursorInfo(h, &info);

    info.bVisible = mode;
    SetConsoleCursorInfo(h, &info);
} // void setCursorVisible

// Clear console screen
void cls()
{
    COORD coordScreen = { 0, 0 }; // Initial cursor position
    DWORD cCharsWritten;
    CONSOLE_SCREEN_BUFFER_INFO csbi;
    DWORD dwConSize;

    // Get number of character cells in the current buffer
    if( !GetConsoleScreenBufferInfo( h, &csbi )) return;

    // Size of the console window in characters
    dwConSize = csbi.dwSize.X * csbi.dwSize.Y;
   
    // Fill the screen with spaces - this is clearing
    if ( !FillConsoleOutputCharacter( h, (TCHAR)' ', dwConSize, coordScreen, &cCharsWritten ))
       return;

    // Set the corresponding buffer attributes from current attributes
    if ( !FillConsoleOutputAttribute( h, csbi.wAttributes,
       dwConSize, coordScreen, &cCharsWritten ))
       return;
    
    // Place the cursor at the initial position after clearing the screen
    SetConsoleCursorPosition( h, coordScreen );
} // cls

// Output a string in the specified color
void cputs(const char* str, short color)
{
    // Save current output color
    short oldColor = getColor();

    // Set specified color and output the string
    setColor(color);
    cout << str;

    // Restore the output color
    setColor(oldColor);
} // cputs

// Output a string at the specified screen coordinates with specified color
void writeXY(short x, short y, const char* str, short color)
{
    // Set specified output color and print the string
    gotoXY(x, y);
    cputs(str, color);
} // writeXY

// Get the current console output color
short getColor()
{
    // System structure - information about the console buffer, including color
    CONSOLE_SCREEN_BUFFER_INFO csbi;

    // Try to get console data, if it fails, return the default color pair (gray on black)
    if (!GetConsoleScreenBufferInfo(h, &csbi)) return GRAY_ON_BLACK;

    // Return color attribute from the console buffer parameters
    return csbi.wAttributes;
} // getColor

// -------------------------------------------

// Implement stream manipulator without parameters
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

// Implement manipulator to turn off the cursor
ostream& cursor_off(ostream& os)
{
    setCursorVisible(false);
    return os;
} // cursor_off

// Implement manipulator to turn on the cursor
ostream& cursor_on(ostream& os)
{
    setCursorVisible(true);
    return os;
} // cursor_on

// Implement manipulator with parameter endlm(n)
ostream &operator<<(ostream &os, const endlm &object)
{
    for (int i=0 ; i < object.n_; ++i)
        os << endl;
    return os;
} // operator<<

// Implement manipulator with parameter color(c)
ostream &operator<<(ostream &os, const color &color)
{
    setColor(color.color_);
    return os;
} // operator<<

ostream &operator<<(ostream &os, const pos &object)
{
    SetConsoleCursorPosition(h, COORD{object.x_, object.y_});
    return os;
}
