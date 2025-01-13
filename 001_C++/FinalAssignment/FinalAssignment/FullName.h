#pragma once
#include "pch.h"

class FullName {
    string surname_;       // surname
    string name_;          // name
    string patronymic_;    // patronymic

public:
    // default constructor
    FullName() : FullName("Ivanov", "Ivan", "Ivanovich") {}

    // constructor with parameters
    FullName(const string& surname, const string& name, const string& patronymic) {
        setSurname(surname);
        setName(name);
        setPatronymic(patronymic);
    } // FullName

    // copy constructor
    FullName(const FullName& value) = default;

    // destructor
    ~FullName() = default;

    // getters and setters
    void   setSurname(const string& surname) { surname_ = surname; }
    string getSurname() const { return surname_; }

    void   setName(const string& name) { name_ = name; }
    string getName() const { return name_; }

    void   setPatronymic(const string& patronymic) { patronymic_ = patronymic; }
    string getPatronymic() const { return patronymic_; }

    FullName& operator=(const FullName& value) = default;

    friend ostream& operator<<(ostream& os, const FullName& fullName) {
        // compose the full name as "Surname Name Patronymic"
        string str = fullName.surname_ + " "s
            + fullName.name_ + " "s
            + fullName.patronymic_;
        os << str;
        return os;
    } // operator<<
};
