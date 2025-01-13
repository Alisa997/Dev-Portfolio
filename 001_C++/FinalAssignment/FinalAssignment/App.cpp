#include "pch.h"
#include "App.h"
#include "Utils.h"
#include "MenuItem.h"
#include "Menu.h"

#include <vector>
#include <functional>  
#include <algorithm> 
#include <numeric> 

// launch the first task
void Task1::start() {

    // application command codes
    enum Commands {
        CMD_ZERO,     // Generate a vector
        CMD_FIRST,    // Number of vector elements equal to 0
        CMD_SECOND,   // Sum of vector elements located after the minimum element
        CMD_THIRD,    // Remove elements that occur less than twice
        CMD_FOURTH,   // Sort the vector in ascending order by the absolute values of its elements
        CMD_FIFTH,    // Duplicate all negative elements in the vector
        CMD_SIXTH,    // Save the vector to a binary file using an output stream
        CMD_SEVENTH,  // Read the vector from a binary file using an input stream
    };

    // application menu items
    const int N_MENU = 9;
    MenuItem items[N_MENU] = {
        MenuItem("Generate a vector", CMD_ZERO),
        MenuItem("Number of vector elements equal to 0", CMD_FIRST),
        MenuItem("Sum of elements located after the minimum element", CMD_SECOND),
        MenuItem("Remove elements that occur less than twice", CMD_THIRD),
        MenuItem("Sort vector by ascending absolute values", CMD_FOURTH),
        MenuItem("Duplicate negative elements in the vector", CMD_FIFTH),
        MenuItem("Save the vector to a binary file (output stream)", CMD_SIXTH),
        MenuItem("Read the vector from a binary file (input stream)", CMD_SEVENTH),
        MenuItem("Exit",  Menu::CMD_QUIT)
    };

    const int N_PALETTE = 5;
    //                          header        item               selected item    console
    short palette[N_PALETTE] = { WHITE_ON_BLACK, LTCYAN_ON_BLACK, BLACK_ON_LTCYAN, mainColor };

    Menu mainMenu("Task 1", items, N_MENU, palette, COORD{ 5, 5 });

    while (true) {
        try {
            cout << color(palette[Menu::PAL_CONSOLE]) << cls;
            int cmd = mainMenu.Navigate();
            cout << color(palette[Menu::PAL_CONSOLE]) << cls;
            if (cmd == Menu::CMD_QUIT) break;

            switch (cmd) {
                // Generate a vector
            case CMD_ZERO:
                createVector();
                break;
                // Number of vector elements equal to 0
            case CMD_FIRST:
                part1();
                break;

                // Sum of elements located after the minimum element
            case CMD_SECOND:
                part2();
                break;

                // Remove elements that occur less than twice
            case CMD_THIRD:
                part3();
                break;

                // Sort vector by ascending absolute values
            case CMD_FOURTH:
                part4();
                break;

                // Duplicate negative elements in the vector
            case CMD_FIFTH:
                part5();
                break;

                // Save the vector to a binary file using an output stream
            case CMD_SIXTH:
                part6();
                break;

                // Read the vector from a binary file using an input stream
            case CMD_SEVENTH:
                part7();
                break;
            } // switch
        }
        catch (exception& ex) {
            cout << color(errColor) << "\n\n\t\t\t                                                                                      \n";
            cout << "\t\t\t ************************************************************************************ \n";
            cout << "\t\t\t                                     Exception.                                      \n";
            cout << "\t\t\t " << setw(80) << ex.what() << "     \n";
            cout << "\t\t\t                                                                                      \n";
            cout << "\t\t\t ************************************************************************************ \n";
            cout << "\t\t\t                                                                                      \n"
                << color(mainColor);
        } // try-catch
        getKey("\n\n\nPress any key to continue...");
    } // while

    cout << cls << pos(0, 24);
} // Task1::start

void Task1::save(vector<int> v1) {
    ofstream ofs(fileName_);

    if (!ofs.is_open())
        throw exception(("App: cannot open file " + fileName_ + " for writing").c_str());

    ostream_iterator<int> ofs_stream(ofs, "\n");

    for (auto v : v1) {
        ofs_stream = v;
        ofs_stream++;
    } // for

    ofs.close();
}

vector<int> Task1::load()
{
    ifstream ifs(fileName_);
    if (!ifs.is_open())
        throw exception(("App: cannot open file " + fileName_ + " for reading").c_str());

    istream_iterator<int> itStream(ifs);
    vector<int> v1;

    // reading from the input stream via iterator
    while (itStream != istream_iterator<int>()) {
        v1.push_back(*itStream);
        ++itStream;
    } // while

    ifs.close();
    return v1;
}

