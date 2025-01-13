#include "Library.h"
#include <algorithm> 

void Library::setAddress(const string& address) {
    address_ = address;
} // Library::setAddress

void Library::setDirector(const string& director) {
    director_ = director;
} // Library::setDirector

void Library::setBooks(vector<Book> books) {
    books_ = books;
} // Library::setBooks

// Sort books in descending order by the number of copies
void Library::sortByCount() {
    sort(books_.begin(), books_.end(),
        [](Book x, Book y) { return x.getCount() > y.getCount(); });
} // Library::sortByCount

// Sort books by their identifier
void Library::sortByNumber() {
    sort(books_.begin(), books_.end(),
        [](Book x, Book y) { return x.getNumber() < y.getNumber(); });
} // Library::sortByNumber

// Sort books by title
void Library::sortByName() {
    sort(books_.begin(), books_.end(),
        [](Book x, Book y) { return x.getName() < y.getName(); });
} // Library::sortByName

ostream& Library::show(ostream& os) {
    os << "\n\n    Library address      : " << address_
        << "\n    Director (Last Name & Initials): " << director_
        << "\n" << Book::header;

    for (auto book : books_)
        os << book.toTableRow() << "\n";

    os << Book::footer;

    return os;
} // Library::show

ostream& operator<<(ostream& os, const Library& library) {
    os << library.address_ << ";"
        << library.director_ << ";"
        << library.books_.size() << endl;

    ostream_iterator<Book> ofs_stream(os);

    for (auto book : library.books_) {
        *ofs_stream = book;  // output to the output stream
        ++ofs_stream;        // move to the next output
    }

    return os;
} // operator<<

istream& operator>>(istream& is, Library& library) {
    string str;
    getline(is, str);

    int pos = str.find(";", 0, 1);
    library.address_ = str.substr(0, pos);

    int pos1 = str.find(";", pos + 1, 1);
    library.director_ = str.substr(pos + 1, pos1 - pos - 1);

    string str1;
    pos = pos1;
    pos1 = str.find("\n", pos + 1, 1);
    str1 = str.substr(pos + 1, pos1 - pos - 1);

    int x;
    sscanf(str1.c_str(), "%d\n", &x);

    int n = x;  // number of book records

    // get an iterator for reading from a formatted stream
    istream_iterator<Book> stream_it(is);

    library.books_.clear();
    int i = 0;
    while (i < n) {
        library.books_.push_back(*stream_it);
        if (i != n - 1)
            ++stream_it;
        i++;
    } // while

    return is;
} // operator>>
