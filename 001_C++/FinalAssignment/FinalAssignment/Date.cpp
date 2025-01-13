#include "pch.h"
#include "Date.h"

// setter for the date
void Date::setDate(short day, short month, short year)
{
    // if the parameters do not form a valid date, throw an exception
    if (!dateValid(day, month, year)) {
        throw exception("Date: Invalid date");
    }

    // if valid, set the new values
    day_ = day;
    month_ = month;
    year_ = year;
} // Date::setDate

// checks if the parameters can form a valid date
bool Date::dateValid(short day, short month, short year)
{
    bool result = true;

    // check if the month is valid
    if (month < 1 || month > 12)
        result = false;
    // check if the day is valid for the given month and year
    else if (day < 1 || day > daysInMonth(month, year))
        result = false;

    return result;
} // Date::dateValid

// returns the number of days in a given month
short Date::daysInMonth(short month, short year)
{
    int daysInMonth[12] = {
        31, 28, 31, 30, 31, 30,
        31, 31, 30, 31, 30, 31
    };

    if (isLeapYear(year)) daysInMonth[1]++;
    return daysInMonth[month - 1];
} // Date::daysInMonth

// checks if the year is a leap year
bool Date::isLeapYear(short year)
{
    return (year % 4 == 0 && year % 100 != 0) || year % 400 == 0;
} // Date::isLeapYear

ostream& operator<<(ostream& os, const Date& date)
{
    os << setfill('0') << setw(2) << date.day_ << "/"
        << setw(2) << date.month_ << "/" << date.year_
        << setfill(' ');
    return os;
} // operator<<
