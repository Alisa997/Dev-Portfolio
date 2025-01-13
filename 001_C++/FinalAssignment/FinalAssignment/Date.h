#pragma once
#include "pch.h"

class Date
{
    short day_;      // day
    short month_;    // month
    short year_;     // year

public:
    // set of constructors
    Date() {
        // get the current date
        SYSTEMTIME st;
        GetLocalTime(&st);
        year_ = st.wYear;
        month_ = st.wMonth;
        day_ = st.wDay;
    } // Date 

    Date(short day, short month, short year) {
        setDate(day, month, year);
    } // Date

    Date(const Date& date) = default;
    ~Date() = default;

    // helper methods
    bool  dateValid(short day, short month, short year);
    short daysInMonth(short month, short year);
    bool  isLeapYear(short year);

    // getters
    short getDay()   const { return day_; }
    short getMonth() const { return month_; }
    short getYear()  const { return year_; }

    // setter
    void setDate(short day, short month, short year);

    // overload of the output operator for Date
    friend ostream& operator<<(ostream& os, const Date& date);

    bool operator<(Date& date) {
        if (year_ == date.year_ && month_ == date.month_)
            return day_ < date.day_;
        else if (year_ == date.year_)
            return month_ < date.month_;
        else
            return year_ < date.year_;
    } // operator<
};