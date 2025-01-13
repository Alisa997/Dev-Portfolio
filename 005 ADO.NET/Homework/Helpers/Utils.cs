using Homework.Models;
using System;

namespace Homework.Helpers
{
    // Helper methods and objects - static class, i.e., a class
    // that contains only static members and methods
    public static class Utils
    {
        // Object for generating random numbers
        public static Random Random = new Random();
        
        // Generate random floating-point numbers in the range from lo to hi
        public static double GetRandom(double lo, double hi)
            => lo + (hi - lo) * Random.NextDouble();
        
        // Generates and prints the header line for tasks
        public static void ShowNavBarTask(string line) {
            // Save the background color
            ConsoleColor oldBgColor = Console.BackgroundColor;
            ConsoleColor oldFgColor = Console.ForegroundColor;

            // When printing, we use some methods of the string class :)
            // PadRight() adds spaces to the string on the right until it reaches the desired length
            Console.BackgroundColor = ConsoleColor.Gray;
            WriteXY(0, 0, line.PadRight(Console.WindowWidth), ConsoleColor.Black);

            // Restore the background color
            Console.BackgroundColor = oldBgColor;
            Console.ForegroundColor = oldFgColor;
        } // ShowNavBarTask
        
        
        // Auxiliary method for printing text at specific coordinates in the console
        // with a specified color
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
        public static void ShowMenu(int x, int y, string title, MenuItem[] menu, ConsoleColor foregroundColor = ConsoleColor.Cyan, ConsoleColor backgroundColor = ConsoleColor.Gray) {
            WriteXY(x, y, title, backgroundColor);
            int offsetY = 2;

            foreach (var menuItem in menu) {
                WriteXY(x, y + offsetY, menuItem.HotKey.ToString(), foregroundColor);
                WriteXY(x + 2, y + offsetY++, menuItem.Text, backgroundColor);
            } // foreach menuItem
        } // ShowMenu

        // Set the current foreground and background color while saving
        // the current foreground and background color
        private static (ConsoleColor Fore, ConsoleColor Back) _storeColor;
        public static void SetColor(ConsoleColor fore, ConsoleColor back) {
            _storeColor = (Console.ForegroundColor, Console.BackgroundColor);
            Console.ForegroundColor = fore;
            Console.BackgroundColor = back;
        } // SetColor

        // Save the color
        public static void SaveColor() =>
            _storeColor = (Console.ForegroundColor, Console.BackgroundColor);

        // Restore the saved color
        public static void RestoreColor() =>
            (Console.ForegroundColor, Console.BackgroundColor) = _storeColor;
    } // class Utils
}
