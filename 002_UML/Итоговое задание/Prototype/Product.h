#pragma once
#include "pch.h"

/*
 *  This is an abstract base class Product.
 *  It defines the Clone function, which forms
 *  the basis of the Prototype pattern.
 */
class Product {
protected:
    // name of the product
    string name;

public:
    // constructors
    Product() : Product("Unknown product") {}
    Product(string name) {
        setName(name);
    } // Goods

    // Pure virtual function
    // It will be used for creating copies
    virtual Product* Clone() const = 0;

    // helper functions
    string getName() const { return name; }          // getName
    void setName(string name) { this->name = name; } // setName
};
