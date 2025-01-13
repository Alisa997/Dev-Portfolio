using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace TcpClientSocket.Infrastructure
{
    // Helper methods and objects - a static class, i.e., a class that contains only static members and methods
    public static class Utils
    {

        // Object for generating random numbers
        public static readonly Random Random = new Random(Environment.TickCount);

        // Getting a random number
        // Short form of the method - this is not a lambda expression
        public static int GetRandom(int lo, int hi) => Random.Next(lo, hi + 1);
        public static double GetRandom(double lo, double hi) => lo + (hi - lo) * Random.NextDouble();

        // Generating random integers in the specified range (lo, hi),
        // excluding the number specified by the exclude parameter
        public static int GetRandomExclude(int lo, int hi, int exclude) {
            int number = 0;
            do
                number = Random.Next(lo, hi);
            while (number == exclude);

            return number;
        } // GetRandomExclude

    } // class Utils
}
