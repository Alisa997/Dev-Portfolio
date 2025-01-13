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
using Workers.Models;

namespace Workers.Views
{
    /// <summary>
    /// Interaction logic for WorkerWindow.xaml
    /// </summary>
    public partial class WorkerWindow : Window
    {
        // Data object
        private Worker _worker;
        public Worker Worker => _worker;
        
        public WorkerWindow() {
            InitializeComponent();

            // Programmatic access to window resources:
            _worker = (Worker)Resources["Worker"];   // Get a reference to the resource
        } // WorkerWindow

        public WorkerWindow(Worker worker) {
            InitializeComponent();

            Title = "Edit Worker";
            BtnOK.Content = "Save";

            // Programmatic access to window resources:
            _worker = (Worker)Resources["Worker"];   // Get a reference to the resource
            _worker.Age = worker.Age;
            _worker.Salary = worker.Salary;
            _worker.Patronymic = worker.Patronymic;
            _worker.Surname = worker.Surname;
            _worker.City = worker.City;
            _worker.Name = worker.Name;
        } // WorkerWindow

        #region Changing text color on button when mouse hovers over it
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

        // Text validation block, allows only numbers
        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e) =>
            e.Handled = !int.TryParse(e.Text, out int temp);

        private void BtnOK_Click(object sender, RoutedEventArgs e) => DialogResult = true;
    }
}
