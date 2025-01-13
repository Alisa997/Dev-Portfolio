using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TcpChatServer
{
    class Program
    {
        private static ServerObject _server;
        private static Thread _listenThread;

        static void Main(string[] args) {
            Console.Title = "21.03.2021: Chat Server using TCP Protocol";
            Console.SetWindowSize(42, 35);

            try {
                _server = new ServerObject();
                _listenThread = new Thread(_server.Listen);
                _listenThread.Start();

                Console.ReadKey(true);
            } // try

            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            } // catch

            finally {
                _server.Disconnect();
            }
        } // Main
    } // class Program
}
