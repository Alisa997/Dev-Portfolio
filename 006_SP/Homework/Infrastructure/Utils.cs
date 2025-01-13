using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Homework.Infrastructure
{
    // Helper methods and objects - a static class, meaning it contains only static members and methods
    public static class Utils
    {

        // Object for generating random numbers
        public static readonly Random Random = new Random(Environment.TickCount);

        // Getting a random number
        // Short form of the method - this is not a lambda expression
        public static int GetRandom(int lo, int hi) => Random.Next(lo, hi + 1);
        public static double GetRandom(double lo, double hi) => lo + (hi - lo) * Random.NextDouble();

        // Generating random integers in the specified range (lo, hi),
        // excluding the specified number (exclude)
        public static int GetRandomExclude(int lo, int hi, int exclude) {
            int number = 0;
            do
                number = Random.Next(lo, hi);
            while (number == exclude);

            return number;
        } // GetRandomExclude


        // Forms and displays the header line for tasks
        public static void ShowNavBarTask(string line) {
            // Save background color
            (ConsoleColor oldBg, ConsoleColor oldFg) = (Console.BackgroundColor, Console.ForegroundColor);

            // When displaying, we slightly use string class methods :)
            // PadRight() adds spaces to the right of the string up to the specified length
            Console.BackgroundColor = ConsoleColor.Gray;
            WriteXY(0, 0, line.PadRight(Console.WindowWidth), ConsoleColor.Black);

            // Restore background color
            (Console.BackgroundColor, Console.ForegroundColor) = (oldBg, oldFg);
        } // ShowNavBarTask
        
        
        // Helper method to display text at specified coordinates in the console window
        // with the specified color
        public static void WriteXY(int x, int y, string s, ConsoleColor color) {
            // Save the current console color and set the specified one
            ConsoleColor oldColor = Console.ForegroundColor;
            Console.ForegroundColor = color;

            Console.SetCursorPosition(x, y);
            Console.Write(s);

            // Restore the console color
            Console.ForegroundColor = oldColor;
        } // WriteXY


        // Display the application menu
        public static void ShowMenu(int x, int y, string title, List<MenuItem> menu) {
            WriteXY(x, y, title, ConsoleColor.Gray);
            int offsetY = 2;

            foreach (var menuItem in menu) {
                // If the menu item text is "Separator", just increase the vertical offset
                // which will result in an empty line
                if (menuItem.Text != "Separator") {
                    WriteXY(x, y + offsetY, menuItem.HotKey.ToString(), ConsoleColor.Cyan);
                    WriteXY(x + 2, y + offsetY, menuItem.Text, ConsoleColor.Gray);
                } // if

                ++offsetY;
            } // foreach menuItem
        } // ShowMenu


        // Display the message "Method in development" at the center of the screen
        public static void ShowUnderConstruction() {
            (ConsoleColor fg, ConsoleColor bg) = (Console.ForegroundColor, Console.BackgroundColor); 
            (Console.ForegroundColor, Console.BackgroundColor) = (ConsoleColor.Black, ConsoleColor.Gray);

            string[] lines = { 
                 " ".PadRight(40),
                 " ".PadRight(40),
                 "     [Note]".PadRight(40),
                 " ".PadRight(40),
                 "     Method under development".PadRight(40),
                 " ".PadRight(40),
                 " ".PadRight(40),
            };

            int x = (Console.WindowWidth - 40) / 2;
            int y = (Console.WindowHeight - lines.Length) / 2;
            foreach(var line in lines)
                WriteXY(x, y++, line, ConsoleColor.DarkGray);

            (Console.ForegroundColor, Console.BackgroundColor) = (fg, bg);
            Console.SetCursorPosition(0, Console.WindowHeight-1);
        } // ShowUnderConstruction

        // ------------------------------------------------------------------------------


        // Generate an array of random integers
        public static int[] Generate(int n, int lo = -10, int hi = 10) =>
            Enumerable
                .Repeat(0, n)
                .Select(m => GetRandom(lo, hi))
                .ToArray();

        // Generate a matrix of random floating-point numbers
        public static double[,] GenerateMatrix(int m, int n, double lo = -10, double hi = 10) {
            double[,] matrix = new double[m, n];

            for (int i = 0; i < m; i++) {
                for (int j = 0; j < n; j++) {
                    matrix[i, j] = GetRandom(lo, hi);
                } // for j
            } // for i

            return matrix;
        } // Generate
    } // class Utils
}