// counts occurrences of an element in the vector
int Task1::elemCount(int elem) {
    int count = 0;

    for_each(v_.begin(), v_.end(), [elem, &count](int x) {
        if (x == elem) count++;
        });

    return count;
} // Task1::elemCount

// generate a vector
void Task1::createVector() {
    showNavBarMessage(hintColor, "    Generate a vector");

    cout << "\n\n";
    showInputLine("    Enter the lower bound of the range : ", 12, hintColor);
    int low;
    cin >> low;

    if (cin.fail()) {
        cin.clear();
        cin.ignore(cin.rdbuf()->in_avail());
        throw exception("App: not a number!");
    } // if
    int high;

    do {
        cout << color(mainColor) << pos(0, 4);
        showInputLine("    Enter the upper bound of the range : ", 12, hintColor);
        cin >> high;
        if (cin.fail()) {
            cin.clear();
            cin.ignore(cin.rdbuf()->in_avail());
            high = low - 1;
        } // if
    } while (low > high);

    int n;
    do {
        cout << color(mainColor) << pos(0, 6);
        showInputLine("    Enter the size of the vector        : ", 12, hintColor);
        cin >> n;
        if (cin.fail()) {
            cin.clear();
            cin.ignore(cin.rdbuf()->in_avail());
            n = 0;
        } // if
    } while (n <= 0);

    vector<int> v1(n);
    generate(v1.begin(), v1.end(), [low, high]() { return getRand(low, high); });

    v_ = v1;
    cout << color(mainColor) << "\n    Generated vector: ";
    for_each(v_.begin(), v_.end(), [](int x) { cout << setw(5) << x; });
    cout << "\n\n";
} // Task1::createVector

// number of vector elements equal to 0
void Task1::part1() {
    showNavBarMessage(hintColor, "    Number of vector elements equal to 0");

    if (v_.empty()) throw exception("Vector is not formed!");

    int count = count_if(v_.begin(), v_.end(), [](int elem) { return elem == 0; });

    cout << "\n\n    Vector                          : ";
    for_each(v_.begin(), v_.end(), [](int x) { cout << setw(5) << x; });

    cout << "\n\n    Number of elements equal to 0   : "
        << color(hintColor) << count << color(mainColor) << "\n";
} // Task1::part1

// sum of elements after the minimum element
void Task1::part2() {
    showNavBarMessage(hintColor, "    Sum of elements located after the minimum element");

    if (v_.empty()) throw exception("Vector is not formed!");

    auto min = min_element(v_.begin(), v_.end());
    int sum = accumulate(min, v_.end(), -*min);

    cout << "\n\n    Vector                                                            : ";
    for_each(v_.begin(), v_.end(), [min](int x) {
        cout << " " << color(x == *min ? hintColor : mainColor) << setw(5) << x << color(mainColor);
        });

    cout << "\n\n    Sum of elements after the minimum element                         : "
        << color(hintColor) << sum << color(mainColor) << "\n";
} // Task1::part2

// remove elements that occur less than twice
void Task1::part3() {
    showNavBarMessage(hintColor, "    Remove elements that occur less than twice");

    if (v_.empty()) throw exception("Vector is not formed!");

    cout << "\n\n    Vector before changes : ";
    for_each(v_.begin(), v_.end(), [](int x) {cout << " " << setw(5) << x; });

    for (int i = 0; i < (int)v_.size(); i++) {
        if (elemCount(v_[i]) < 2) {
            v_.erase(find(v_.begin(), v_.end(), v_[i]));
            i--;
        }
    }

    cout << "\n\n    Vector after changes  : ";
    for_each(v_.begin(), v_.end(), [](int x) {cout << " " << setw(5) << x; });
} // Task1::part3

// sort the vector in ascending order by the absolute values of its elements
void Task1::part4() {
    showNavBarMessage(hintColor, "    Sort the vector by ascending absolute values");

    if (v_.empty()) throw exception("Vector is not formed!");

    cout << "\n\n    Vector before sorting : ";
    for_each(v_.begin(), v_.end(), [](int x) {cout << " " << setw(5) << x; });

    sort(v_.begin(), v_.end(), [](int x, int y) { return abs(x) < abs(y); });

    cout << "\n\n    Vector after sorting  : ";
    for_each(v_.begin(), v_.end(), [](int x) {cout << " " << setw(5) << x; });
} // Task1::part4

// duplicate negative vector elements
void Task1::part5() {
    showNavBarMessage(hintColor, "    Duplicate negative elements in the vector");

    if (v_.empty()) throw exception("Vector is not formed!");

    cout << "\n\n    Vector before changes : ";
    for_each(v_.begin(), v_.end(), [](int x) {cout << " " << setw(5) << x; });

    vector<int> temp;

    for (int i = 0; i < (int)v_.size(); i++) {
        temp.push_back(v_[i]);
        if (v_[i] < 0)
            temp.push_back(v_[i]);
    }

    v_ = temp;

    cout << "\n\n    Vector after changes  : ";
    for_each(v_.begin(), v_.end(), [](int x) {cout << " " << setw(5) << x; });
} // Task1::part5

