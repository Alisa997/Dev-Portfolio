using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TcpChatClient.Views
{
    /// <summary>
    /// Interaction logic for StartWindow.xaml
    /// </summary>
    public partial class StartWindow : Window
    {
        public StartWindow()
        {
            InitializeComponent();
        }

        #region Change button text color when mouse hovers over it
        private void Button_MouseEnter(object sender, MouseEventArgs e) {
            Button btn = e.OriginalSource as Button;
            btn.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
        } // Button_MouseEnter

        private void Button_MouseLeave(object sender, MouseEventArgs e) {
            Button btn = e.OriginalSource as Button;
            btn.Foreground = new SolidColorBrush(Colors.White);
        } // Button_MouseLeave
        #endregion

        // Text validation block, only allows digits
        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e) => 
            e.Handled = !int.TryParse(e.Text, out int temp);

        private void Exit_Command(object sender, RoutedEventArgs e) => Close();

        private void Ok_Command(object sender, RoutedEventArgs e) {
            if(string.IsNullOrWhiteSpace(TbxUserName.Text)) return;

            new MainWindow(TbxUserName.Text).Show();
            Close();
        } // Ok_Command
    }
}
