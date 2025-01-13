namespace Processes.Views
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LsvProcesses = new System.Windows.Forms.ListView();
            this.ClhId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ClhProcessName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ClhVirtualMemory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ClhPriority = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.BtnOpen = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.OfdMain = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // LsvProcesses
            // 
            this.LsvProcesses.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ClhId,
            this.ClhProcessName,
            this.ClhVirtualMemory,
            this.ClhPriority,
            this.columnHeader1});
            this.LsvProcesses.HideSelection = false;
            this.LsvProcesses.Location = new System.Drawing.Point(21, 29);
            this.LsvProcesses.Name = "LsvProcesses";
            this.LsvProcesses.Size = new System.Drawing.Size(685, 328);
            this.LsvProcesses.TabIndex = 0;
            this.LsvProcesses.UseCompatibleStateImageBehavior = false;
            this.LsvProcesses.View = System.Windows.Forms.View.Details;
            // 
            // ClhId
            // 
            this.ClhId.Text = "ID";
            // 
            // ClhProcessName
            // 
            this.ClhProcessName.Text = "Process";
            this.ClhProcessName.Width = 150;
            // 
            // ClhVirtualMemory
            // 
            this.ClhVirtualMemory.Text = "Virtual Memory";
            this.ClhVirtualMemory.Width = 220;
            // 
            // ClhPriority
            // 
            this.ClhPriority.Text = "Priority";
            this.ClhPriority.Width = 100;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Number of Threads";
            this.columnHeader1.Width = 140;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(21, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(409, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Running processes: ";
            // 
            // BtnOpen
            // 
            this.BtnOpen.BackColor = System.Drawing.Color.SteelBlue;
            this.BtnOpen.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnOpen.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BtnOpen.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BtnOpen.Location = new System.Drawing.Point(21, 374);
            this.BtnOpen.Name = "BtnOpen";
            this.BtnOpen.Size = new System.Drawing.Size(312, 44);
            this.BtnOpen.TabIndex = 2;
            this.BtnOpen.Text = "Start Process";
            this.BtnOpen.UseVisualStyleBackColor = false;
            this.BtnOpen.Click += new System.EventHandler(this.BtnOpen_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkRed;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(394, 374);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(312, 44);
            this.button1.TabIndex = 3;
            this.button1.Text = "History of Started Processes";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.History_Command);
            // 
            // OfdMain
            // 
            this.OfdMain.FileName = "openFileDialog1";
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(728, 444);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.BtnOpen);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LsvProcesses);
            this.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Task for 31.01.2022";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView LsvProcesses;
        private System.Windows.Forms.ColumnHeader ClhProcessName;
        private System.Windows.Forms.ColumnHeader ClhVirtualMemory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnOpen;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog OfdMain;
        private System.Windows.Forms.ColumnHeader ClhId;
        private System.Windows.Forms.ColumnHeader ClhPriority;
        private System.Windows.Forms.ColumnHeader columnHeader1;
    }
}
