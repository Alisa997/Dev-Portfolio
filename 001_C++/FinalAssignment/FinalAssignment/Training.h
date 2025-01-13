#pragma once
#include "pch.h"
#include "Date.h"
#include "Time.h"
#include "Person.h"
#include "Personnel.h"
#include <vector>

/*
*   Information about a training session includes:
*       start time of the training session,
*       end time of the training session,
*       date of the training session,
*       the name of the hall,
*       the trainer,
*       list of participants,
*       type (individual or group)
*/

// training type codes
enum trainingType {
    INDIVIDUAL,    // individual
    GROUP          // group
};

class Training {
    Time start_;                  // time the training starts
    Time finish_;                 // time the training ends
    Date date_;                   // date of the training
    string gym_;                  // name of the hall
    Personnel trainer_;           // trainer
    vector<Person> participants_; // list of participants
    trainingType type_;           // type (individual or group)

public:
    // default constructor
    Training() = default;

    // constructor with parameters
    Training(Time start, Time finish, Date date, const string& gym,
        Personnel trainer, vector<Person> participants, trainingType type)
    {
        setTime(start, finish);
        setDate(date);
        setGym(gym);
        setTrainer(trainer);
        setType(type);
        setParticipants(participants);
    } // Training

    // copy constructor
    Training(const Training& value) = default;

    // destructor
    ~Training() = default;

    // getters and setters
    void setTime(Time start, Time finish);
    Time getStart()  const { return start_; }
    Time getFinish() const { return finish_; }

    void setDate(Date date);
    Date getDate() const { return date_; }

    void   setGym(const string& gym) { gym_ = gym; }
    string getGym()  const { return gym_; }

    void      setTrainer(Personnel trainer);
    Personnel getTrainer() const { return trainer_; }

    void           setParticipants(vector<Person> participants);
    vector<Person> getParticipants() const { return participants_; }

    void         setType(trainingType type) { type_ = type; }
    trainingType getType() const { return type_; }

    Training& operator=(const Training& value) = default;

    friend ostream& operator<<(ostream& os, const Training& training);

    // output the table header
    static ostream& header(ostream& os);

    // output the table footer
    static ostream& footer(ostream& os);
};