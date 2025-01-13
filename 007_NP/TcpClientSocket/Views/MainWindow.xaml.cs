using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
using TcpClientSocket.Models;
using TcpClientSocket.Infrastructure;

namespace TcpClientSocket.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ClientObject _clientObject;
        public MainWindow() : this("127.0.0.1", 8888) { }
        public MainWindow(string ip, int port) {
            InitializeComponent();
            _clientObject = new ClientObject(port, ip);
        } // MainWindow

        private void Exit_Command(object sender, RoutedEventArgs e) => Close();

        #region Change the button text color when mouse moves over the button
        private void Button_MouseEnter(object sender, MouseEventArgs e) {
            Button btn = e.OriginalSource as Button;
            btn.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
        } // Button_MouseEnter

        private void Button_MouseLeave(object sender, MouseEventArgs e) {
            Button btn = e.OriginalSource as Button;
            btn.Foreground = new SolidColorBrush(Colors.White);
        } // Button_MouseLeave
        #endregion

        // Client operations with TCP socket
        private void Send_Command(object sender, RoutedEventArgs e) {
            if (TbxSendData.Text.Length == 0) return;

            switch (TbxSendData.Text.ToLower()) {
                case "clear":
                    TbxReceivedData.Text = "";
                    break;
                case "exit":
                    Close();
                    break;
                default:
                    TbxReceivedData.Text += $"{_clientObject.Send(TbxSendData.Text)}\n";
                    break;
            } // switch
            
            TbxSendData.Text = "";
        } // TcpClient

        // Command for date
        private void Date_Command(object sender, RoutedEventArgs e) {
            TbxSendData.Text = $"date";
            Send_Command(sender, e);
        } // Date_Command

        // Command for host_name
        private void HostName_Command(object sender, RoutedEventArgs e) {
            TbxSendData.Text = "host_name";
            Send_Command(sender, e);
        } // HostName_Command

        // Command for pwd
        private void Pwd_Command(object sender, RoutedEventArgs e) {
            TbxSendData.Text = "pwd";
            Send_Command(sender, e);
        } // Pwd_Command

        // Command for list
        private void List_Command(object sender, RoutedEventArgs e) {
            TbxSendData.Text = "list";
            Send_Command(sender, e);
        } // List_Command

        // Command for mul
        private void Mul_Command(object sender, RoutedEventArgs e) {
            TbxSendData.Text = $"mul {Utils.GetRandom(-10d, 10d)} {Utils.GetRandom(-10d, 10d)}";
            Send_Command(sender, e);
        } // List_Command

        // Command for sum
        private void Sum_Command(object sender, RoutedEventArgs e) {
            TbxSendData.Text = $"sum {Utils.GetRandom(-10d, 10d)} {Utils.GetRandom(-10d, 10d)}";
            Send_Command(sender, e);
        } // Sum_Command

        // Command for solve
        private void Solve_Command(object sender, RoutedEventArgs e) {
            TbxSendData.Text = $"solve {Utils.GetRandom(-10d, 10d)} {Utils.GetRandom(-10d, 10d)} {Utils.GetRandom(-10d, 10d)}";
            Send_Command(sender, e);
        } // Solve_Command

        // Command for shutdown
        private void Shutdown_Command(object sender, RoutedEventArgs e) {
            TbxSendData.Text = $"shutdown";
            Send_Command(sender, e);
        } // Shutdown_Command

        // Commands for rename, upload, download
        private void Button_Command(object sender, RoutedEventArgs e) {
            TbxSendData.Text = $"{(sender as Button).Tag} ";
            Keyboard.Focus(TbxSendData);
            TbxSendData.SelectionStart = TbxSendData.Text.Length;
        } // Button_Click

        // Commands for rename, upload, download (menu items)
        private void MenuItem_Click(object sender, RoutedEventArgs e) {
            TbxSendData.Text = $"{(sender as MenuItem).Header} ";
            Keyboard.Focus(TbxSendData);
            TbxSendData.SelectionStart = TbxSendData.Text.Length;
        }// MenuItem_Click
    }
}
