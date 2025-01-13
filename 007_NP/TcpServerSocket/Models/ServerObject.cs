using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TcpServerSocket.Controllers;

namespace TcpServerSocket.Models
{
    internal class ServerObject {
        // for communication with the client
        public TcpClient Client;
        // for sending emails
        private SmtpClient _smtpClient;
        // sender's address
        private MailAddress _from;
        // recipient's address
        private MailAddress _to;

        public ServerObject(TcpClient client) {
            Client = client;

            _from = new MailAddress("step.programmer@gmail.com", "step async");
            //_to = new MailAddress("lychagin@itstep.academy");
            _to = new MailAddress("step.programmer@gmail.com");

            _smtpClient = new SmtpClient("smtp.gmail.com", 587);
            // login and password for sending emails
            _smtpClient.Credentials = new NetworkCredential("step.programmer@gmail.com", "sP1234568");
            _smtpClient.EnableSsl = true;
        } // ServerObject

        // One cycle of interaction with the client
        public void Process() {
            NetworkStream networkStream = null;

            try {
                // get the network stream and read the client's request
                networkStream = Client.GetStream();
                byte[]        data = new byte[64];
                StringBuilder sbr  = new StringBuilder();

                do {
                    int bytes = networkStream.Read(data, 0, data.Length);
                    sbr.Append(Encoding.UTF8.GetString(data, 0, bytes));
                } while (networkStream.DataAvailable);

                string request = sbr.ToString();
                Console.WriteLine($"{DateTime.Now:T}: {request}");
                string answer = "";
                string fileName;

                switch (request.Split(' ')[0].ToLower()) {
                    // date – returns the date and time on the server
                    case "date":
                        answer = $"Date and time on the server: {DateTime.Now:f}";
                        break;
                    // host_name– returns the name of the computer on which the server is running
                    case "host_name":
                        answer = $"Computer name: {Environment.MachineName}";
                        break;
                    // pwd– returns the full path of the App_Files folder of the application
                    case "pwd":
                        answer = Path.GetFullPath(@"..\..\App_Files");
                        break;
                    // list– client receives a list of file names stored on the server,
                    // in the App_Files folder, file names are separated by "\r\n"
                    case "list":
                        string[] files = Directory.GetFiles(@"..\..\App_Files").Select(x => Path.GetFileName(x)).ToArray();
                        answer = files.Length > 0 ? $"Contents of the folder \"App_Files\":\n\t{string.Join("\n\t", files)}" : "The folder is empty";
                        break;
                    // mul number1 number2 – server returns a string,
                    // containing two floating point numbers and their product
                    case "mul":
                        answer = TaskController.Mul(request);
                        break;
                    // sum number1 number2 – server returns a string,
                    // containing two floating point numbers and their sum
                    case "sum":
                        answer = TaskController.Sum(request);
                        break;
                    // solve a b c – server returns three numbers a, b, c, and the calculated roots
                    // of the quadratic equation, if no real roots, returns
                    // a, b, c and the string "no roots"
                    case "solve":
                        answer = TaskController.Solve(request);
                        break;
                    // rename oldName newName - renaming a file in the App_Files folder on the server
                    case "rename":
                        answer = TaskController.Rename(request);
                        break;
                    // upload fileName – upload file to the server
                    case "upload":
                        fileName = request.Substring(request.IndexOf(' ') + 1);
                        TaskController.Upload(networkStream, fileName);
                        SendMailWithFile(request, fileName);
                        break;
                    // download fileName – download file from the server
                    case "download":
                        fileName = request.Substring(request.IndexOf(' ') + 1);
                        TaskController.Download(networkStream, fileName);
                        SendMailWithFile(request, fileName);
                        break;
                    // delete fileName – server deletes the file from the App_Files folder
                    case "delete":
                        answer = TaskController.Delete(request);
                        SendMail(request, answer);
                        break;
                    // shutdown – shuts down the server
                    case "shutdown":
                        answer = "Server shutdown!";
                        SendMail(request, answer);
                        break;
                    default:
                        answer = "Command not found!";
                        break;
                } // switch

                // write the server's response to the client's network stream
                data = Encoding.UTF8.GetBytes(answer);
                networkStream.Write(data, 0, data.Length);

                // shutdown – shuts down the server
                if(request.Contains("shutdown")) Environment.Exit(0);
            } catch (Exception ex) {
                Console.WriteLine($"TcpServer error: {ex.Message}");
            } finally {
                networkStream?.Close();
                Client.Close();
            } // try-catch-finally
        } // Process

        // sending an email
        private void SendMail(string request, string answer) {
            // creating the message (email)
            MailMessage mailMessage = new MailMessage(_from, _to) {
                // subject of the email
                Subject = "TcpServerSocket",

                // body of the email
                Body = $"<html><head><meta charset='UTF-8'/></head><body><h1>Hello.</h1><p>The command \"{request}\" was received by the server.<br>Server's response: {answer}</p><h3>Goodbye!</h3></body></html>",

                // the body of the email contains HTML markup
                IsBodyHtml = true
            };

            _smtpClient.Send(mailMessage);
        } // SendMail

        // sending an email with attachment
        private void SendMailWithFile(string request, string fileName) {
            // creating the message (email)
            MailMessage mailMessage = new MailMessage(_from, _to) {
                // subject of the email
                Subject = "TcpServerSocket",

                // body of the email
                Body = $"<html><head><meta charset='UTF-8'/></head><body><h1>Hello.</h1><p>The command \"{request}\" was received by the server.</p><h3>Goodbye!</h3></body></html>",

                // the body of the email contains HTML markup
                IsBodyHtml = true
            };
            // Adding an attachment
            if(File.Exists(TaskController.AppFilesFolder + fileName)) 
                mailMessage.Attachments.Add(new Attachment(TaskController.AppFilesFolder + fileName));

            _smtpClient.Send(mailMessage);
        } // SendMail
    } // ServerObject
}
