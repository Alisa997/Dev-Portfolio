using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homework.Controllers;
using Homework.Infrastructure;

namespace Homework.App
{
    // implementation of the assignment items
    public class Application
    {
        // controller for performing operations
        private TaskController _taskController;

        #region Constructor Ensemble
        public Application() : this(new TaskController()) { }

        public Application(TaskController taskController) {
            _taskController = taskController;
        } // Application
        #endregion


        #region Text File Processing
        // Change the case of characters in all words that start and end with vowels
        public void AsyncTextByLine() {
            Utils.ShowNavBarTask("  Line-by-line text file processing");

            string fileName = @"..\..\App_Data\test.txt";

            _taskController.TextProcess(fileName);
        } // AsyncTextByLine
        #endregion


        #region Array of Integers Processing
        // Sort an array of integers by the rule "odd numbers first",
        // write the array to a binary file, and display the array from the file in the console
        // writing to the file and reading from the file will be asynchronous
        public void AsyncArray() {
            Utils.ShowNavBarTask("  Sorting an array of integers by the rule \"odd numbers first\"");

            // generating the array for processing
            int[] array = Utils.Generate(Utils.GetRandom(12, 22));

            _taskController.ArrayProcess(array, @"..\..\App_Data\async_array.bin");
        } // AsyncArray
        #endregion


        #region Rectangular Matrix Processing
        // In a two-dimensional array (rectangular array) of floating point numbers
        // (of size 9x6), swap columns so that they are ordered by ascending sums of elements
        public void AsyncOrderMatrix() {
            Utils.ShowNavBarTask("  Sorting matrix columns by ascending sums of elements");
            
            // generating the matrix for processing
            double[,] matrix = Utils.GenerateMatrix(6, 9);

            _taskController.MatrixProcess(matrix);
        } // AsyncOrderMatrix
        #endregion

        #region Running All Processes Simultaneously
        // Run all processes in parallel
        public async Task Run() {
            Utils.ShowNavBarTask("  Running all processes in parallel");
            // task management block
            Task task1 = null, task2 = null, task3 = null, allTasks = null;

            try {
                // parallel start of tasks
                task1 = Task.Run(() => _taskController.TextProcess(@"..\..\App_Data\test.txt"));
                task2 = Task.Run(() => _taskController.ArrayProcess(Utils.Generate(Utils.GetRandom(12, 22)), @"..\..\App_Data\async_array.bin"));
                task3 = Task.Run(() => _taskController.MatrixProcess(Utils.GenerateMatrix(6, 9)));

                // start and await tasks
                allTasks = Task.WhenAll(task1, task2, task3);
                await allTasks;
            }
            catch (Exception ex) {
                Console.WriteLine($"\n\nExceptions in tasks:\n");

                // iterate through the list of tasks to find exceptions
                foreach (var inx in allTasks.Exception.InnerExceptions) {
                    Console.WriteLine($"Inner exception: {inx.Message}");
                } // foreach
            } // try-catch
        } // Run

        // Running all processes in parallel (incorrect parameters to test exception handling)
        public async Task RunWithExceptions(string fileNameTask1 = @"..\..\App_Data\testxt") {
            Utils.ShowNavBarTask("  Running all processes in parallel (incorrect parameters to test exception handling)");
            // task management block
            Task task1 = null, task2 = null, task3 = null, allTasks = null;

            try {
                // parallel start of tasks
                task1 = Task.Run(() => _taskController.TextProcess(""));
                task2 = Task.Run(() => _taskController.ArrayProcess(new int[0], ""));
                task3 = Task.Run(() => _taskController.MatrixProcess(new double[0,0]));

                // start and await tasks
                allTasks = Task.WhenAll(task1, task2, task3);
                await allTasks;
            }
            catch (Exception ex) {
                Console.WriteLine($"\n\nExceptions in tasks:\n");

                // iterate through the list of tasks to find exceptions
                foreach (var inx in allTasks.Exception.InnerExceptions)
                {
                    Console.WriteLine($"Inner exception: {inx.Message}");
                } // foreach
            } // try-catch
        } // RunWithExceptions
        #endregion
    } // class Application
}
