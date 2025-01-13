using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TcpChatServer
{
    public class ServerObject
    {
        // server for listening to the network
        private static TcpListener _tcpListener;

        // chat participants' connections
        private List<ClientObject> _clients = new List<ClientObject>();

        // get the list of user names
        public List<string> UsersNames() => _clients.Select(u => u.UserName).ToList();

        protected internal void AddConnection(ClientObject clientObject) {
            _clients.Add(clientObject);
        } // AddConnection

        // remove closed client connection
        protected internal void RemoveConnection(string id) {
            // find the closed connection by Id
            ClientObject client = _clients.FirstOrDefault(c => c.Id == id);
            if (client != null) _clients.Remove(client);
        } // RemoveConnection

        // listener for incoming connections
        protected internal void Listen() {
            try {
                // start listening to the network
                _tcpListener = new TcpListener(IPAddress.Any, 8888);
                _tcpListener.Start();
                Console.WriteLine("Chat server started, waiting for connections...");

                while (true) {
                    // wait for the next client request
                    TcpClient tcpClient = _tcpListener.AcceptTcpClient();

                    ClientObject clientObject = new ClientObject(tcpClient, this);
                    Thread clientThread = new Thread(clientObject.Process);
                    clientThread.Start();
                } // while
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                Disconnect();
            } // try-catch
        } // Listen


        // disconnect all clients
        protected internal void Disconnect() {
            _tcpListener.Stop();
            _clients.ForEach(c => c.Close());
        } // Disconnect


        // broadcast message to all clients except the sender
        protected internal void BroadcastMessage(string message, string id) {
            byte[] data = Encoding.UTF8.GetBytes(message);
            _clients.ForEach(c => {
                if (c.Id != id) c.Stream.Write(data, 0, data.Length);
            });
        } // BroadcastMessage

        // send message to the sender
        protected internal void EchoMessage(string message, string id) {
            byte[] data = Encoding.UTF8.GetBytes(message);
            _clients.First(c => c.Id == id).Stream.Write(data, 0, data.Length);
        } // EchoMessage
    } // class ServerObject
}
