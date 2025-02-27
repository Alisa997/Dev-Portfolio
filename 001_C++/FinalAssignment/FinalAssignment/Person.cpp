#include "Person.h"

// output the table header
ostream& Person::header(ostream& os) {
    os << "    +覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧�+覧覧覧覧覧覧覧覧�+\n"
        << "    |             Full Name             | Passport Number |\n"
        << "    +覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧�+覧覧覧覧覧覧覧覧�+\n";
    return os;
} // Person::header

// output the table footer
ostream& Person::footer(ostream& os) {
    os << "    +覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧�+覧覧覧覧覧覧覧覧�+\n";
    return os;
} // Person::footer

ostream& operator<<(ostream& os, const Person& person) {
    os << "    | " << left << setw(33) << person.name_
        << " | " << right << setw(15) << person.passportID_
        << " | ";
    return os;
} // operator<<