#pragma once
#include "pch.h"

class MenuItem
{
public:
    static const int MAX_ITEM_TEXT = 191;

    char* text;       // menu item text
    bool current;     // indicator for the current menu item
    int  command;     // command code assigned to the menu item

    MenuItem() : text(), current(), command() { }

    MenuItem(const char* text, int command)
        : text(), current(), command(command)
    {
        this->text = new char[MAX_ITEM_TEXT];
        strcpy(this->text, text);
    }

    MenuItem(const MenuItem& menuItem)
        : text(), current(menuItem.current), command(menuItem.command)
    {
        this->text = new char[MAX_ITEM_TEXT];
        strcpy(this->text, menuItem.text);
    }

    ~MenuItem() { delete[] text; }
};