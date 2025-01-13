#pragma once
#include "pch.h"

// Base class
class Pizza {
protected:
	// Common properties
	string name; // Name
	int price;   // Price

public:
	Pizza() : Pizza("Not specified", 1) {}
	Pizza(const string& name, int price) : name(name) {
		setPrice(price);
	} // Pizza
	virtual ~Pizza() {}

	void Show() const {
		cout << "\n"
			<< "\t========================\n"
			<< "\tPizza Information\n"
			<< "\tName       : \"" << name << "\"\n"
			<< "\tPrice      : " << price << " rub.\n"
			<< "\t========================\n";
	} // Show

	const string& getName()const { return name; }

	int  getPrice()const { return price; }
	virtual void setPrice(int value) { 
		if (value <= 0) throw exception("Pizza: Invalid pizza price!");
		price = value; 
	} // setPrice
};
