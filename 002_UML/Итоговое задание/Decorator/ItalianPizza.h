#pragma once
#include "pch.h"
#include "Pizza.h"

// Specific type of pizza (Italian)
class ItalianPizza : public Pizza {
public:
	ItalianPizza() : ItalianPizza(250) {}
	ItalianPizza(int price) : Pizza("Italian Pizza", price) {}

	virtual ~ItalianPizza() {}
};

