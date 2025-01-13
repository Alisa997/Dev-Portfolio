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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Workers.Controllers;
using Workers.Models;
using Workers.Helpers;
using Microsoft.Win32;

namespace Workers.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private WorkersController _workersController;
        public MainWindow() {
            InitializeComponent();
            _workersController = new WorkersController();
            DgvWorkers.ItemsSource = _workersController.Workers;

            TbStatusBar.Text = $"Number of workers in the collection: {_workersController.Workers.Count}";
        } // MainWindow

        private void Exit_Click(object sender, RoutedEventArgs e) => Close();

        // Generate new data
        private void New_Command(object sender, RoutedEventArgs e) {
            _workersController.Initialize(Utils.GetRandom(12, 20));

            DgvWorkers.ItemsSource = null;
            DgvWorkers.ItemsSource = _workersController.Workers;

            TbStatusBar.Text = $"Number of workers in the collection: {_workersController.Workers.Count}";
        } // New_Command

        private void AddWorker_Command(object sender, RoutedEventArgs e) {
            WorkerWindow workerWindow = new WorkerWindow();

            if (workerWindow.ShowDialog() != true) return;

            _workersController.Add(workerWindow.Worker);

            DgvWorkers.ItemsSource = null;
            DgvWorkers.ItemsSource = _workersController.Workers;

            TbStatusBar.Text = $"Number of workers in the collection: {_workersController.Workers.Count}";
        } // AddWorker_Command

        private void EditWorker_Command(object sender, RoutedEventArgs e) {
            int index = DgvWorkers.SelectedIndex;
            if (index == -1) return;

            WorkerWindow workerWindow = new WorkerWindow(_workersController[index]);

            if (workerWindow.ShowDialog() != true) return;

            _workersController[index] = workerWindow.Worker;

            DgvWorkers.ItemsSource = null;
            DgvWorkers.ItemsSource = _workersController.Workers;
        } // EditWorker_Command

        private void DeleteWorker_Command(object sender, RoutedEventArgs e)  {
            int index = DgvWorkers.SelectedIndex;
            if (index == -1) return;

            _workersController.RemoveAt(index);

            DgvWorkers.ItemsSource = null;
            DgvWorkers.ItemsSource = _workersController.Workers;

            TbStatusBar.Text = $"Number of workers in the collection: {_workersController.Workers.Count}";
            DgvWorkers.SelectedIndex = index != _workersController.Workers.Count? index: index - 1;
        } // DeleteWorker_Command


        // Sorting the collection by employee's name
        private void OrderByName_Command(object sender, RoutedEventArgs e) {
            _workersController.OrderByName();

            DgvWorkers.ItemsSource = null;
            DgvWorkers.ItemsSource = _workersController.Workers;
        } // OrderByName_Command


        // Sorting the collection by employee's surname
        private void OrderBySurname_Command(object sender, RoutedEventArgs e) {
            _workersController.OrderBySurname();

            DgvWorkers.ItemsSource = null;
            DgvWorkers.ItemsSource = _workersController.Workers;
        } // OrderBySurname_Command


        // Sorting the collection by employee's patronymic
        private void OrderByPatronymic_Command(object sender, RoutedEventArgs e) {
            _workersController.OrderByPatronymic();

            DgvWorkers.ItemsSource = null;
            DgvWorkers.ItemsSource = _workersController.Workers;
        } // OrderByPatronymic_Command


        // Sorting the collection by descending employee salary
        private void OrderBySalaryDesc_Command(object sender, RoutedEventArgs e) {
            _workersController.OrderBySalaryDesc();

            DgvWorkers.ItemsSource = null;
            DgvWorkers.ItemsSource = _workersController.Workers;
        } // OrderBySalaryDesc_Command


        // Open a file
        private void Open_Command(object sender, RoutedEventArgs e)  {
            OpenFileDialog ofd = new OpenFileDialog {
                Multiselect = false,
                Title = "File for loading data",
                Filter = "JSON files (*.json)|*.json",
                FilterIndex = 0,
                InitialDirectory = AppDomain.CurrentDomain.BaseDirectory
            };

            if (ofd.ShowDialog() != true) return;
            _workersController.FileName = ofd.FileName;
            _workersController.DeserializeData();
            DgvWorkers.ItemsSource = null;
            DgvWorkers.ItemsSource = _workersController.Workers;
            TbStatusBar.Text = $"Number of workers: {_workersController.Workers.Count}";
        } // Open_Click


        // Save As
        private void SaveAs_Command(object sender, RoutedEventArgs e) {
            SaveFileDialog sfd = new SaveFileDialog {
                Title = "File for saving data",
                Filter = "JSON files (*.json)|*.json",
                FilterIndex = 0,
                InitialDirectory = AppDomain.CurrentDomain.BaseDirectory
            };

            if (sfd.ShowDialog() != true) return;
            _workersController.FileName = sfd.FileName;
            _workersController.SerializeData();
            TbStatusBar.Text = $"File saved! ";
        } // SaveAs_Command


        // Save
        private void Save_Command(object sender, RoutedEventArgs e) {
            _workersController.SerializeData();
            TbStatusBar.Text = $"File saved!";
        } // Save_Command

        // Drag and drop data file from Explorer
        private void Dgv_Drop(object sender, DragEventArgs e) {
            if (e.Data.GetFormats().Contains(DataFormats.FileDrop)) {
                var fileNames = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (fileNames != null) {
                    _workersController.FileName = fileNames[0];
                    _workersController.DeserializeData();
                    DgvWorkers.ItemsSource = null;
                    DgvWorkers.ItemsSource = _workersController.Workers;
                    TbStatusBar.Text = $"Number of workers: {_workersController.Workers.Count}";
                } // if
            } // if
        } // Dgv_Drop

    } // MainWindow
}
