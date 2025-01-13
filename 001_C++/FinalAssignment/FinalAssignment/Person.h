#pragma once
#include "pch.h"
#include "FullName.h"

/*
* Application users are characterized by:
*    first name, last name, and patronymic (encapsulated in FullName),
*    passport number
*/
class Person {
    FullName name_;      // first name, last name, and patronymic
    string passportID_;  // passport number

public:
    // default constructor
    Person() : Person(FullName(), "11 04 000000") {}

    // constructor with parameters
    Person(FullName name, const string& passportID) {
        setName(name);
        setPassportID(passportID);
    } // Person

    // copy constructor
    Person(const Person& value) = default;

    // destructor
    ~Person() = default;

    // getters and setters
    void     setName(FullName name) { name_ = name; }
    FullName getName() const { return name_; }

    void     setPassportID(const string& passportID) { passportID_ = passportID; }
    string   getPassportID() const { return passportID_; }

    Person& operator=(const Person& value) = default;
    bool operator==(const Person& person) { return passportID_ == person.passportID_; }

    friend ostream& operator<<(ostream& os, const Person& person);

    // output the table header
    static ostream& header(ostream& os);

    // output the table footer
    static ostream& footer(ostream& os);
};