using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Processes.Views
{
    public partial class MainForm : Form
    {
        // List of running processes
        private List<Process> _processes;

        private string _fileNameHistory;
        public MainForm() {
            InitializeComponent();
            _processes = new List<Process>();
            _fileNameHistory = "history.txt";
        } // MainForm

        private void BtnOpen_Click(object sender, EventArgs e) {
            OfdMain.Title = "Open file";
            OfdMain.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
            OfdMain.Filter = "EXE Files (*.exe)|*.exe";
            OfdMain.FilterIndex = 1;
            if (OfdMain.ShowDialog() == DialogResult.OK) {
                // Adding a process
                Process pr = new Process() {
                    StartInfo = new ProcessStartInfo(OfdMain.FileName)
                    { WindowStyle = ProcessWindowStyle.Normal }
                };
                pr.EnableRaisingEvents = true;
                pr.Exited += new EventHandler(Process_Exited);
                _processes.Add(pr);
                 
                // Starting the process
                _processes.Last().Start();

                // Writing to the history file
                using (StreamWriter sw = new StreamWriter(_fileNameHistory, true, Encoding.Default)) {
                    // Writing the line to the file
                    sw.WriteLine($"{OfdMain.FileName}\r\n{DateTime.Now}\r\n\r\n");
                } // using

                // Displaying the running processes in listView
                ShowProcesses();
            } // if
        } // BtnOpen_Click

        // Process completion - removing from the list of running processes
        private void Process_Exited(object sender, EventArgs e) {
            Process pr = sender as Process;

            _processes.Remove(pr);
            ShowProcesses();
        } // Process_Exited

        // Displaying the running processes in listView
        private void ShowProcesses() {
            LsvProcesses.Items.Clear();
            _processes.ForEach(p => {
                ListViewItem listViewItem = new ListViewItem($"{p.Id}", 0);

                listViewItem.SubItems.Add(p.ProcessName);
                listViewItem.SubItems.Add($"{p.VirtualMemorySize64 / 1024:n}k");
                listViewItem.SubItems.Add($"{p.BasePriority:n}");
                listViewItem.SubItems.Add($"{p.Threads.Count}");

                // Add the row to ListView
                LsvProcesses.Items.Add(listViewItem);
            });
        } // ShowProcesses

        // When closing the form, all processes are terminated
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) =>
            _processes.ForEach(p => { p.Kill(); });

        private void History_Command(object sender, EventArgs e) {
            HistoryForm journalForm = new HistoryForm(_fileNameHistory);
            journalForm.ShowDialog();
        }
    }
}
