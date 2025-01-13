#pragma once
#include "pch.h"
#include "Pizza.h"

// Decorator
class Decorator : public Pizza
{
protected:
	// pointer to the decorated item
	Pizza* item; // functionality is added to this item

public:
	Decorator(Pizza* pItem) : item(pItem) {};
	virtual ~Decorator() = default;

	void Show() const { item->Show(); }
};