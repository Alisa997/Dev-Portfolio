using Homework.Helpers;
using Homework.Models;
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

namespace Publications.Views
{
    /// <summary>
    /// Interaction logic for PublicationWindow.xaml
    /// </summary>
    public partial class PublicationWindow : Window
    {
        Subscriber _subscriber;
        public Subscriber Subscriber => _subscriber;
        public PublicationWindow() {
            InitializeComponent();
            Title = "Add Subscription";
            BtnOK.Content = "Add";

            CmbDuration.ItemsSource = new string[] { "1", "3", "6", "12" };
            CmbDuration.SelectedIndex = 0;

            // Programmatic access to window resources:
            _subscriber = (Subscriber)Resources["Subscriber"];   // get reference to resource

            _subscriber.PubIndex = Utils.GetRandom(10000, 99999);
        } // PublicationWindow
        public PublicationWindow(Subscriber subscriber) {
            InitializeComponent();
            Title = "Edit Subscription";
            BtnOK.Content = "Save";

            CmbDuration.ItemsSource = new string[]{ "1", "3", "6", "12"};
            //CmbDuration.SelectedIndex = 0;

            // Programmatic access to window resources:
            _subscriber = (Subscriber)Resources["Subscriber"];   // get reference to resource

            _subscriber.FullName = subscriber.FullName ;
            _subscriber.Street = subscriber.Street;
            _subscriber.Building = subscriber.Building;
            _subscriber.Flat = subscriber.Flat;
            _subscriber.Title = subscriber.Title;
            _subscriber.PubType = subscriber.PubType;
            _subscriber.DateStart = subscriber.DateStart;
            _subscriber.Duration = subscriber.Duration;
            _subscriber.PubIndex = subscriber.PubIndex;
        } // PublicationWindow

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

        // Text validation block, only allows numbers
        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e) =>
            e.Handled = !int.TryParse(e.Text, out int temp);

        // Handle OK button click - close the window
        private void Add_Click(object sender, RoutedEventArgs e) => DialogResult = true;
    }
}
