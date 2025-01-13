#include "pch.h"
#include "StudyAssignment.h"
#include "StudyAssignmentStates.h"

// "Issued" -- change state to another one
void IssuedState::handle(StudyAssignment* studyAssignment) {
	// transition to "Completed" state
	studyAssignment->setState(new CompletedState());
} // IssuedState::handle

// "Completed" -- change state to another one
void CompletedState::handle(StudyAssignment* studyAssignment) {
	// transition to "Sent for Verification" state
	studyAssignment->setState(new SentForVerificationState());
} // CompletedState::handle

// "Sent for Verification" -- change state to another one
void SentForVerificationState::handle(StudyAssignment* studyAssignment) {
	// transition to "Verified" state, if a grade has been assigned
	if(studyAssignment->GetMark() != 0)
		studyAssignment->setState(new VerifiedState());
} // SentForVerificationState::handle

// "Verified" -- change state to another one
void VerifiedState::handle(StudyAssignment* studyAssignment) {
	if (studyAssignment->GetMark() >= 7)
		// transition to "Accepted" state if grade >= 7
		studyAssignment->setState(new AcceptedState());
	else 
		// transition to "Not Accepted" state if grade < 7
		studyAssignment->setState(new NotAcceptedState());
} // VerifiedState::handle

// "Not Accepted" -- change state to another one
void NotAcceptedState::handle(StudyAssignment* studyAssignment) {
	// transition to "Retold for Verification" state
	studyAssignment->setState(new RetoldForVerificationState());
} // NotAcceptedState::handle

// "Retold for Verification" -- change state to another one
void RetoldForVerificationState::handle(StudyAssignment* studyAssignment) {
	// remove the old grade
	studyAssignment->SetMark(0);
	// transition to "Sent for Verification" state
	studyAssignment->setState(new SentForVerificationState());
} // RetoldForVerificationState::handle