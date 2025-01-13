#pragma once
#include "pch.h"
#include "Library.h"
#include "Book.h"
#include "Person.h"
#include "Personnel.h"
#include "Training.h"
#include "FitnessClub.h"
#include <vector>

// Task 1
class Task1
{
    vector<int> v_;    // vector consisting of integer elements

    // name of the binary file for storing the vector
    string fileName_;

    // save the vector to a binary file using an output stream
    void save(vector<int> v1);

    // read the vector from a binary file using an input stream
    vector<int> load();

    // counter for an element in the vector
    int elemCount(int elem);

    // generate a vector
    void createVector();

    // number of vector elements equal to 0
    void part1();

    // sum of elements located after the minimum element
    void part2();

    // remove elements that occur less than twice
    void part3();

    // sort the vector by ascending absolute values
    void part4();

    // duplicate negative elements in the vector
    void part5();

    // save the vector to a binary file using an output stream
    void part6();

    // read the vector from a binary file using an input stream
    void part7();

public:
    Task1() : Task1("vector.bin") {}
    Task1(string fileName) : fileName_(fileName) {}

    ~Task1() = default;

    // launch the first task
    void start();
};

// Task 2
class Task2
{
    Library library_; // library

    // name of the text file for storing library data
    string fileName_;

    // save the library to a text file
    void save(Library library);

    // read the library from a text file
    Library load();

    void show(vector<Book> vec);

    // initial formation of the library
    void initialize();

    // display library data and the collection of books in the console
    void part1();

    // add a book (enter data from the keyboard), save the modified collection to a text file
    void part2();

    // remove books by ID, save the modified collection to a text file
    void part3();

    // change the number of books by a specified author (entered from the keyboard), save the modified collection
    void part4();

    // filter books by a specified publication year into a separate list, display it, sort by year, 
    // do not modify the original book collection or the data file
    void part5();

    // filter books by author into a separate list, display it, sort by author, 
    // do not modify the original book collection or the data file
    void part6();

    // sort books in descending order by quantity, display without modifying the data file
    void part7();

    // sort books by ID, display without modifying the data file
    void part8();

    // sort books by title, display without modifying the data file
    void part9();

public:
    Task2() : Task2("library.txt") {}
    Task2(string fileName) : fileName_(fileName) {}

    ~Task2() = default;

    // launch the second task
    void start();
};

// Task 3
class Task3
{
    FitnessClub fitnessClub_; // fitness club

    Date date_;       // date for scheduling workouts
    Time start_;      // workout start time
    Time finish_;     // workout end time

    // initial formation of the fitness club
    void initialize();

    // display fitness club data in the console
    void part0();

    // assign a trainer for a group workout (more than 2 participants)
    void part1();

    // assign a trainer for a group workout (fewer than 2 participants)
    void part2();

    // assign a trainer for an individual workout
    void part3();

public:
    Task3() = default;
    ~Task3() = default;

    // launch the third task
    void start();
};

class App
{
    Task1 task1_; // Task 1
    Task2 task2_; // Task 2
    Task3 task3_; // Task 3

public:
    App() = default;
    ~App() = default;

    Task1 getTask1() { return task1_; }
    Task2 getTask2() { return task2_; }
    Task3 getTask3() { return task3_; }
};