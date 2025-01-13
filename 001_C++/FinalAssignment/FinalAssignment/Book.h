#pragma once
#include "pch.h"

/*
*	Information about books includes:
*			identifier (inventory number of the storage unit),
*			the author's last name and initials,
*			the book title,
*			the publication year,
*			the number of copies of this book in the library
*/
class Book {
public:

    static int n;    // variable used for generating a unique identifier
private:
    int number_;    // identifier
    string author_; // author's last name and initials
    string name_;   // title of the book
    int year_;      // publication year
    int count_;     // number of copies of this book in the library

public:
    // default constructor
    Book() = default;

    // constructor with parameters
    Book(const string& author, const string& name, int year, int count) {
        setAuthor(author);
        setName(name);
        setYear(year);
        setCount(count);
        setNumber();
    } // Book

    // copy constructor
    Book(const Book& book) = default;

    // destructor
    ~Book() = default;

    // getters and setters
    void setNumber();
    int  getNumber() const { return number_; }

    void   setAuthor(const string& author);
    string getAuthor() const { return author_; }

    void   setName(const string& name);
    string getName() const { return name_; }

    void setYear(int year);
    int  getYear() const { return year_; }

    void setCount(int count);
    int  getCount() const { return count_; }

    Book& operator=(const Book& book) = default;
    bool operator==(const Book& book) {
        return  number_ == book.number_ &&
            author_ == book.author_ &&
            name_ == book.name_ &&
            year_ == book.year_ &&
            count_ == book.count_;
    } // operator==

    // used for working with formatted input/output streams
    friend ostream& operator<<(ostream& os, const Book& book);
    friend istream& operator>>(istream& is, Book& book);

    // outputs a table row
    string toTableRow() const;

    // outputs a table header
    static ostream& header(ostream& os);

    // outputs a table footer
    static ostream& footer(ostream& os);
};