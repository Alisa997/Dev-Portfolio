#pragma once
#include "BaseState.h"

// Assignment state - "Issued"
class IssuedState : public BaseState {
public:
	IssuedState() = default;
	~IssuedState() = default;

	// Change the state to another one
	void handle(StudyAssignment* studyAssignment);

	string getNameOfState() const { return "\"Assignment Issued\""; }
};

// Assignment state - "Completed"
class CompletedState : public BaseState {
public:
	CompletedState() = default;
	~CompletedState() = default;

	// Change the state to another one
	void handle(StudyAssignment* studyAssignment);

	string getNameOfState() const { return "\"Assignment Completed\""; }
};

// Assignment state - "Sent for Verification"
class SentForVerificationState : public BaseState {
public:
	SentForVerificationState() = default;
	~SentForVerificationState() = default;

	// Change the state to another one
	void handle(StudyAssignment* studyAssignment);

	string getNameOfState() const { return "\"Assignment Sent for Verification\""; }
};

// Assignment state - "Verified"
class VerifiedState : public BaseState {
public:
	VerifiedState() = default;
	~VerifiedState() = default;

	// Change the state to another one
	void handle(StudyAssignment* studyAssignment);

	string getNameOfState() const { return "\"Assignment Verified\""; }
};

// Assignment state - "Accepted"
class AcceptedState : public BaseState {
public:
	AcceptedState() = default;
	~AcceptedState() = default;

	// This is the final state, no further state transition
	void handle(StudyAssignment* studyAssignment) {
		// This is a final state
	} // handle

	string getNameOfState() const { return "\"Assignment Accepted\""; }
};

// Assignment state - "Not Accepted"
class NotAcceptedState : public BaseState {
public:
	NotAcceptedState() = default;
	~NotAcceptedState() = default;

	// Change the state to another one
	void handle(StudyAssignment* studyAssignment);

	string getNameOfState() const { return "\"Assignment Not Accepted\""; }
};

// Assignment state - "Retold for Verification"
class RetoldForVerificationState : public BaseState {
public:
	RetoldForVerificationState() = default;
	~RetoldForVerificationState() = default;

	// Change the state to another one
	void handle(StudyAssignment* studyAssignment);

	string getNameOfState() const { return "\"Assignment Retold for Verification\""; }
};