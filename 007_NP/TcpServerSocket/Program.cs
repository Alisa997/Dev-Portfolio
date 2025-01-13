using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using TcpServerSocket.Controllers;
using TcpServerSocket.Models;

namespace TcpServerSocket
{
    internal class Program {

        // server's address and its port
        private static string _ip = "127.0.0.1";
        private static int _port = 8888;

        static void Main(string[] args) {
            Console.SetWindowSize(60, 20);
            Console.Title = "--- Server ---";
            Console.WriteLine("--- Server ---");

            TcpListener server = null;

            try {
                // create a TCP listener - server
                IPAddress localAddr = IPAddress.Parse(_ip);
                server = new TcpListener(localAddr, _port);

                // start the TCP listener - i.e., start the server
                server.Start();
                while (true) {
                    Console.WriteLine("\nThe server is waiting for connections...");

                    // blocking call, until a client connects
                    TcpClient client = server.AcceptTcpClient();

                    // create an object for working with the client
                    ServerObject serverObject = new ServerObject(client);
                    Console.WriteLine("New connection established");

                    // create a task - run it in a separate thread from the thread pool
                    Task clientThread = new Task(serverObject.Process);
                    clientThread.Start();
                } // while
            } catch (Exception ex) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n\n{ex.Message}\n");
                Console.ForegroundColor = ConsoleColor.Gray;
            } finally {
                server?.Stop();
                Console.WriteLine("Server shutdown completed!");
            } // try-catch-finally

        } // Main
    } // Program
}