// save the vector to a binary file using an output stream
void Task1::part6() {
    showNavBarMessage(hintColor, "    Save the vector to a binary file using an output stream");

    if (v_.empty()) throw exception("Vector is not formed!");

    // saving the vector to a binary file using an output stream
    save(v_);

    cout << "\n\n\t\t\t The vector has been written to the file \"" << fileName_ << "\" !";
} // Task1::part6

// read the vector from a binary file using an input stream
void Task1::part7() {
    showNavBarMessage(hintColor, "    Read the vector from a binary file using an input stream");

    v_ = load();

    cout << "\n\n    Read from the file \"" << fileName_ << "\" :\n\t";
    for_each(v_.begin(), v_.end(), [](int x) {cout << " " << setw(5) << x; });
} // Task1::part7


// launch the second task
void Task2::start() {

    // application command codes
    enum Commands {
        CMD_FIRST,     // Display library data and collection of books in the console
        CMD_SECOND,    // Add a book
        CMD_THIRD,     // Remove books by ID
        CMD_FOURTH,    // Change the quantity of books by a specific author
        CMD_FIFTH,     // Filter books by publication year into a separate list
        CMD_SIXTH,     // Filter books by author into a separate list
        CMD_SEVENTH,   // Sort books in descending order by quantity
        CMD_EIGHTH,    // Sort books by ID
        CMD_NINTH,     // Sort books by title
    };

    // application menu items
    const int N_MENU = 10;
    MenuItem items[N_MENU] = {
        MenuItem("Display library data and book collection in the console", CMD_FIRST),
        MenuItem("Add a book", CMD_SECOND),
        MenuItem("Remove books by ID", CMD_THIRD),
        MenuItem("Change the quantity of books by the specified author", CMD_FOURTH),
        MenuItem("Filter books by publication year into a separate list", CMD_FIFTH),
        MenuItem("Filter books by author into a separate list", CMD_SIXTH),
        MenuItem("Sort books by descending quantity", CMD_SEVENTH),
        MenuItem("Sort books by ID", CMD_EIGHTH),
        MenuItem("Sort books by title", CMD_NINTH),
        MenuItem("Exit",  Menu::CMD_QUIT)
    };

    const int N_PALETTE = 5;
    //                          header        item               selected item    console
    short palette[N_PALETTE] = { WHITE_ON_BLACK, LTCYAN_ON_BLACK, BLACK_ON_LTCYAN, mainColor };

    Menu mainMenu("Task 2", items, N_MENU, palette, COORD{ 5, 5 });
    initialize();

    while (true) {
        try {
            cout << color(palette[Menu::PAL_CONSOLE]) << cls;
            int cmd = mainMenu.Navigate();
            cout << color(palette[Menu::PAL_CONSOLE]) << cls;
            if (cmd == Menu::CMD_QUIT) break;

            switch (cmd) {
                // Display library data and collection of books in the console
            case CMD_FIRST:
                part1();
                break;

                // Add a book
            case CMD_SECOND:
                part2();
                break;

                // Remove books by ID
            case CMD_THIRD:
                part3();
                break;

                // Change the quantity of books by the specified author
            case CMD_FOURTH:
                part4();
                break;

                // Filter books by publication year into a separate list
            case CMD_FIFTH:
                part5();
                break;

                // Filter books by author into a separate list
            case CMD_SIXTH:
                part6();
                break;

                // Sort books by descending quantity
            case CMD_SEVENTH:
                part7();
                break;

                // Sort books by ID
            case CMD_EIGHTH:
                part8();
                break;

                // Sort books by title
            case CMD_NINTH:
                part9();
                break;
            } // switch
        }
        catch (exception& ex) {
            cout << color(errColor) << "\n\n\t\t\t                                                                                      \n";
            cout << "\t\t\t ************************************************************************************ \n";
            cout << "\t\t\t                                     Exception.                                      \n";
            cout << "\t\t\t " << setw(80) << ex.what() << "     \n";
            cout << "\t\t\t                                                                                      \n";
            cout << "\t\t\t ************************************************************************************ \n";
            cout << "\t\t\t                                                                                      \n"
                << color(mainColor);
        } // try-catch
        getKey("\n\n\nPress any key to continue...");
    } // while

    cout << cls << pos(0, 24);
} // Task2::start

