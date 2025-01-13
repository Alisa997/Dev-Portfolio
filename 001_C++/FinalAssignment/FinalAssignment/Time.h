#pragma once
#include "pch.h"

class Time
{
    short hour_;         // hour
    short minute_;       // minute
    short second_;       // second

    static const short N_BUF = 21;
    char* buf_;           // used by the toString() method

public:
    // set of constructors
    Time() : buf_(new char[N_BUF] {0}) {
        // get the current time
        SYSTEMTIME st;
        GetLocalTime(&st);
        hour_ = st.wHour;
        minute_ = st.wMinute;
        second_ = st.wSecond;
    } // Time

    Time(short hour, short minute, short second) {
        setTime(hour, minute, second);
    } // Time

    Time(const Time& time) = default;
    ~Time() = default;
    Time& operator=(const Time& time) = default;

    // helper methods
    bool timeValid(short hour, short minute, short second);

    // getters
    short getHour()   const { return hour_; }
    short getMinute() const { return minute_; }
    short getSecond() const { return second_; }

    // setter
    void setTime(short hour, short minute, short second);

    char* toString() {
        // output to a string according to the task
        char* str = new char[256];
        ostringstream oss;
        oss << *this;
        strcpy(str, oss.str().c_str());
        return str;
    } // toString

    // overload of the output operator for Time
    friend ostream& operator<<(ostream& os, const Time& time);
};