namespace Processes.Views
{
    partial class HistoryForm
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
            this.BtnClear = new System.Windows.Forms.Button();
            this.BtnQuit = new System.Windows.Forms.Button();
            this.TxbJournal = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // BtnClear
            // 
            this.BtnClear.BackColor = System.Drawing.Color.SteelBlue;
            this.BtnClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnClear.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnClear.Location = new System.Drawing.Point(383, 373);
            this.BtnClear.Name = "BtnClear";
            this.BtnClear.Size = new System.Drawing.Size(149, 29);
            this.BtnClear.TabIndex = 6;
            this.BtnClear.Text = "Clear";
            this.BtnClear.UseVisualStyleBackColor = false;
            this.BtnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // BtnQuit
            // 
            this.BtnQuit.BackColor = System.Drawing.Color.DarkRed;
            this.BtnQuit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnQuit.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnQuit.Location = new System.Drawing.Point(541, 373);
            this.BtnQuit.Name = "BtnQuit";
            this.BtnQuit.Size = new System.Drawing.Size(149, 29);
            this.BtnQuit.TabIndex = 7;
            this.BtnQuit.Text = "Exit";
            this.BtnQuit.UseVisualStyleBackColor = false;
            this.BtnQuit.Click += new System.EventHandler(this.BtnQuit_Click);
            // 
            // TxbJournal
            // 
            this.TxbJournal.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TxbJournal.Location = new System.Drawing.Point(12, 22);
            this.TxbJournal.Multiline = true;
            this.TxbJournal.Name = "TxbJournal";
            this.TxbJournal.ReadOnly = true;
            this.TxbJournal.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxbJournal.Size = new System.Drawing.Size(678, 336);
            this.TxbJournal.TabIndex = 8;
            // 
            // JournalForm
            // 
            this.AcceptButton = this.BtnQuit;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(704, 414);
            this.Controls.Add(this.TxbJournal);
            this.Controls.Add(this.BtnQuit);
            this.Controls.Add(this.BtnClear);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "JournalForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "History";
            this.Load += new System.EventHandler(this.JournalForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnClear;
        private System.Windows.Forms.Button BtnQuit;
        private System.Windows.Forms.TextBox TxbJournal;
    }
}