// save the library to a text file
void Task2::save(Library library) {
    // output stream iterator for files
    ofstream ofs(fileName_);
    if (!ofs.is_open())
        throw exception(("Cannot open file " + fileName_ + " for writing").c_str());

    ostream_iterator<Library> ofs_stream(ofs);
    *ofs_stream = library;

    ofs.close();
} // Task2::save

// read the library from a text file
Library Task2::load() {
    // reading from the file using an input stream iterator
    ifstream ifs(fileName_);
    if (!ifs.is_open())
        throw exception(("Cannot open file " + fileName_ + " for reading").c_str());

    // get an iterator for reading from a formatted stream
    istream_iterator<Library> stream_it(ifs);
    Library temp;
    temp = *stream_it;

    ifs.close();
    return temp;
} // Task2::load

void Task2::show(vector<Book> vec) {
    auto outBook = [](const Book& book) mutable {
        cout << book.toTableRow() << endl;
    };

    cout << Book::header;
    for_each(vec.begin(), vec.end(), outBook);
    cout << Book::footer;
} // Task2::show

void Task2::initialize() {
    ifstream ifs(fileName_);
    if (!ifs.is_open()) {
        library_.setAddress("Artyoma Street, 84, Donetsk"s);
        library_.setDirector(" Kornilova A. Yu."s);

        vector<Book> books = {
            Book("Tolstoy A. N.", "Peter the Great", 1977, 12),
            Book("Chekhov A. P.", "Selected Works", 1984, 21),
            Book("Bulgakov M. A.", "The Master and Margarita", 2000, 16),
            Book("Sholokhov M. A.", "And Quiet Flows the Don", 1975, 26),
            Book("Doyle A. C.", "The Memoirs of Sherlock Holmes", 1991, 18),
            Book("Dostoevsky F. M.", "Crime and Punishment", 1988, 21),
            Book("Ostrovsky A. N.", "Plays", 1986, 11),
            Book("Lagin L. I.", "Old Man Hottabych", 1986, 14),
            Book("Bronte Sh.", "Jane Eyre", 1988, 15),
            Book("Verne J.", "In Search of the Castaways", 1985, 23),
            Book("Karamzin N. M.", "Tales of the Ages", 1988, 13),
            Book("Kuprin A. I.", "Stories and Novellas", 1984, 24)
        };
        library_.setBooks(books);

        save(library_);
    }
    else {
        ifs.close();
    }
} // Task2::initialize

// Display library data and the collection of books in the console
void Task2::part1() {
    showNavBarMessage(hintColor, "    Display library data and book collection in the console");

    if (library_.getBooks().empty()) library_ = load();

    library_.show(cout);

} // Task2::part1

// Add a book, input data from the keyboard, save the modified collection to a text file
void Task2::part2(){
    showNavBarMessage(hintColor, "    Add a book");

    if (library_.getBooks().empty()) library_ = load();

    cin.ignore(cin.rdbuf()->in_avail());
    cout << pos(5, 4);
    showInputLine("Enter the author's Last Name and Initials  : ", 12, hintColor);
    string author;
    setCursorVisible(true);
    getline(cin, author);
    setColor(mainColor);

    cout << pos(5, 7);
    showInputLine("Enter the book title                       : ", 12, hintColor);
    string name;
    getline(cin, name);
    setColor(mainColor);

    int year = -1;

    while (year <= 0) {
        cout << pos(5, 10);
        showInputLine("Enter the publication year                  : ", 12, hintColor);
        cin >> year;
        setColor(mainColor);
        if (cin.fail()) {
            cin.clear();
            cin.ignore(cin.rdbuf()->in_avail());
        }
    }

    int count = -1;

    while (count <= 0) {
        cout << pos(5, 13);
        showInputLine("Enter the number of copies                 : ", 12, hintColor);
        cin >> count;

        setColor(mainColor);
        setCursorVisible(false);

        if (cin.fail()) {
            cin.clear();
            cin.ignore(cin.rdbuf()->in_avail());
        }
    }

    vector<Book> temp = library_.getBooks();
    temp.push_back(Book(author, name, year, count));
    library_.setBooks(temp);

    cout << color(hintColor) << "\n\n\t\t\tBook added:" << color(mainColor);
    library_.show(cout);
    
    save(library_);
} // Task2::part2

