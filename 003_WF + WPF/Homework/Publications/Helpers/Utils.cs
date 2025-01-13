using System;
using System.Collections.Generic;

namespace Homework.Helpers
{
    // Helper methods and objects - static class, i.e., a class
    // that contains only static members and methods
    public static class Utils {

        // Generate random integers in a given range (lo, hi),
        // excluding the number specified by the exclude parameter
        public static int GetRandomExclude(int lo, int hi, int exclude) {
            int number = 0;
            do
                number = Random.Next(lo, hi);
            while (number == exclude);

            return number;
        } // GetRandomExclude

        // Object for generating random numbers
        public static readonly Random Random = new Random(Environment.TickCount);

        // Get a random integer
        // shorthand method, not a lambda expression
        public static int GetRandom(int lo, int hi) => Random.Next(lo, hi + 1);
        public static double GetRandom(double lo, double hi) => lo + (hi - lo) * Random.NextDouble();


        // Streets
        public static string[] Streets = new[] {
             "Sadovaya St.", "Izmailova Ave.", "Voinskaya St.", "Stolichnaya St.",
             "Orekhovaya St.", "Radio Ave.", "Pavlova St.", "Koroleva Ave.",
            "Nikolaevsky Ave.", "Prokatchikov St."
        };

        // Last names and initials for generating personal data
        public static string[] FullNames = new[] {
            "Petrova D.A.", "Tsibenko R.A.", "Yudina N.A.", "Fortranova B.V.", "Shavyrkina P.A.",
            "Faronova R.V.", "Schupak D.Yu.", "Zlatopolsky D.M.", "Abramyan M.E.", "Vasiliev A.N.",
            "Fedorova V.O.", "Muradov I.S.", "Shturlak A.V.", "Gamdzashvili Y.I.", "Baranova E.V.",
            "Maslova E.V.", "Fedorin M.N."
        };

        // Publication titles and types
        public static (string Name, string pubType)[] Publications = new[] {
            ("Izvestia",                        "newspaper"),
            ("My Family",                       "newspaper"),
            ("Pensioner's Truth",               "newspaper"),
            ("Cables and Wires",                "magazine"),
            ("Poisk",                           "newspaper"),
            ("Pravda",                          "newspaper"),
            ("Cosmonautics and Rocketry",       "magazine"),
            ("Economy and Life",               "newspaper"),
            ("Taxes. Economy. Finance",        "newspaper"),
            ("Clinical Medicine",              "magazine"),
            ("Home Hearth",                    "magazine"),
            ("RBK",                             "newspaper"),
            ("Young Technician",                "magazine"),
            ("Arguments and Facts",            "newspaper"),
            ("Murzilka",                        "magazine"),
            ("Science and Life",               "magazine"),
            ("Zavalinka",                       "newspaper"),
            ("64th Chess Review",              "magazine"),
            ("Almanac of Walking Routes",      "almanac"),
            ("Grass",                          "newspaper"),
            ("Marine Collection",               "magazine"),
            ("Model Designer",                 "magazine"),
            ("HIV Info",                       "newspaper"),
            ("Automation, Communication, Informatics",  "magazine"),
            ("Developers",                     "magazine"),
            ("Be Healthy!",                    "magazine"),
            ("Cheerful Trickster",             "magazine"),
            ("Teenage Mutant Ninja Turtles. Play and Learn", "magazine"),
            ("Medical Herald of Chelyabinsk",  "newspaper")
        };
    } // class Utils
}