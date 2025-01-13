#include "pch.h"
#include "Time.h"

bool Time::timeValid(short hour, short minute, short second)
{
    bool result = true;

    // check if the time is valid
    if (hour < 0 || hour > 23)
        result = false;
    else if (minute < 0 || minute > 59)
        result = false;
    else if (second < 0 || second > 59)
        result = false;

    return result;
} // Time::timeValid

void Time::setTime(short hour, short minute, short second)
{
    // if the parameters do not form a valid time, throw an exception
    if (!timeValid(hour, minute, second)) {
        throw exception("Time: Invalid time");
    }

    // if valid, accept the new values
    hour_ = hour;
    minute_ = minute;
    second_ = second;
}

ostream& operator<<(ostream& os, const Time& time)
{
    os << setfill('0') << setw(2) << time.hour_
        << ":" << setw(2) << time.minute_
        /*<< ":" << time.second_*/
        << setfill(' ');
    return os;
} // operator<<