#pragma once
#include "pch.h"
#include "BaseState.h"
#include "StudyAssignmentStates.h"

// Context class - Study Assignment
// Its internal state will change
class StudyAssignment {

	// Variable for internal state
	BaseState* pCurrentState = nullptr;

	// Assignment fields
	string fullName_;  // Full name of the student (Surname, First name, Middle name)
	int    mark_;      // Mark (if the mark is 0, the assignment has not been checked yet)

public:
	StudyAssignment() : StudyAssignment("Ivanov I. I.", 0) {}
	StudyAssignment(const string& fullName, int mark) {
		SetFullName(fullName);
		SetMark(mark);
		pCurrentState = new IssuedState();
	} // StudyAssignment

	~StudyAssignment() {
		if (pCurrentState) delete pCurrentState;
	} // ~StudyAssignment

	// Return the state of the assignment
	BaseState* getState() const { return pCurrentState; }

	// Change the state of the assignment
	void setState(BaseState* pState) {
		if (pCurrentState)
			delete pCurrentState;

		pCurrentState = pState;
	} // setState

	// Perform some action as a result of which the internal state changes
	void request() { pCurrentState->handle(this); }

	// Accessors
	BaseState* getPCurrentState() const { return pCurrentState; }
	void setPCurrentState(BaseState* const pCurrentState) { this->pCurrentState = pCurrentState; }

	string GetFullName() const { return fullName_; }
	void   SetFullName(const string& fullName) { fullName_ = fullName; }

	int  GetMark() const { return mark_; }
	void SetMark(const int mark) {
		// If the mark is 0, the assignment has not been checked yet
		if (mark < 0 || mark > 12) throw exception("StudyAssignment: Invalid mark!");
		mark_ = mark;
	} // setMark

	friend ostream& operator<<(ostream& os, const StudyAssignment& studyAssignment) {
		os << "\n    Full Name of the Student: ";
		if (studyAssignment.fullName_.empty())
			os << "Not provided";
		else os << studyAssignment.fullName_;

		os << "\n    Mark                   : ";
		if (studyAssignment.mark_ != 0)
			os << studyAssignment.mark_;
		else os << "Not provided";

		os << "\n    State                : " << studyAssignment.pCurrentState->getNameOfState();
		return os;
	} // operator<<
};
