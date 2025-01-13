#ifndef PCH_H
#define PCH_H
// Allow compilation of "classic" functions for working with strings,
// files: str___(), f______()
#define _CRT_SECURE_NO_WARNINGS

// Use of mathematical constants, modern style
#include <corecrt_math_defines.h>

#include <iostream>  // This file enables access to engineering functions
#include <iomanip>   // For output manipulators such as setw(), setprecision()
#include <Windows.h>
#include <conio.h>

#include <sstream>

using namespace std;

// Declare symbolic constant - code page
#define CODE_PAGE 1251

#endif //PCH_H
