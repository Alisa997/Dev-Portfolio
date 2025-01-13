#pragma once
#include "pch.h"
#include "Person.h"

// Personnel are also characterized by a position (trainer, administrator, janitor, etc.) and a salary
class Personnel {
    Person person_;
    string position_;    // position
    double salary_;      // salary

public:
    // default constructor
    Personnel() : Personnel(Person(), "Trainer", 10000.) {}

    // constructor with parameters
    Personnel(Person person, const string& position, double salary) {
        setPerson(person);
        setPosition(position);
        setSalary(salary);
    } // Personnel

    // copy constructor
    Personnel(const Personnel& value) = default;

    // destructor
    ~Personnel() = default;

    // getters and setters
    void   setPerson(Person person) { person_ = person; }
    Person getPerson() const { return person_; }

    void   setPosition(const string& position) { position_ = position; }
    string getPosition() const { return position_; }

    void   setSalary(double salary) {
        if (salary <= 0) throw exception("Personnel: invalid salary value!");
        salary_ = salary;
    } // setSalary
    double getSalary() const { return salary_; }

    Personnel& operator=(const Personnel& value) = default;
    bool operator==(const Personnel& personnel) {
        return person_ == personnel.person_;
    }

    friend ostream& operator<<(ostream& os, const Personnel& personnel);

    // output the table header
    static ostream& header(ostream& os);

    // output the table footer
    static ostream& footer(ostream& os);
};