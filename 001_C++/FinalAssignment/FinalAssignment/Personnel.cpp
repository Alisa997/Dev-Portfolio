#include "Personnel.h"

// output the table header
ostream& Personnel::header(ostream& os) {
    os  << "    +覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧�+覧覧覧覧覧覧--覧�+覧覧覧覧覧覧覧�+覧覧覧覧覧�+\n"
        << "    |             Full Name             | Passport Number |   Position    |   Salary   |\n"
        << "    +覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧�+覧覧覧覧覧�--覧覧+覧覧覧覧覧覧覧�+覧覧覧覧覧�+\n";
    return os;
} // Personnel::header

// output the table footer
ostream& Personnel::footer(ostream& os) {
    os << "    +覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧�+覧覧--覧覧覧覧覧�+覧覧覧覧覧覧覧�+覧覧覧覧覧�+\n";
    return os;
} // Personnel::footer

ostream& operator<<(ostream& os, const Personnel& personnel) {
    os << personnel.person_
        << left << setw(13) << personnel.position_
        << " | " << right << setw(9) << personnel.salary_
        << " |";
    return os;
} // operator<<