// Remove books by ID, save the modified collection to a text file
void Task2::part3() {
    showNavBarMessage(hintColor, "    Remove books by ID");

    if (library_.getBooks().empty()) library_ = load();

    int number = -1;

    while (number <= 0) {
        library_.show(cout);
        cout << "\n";

        setCursorVisible(true);
        showInputLine("    Enter the ID: ", 12, hintColor);
        cin >> number;
        setColor(mainColor);
        setCursorVisible(false);

        if (cin.fail()) {
            cin.clear();
            cin.ignore(cin.rdbuf()->in_avail());
        }

        cout << cls;
    }

    vector<Book> temp = library_.getBooks();

    for (auto book : temp) {
        if (book.getNumber() == number){
            temp.erase(find(temp.begin(), temp.end(), book));
            break;
        }
    }

    if (temp.size() == library_.getBooks().size()) {
        cout << color(hintColor) << "\n\n\t\t\tBook not found!\n" << color(mainColor);
    } else {
        library_.setBooks(temp);
        cout << color(hintColor) << "\n\n\t\t\tBook successfully removed!\n" << color(mainColor);

        library_.show(cout);
        save(library_);
    }
} // Task2::part3

// Change the number of books by a specified author, using keyboard input, save the modified collection to a text file
void Task2::part4() {
    showNavBarMessage(hintColor, "    Change the number of books by a specified author");

    if (library_.getBooks().empty()) library_ = load();

    library_.show(cout);

    cin.ignore(cin.rdbuf()->in_avail());
    cout << "\n";
    showInputLine("Enter the author's Last Name and Initials  : ", 12, hintColor);
    string author;
    setCursorVisible(true);
    getline(cin, author);
    setColor(mainColor);
    setCursorVisible(false);

    vector<Book> temp;
    vector<Book> temp1 = library_.getBooks();

    // Collect all books by the specified author
    for (auto book : temp1) {
        if (book.getAuthor() == author) {
            temp.push_back(book);
        }
    }

    if (temp.empty()) {
        cout << color(hintColor) << "\n\n\t\t\tAuthor not found!\n" << color(mainColor);
    } else {
        Book book;

        // If there's exactly one book by this author
        if (temp.size() == 1) {
            book = temp.back();
        } else {
            // If multiple books, user must specify the title
            cout << "\n";
            showInputLine("Enter the book title                       : ", 12, hintColor);
            string name;
            getline(cin, name);
            setColor(mainColor);

            bool flag = false;
            for (auto item : temp) {
                if (item.getName() == name) {
                    flag = true;
                    book = item;
                    break;
                }
            }
            if (!flag) throw exception("Author not found!");
        }

        int count = -1;

        // Prompt user for new number of copies
        while (count <= 0) {
            cout << cls;
            showNavBarMessage(hintColor, "    Change the number of books by a specified author");
            cout << pos(5, 4);
            showInputLine("Enter the number of copies                 : ", 12, hintColor);
            cin >> count;

            setColor(mainColor);
            setCursorVisible(false);

            if (cin.fail()) {
                cin.clear();
                cin.ignore(cin.rdbuf()->in_avail());
            }
        }

        Book toDelete = book;
        book.setCount(count);

        // Insert updated book and remove old record
        temp1.emplace(find(temp1.begin(), temp1.end(), toDelete), book);
        temp1.erase(find(temp1.begin(), temp1.end(), toDelete));
        library_.setBooks(temp1);

        cout << color(hintColor) << "\n\n\t\t\tData changed!\n" << color(mainColor);
        library_.show(cout);
    }

    save(library_);
} // Task2::part4

// Filter books by the specified publication year into a separate list, display it, sorted by publication year;
// do not modify the original book collection or the data file
void Task2::part5() {
    showNavBarMessage(hintColor, "    Filter books by publication year into a separate list");

    if (library_.getBooks().empty()) library_ = load();

    library_.show(cout);

    int year = -1;

    while (year <= 0) {
        cout << "\n";
        showInputLine("    Enter the publication year           : ", 12, hintColor);
        cin >> year;
        setColor(mainColor);
        if (cin.fail()) {
            cin.clear();
            cin.ignore(cin.rdbuf()->in_avail());
        }
    }

    vector<Book> books = library_.getBooks();
    vector<Book> temp;

    // Collect all books matching the specified year
    for_each(books.begin(), books.end(), [&temp, year](Book& book) {
        if (book.getYear() == year) temp.push_back(book);
    });

    if (temp.empty()) {
        cout << color(hintColor) << "\n\n\t\t\tNo books found!\n" << color(mainColor);
    } else {
        cout << "\n\n\t\t\t\t\tFound books:\n";
        show(temp);
    }
} // Task2::part5

