#pragma once
#include "pch.h"
#include "Pizza.h"

// Specific type of pizza (seafood)
class SeafoodPizza : public Pizza {
public:
	SeafoodPizza() : SeafoodPizza(400) {}
	SeafoodPizza(int price) : Pizza("Seafood Pizza", price) {}

	virtual ~SeafoodPizza() {}
};
