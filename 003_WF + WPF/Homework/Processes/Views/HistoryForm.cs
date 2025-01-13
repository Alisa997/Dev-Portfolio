using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Processes.Views
{
    public partial class HistoryForm : Form
    {
        private string _fileName;
        public HistoryForm(string fileName) {
            InitializeComponent();
            _fileName = fileName;
            TxbJournal.Text = "\r\n\r\n\t\t\t\t\tNo data available";
        }

        private void BtnQuit_Click(object sender, EventArgs e) => Close();

        private void JournalForm_Load(object sender, EventArgs e) {
            TxbJournal.Text = "";
            if (!File.Exists(_fileName)) { 
                return;
            }
            TxbJournal.Text += File.ReadAllText(_fileName, Encoding.Default);
        } // JournalForm_Load

        private void BtnClear_Click(object sender, EventArgs e) {
            File.WriteAllText(_fileName, "");
            TxbJournal.Text = "\r\n\r\n\t\t\t\t\tNo data available";
        } // BtnClear_Click
    }
}
