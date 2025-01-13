using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homework.App;
using Homework.Infrastructure;

namespace Homework
{
    /*
     * In the console application using asynchronous operations in the TAP pattern, solve the following tasks.
     * Handle errors that occur in tasks. All tasks should be launched in parallel.
     * 
     * • In a text file (words are separated by spaces), change the case of characters in all words that 
     *   start and end with a vowel.
     *    
     * • In a one-dimensional array of integers, perform a sort according to the rule "odd numbers first", 
     *   write the array to a binary file, and display the array from the file in the console.
     *     
     * • In a two-dimensional array (rectangular array) of floating-point numbers (9x6), swap columns 
     *   so that they are ordered by increasing column sums.
     *  
     */
    public class Program
    {
        static void Main(string[] args) {
            Console.Title = "Task for 10.03.2022 - Error Handling in Tasks";

            // Simple application menu
            List<MenuItem> menu = new List<MenuItem>(new[]{
                new MenuItem { HotKey = ConsoleKey.Q, Text = "Line-by-line file processing"},
                new MenuItem { HotKey = ConsoleKey.W, Text = "One-dimensional array processing"},
                new MenuItem { HotKey = ConsoleKey.E, Text = "Two-dimensional array processing"},
                new MenuItem { HotKey = ConsoleKey.P, Text = "Separator" },
                new MenuItem { HotKey = ConsoleKey.A, Text = "Run all processes in parallel"},
                new MenuItem { HotKey = ConsoleKey.S, Text = "Run all processes in parallel with errors"},
                new MenuItem { HotKey = ConsoleKey.P, Text = "Separator" },
                //--------------------------------------------------------------------------------------------------------------------------
                new MenuItem { HotKey = ConsoleKey.Z, Text = "Exit" },
            });
            // Create an instance of the application class
            Application app = new Application();

            // Main application loop
            while (true) {
                try {
                    // Set color scheme
                    (Console.ForegroundColor, Console.BackgroundColor) = (ConsoleColor.Gray, ConsoleColor.DarkGray);
                    Console.Clear();
                    Console.CursorVisible = false;

                    Utils.ShowNavBarTask("Task for 10.03.2022 - Error Handling in Tasks");
                    Utils.ShowMenu(12, 5, "Main Menu", menu);

                    // Get the key pressed, do not display the key's character
                    ConsoleKey key = Console.ReadKey(true).Key;
                    Console.Clear();

                    switch (key) {
                        // Line-by-line file processing
                        case ConsoleKey.Q:
                            app.AsyncTextByLine();
                            break;

                        // One-dimensional array processing
                        case ConsoleKey.W:
                            app.AsyncArray();
                            break;

                        // Two-dimensional array processing
                        case ConsoleKey.E:
                            app.AsyncOrderMatrix();
                            break;

                        // Run all processes in parallel
                        case ConsoleKey.A:
                            app.Run();
                            break;

                        // Run all processes in parallel with errors
                        case ConsoleKey.S:
                            app.RunWithExceptions();
                            break;

                        // Exit the application assigned to F10, Z, or Escape
                        case ConsoleKey.F10:
                        case ConsoleKey.Escape:
                        case ConsoleKey.Z:
                            Console.ResetColor();   // Reset color scheme to default
                            Console.Clear();
                            Utils.WriteXY(0, Console.WindowHeight - 1, "", ConsoleColor.Gray);
                            Console.CursorVisible = true;
                            return;

                        default:
                            throw new Exception("This menu option does not exist!");
                    } // switch

                }
                catch (Exception ex) {
                    // Get the first 79 characters of the error message
                    string str = ex.Message.Length > 79 ? ex.Message.Substring(0, 79) : ex.Message;

                    Console.Clear();
                    ConsoleColor oldColor = Console.BackgroundColor;
                    Console.BackgroundColor = ConsoleColor.Red;
                    Utils.WriteXY(20, 9, $"                                                                                        ", ConsoleColor.White);
                    Utils.WriteXY(20, 10, $"  ┌──────────────────────────────────────────────────────────────────────────────────┐  ", ConsoleColor.White);
                    Utils.WriteXY(20, 11, $"  │                                    Exception                                     │  ", ConsoleColor.White);
                    Utils.WriteXY(20, 12, $"  │ {str,-79}  │  ", ConsoleColor.White);
                    Utils.WriteXY(20, 13, $"  │                                                                                  │  ", ConsoleColor.White);
                    Utils.WriteXY(20, 14, $"  └──────────────────────────────────────────────────────────────────────────────────┘  ", ConsoleColor.White);
                    Utils.WriteXY(20, 15, $"                                                                                        ", ConsoleColor.White);
                    Console.BackgroundColor = oldColor;
                }
                finally {
                    // Wait for any key press after finishing the menu option
                    Console.CursorVisible = true;
                    Console.WriteLine("\nPress any key...");
                    Console.ReadKey(true);
                } // try-catch
            } // while
        } // Main
    } // class Program
}
