using System;
using System.Collections.Generic;

namespace Workers.Helpers
{
    // Helper methods and objects - a static class, i.e., a class
    // that contains only static members and methods.
    public static class Utils
    {

        // Generate random integers within the specified range (lo, hi),
        // excluding the number specified by the parameter exclude.
        public static int GetRandomExclude(int lo, int hi, int exclude) {
            int number = 0;
            do
                number = Random.Next(lo, hi);
            while (number == exclude);

            return number;
        } // GetRandomExclude

        // Object for generating random numbers
        public static readonly Random Random = new Random(Environment.TickCount);

        // Generate a random number
        // A concise form of the method, this is not a lambda expression
        public static int GetRandom(int lo, int hi) => Random.Next(lo, hi + 1);
        public static double GetRandom(double lo, double hi) => lo + (hi - lo) * Random.NextDouble();


        // Cities
        public static string[] Cities = new[] {
             "Kyiv", "Lviv", "Odesa", "Kharkiv",
             "Donetsk", "Vinnytsia"
        };


        // Full names for generating personal data
        public static (string Surname, string Name, string Patronymic)[] FullNames = new[] {
            ("Petrova",     "Diana",     "Alexandrovna"),
            ("Yurkovskiy",   "Mark",      "Maximilianovich"),
            ("Yakubovskaya",  "Diana",     "Pavlovna"),
            ("Shapiro",      "Fedor",     "Fedorovich"),
            ("Vozhaev",     "Sergey",    "Denisovich"),
            ("Khromenko",    "Igor",     "Vladimirovich"),
            ("Pelykh",       "Marina",    "Ulyanovna"),
            ("Lapotnikova", "Tamara",    "Oskarovna"),
            ("Ogorodnikov", "Sergey",    "Ivanovich"),
            ("Yaylo",        "Ekaterina", "Nikolaevna"),
            ("Loseva",      "Inna",      "Stepanovna"),
            ("Mikhaylovich",  "Anna",      "Valentinovna"),
            ("Tarapata",    "Mikhail",    "Isaakovich"),
            ("Trubikhin",    "Eduard",    "Mikhaylovich"),
            ("Chmykhalo",     "Oleg",      "Tarasovich"),
            ("Knyazkov",    "Stepan",    "Sidorovich"),
            ("Potemkina",   "Natalya",   "Pavlovna"),
            ("Gritchenko",   "Stepan",    "Romanovich"),
            ("Selivanov",   "Alexander", "Mikhaylovich"),
            ("Tsarkhova",    "Larisa",    "Ilyinichna"),
            ("Yastrub",      "Vladimir",  "Danilovich")
        };

    } // class Utils
}
