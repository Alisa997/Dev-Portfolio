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

namespace Homework.Views
{
    /// <summary>
    /// Interaction logic for ChoiceWindow.xaml
    /// </summary>
    public partial class ChoiceWindow : Window
    {
        public string Choice { get; set; }
        public ChoiceWindow(List<string> list, string header) {
            InitializeComponent();
            CmbChoice.ItemsSource = list;
            CmbChoice.SelectedIndex = 0;
            TbxHeader.Text = header;
        } // ChoiceWindow

        #region Change button text color on mouse hover
        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            Button btn = e.OriginalSource as Button;
            btn.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
        } // Button_MouseEnter

        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            Button btn = e.OriginalSource as Button;
            btn.Foreground = new SolidColorBrush(Colors.White);
        } // Button_MouseLeave
        #endregion

        // Handle OK button click - close the window
        private void Ok_Click(object sender, RoutedEventArgs e) {
            this.DialogResult = true;
            Choice = CmbChoice.SelectedItem.ToString();
            Close();
        } // Ok_Click
    }
}
