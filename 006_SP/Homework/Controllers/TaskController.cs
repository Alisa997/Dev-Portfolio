using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Homework.Controllers
{
    public class TaskController
    {
        #region Processing 1 - Text file processing
        // Change the case of characters in all words that start and end with vowels
        public void TextProcess(string fileName) {
            if (!File.Exists(fileName)) throw new Exception("Processing 1: File for processing not found!");
            
            // Read all lines of the file into a collection
            string[] lines = File.ReadAllLines(fileName, Encoding.UTF8);
            StringBuilder sb = new StringBuilder();

            // Output text to StringBuilder
            sb.Append(TextToStringBuilder(lines, "\n    Processing 1: Text for processing:\n\n"));

            lines = TextProcessAsync(lines).Result;

            // Save the modified collection to the file
            File.WriteAllLines(fileName, lines, Encoding.UTF8);

            // Output text to StringBuilder after processing
            sb.Append(TextToStringBuilder(lines, "\n    Processing 1: The case in words starting and ending with vowels has been changed:\n\n"));

            // Output text to console after processing
            Console.WriteLine(sb.ToString());
        } // TextProcess 

        // Output text to StringBuilder
        private StringBuilder TextToStringBuilder(string[] text, string title) {
            StringBuilder sb = new StringBuilder(title);

            foreach (var line in text) {
                sb.AppendLine($"\t{line}");
            } // foreach line
            return sb;
        } // Showtext

        // Process each line as per the task - change the case of characters in all words
        // starting and ending with vowels
        private async Task<string[]> TextProcessAsync(string[] lines) {
            await Task.Run(() => {
                for (int i = 0; i < lines.Length; ++i) {
                    // Skip empty lines
                    if (lines[i].Length == 0) continue;
                    // Get the array of words
                    string[] words = lines[i].Split(" \n\t\r".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    // Vowels
                    string vowels = "ауоыиэяюёеaeiou";

                    for (int j = 0; j < words.Length; ++j)
                        if (vowels.Contains(words[j][0].ToString().ToLower()) && vowels.Contains(words[j][words[j].Length - 1].ToString().ToLower()))
                            ChangeTheCase(ref words[j]);

                    // Reassemble the new line from the word array, space as separator
                    lines[i] = string.Join(" ", words);
                } // for i
            });
            return lines;
        } // TextProcessAsync
        
        // Change the case
        private void ChangeTheCase(ref string word) {
            StringBuilder temp = new StringBuilder();
            for (int i = 0; i < word.Length; ++i) 
                temp.Append(char.IsLower(word[i])? word[i].ToString().ToUpper(): word[i].ToString().ToLower());

           word = temp.ToString();
        } // ChangeTheCase
        #endregion


        #region Processing 2 - Integer array processing
        // In a one-dimensional array of integers, perform sorting with the rule "odd numbers first",
        // write the array to a binary file, and output the array from the file to the console
        // writing to and reading from the file will be asynchronous
        public void ArrayProcess(int[] array, string fileName) {
            if (!File.Exists(fileName)) throw new Exception("Processing 2: File for writing results not found!");
            if (array.Length == 0) throw new Exception("Processing 2: The array for sorting is empty!");

            StringBuilder sb = new StringBuilder("\n    Processing 2: Data array:\n\t");
            int i = 0;
            Array.ForEach(array, item => {
                sb.Append($"{item,8}");
                if (++i % 10 == 0) sb.Append("\n\t");
            });

            array = SortArrayAsync(array).Result;

            WriteToBinFiles(array, fileName);
            sb.Append(ShowBinaryFile(fileName, $"\n\n    Processing 2: The sorted array with the rule \"odd numbers first\", read from file \"{Path.GetFileName(fileName)}\":\n\t"));
            Console.WriteLine(sb.ToString());
        } // ArrayProcess

        // Write to binary file 
        private void WriteToBinFiles(int[] array, string fileName) {
            using (BinaryWriter bwr = new BinaryWriter(File.Create(fileName))) {
                foreach (var item in array) {
                    bwr.Write(item);
                } // foreach index
            } // using
        } // WriteToBinFiles

        // Read binary file of integers, output to StringBuilder
        private StringBuilder ShowBinaryFile(string fileName, string title) {
            List<int> list = new List<int>();

            using (BinaryReader brd = new BinaryReader(File.OpenRead(fileName))) {
                while (brd.BaseStream.Position < brd.BaseStream.Length)
                    list.Add(brd.ReadInt32());
            } // using

            // Output 
            StringBuilder sb = new StringBuilder(title);
            int i = 0;
            list.ForEach(item => {
                sb.Append($"{item,8}");
                if (++i % 10 == 0) sb.Append("\n\t");
            });
            sb.Append("\n\n");
            return sb;
        } // ShowBinaryFile

        public async Task<int[]> SortArrayAsync(int[] array) => await Task.Run(() => array.OrderBy(item => (item & 1) == 0).ToArray());
        #endregion


        #region Processing 3 - Floating-point matrix processing
        // In a two-dimensional array (rectangular array) of floating-point numbers
        // (size 9x6), swap columns so that they are ordered by increasing column sums
        public void MatrixProcess(double[,] matrix) {
            if (matrix.Length == 0) throw new Exception("Processing 3: Rectangular array for sorting is empty!");
            StringBuilder sb = new StringBuilder();
            sb.Append(ShowMatrix(matrix, "\n    Processing 3: Matrix before sorting:\n\t"));

            matrix = SortMatrixAsync(matrix).Result;

            sb.Append(ShowMatrix(matrix, "\n\n    Processing 3: Matrix after sorting columns by increasing column sums:\n\t"));
            Console.WriteLine(sb.ToString());
        } // MatrixProcess

        public async Task<double[,]> SortMatrixAsync(double[,] matrix) =>
            await Task.Run(() => ArrayToMatrix(MatrixToArray(matrix).OrderBy(x => x.Sum()).ToArray()));

        // Convert matrix to array of arrays
        // (rows of the array represent matrix columns for convenience in sorting)
        private double[][] MatrixToArray(double[,] matrix) {
            double[][] array = new double[matrix.GetLength(1)][];
            for (int i = 0; i < matrix.GetLength(1); i++) array[i] = new double[matrix.GetLength(0)];

            for (int i = 0; i < matrix.GetLength(0); i++) {
                for (int j = 0; j < matrix.GetLength(1); j++)
                    array[j][i] = matrix[i, j];
            } // for i 

            return array;
        }// MatrixToArray

        // Convert array of arrays to matrix
        // (rows of the array represent matrix columns for convenience in sorting)
        private double[,] ArrayToMatrix(double[][] array) {
            double[,] matrix = new double[array[0].Length, array.Length];

            for (int i = 0; i < array.Length; i++)
                for (int j = 0; j < array[0].Length; j++)
                    matrix[j, i] = array[i][j];

            return matrix;
        }// MatrixToArray

        // Output matrix to StringBuilder
        public StringBuilder ShowMatrix(double[,] matrix, string title) {
            StringBuilder sb = new StringBuilder(title);

            int n = matrix.GetLength(1);
            double[][] array = MatrixToArray(matrix);
            for (int i = 0; i < matrix.GetLength(0); i++) {
                for (int j = 0; j < n; j++) {
                    sb.Append($"{matrix[i, j], 10:f3} ");
                } // for j

                sb.Append($"\n\t");
            } // for i

            // Output "arrows"
            for (int i = 0; i < n; i++) sb.Append($"   {"|", 5}   ");
            sb.Append($"\n\t");
            for (int i = 0; i < n; i++) sb.Append($"   {"V", 5}   ");
            sb.Append($"\n\t");

            // Output column sums
            foreach (var item in array) sb.Append($"{item.Sum(), 10:f3} ");
            return sb;
        } // ShowMatrix

        #endregion
    } // TaskController
}
