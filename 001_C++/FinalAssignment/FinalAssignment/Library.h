#pragma once
#include "pch.h"
#include "Book.h"
#include <vector>

/*
*   Information about the library includes:
*       library address,
*       the director's last name and initials,
*       a collection of books
*/
class Library {
    string address_;     // library address
    string director_;    // director's last name and initials
    vector<Book> books_; // collection of books

public:
    // default constructor
    Library() = default;

    // constructor with parameters
    Library(string address, string director, vector<Book> books) {
        setAddress(address);
        setDirector(director);
        setBooks(books);
    } // Library

    // copy constructor
    Library(const Library& library) = default;

    // destructor
    ~Library() = default;

    // getters and setters
    void   setAddress(const string& address);
    string getAddress() const { return address_; }

    void   setDirector(const string& director);
    string getDirector() const { return director_; }

    void         setBooks(vector<Book> books);
    vector<Book> getBooks() const { return books_; }

    // used for working with formatted input/output streams
    friend ostream& operator<<(ostream& os, const Library& library);
    friend istream& operator>>(istream& is, Library& library);

    // sort books in descending order by the number of copies
    void sortByCount();

    // sort books by identifier
    void sortByNumber();

    // sort books by title
    void sortByName();

    // display library data
    ostream& show(ostream& os);
};