// Filter books by author into a separate list, display it, sorted by author;
// do not modify the original book collection or the data file
void Task2::part6() {
    showNavBarMessage(hintColor, "    Filter books by author into a separate list");

    if (library_.getBooks().empty()) library_ = load();

    library_.show(cout);

    cin.ignore(cin.rdbuf()->in_avail());
    cout << "\n";
    showInputLine("    Enter the author's Last Name and Initials  : ", 12, hintColor);
    string author;
    setCursorVisible(true);
    getline(cin, author);
    setColor(mainColor);
    setCursorVisible(false);

    vector<Book> books = library_.getBooks();
    vector<Book> temp;

    // Collect all books by the specified author
    for_each(books.begin(), books.end(), [&temp, author](Book& book) {
        if (book.getAuthor() == author) temp.push_back(book);
    });

    if (temp.empty()) {
        cout << color(hintColor) << "\n\n\t\t\tNo books found!\n" << color(mainColor);
    } else {
        cout << "\n\n\t\t\t\t\tFound books:\n";
        show(temp);
    }
} // Task2::part6

// Sort books in descending order by quantity, display them without modifying the data file
void Task2::part7() {
    showNavBarMessage(hintColor, "    Sort books by descending quantity");

    if (library_.getBooks().empty())
        library_ = load();

    library_.sortByCount();
    cout << "\n    Sorted by descending quantity:";
    library_.show(cout);

} // Task2::part7

// Sort books by ID, display them without modifying the data file
void Task2::part8() {
    showNavBarMessage(hintColor, "    Sort books by ID");

    if (library_.getBooks().empty())
        library_ = load();

    library_.sortByNumber();
    cout << "\n    Sorted by ID:";
    library_.show(cout);
} // Task2::part8

// Sort books by title, display them without modifying the data file
void Task2::part9() {
    showNavBarMessage(hintColor, "    Sort books by title");

    if (library_.getBooks().empty())
        library_ = load();

    library_.sortByName();
    cout << "\n    Sorted by title:";
    library_.show(cout);
} // Task2::part9

// Initial setup of the fitness club
void Task3::initialize(){
    Date now;

    date_.setDate(now.getDay() + 1, now.getMonth(), now.getYear());
    finish_.setTime(start_.getHour() + 1, start_.getMinute(), start_.getSecond());

    fitnessClub_.setAdministration(Personnel(
        Person(FullName("Volkova", "Nadezhda", "Valerievna"), "25 63 891324"),
        "Administrator", 42000.));

    vector<Personnel> trainers = {
        Personnel(Person(FullName("Lebedev",    "Dmitry",    "Sergeevich"),  "06 73 562734"),
                  "Trainer", 15000.),
        Personnel(Person(FullName("Gerasimova", "Elizaveta", "Eduardovna"), "29 97 924581"),
                  "Trainer", 15000.),
        Personnel(Person(FullName("Belozyorov", "Yuri",      "Lvovich"),    "31 41 159265"),
                  "Trainer", 15000.)
    };
    fitnessClub_.setTrainers(trainers);

    vector<Person> clients = {
       Person(FullName("Kravchenko", "Grigory",  "Artyomovich"),  "26 09 156478"), 
       Person(FullName("Nekrasova",  "Larisa",   "Gennadievna"),  "11 10 200303"),
       Person(FullName("Kutsenkova", "Elena",    "Vladimirovna"), "12 04 197811"),
       Person(FullName("Topchiy",    "Alina",    "Danilovna"),    "11 03 198107"),
       Person(FullName("Kulikov",    "Maksim",   "Viktorovich"),  "23 18 982356"),
       Person(FullName("Kuznetsova", "Lyubov",   "Sergeevna"),    "08 16 763452"),
       Person(FullName("Mikhailov",  "Matvey",   "Ivanovich"),    "07 28 345162")
    };
    fitnessClub_.setClients(clients);

    fitnessClub_.setSportsHalls(vector<string>{"gym", "aerobics hall", "martial arts hall"});

} // Task3::initialize

// Display fitness club data in the console
void Task3::part0(){
    showNavBarMessage(hintColor, "    Display fitness club data in the console");
    cout << fitnessClub_;
} // Task3::part0

