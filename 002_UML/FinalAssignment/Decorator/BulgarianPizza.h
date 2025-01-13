#pragma once
#include "pch.h"
#include "Pizza.h"

// specific type of pizza (Bulgarian pizza)
class BulgarianPizza : public Pizza {
public:
	BulgarianPizza() : BulgarianPizza(300) {}
	BulgarianPizza(int price) : Pizza("Bulgarian Pizza", price) {}

	virtual ~BulgarianPizza() {}
};
