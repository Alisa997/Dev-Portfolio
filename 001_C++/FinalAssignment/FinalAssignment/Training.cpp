#include "Training.h"

void Training::setTime(Time start, Time finish) {
    if (start.getHour() >= finish.getHour())
        throw exception("Training: invalid workout time!");

    start_ = start;
    finish_ = finish;
} // Training::setTime

void Training::setDate(Date date) {
    Date now;
    if (date < now)
        throw exception("Training: invalid workout date!");

    date_ = date;
} // Training::setDate

void Training::setTrainer(Personnel trainer) {
    if (trainer.getPosition() != "Trainer")
        throw exception("Training: only a trainer can conduct the workout!");

    trainer_ = trainer;
} // Training::setTrainer

void Training::setParticipants(vector<Person> participants) {
    if (type_ == GROUP && participants.size() <= 1)
        throw exception("Training: the minimum number of participants in a group workout is 2!");

    if (type_ == INDIVIDUAL && participants.size() > 1)
        throw exception("Training: only 1 participant can attend an individual workout!");

    participants_ = participants;
} // Training::setParticipants

ostream& Training::header(ostream& os) {
    os  << "    +————————————+—————————————+———————————————————————————————————+—————————————————————+———————————+\n"
        << "    |    Date    |    Time     |              Trainer              |         Hall        |  Members  |\n"
        << "    |            |             |                                   |                     |           |\n"
        << "    +————————————+—————————————+———————————————————————————————————+—————————————————————+———————————+\n";
    return os;
} // Training::header

ostream& Training::footer(ostream& os) {
    os << "    +————————————+—————————————+———————————————————————————————————+—————————————————————+———————————+\n";
    return os;
} // Training::footer

ostream& operator<<(ostream& os, const Training& training) {
    os << "    | " << training.date_
        << " | " << training.start_ << "-" << training.finish_
        << " | " << left << setw(33) << training.trainer_.getPerson().getName()
        << " | " << setw(19) << training.gym_
        << " | " << right << setw(9) << training.participants_.size()
        << " | ";
    return os;
} // operator<<