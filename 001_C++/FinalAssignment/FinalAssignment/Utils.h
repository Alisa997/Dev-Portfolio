#pragma once
#include "pch.h"
#include "Colors.h"
#include "Palette.h"

// codes for function keys
const int K_F1 = 59, K_F2 = 60, K_F3 = 61, K_F4 = 62;
const int K_F5 = 63, K_F6 = 64, K_F7 = 65, K_F8 = 66;
const int K_F9 = 67, K_F10 = 68, K_F11 = 133, K_F12 = 134;
const int K_UP = 72, K_DOWN = 80, K_ENTER = 13, K_ESC = 27;

const int MAX_SECONDS = 24 * 60 * 60;

// procedure to set up the console for the application
void init(const wchar_t title[] = L"Application Title");

// get the pressed key code
int getKey(const char* prompt = "\nPress any key to continue... ");

// generate a random number
int    getRand(int low, int high);
double getRand(double low, double high);

// set the console color
void setColor(short color);

// input an integer
int getInt(const char prompt[], int from = INT_MIN, int to = INT_MAX);

// input a double
double getDouble(const char* prompt, double from = -DBL_MAX, double to = DBL_MAX);

// return the current console color
short getColor();

// output an empty top line of the console window (navigation line) while tasks are running
void showNavBarMessage(short hintColor, const char* message = " Press any key to continue...");

// output the "Under development..." message
void showUnderConstruction(short width, short infoColor);

// output a text message
void showMessage(short x, short y, short width, const char* msg[], short msgColor);

// output an input prompt, switch the color to the given one
void showInputLine(const char* prompt, int n, short color);

// --------------------------- using WinAPI structures ---------------------------
void gotoXY(short x, short y);
void setCursorVisible(bool mode);
void cls();

// output a string in the given color
void cputs(const char* str, short color = mainColor);

// output a string at the specified console coordinates
void writeXY(short x, short y, const char* str, short color = mainColor);

// -------------------------------------------

ostream& tab(ostream& os);
ostream& cls(ostream& os);
ostream& cursor_off(ostream& os);
ostream& cursor_on(ostream& os);

// manipulator with a parameter, implemented via a functor;
// a functor is a struct or class with a single constructor
class endlm
{
    int n_;

public:
    // TODO: parameter validation
    endlm(int n) : n_(n) {}

    // when printing an object of type endlm,
    // the manipulator's action is performed
    friend ostream& operator<<(ostream& os, const endlm& object);
};

class color
{
    short color_;

public:
    color(short color) : color_(color) {}

    // when printing an object of type color,
    // the manipulator's action is performed
    friend ostream& operator<<(ostream& os, const color& color);
};

class pos
{
    short x_;
    short y_;

public:
    pos(short x, short y) : x_(x), y_(y) {}

    friend ostream& operator<<(ostream& os, const pos& object);
};