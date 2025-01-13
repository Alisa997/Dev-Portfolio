#include "pch.h"
#include "Utils.h"
#include "Palette.h"
#include "StudyAssignment.h"

/*
*   State Pattern – console application. Define the logic for changing states.
*   A study assignment performed by a student can be in the following states:
*    •	Issued
*    •	Completed
*    •	Sent for Verification
*    •	Verified
*    •	Accepted (grade not less than 7 points)
*    •	Not Accepted (grade less than 7 points)
*    •	Retold for Verification
*/

int main()
{
    // setting up console output
    init(L"Final Task on 11.10.2021 - Task 2. State Pattern");

    try {
        cout << "\t\t\t\t\t\tDemonstrating all states of the assignment\n\n";
        cout << color(hintColor) << "    Assignment Issued:" << setw(121) << " " << color(mainColor);
        StudyAssignment sa1;
        cout << sa1 << "\n\n";


        //------------------------------------------------------------------------------------------------------------
        sa1.request();           // processing the assignment
        cout << color(hintColor) << "    Assignment Completed:" << setw(118) << " " << color(mainColor);
        cout << sa1 << "\n\n";

        //------------------------------------------------------------------------------------------------------------
        sa1.request();           // processing the assignment
        cout << color(hintColor) << "    Assignment Sent for Verification:" << setw(110) << " " << color(mainColor);
        cout << sa1 << "\n\n";

        //------------------------------------------------------------------------------------------------------------
        sa1.SetMark(6);          // Setting a grade to demonstrate the "Assignment Verified" state
        sa1.request();           // processing the assignment
        cout << color(hintColor) << "    Assignment Verified:" << setw(118) << " " << color(mainColor);
        cout << sa1 << "\n\n";

        //------------------------------------------------------------------------------------------------------------
        // Assignment is not accepted as the grade is below 7
        sa1.request();           // processing the assignment
        cout << color(hintColor) << "    Assignment Not Accepted:" << setw(115) << " " << color(mainColor);
        cout << sa1 << "\n\n";

        //------------------------------------------------------------------------------------------------------------
        sa1.request();           // processing the assignment
        cout << color(hintColor) << "    Assignment Retold for Verification:" << setw(106) << " " << color(mainColor);
        cout << sa1 << "\n\n";

        //------------------------------------------------------------------------------------------------------------
        sa1.request();            // processing the assignment (transition to "Assignment Sent for Verification")
        sa1.SetMark(12);          // Setting a grade to demonstrate the "Assignment Accepted" state
        sa1.request();            // processing the assignment (transition to "Assignment Verified")
        sa1.request();            // processing the assignment (transition to "Assignment Accepted")
        cout << color(hintColor) << "    Assignment Accepted:" << setw(118) << " " << color(mainColor);
        cout << sa1 << "\n\n";

        getKey();
    }
    catch (exception& ex) {
        setColor(mainColor);
        cls();
        showNavBarMessage(hintColor, "  Application Error, press any key to continue...");

        // adding 4 spaces before the error message, line length 64 characters
        char buf[65];
        sprintf(buf, "    %-60s", ex.what());

        // control passes here with the throw operator
        const char* msg[] = {
            " ",
            "    [Error]",
            buf,
            " ",
            " ",
            nullptr
        };
        showMessage(8, 4, 64, msg, errColor);
    } // try-catch
    cout << endlm(2);

    return 0;
} // main
