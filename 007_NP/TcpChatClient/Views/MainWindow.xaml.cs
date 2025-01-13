using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace TcpChatClient.Views
{
    /// <summary>
    /// Logic for interaction in MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static string _userName;
        private static string host = "127.0.0.1";
        private static int port = 8888;
        private static TcpClient _client;
        private static NetworkStream _stream;
        public MainWindow(string userName) {
            InitializeComponent();
            _userName = userName;
            _client = new TcpClient();

            Start();
        } // MainWindow

        private void Start() {
            try { 
                // connecting to the server
                _client.Connect(host, port);
                _stream = _client.GetStream();

                // sending the first message to the server - sending the client name
                byte[] data = Encoding.UTF8.GetBytes(_userName);
                _stream.Write(data, 0, data.Length);

                // starting to receive messages from the server in a separate thread
                Thread receiveThread = new Thread(ReceiveMessage);
                receiveThread.Start();

                AddToTextBlock(TbxReceivedData, $"Welcome, {_userName}\n");
            } // try
            catch (Exception ex) {
                OutputToTextBlock(TbStatusBar, ex.Message);
            } // catch
        } // Start

        private void Exit_Command(object sender, RoutedEventArgs e) => Close();

        #region Change text color on button hover
        private void Button_MouseEnter(object sender, MouseEventArgs e) {
            Button btn = e.OriginalSource as Button;
            btn.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
        } // Button_MouseEnter

        private void Button_MouseLeave(object sender, MouseEventArgs e) {
            Button btn = e.OriginalSource as Button;
            btn.Foreground = new SolidColorBrush(Colors.White);
        } // Button_MouseLeave
        #endregion


        // receiving messages - performed in a separate thread
        private void ReceiveMessage() {
            try {
                while (true) {
                    // receiving the next message and displaying it in the console
                    byte[] data = new byte[64];
                    StringBuilder sbr = new StringBuilder();
                    do {
                        int bytes = _stream.Read(data, 0, data.Length);
                        sbr.Append(Encoding.UTF8.GetString(data, 0, bytes));
                    } while (_stream.DataAvailable);

                    // !! additional server message processing can be implemented here !!

                    // simply displaying the message
                    AddToTextBlock(TbxReceivedData, sbr.ToString() + "\n");
                } // while
            } catch {
                OutputToTextBlock(TbStatusBar, "Connection interrupted!");
            } // try-catch
        } // ReceiveMessage


        // sending a message
        private void Send_Command(object sender, RoutedEventArgs e) {
            // enter the message, do not send an empty string to the server
            string message = TbxSendData.Text;
            if (string.IsNullOrEmpty(message)) return;
            TbxSendData.Text = "";
            
            AddToTextBlock(TbxReceivedData, $"{message.PadLeft(43) + " <<"}\n");
            switch (message.ToLower()) {
                case "@clear":
                    OutputToTextBox(TbxReceivedData, "");
                    break;
                case "@exit":
                    Close();
                    break;
                default:
                    // create and send the message as a byte array
                    byte[] data = Encoding.UTF8.GetBytes(message);
                    _stream.Write(data, 0, data.Length);
                    break;
            } // switch
        } // TcpClient

        // disconnecting and closing the application
        private static void Disconnect() {
            _stream?.Close();
            _client?.Close();
            Environment.Exit(1);
        } // Disconnect

        // output text to TextBlock
        private void OutputToTextBlock(TextBlock textBlock, string text) =>
            Dispatcher.BeginInvoke(
                DispatcherPriority.Normal,
                (ThreadStart)(() => textBlock.Text = text));

        // output text to TextBox
        private void OutputToTextBox(TextBox textBox, string text) =>
            Dispatcher.BeginInvoke(
                DispatcherPriority.Normal,
                (ThreadStart)(() => textBox.Text = text));

        // add text to TextBox
        private void AddToTextBlock(TextBox textBox, string text) =>
            Dispatcher.BeginInvoke(
                DispatcherPriority.Normal,
                (ThreadStart)(() => textBox.Text += text));

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) =>
            Disconnect();

        // sending commands via buttons
        private void BtnCommand(object sender, RoutedEventArgs e) {
            TbxSendData.Text = $"{(sender as Button).Tag}";
            Send_Command(sender, e);
        } // BtnCommand

        private void Rename_Command(object sender, RoutedEventArgs e){
            TbxSendData.Text = $"{(sender as Button).Tag} ";
            Keyboard.Focus(TbxSendData);
            TbxSendData.SelectionStart = TbxSendData.Text.Length;
        } // Rename_Command

        // Auto-scroll TextBox
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e) {
            TextBox tb = sender as TextBox;
            tb.ScrollToEnd();
        } // TextBox_TextChanged
    }
}
