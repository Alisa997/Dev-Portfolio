using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TcpClientSocket.Models
{
    public class ClientObject
    {
        // TCP server connection data
        private int _port;
        private string _server;

        // Path to the file storage folder
        private const string AppFilesFolder = @"..\..\App_Files\";
        
        public ClientObject(int port, string server)
        {
            _port = port;
            _server = server;
            // _textBlock = textBlock;
        }

        public string Send(string request)
        {
            string response;

            switch (request.Split(' ')[0].ToLower())
            {
                case "upload":
                    response = UploadClientTcp(request);
                    break;
                case "download":
                    response = DownloadClientTcp(request);
                    break;
                default:
                    response = ClientTcp(request);
                    break;
            } // switch
            
            return response;
        } // Send

        // One cycle of client operation: sending a request, receiving a response
        // from the server, and returning the server's response
        private string ClientTcp(string request)
        {
            TcpClient client = new TcpClient();
            NetworkStream networkStream = null;
            StringBuilder sbr = new StringBuilder();

            try
            {
                client.Connect(_server, _port);

                // Get the input/output stream to work with the network
                networkStream = client.GetStream();

                // Request to the server
                byte[] data = Encoding.UTF8.GetBytes(request);
                networkStream.Write(data, 0, data.Length);

                // Read the server's response in 64-byte blocks.
                // Assemble the response in the 'sbr' variable
                data = new byte[64];
                
                do
                {
                    int bytes = networkStream.Read(data, 0, data.Length);
                    sbr.Append(Encoding.UTF8.GetString(data, 0, bytes));
                } while (networkStream.DataAvailable);
            }
            finally
            {
                networkStream?.Close();
                client.Close();
            }

            return sbr.ToString();
        } // ClientTcp

        
        // One cycle of client operation - writing to a local binary output stream
        private string DownloadClientTcp(string request)
        {
            string res = "";
            // Connect to the server
            using (TcpClient client = new TcpClient())
            {
                client.Connect(_server, _port);

                // Get the input/output stream to work with the network
                NetworkStream networkStream = client.GetStream();

                // Request to the server - the request string 
                // in the format: download fileName
                byte[] data = Encoding.UTF8.GetBytes(request);
                networkStream.Write(data, 0, data.Length);

                // Binary output stream to file
                string fileName = request.Substring(request.IndexOf(' ') + 1);
                using (BinaryWriter bwr = new BinaryWriter(File.Create(AppFilesFolder + fileName)))
                {
                    // Reading the server's response
                    data = new byte[4096];
                    do
                    {
                        // Read the next portion of data
                        int bytes = networkStream.Read(data, 0, data.Length);

                        // Write to the file
                        bwr.Write(data, 0, bytes);
                    } while (networkStream.DataAvailable);
                    long t = bwr.BaseStream.Length;
                    if (t == 0) File.Delete(AppFilesFolder + fileName);
                    res = t > 0 ? $"Ok {t:n0} bytes" : "Not found";
                } // using BinaryWriter

                // Close the network input/output stream
                networkStream.Close();
            } // using client

            return res;
        } // DownloadClientTcp

        private string UploadClientTcp(string request)
        {
            string res = "";
            // Connect to the server
            using (TcpClient client = new TcpClient())
            {
                client.Connect(_server, _port);

                // Get the input/output stream to work with the network
                NetworkStream networkStream = client.GetStream();

                // Binary output stream to file
                string fileName = request.Substring(request.IndexOf(' ') + 1);
                if (!File.Exists(AppFilesFolder + fileName)) return "Not found";

                // Request to the server - the request string 
                // in the format: download fileName
                byte[] data = Encoding.UTF8.GetBytes(request);
                networkStream.Write(data, 0, data.Length);
                Thread.Sleep(10);
                
                using (BinaryReader brd = new BinaryReader(File.OpenRead(AppFilesFolder + fileName)))
                {
                    data = new byte[4096];
                    while (brd.BaseStream.Position < brd.BaseStream.Length)
                    {
                        // Read the next portion of data
                        int bytes = brd.Read(data, 0, data.Length);

                        // Write to the network stream
                        networkStream.Write(data, 0, bytes);
                    } // while
                    res = $"Length {brd.BaseStream.Length} bytes\nOk";
                } // using BinaryWriter
                // Close the network input/output stream
                networkStream.Close();
            } // using client

            return res;
        } // UploadClientTcp

    } // ClientObject
}
