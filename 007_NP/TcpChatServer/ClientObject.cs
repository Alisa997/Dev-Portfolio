using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace TcpChatServer
{
    // Server's work with chat client - an object of this class is created 
    // for each connected client
    public class ClientObject
    {
        // unique client identifier, generated in the constructor
        protected internal string Id { get; private set; }
        protected internal NetworkStream Stream { get; private set; }

        private string    _userName;
        public string     UserName => _userName;
        private TcpClient _client;
        ServerObject     _server;


        // constructor performs dependency injection, receives
        // ready-made objects
        public ClientObject(TcpClient tcpClient, ServerObject serverObject) {
            // generate a unique Id for the client connection
            Id = Guid.NewGuid().ToString();

            _client = tcpClient;
            _server = serverObject;

            // add self to the collection of connections
            _server.AddConnection(this); 
        } // ClientObject

        // client's work in the chat
        protected internal void Process() {
            try {
                // first message from the client - the client's name in the chat
                Stream = _client.GetStream();
                _userName = GetMessage();

                // notify everyone about the user's entry into the chat, display the same message
                // in the server console
                string message = $"{_userName} has entered the chat";
                _server.BroadcastMessage(message, this.Id);
                Console.WriteLine(message);

                // send a list of users to the client...

                // loop part of working with the client
                // receive messages from clients
                while (true) {
                    try {
                        message = GetMessage();
                        if (string.IsNullOrEmpty(message)) throw new Exception();
                        switch (message.Split(' ')[0].ToLower()) {
                            // list of participants
                            case "@list":
                                StringBuilder sb = new StringBuilder("List of users:\n\t");
                                _server.UsersNames().ForEach(un => sb.Append(un+"\n\t"));
                                message = sb.ToString();
                                // echo message
                                _server.EchoMessage(message, this.Id);
                                break;
                            // rename
                            case "@rename":
                                string newName = message.Substring(message.IndexOf(' ') + 1);
                                if (string.IsNullOrWhiteSpace(newName)) goto default;
                                // echo message
                                message = $"Your name has been changed to \"{newName}\"";
                                _server.EchoMessage(message, this.Id);
                                // message to all participants
                                message = $"{_userName} changed their name to \"{newName}\"";
                                _server.BroadcastMessage(message, this.Id);
                                // change the name
                                _userName = newName;
                                break;
                            default:
                                message = $"{_userName}: {message}";
                                // send to all chat participants, except the current user
                                _server.BroadcastMessage(message, this.Id);
                                break;
                        } // switch

                        // echo message in the console
                        Console.WriteLine(message);

                    } catch {
                        // any problem with the client is treated as
                        // client disconnection
                        message = $"{_userName} has left the chat";
                        Console.WriteLine(message);
                        _server.BroadcastMessage(message, this.Id);
                        _server.RemoveConnection(this.Id);
                        break;
                    } // try-catch
                } // while
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                _server.RemoveConnection(this.Id);
            } // try-catch
        } // Process

        // receiving an incoming message and outputting it to the string
        private string GetMessage() {
            byte[] data = new byte[64];
            StringBuilder sbr = new StringBuilder();
            do {
                // Stream.Read() is a blocking call
                int bytes = Stream.Read(data, 0, data.Length);
                sbr.Append(Encoding.UTF8.GetString(data, 0, bytes));
            } while (Stream.DataAvailable);

            return sbr.ToString();
        } // GetMessage

        // closing the connection
        protected internal void Close() {
            Stream?.Close();
            _client?.Close();
        } // Close
    } // class ClientObject
}
