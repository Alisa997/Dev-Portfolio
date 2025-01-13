using Homework.Controllers;
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
using Homework.Models;
using Homework.Helpers;
using Publications.Views;
using Microsoft.Win32;
using System.IO;

namespace Homework.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // controller
        private PublicationsController _publicationsController;

        public MainWindow() : this(new PublicationsController()) { }
        public MainWindow(PublicationsController publicationsController)
        {
            InitializeComponent();

            _publicationsController = publicationsController;

            BindCollection(_publicationsController.Subscribers, DgvPublications);
            TbStatusBar.Text = $"Number of subscriptions: {_publicationsController.Subscribers.Count}";
        } // RepairShopWindow

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

        // bind collection to DataGrid
        private void BindCollection(List<Subscriber> list, DataGrid dataGrid)
        {
            // stop current binding
            dataGrid.ItemsSource = null;

            // set new binding
            dataGrid.ItemsSource = list;
        } // BindCollection
        private void Exit_Click(object sender, RoutedEventArgs e) => Close();

        // Open the window with application and developer information
        private void About_Click(object sender, RoutedEventArgs e)
        {
            AboutWindow aboutWindow = new AboutWindow();
            aboutWindow.ShowDialog();
        } // About_Click

        // Generate new data
        private void New_Command(object sender, RoutedEventArgs e)
        {
            TbcPublications.SelectedItem = MainTab;

            _publicationsController.Initialize(Utils.GetRandom(12, 15));

            BindCollection(_publicationsController.Subscribers, DgvPublications);
            BindCollection(new List<Subscriber>(), DgvSorted);
            BindCollection(new List<Subscriber>(), DgvSelected);
            TbStatusBar.Text = $"Number of subscriptions: {_publicationsController.Subscribers.Count}";
        } // New_Command

        // Sort collection by publication index
        private void OrderByIndex_Command(object sender, RoutedEventArgs e)
        {
            BindCollection(_publicationsController.OrderByIndex(), DgvSorted);

            TbcPublications.SelectedItem = SortedTab;
        } // OrderByIndex_Command


        // Sort collection by address
        private void OrderByAddress_Command(object sender, RoutedEventArgs e)
        {
            BindCollection(_publicationsController.OrderByAddress(), DgvSorted);

            TbcPublications.SelectedItem = SortedTab;
        } // OrderByAddress_Command


        // Sort collection by descending subscription duration
        private void OrderByDurationDesc_Command(object sender, RoutedEventArgs e)
        {
            BindCollection(_publicationsController.OrderByDurationDesc(), DgvSorted);

            TbcPublications.SelectedItem = SortedTab;
        } // OrderByDurationDesc_Command

        // Sort collection by publication type
        private void OrderByPubType_Command(object sender, RoutedEventArgs e)
        {
            BindCollection(_publicationsController.OrderByPubType(), DgvSorted);

            TbcPublications.SelectedItem = SortedTab;
        } // OrderByPubType_Command

        // Filter collection by selected publication type
        private void SelectPubType_Command(object sender, RoutedEventArgs e)
        {
            List<string> pubTypes = _publicationsController.GetPubTypes();
            pubTypes.Sort();
            // Create a window for selection, pass list to window
            ChoiceWindow ChoiceWindow = new ChoiceWindow(pubTypes, "Select publication type:");

            if (ChoiceWindow.ShowDialog() == false) return;

            BindCollection(_publicationsController.SelectWherePubType(ChoiceWindow.Choice), DgvSelected);
            TbcPublications.SelectedItem = SelectedTab;
        } // SelectPubType_Command

        // Filter collection by selected subscription duration
        private void SelectDuration_Command(object sender, RoutedEventArgs e)
        {
            // Get list of durations from collection
            List<string> durations = new List<string>(new string[] { "1", "3", "6", "12" });

            // Create a window for selection, pass list to window
            ChoiceWindow ChoiceWindow = new ChoiceWindow(durations, "Select subscription duration:");

            if (ChoiceWindow.ShowDialog() == false) return;

            BindCollection(_publicationsController.SelectWhereDuration(int.Parse(ChoiceWindow.Choice)), DgvSelected);
            TbcPublications.SelectedItem = SelectedTab;
        } // SelectDuration_Command

        // Filter collection by selected subscriber's full name
        private void SelectFullNames_Command(object sender, RoutedEventArgs e)
        {
            // Get list of full names from collection
            List<string> fullNames = _publicationsController.GetFullNames();
            fullNames.Sort();
            // Create a window for selection, pass list to window
            ChoiceWindow ChoiceWindow = new ChoiceWindow(fullNames, "Select subscriber for filtering:");

            if (ChoiceWindow.ShowDialog() == false) return;

            BindCollection(_publicationsController.SelectWhereFullName(ChoiceWindow.Choice), DgvSelected);
            TbcPublications.SelectedItem = SelectedTab;
        } // SelectFullNames_Command

        // Filter collection by selected publication title
        private void SelectTitle_Command(object sender, RoutedEventArgs e)
        {
            // Get list of titles from collection
            List<string> titles = _publicationsController.GetTitles();
            titles.Sort();
            // Create a window for selection, pass list to window
            ChoiceWindow ChoiceWindow = new ChoiceWindow(titles, "Select publication title:");

            if (ChoiceWindow.ShowDialog() == false) return;

            BindCollection(_publicationsController.SelectWhereTitle(ChoiceWindow.Choice), DgvSelected);
            TbcPublications.SelectedItem = SelectedTab;
        } // SelectTitle_Command

        // Delete subscription
        private void DeletePublication_Command(object sender, RoutedEventArgs e)
        {
            TbcPublications.SelectedItem = MainTab;
            int index = DgvPublications.SelectedIndex;
            if (index == -1) return;

            _publicationsController.RemoveAt(index);

            BindCollection(_publicationsController.Subscribers, DgvPublications);
            TbStatusBar.Text = $"Number of subscriptions: {_publicationsController.Subscribers.Count}";
            DgvPublications.SelectedIndex = index != _publicationsController.Subscribers.Count ? index : index - 1;
        } // DeletePublication_Command

        // Add subscription
        private void AddTelevision_Command(object sender, RoutedEventArgs e)
        {
            TbcPublications.SelectedItem = MainTab;
            // Create a window for entering subscription parameters
            PublicationWindow publicationWindow = new PublicationWindow();

            // Show the input window modally, exit silently if the form does not close with OK
            if (publicationWindow.ShowDialog() == false) return;

            // Add subscriber to the collection
            _publicationsController.Add(publicationWindow.Subscriber);

            BindCollection(_publicationsController.Subscribers, DgvPublications);
            TbStatusBar.Text = $"Number of subscriptions: {_publicationsController.Subscribers.Count}";
            DgvPublications.SelectedIndex = _publicationsController.Subscribers.Count - 1;
        } // AddTelevision_Command

        // Edit subscription
        private void EditPublication_Command(object sender, RoutedEventArgs e)
        {
            TbcPublications.SelectedItem = MainTab;
            int index = DgvPublications.SelectedIndex;
            if (index == -1) return;
            // Create a window for entering subscription parameters
            PublicationWindow publicationWindow = new PublicationWindow(_publicationsController.Subscribers[index]);

            // Show the input window modally, exit silently if the form does not close with OK
            if (publicationWindow.ShowDialog() == false) return;

            // Edit subscription
            _publicationsController.Subscribers[index] = publicationWindow.Subscriber;

            BindCollection(_publicationsController.Subscribers, DgvPublications);
            DgvPublications.SelectedIndex = index;
            _publicationsController.SerializeData();
        } // EditTelevision_Command

        // Open file
        private void Open_Command(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Multiselect = false,
                Title = "Select data file for loading",
                Filter = "JSON Files (*.json)|*.json",
                FilterIndex = 0,
                InitialDirectory = AppDomain.CurrentDomain.BaseDirectory
            };

            if (ofd.ShowDialog() != true) return;
            _publicationsController.FileName = ofd.FileName;
            _publicationsController.DeserializeData();
            BindCollection(_publicationsController.Subscribers, DgvPublications);
            TbStatusBar.Text = $"Number of subscriptions: {_publicationsController.Subscribers.Count}";
        } // Open_Click

        // Save as
        private void SaveAs_Command(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                Title = "Select data file to save",
                Filter = "JSON Files (*.json)|*.json",
                FilterIndex = 0,
                InitialDirectory = AppDomain.CurrentDomain.BaseDirectory
            };

            if (sfd.ShowDialog() != true) return;
            _publicationsController.FileName = sfd.FileName;
            _publicationsController.SerializeData();
            TbStatusBar.Text = $"File saved! ";
        } // SaveAs_Command

        // Save
        private void Save_Command(object sender, RoutedEventArgs e)
        {
            _publicationsController.SerializeData();
            TbStatusBar.Text = $"File saved!";
        } // Save_Command

        // Data loading by dragging the file from File Explorer
        private void Dgv_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetFormats().Contains(DataFormats.FileDrop))
            {
                var fileNames = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (fileNames != null)
                {
                    _publicationsController.FileName = fileNames[0];
                    _publicationsController.DeserializeData();
                    BindCollection(_publicationsController.Subscribers, DgvPublications);
                    TbStatusBar.Text = $"Number of subscriptions: {_publicationsController.Subscribers.Count}";
                } // if
            } // if
        } // Dgv_Drop
    }
}
