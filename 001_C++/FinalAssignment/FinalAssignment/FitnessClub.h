#pragma once
#include "pch.h"
#include "Person.h"
#include "Personnel.h"
#include "Training.h"
#include <vector>

/*
* Three categories of users can be distinguished: clients, trainers, administration.
* The fitness club also has three halls: a gym, an aerobics hall, and a martial arts hall.
*/
class FitnessClub {
    vector<Person> clients_;        // clients
    vector<Personnel> trainers_;    // trainers
    Personnel administration_;      // administration
    vector<string> sportsHalls_;    // halls
    vector<Training> trainings_;    // workouts

public:
    // default constructor
    FitnessClub()
        : FitnessClub(
            vector<Person>(),
            vector<Personnel>(),
            Personnel(
                Person(FullName("Volkova", "Nadezhda", "Valerievna"), "25 63 891324"),
                "Administrator",
                42000.),
            vector<string>{"gym", "aerobics hall", "martial arts hall"},
            vector<Training>()
        )
    {}

    // constructor with parameters
    FitnessClub(
        vector<Person> clients,
        vector<Personnel> trainers,
        Personnel administration,
        vector<string> sportsHalls,
        vector<Training> trainings
    ) {
        setClients(clients);
        setTrainers(trainers);
        setAdministration(administration);
        setSportsHalls(sportsHalls);
        setTrainings(trainings);
    } // FitnessClub

    // getters and setters
    void           setClients(vector<Person> clients);
    vector<Person> getClients() const { return clients_; }

    void              setTrainers(vector<Personnel> trainers);
    vector<Personnel> getTrainers() const { return trainers_; }

    void        setAdministration(Personnel administration);
    Personnel   getAdministratin() const { return administration_; }

    void           setSportsHalls(vector<string> sportsHalls) { sportsHalls_ = sportsHalls; }
    vector<string> getSportsHalls() const { return sportsHalls_; }

    void             setTrainings(vector<Training> trainings);
    vector<Training> getTrainings() const { return trainings_; }

    // overload of the output operator
    friend ostream& operator<<(ostream& os, const FitnessClub& fitnessClub);

    // adding a client
    void addClient(Person client);

    // adding a trainer
    void addTrainer(Personnel trainer);

    // adding a workout
    void addTraining(Training training);
};
