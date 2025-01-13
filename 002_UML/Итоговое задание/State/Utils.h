#pragma once
#include "Colors.h"
#include "Palette.h"

// Function key codes
const int K_F1 = 59, K_F2 = 60, K_F3 = 61, K_F4 = 62;
const int K_F5 = 63, K_F6 = 64, K_F7 = 65, K_F8 = 66;
const int K_F9 = 67, K_F10 = 68, K_F11 = 133, K_F12 = 134;
const int K_UP = 72, K_DOWN = 80, K_ENTER = 13, K_ESC = 27;

const int MAX_SECONDS = 24 * 60 * 60;

// Procedure to prepare the console for the application
void init(const wchar_t title[] = L"Application Title");

// Get the code of the pressed key
int getKey(const char *prompt = "\nPress any key to continue... ");

// Generate a random number
int getRand(int low, int high);
double getRand(double low, double high);

// Set console color
void setColor(short color);

// Input an integer
int getInt(const char prompt[], int from = INT_MIN, int to = INT_MAX);

// Input a floating-point number
double getDouble(const char *prompt, double from = -DBL_MAX, double to = DBL_MAX);

// Return the console color
short getColor();

// Output an empty top line of the window - a navigation line during task execution
void showNavBarMessage(short hintColor, const char* message = " Press any key to continue..");

// Output message "Under construction..."
void showUnderConstruction(short width, short infoColor);

// Output a text message
void showMessage(short x, short y, short width, const char* msg[], short msgColor);

// Output a prompt for input, presenting the input line, the color switches
// to the specified color
void showInputLine(const char* prompt, int n, short color);

// Using WinAPI structures -----------------------------------------
void gotoXY(short x, short y);
void setCursorVisible(bool mode);
void cls();

// Output a string in the specified color
void cputs(const char* str, short color = mainColor);

// Output a string at the specified coordinates in the console window
void writeXY(short x, short y, const char* str, short color = mainColor);


//-------------------------------------------

ostream &tab(ostream &os);
ostream &cls(ostream &os);
ostream& cursor_off(ostream& os);
ostream& cursor_on(ostream& os);

// Manipulator with a parameter
// Implemented using a functor 
// A functor is a structure or class with a single constructor
class endlm
{
    int n_;

public: // TODO: check the correctness of the parameters - validate parameters
    endlm(int n): n_(n) {}

    // When implementing the output operation for an object of type endlm 
    // the manipulator's action is performed
    friend ostream &operator<<(ostream &os, const endlm &object);
};

class color
{
    short color_;

public:
    color(short color): color_(color) {}

    // When implementing the output operation for an object of type color 
    // the manipulator's action is performed
    friend ostream &operator<<(ostream &os, const color &color);
};

class pos
{
    short x_;
    short y_;

public:
    pos(short x, short y): x_(x), y_(y) {}

    friend ostream &operator<<(ostream &os, const pos &object);
};
