#include "FitnessClub.h"

void FitnessClub::setClients(vector<Person> clients) {
    for (auto client : clients)
        addClient(client);
} // FitnessClub::setClients

void FitnessClub::setTrainers(vector<Personnel> trainers) {
    for (auto trainer : trainers)
        addTrainer(trainer);
} // FitnessClub::setTrainers

void FitnessClub::setAdministration(Personnel administration) {
    // Check if this person really is an Administrator
    if (administration.getPosition() != "Administrator")
        throw exception("FitnessClub: this person is not an Administrator!");

    administration_ = administration;
} // FitnessClub::setAdministration

void FitnessClub::setTrainings(vector<Training> trainings) {
    for (auto training : trainings)
        addTraining(training);
} // FitnessClub::setTrainings

void FitnessClub::addClient(Person client) {
    // Check if the person is already in the client list
    if (find(clients_.begin(), clients_.end(), client) != clients_.end())
        throw exception("FitnessClub: this person is already a client of the fitness club!");

    clients_.push_back(client);
} // FitnessClub::addClient

void FitnessClub::addTrainer(Personnel trainer) {
    // Check if the person is already in the trainer list
    if (find(trainers_.begin(), trainers_.end(), trainer) != trainers_.end())
        throw exception("FitnessClub: this person is already a trainer of the fitness club!");

    // Check if the position is actually "Trainer"
    if (trainer.getPosition() != "Trainer")
        throw exception("FitnessClub: this person is not a Trainer!");

    trainers_.push_back(trainer);
} // FitnessClub::addTrainer

void FitnessClub::addTraining(Training training) {
    // Verify that all participants are clients of the fitness club
    for (auto client : training.getParticipants()) {
        if (find(clients_.begin(), clients_.end(), client) == clients_.end())
            throw exception("FitnessClub: this person is not a client of the fitness club!");
    }

    // Check if the gym (sports hall) is in the list
    if (find(sportsHalls_.begin(), sportsHalls_.end(), training.getGym()) == sportsHalls_.end())
        throw exception("FitnessClub: sports hall not found!");

    trainings_.push_back(training);
} // FitnessClub::addTraining

ostream& operator<<(ostream& os, const FitnessClub& fitnessClub) {
    // Administrator and name
    os << "    Administrator: " 
       << fitnessClub.administration_.getPerson().getName() 
       << "\n\n   Trainers:\n"
       << Personnel::header;

    // Trainers
    if (fitnessClub.trainers_.empty()) {
        os << "    |                                        EMPTY                                   |\n";
    } else {
        for (auto item : fitnessClub.trainers_)
            os << item << "\n";
    }
    os << Personnel::footer << "\n\n   Clients:\n" << Person::header;

    // Clients
    if (fitnessClub.clients_.empty()) {
        os << "    |                        EMPTY                       |\n";
    } else {
        for (auto item : fitnessClub.clients_)
            os << item << "\n";
    }
    os << Person::footer << "\n\n   Workouts:  \n" << Training::header;

    // Workouts
    if (fitnessClub.trainings_.empty()) {
        os << "    |                                              EMPTY                                             |\n";
    } else {
        for (auto item : fitnessClub.trainings_)
            os << item << "\n";
    }
    os << Training::footer << "\n\n   Halls: ";

    // List of sports halls
    for (auto item : fitnessClub.sportsHalls_)
        os << item << ", ";

    // Remove the trailing ", "
    os << "\b\b  \n\n";
    return os;
} // operator<<