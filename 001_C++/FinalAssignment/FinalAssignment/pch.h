#ifndef PCH_H
#define PCH_H

// enabling compilation of "classic" functions for working with strings, files: str___(), f______()
#define _CRT_SECURE_NO_WARNINGS

// use of math constants in modern style
#include <corecrt_math_defines.h>

#include <iostream>  // this header makes engineering functions available
#include <iomanip>   // for output manipulators such as setw(), setprecision()
#include <Windows.h>
#include <conio.h>

#include <sstream>   // for working with string output streams
#include <fstream>   // for working with file input/output streams

using namespace std;

// declaration of a symbolic constant - code page
#define CODE_PAGE 1251

#endif //PCH_H