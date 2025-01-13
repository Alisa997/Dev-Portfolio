#pragma once
#include "pch.h"
#include <vector>
#include <algorithm> 
#include "Decorator.h"

class AddIngredient : public Decorator
{
	// list of added ingredients
	vector<string> ingredients;

public:
	AddIngredient(Pizza* item) :Decorator(item) {};
	virtual ~AddIngredient() = default;

	void AddItem(string ingredient, int price) {
		// add ingredient
		ingredients.push_back(ingredient);

		// polymorphically modify the decorated object
		// decorate the object with the ability to change the price
		item->setPrice(item->getPrice() + price);
	} // AddItem

	void RemoveItem(string ingredient, int price) {
		auto result = find(ingredients.begin(), ingredients.end(), ingredient);
		if (result != ingredients.end()) {
			ingredients.erase(result);

			// polymorphically modify the decorated object
			// decorate the object with the ability to change the price
			item->setPrice(item->getPrice() - price);
		} // if
	} // RemoveItem

	void Show() const {
		item->Show();
		cout << "\tAdded ingredients:\n";
		for_each(ingredients.begin(), ingredients.end(), [](string ingredient)
			{	cout << "\t- " << ingredient << "\n"; });
	} // Show
};