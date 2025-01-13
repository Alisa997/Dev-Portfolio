#pragma once
#include "pch.h"

// Forward declaration
class StudyAssignment;

// Base class for the state hierarchy
class BaseState
{
public:
	BaseState() = default;
	~BaseState() = default;

	// Get the name of the state
	virtual string getNameOfState() const = 0;

	// Handle transition to another state
	virtual void handle(StudyAssignment* studyAssignment) = 0;
};