// Assign a trainer for a group workout (more than 2 participants)
void Task3::part1(){
    showNavBarMessage(hintColor, "    Assign a trainer for a group workout (more than 2 participants)");

    // vector of clients who are busy at this time
    vector<Person> busy;
    // vector of halls that are busy at this time
    vector<string> busyHalls;
    // vector of trainers who are busy at this time
    vector<Personnel> busyTrainers;

    for (auto training : fitnessClub_.getTrainings()) {
        // find busy clients
        for (auto person : training.getParticipants())
            busy.push_back(person);

        // find busy halls
        busyHalls.push_back(training.getGym());

        // find busy trainers
        busyTrainers.push_back(training.getTrainer());
    }

    if (busy.size() >= fitnessClub_.getClients().size() - 1) 
        throw exception("All clients are busy at this time!");
    if (busyHalls.size() == fitnessClub_.getSportsHalls().size()) 
        throw exception("All sports halls are busy at this time!");
    if (busyTrainers.size() == fitnessClub_.getTrainers().size()) 
        throw exception("All trainers are busy at this time!");

    // vector of clients who are free at this time
    vector<Person> free;
    // vector of halls that are free at this time
    vector<string> freeHalls;
    // vector of trainers who are free at this time
    vector<Personnel> freeTrainers;

    for (auto person : fitnessClub_.getClients()) {
        if (find(busy.begin(), busy.end(), person) == busy.end())
            free.push_back(person);
    }

    for (auto hall : fitnessClub_.getSportsHalls()) {
        if (find(busyHalls.begin(), busyHalls.end(), hall) == busyHalls.end())
            freeHalls.push_back(hall);
    }

    for (auto trainer : fitnessClub_.getTrainers()) {
        if (find(busyTrainers.begin(), busyTrainers.end(), trainer) == busyTrainers.end())
            freeTrainers.push_back(trainer);
    }

    // generate indices of the clients to add
    int clientIndex1, clientIndex2;
    clientIndex1 = clientIndex2 = getRand(0, free.size() - 1);
    while (clientIndex1 == clientIndex2)
        clientIndex2 = getRand(0, free.size() - 1);

    // generate index of the hall
    int hallIndex = getRand(0, freeHalls.size() - 1);

    // generate index of the trainer
    int trainerIndex = getRand(0, freeTrainers.size() - 1);

    Training toAdd(
        start_, 
        finish_, 
        date_, 
        freeHalls[hallIndex], 
        freeTrainers[trainerIndex],
        vector<Person>{free[clientIndex1], free[clientIndex2]}, 
        GROUP
    );

    fitnessClub_.addTraining(toAdd);

    cout << color(hintColor) << "\n\n\t\t\t Workout successfully added!\n\n" 
         << color(mainColor) << fitnessClub_;

} // Task3::part1

// Assign a trainer for a group workout (fewer than 2 participants)
void Task3::part2(){
    showNavBarMessage(hintColor, "    Assign a trainer for a group workout (fewer than 2 participants)");

    // vector of clients who are busy at this time
    vector<Person> busy;
    // vector of halls that are busy at this time
    vector<string> busyHalls;
    // vector of trainers who are busy at this time
    vector<Personnel> busyTrainers;

    for (auto training : fitnessClub_.getTrainings()) {
        for (auto person : training.getParticipants())
            busy.push_back(person);

        busyHalls.push_back(training.getGym());
        busyTrainers.push_back(training.getTrainer());
    }

    if (busy.size() >= fitnessClub_.getClients().size() - 1) 
        throw exception("All clients are busy at this time!");
    if (busyHalls.size() == fitnessClub_.getSportsHalls().size()) 
        throw exception("All sports halls are busy at this time!");
    if (busyTrainers.size() == fitnessClub_.getTrainers().size()) 
        throw exception("All trainers are busy at this time!");

    // vector of free clients
    vector<Person> free;
    // vector of free halls
    vector<string> freeHalls;
    // vector of free trainers
    vector<Personnel> freeTrainers;

    for (auto person : fitnessClub_.getClients()) {
        if (find(busy.begin(), busy.end(), person) == busy.end())
            free.push_back(person);
    }

    for (auto hall : fitnessClub_.getSportsHalls()) {
        if (find(busyHalls.begin(), busyHalls.end(), hall) == busyHalls.end())
            freeHalls.push_back(hall);
    }

    for (auto trainer : fitnessClub_.getTrainers()) {
        if (find(busyTrainers.begin(), busyTrainers.end(), trainer) == busyTrainers.end())
            freeTrainers.push_back(trainer);
    }

    // generate index for the single client
    int clientIndex = getRand(0, free.size() - 1);

    // generate index of the hall
    int hallIndex = getRand(0, freeHalls.size() - 1);

    // generate index of the trainer
    int trainerIndex = getRand(0, freeTrainers.size() - 1);

    Training toAdd(
        start_, 
        finish_, 
        date_, 
        freeHalls[hallIndex], 
        freeTrainers[trainerIndex],
        vector<Person>{free[clientIndex]}, 
        GROUP
    );

    fitnessClub_.addTraining(toAdd);

    cout << color(hintColor) << "\n\n\t\t\t Workout successfully added!\n\n" 
         << color(mainColor) << fitnessClub_;
} // Task3::part2

