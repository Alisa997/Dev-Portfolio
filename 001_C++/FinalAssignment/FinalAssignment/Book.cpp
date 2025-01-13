#include "Book.h"

int Book::n = 0;

void Book::setNumber() {
	// Identifier format: YYYYNNNN
	// YYYY - year
	// NNNN - sequential number

	number_ = year_ * 10000;
	number_ += ++n;

} // Book::setNumber

void Book::setAuthor(const string& author) {
	author_ = author;
} // Book::setAuthor

void Book::setName(const string& name) {
	name_ = name;
} // Book::setName

void Book::setYear(int year) {
	// get the current year
	SYSTEMTIME st;
	GetLocalTime(&st);
	int localYear = st.wYear;

	if (year < 0 || year > localYear)
		throw exception("Book: invalid publication year value!");

	year_ = year;
} // Book::setYear

void Book::setCount(int count) {
	if (count < 0)
		throw exception("Book: invalid number of copies for this book!");

	count_ = count;
} // Book::setCount

string Book::toTableRow() const {
	ostringstream oss;
	oss << "    | " << setw(13) << number_
		<< " | " << left << setw(18) << author_
		<< " | " << setw(26) << left << name_ << right
		<< " | " << setw(5) << year_ << "  "
		<< " | " << setw(7) << count_ << "     |";
	return oss.str();
} // Book::toTableRow

ostream& Book::header(ostream& os) {
	os  << "    +———————————————+————————————————————+————————————————————————————+—————————+—————————————+\n"
		<< "    |   Identifier  |    Author (L.I.)   |           Title            |   Year  |   Copies    |\n"
		<< "    |               |                    |                            |         |             |\n"
		<< "    +———————————————+————————————————————+————————————————————————————+—————————+—————————————+\n";
	return os;
} // Book::header

ostream& Book::footer(ostream& os) {
	os << "    +———————————————+————————————————————+————————————————————————————+—————————+—————————————+\n";
	return os;
} // Book::footer

ostream& operator<<(ostream& os, const Book& book) {
	os << book.number_ << ";"
		<< book.author_ << ";"
		<< book.name_ << ";"
		<< book.year_ << ";"
		<< book.count_ << endl;
	return os;
} // operator<<

istream& operator>>(istream& is, Book& book)
{
	string str;
	getline(is, str);

	int pos = str.find(";", 0, 1);

	// read the identifier
	int x;
	sscanf(str.c_str(), "%d;", &x);
	book.number_ = x;

	// read the author's last name and initials
	int pos1 = str.find(";", pos + 1, 1);
	book.author_ = str.substr(pos + 1, pos1 - pos - 1);

	// read the book title
	pos = pos1;
	pos1 = str.find(";", pos + 1, 1);
	book.name_ = str.substr(pos + 1, pos1 - pos - 1);

	// read the publication year and the number of copies
	string str1;
	pos = pos1;
	pos1 = str.find("\n", pos + 1, 1);
	str1 = str.substr(pos + 1, pos1 - pos - 1);

	int x1;
	sscanf(str1.c_str(), "%d;%d\n", &x, &x1);

	book.year_ = x;
	book.count_ = x1;

	return is;
} // operator>>