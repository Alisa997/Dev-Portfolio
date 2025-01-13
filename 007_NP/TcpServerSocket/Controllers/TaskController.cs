using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TcpServerSocket.Controllers
{
    static class TaskController {
        // path to the file storage folder
        public static string AppFilesFolder = @"..\..\App_Files\";

        // returns a string containing two floating point numbers and the product of these numbers
        public static string Mul(string s) {
            string[] words = s.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            if (words.Length != 3 ||
                !double.TryParse(words[1], out double a) ||
                !double.TryParse(words[2], out double b)) return "Command not found!";

            return $"{a:f5} * {b:f5} = {a * b:f5}";
        } // Mul

        // returns a string containing two floating point numbers and the sum of these numbers
        public static string Sum(string s) {
            string[] words = s.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            if (words.Length != 3 ||
                !double.TryParse(words[1], out double a) ||
                !double.TryParse(words[2], out double b)) return "Command not found!";

            return $"{a:f5} + {b:f5} = {a + b:f5}";
        } // Sum

        // returns three numbers a, b, c and calculates the roots of the quadratic equation,
        // if there are no real roots, return a, b, c, and the string "no roots"
        public static string Solve(string s) {
            string[] words = s.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            if (words.Length != 4 ||
                !double.TryParse(words[1], out double a) ||
                !double.TryParse(words[2], out double b) ||
                !double.TryParse(words[3], out double c)) return "Command not found!";

            string res = $"a = {a:f5}; b = {b:f5}; c = {c:f5}\n";

            if (a == 0) return res + "no solution";

            double d = b * b - 4 * a * c;
            if (d < 0) return res + "no roots";

            double root1 = (-b + Math.Sqrt(d)) / (2 * a);
            double root2 = (-b - Math.Sqrt(d)) / (2 * a);

            return res + $"x1 = {root1:f5}; x2 = {root2:f5};";
        } // Sum


        // renames a file in the App_Files folder on the server
        public static string Rename(string s) {
            string[] words = s.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            if (words.Length != 3) return "Command not found!";

            if(!File.Exists(AppFilesFolder + words[1])) return $"File \"{words[1]}\" not found";
            if(File.Exists(AppFilesFolder + words[2])) return $"File \"{words[2]}\" already exists";

            File.Move(AppFilesFolder + words[1], AppFilesFolder + words[2]);
            return $"{words[1]} --> {words[2]}";
        }// Rename

        // client selects a file and sends it to the server
        public static void Upload(NetworkStream networkStream, string fileName) {
            using (BinaryWriter bwr = new BinaryWriter(File.Create(@"..\..\App_Files\" + fileName))) {
                // reading the server's response
                var data = new byte[4096];
                do {
                    // reading the next portion of data
                    int bytes = networkStream.Read(data, 0, data.Length);

                    // writing to the file
                    bwr.Write(data, 0, bytes);
                } while (networkStream.DataAvailable);
            } // using BinaryWriter
        }// Upload


        // server sends the requested file from the App_Files folder to the client
        public static void Download(NetworkStream networkStream, string fileName) {
            if(!File.Exists(AppFilesFolder + fileName)) return;
            using (BinaryReader brd = new BinaryReader(File.OpenRead(AppFilesFolder + fileName))) {
                var data = new byte[4096];
                while (brd.BaseStream.Position < brd.BaseStream.Length) {
                    // reading the next portion of data
                    int bytes = brd.Read(data, 0, data.Length);

                    // writing to the network stream
                    networkStream.Write(data, 0, bytes);
                } // while
            } // using BinaryWriter
        }// Download

        // server deletes the file from the AppFiles folder and returns the string
        // “Ok”    - if such a file exists on the server or the string
        // "Not found" - if there is no such file on the server.
        public static string Delete(string s) {
            string[] words = s.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            if (words.Length != 2) return "Command not found!";

            if (!File.Exists(AppFilesFolder + words[1])) return $"Not found";

            File.Delete(AppFilesFolder + words[1]);
            return $"Ok";
        } // Delete
    } // TaskController
}