// Assign a trainer for an individual workout
void Task3::part3(){
    showNavBarMessage(hintColor, "    Assign a trainer for an individual workout");

    // vector of clients who are busy at this time
    vector<Person> busy;
    // vector of halls that are busy at this time
    vector<string> busyHalls;
    // vector of trainers who are busy at this time
    vector<Personnel> busyTrainers;

    for (auto training : fitnessClub_.getTrainings()) {
        for (auto person : training.getParticipants())
            busy.push_back(person);

        busyHalls.push_back(training.getGym());
        busyTrainers.push_back(training.getTrainer());
    }

    if (busy.size() >= fitnessClub_.getClients().size() - 1) 
        throw exception("All clients are busy at this time!");
    if (busyHalls.size() == fitnessClub_.getSportsHalls().size()) 
        throw exception("All sports halls are busy at this time!");
    if (busyTrainers.size() == fitnessClub_.getTrainers().size()) 
        throw exception("All trainers are busy at this time!");

    // vector of free clients
    vector<Person> free;
    // vector of free halls
    vector<string> freeHalls;
    // vector of free trainers
    vector<Personnel> freeTrainers;

    for (auto person : fitnessClub_.getClients()) {
        if (find(busy.begin(), busy.end(), person) == busy.end())
            free.push_back(person);
    }

    for (auto hall : fitnessClub_.getSportsHalls()) {
        if (find(busyHalls.begin(), busyHalls.end(), hall) == busyHalls.end())
            freeHalls.push_back(hall);
    }

    for (auto trainer : fitnessClub_.getTrainers()) {
        if (find(busyTrainers.begin(), busyTrainers.end(), trainer) == busyTrainers.end())
            freeTrainers.push_back(trainer);
    }

    // generate index for the single client
    int clientIndex = getRand(0, free.size() - 1);

    // generate index of the hall
    int hallIndex = getRand(0, freeHalls.size() - 1);

    // generate index of the trainer
    int trainerIndex = getRand(0, freeTrainers.size() - 1);

    Training toAdd(
        start_,
        finish_,
        date_,
        freeHalls[hallIndex],
        freeTrainers[trainerIndex],
        vector<Person>{free[clientIndex]},
        INDIVIDUAL
    );

    fitnessClub_.addTraining(toAdd);

    cout << color(hintColor) << "\n\n\t\t\t Workout successfully added!\n\n" 
         << color(mainColor) << fitnessClub_;
} // Task3::part3

void Task3::start(){

    // application command codes
    enum Commands {
        CMD_FIRST,      // Display fitness club data in the console
        CMD_SECOND,     // Assign a trainer for a group workout (more than 2 participants)
        CMD_THIRD,      // Assign a trainer for a group workout (fewer than 2 participants)
        CMD_FOURTH,     // Assign a trainer for an individual workout
    };

    // application menu items
    const int N_MENU = 5;
    MenuItem items[N_MENU] = {
        MenuItem("Display fitness club data in the console", CMD_FIRST),
        MenuItem("Assign a trainer for a group workout (more than 2 participants)", CMD_SECOND),
        MenuItem("Assign a trainer for a group workout (fewer than 2 participants)", CMD_THIRD),
        MenuItem("Assign a trainer for an individual workout", CMD_FOURTH),
        MenuItem("Exit",  Menu::CMD_QUIT)
    };

    const int N_PALETTE = 5;
    //                          header         item               selected item    console
    short palette[N_PALETTE] = { WHITE_ON_BLACK, LTCYAN_ON_BLACK, BLACK_ON_LTCYAN, mainColor };

    // Note: originally the title was "Задача 2", but since this is Task 3, we'll translate accordingly.
    Menu mainMenu("Task 3", items, N_MENU, palette, COORD{ 5, 5 });
    initialize();

    while (true) {
        try {
            cout << color(palette[Menu::PAL_CONSOLE]) << cls;
            int cmd = mainMenu.Navigate();
            cout << color(palette[Menu::PAL_CONSOLE]) << cls;
            if (cmd == Menu::CMD_QUIT) break;

            switch (cmd) {
                // Display fitness club data in the console
            case CMD_FIRST:
                part0();
                break;

                // Assign a trainer for a group workout (more than 2 participants)
            case CMD_SECOND:
                part1();
                break;

                // Assign a trainer for a group workout (fewer than 2 participants)
            case CMD_THIRD:
                part2();
                break;

                // Assign a trainer for an individual workout
            case CMD_FOURTH:
                part3();
                break;
            }
        }
        catch (exception& ex) {
            cout << color(errColor) << "\n\n\t\t\t                                                                                      \n";
            cout << "\t\t\t ************************************************************************************ \n";
            cout << "\t\t\t                                     Exception.                                       \n";
            cout << "\t\t\t " << setw(80) << ex.what() << "     \n";
            cout << "\t\t\t                                                                                      \n";
            cout << "\t\t\t ************************************************************************************ \n";
            cout << "\t\t\t                                                                                      \n"
                 << color(mainColor);
        }
        getKey("\n\n\nPress any key to continue...");
    }

    cout << cls << pos(0, 24);
} // Task3::start