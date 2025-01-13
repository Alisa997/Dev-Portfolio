namespace Homework.Views
{
    partial class FormAbout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAbout));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.BtnOk = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.GrbAbout = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.AutoCompleteCustomSource.AddRange(new string[] {
            "Please develop a Windows Forms application to solve the task of executing " +
                "queries to the wholesale store sales accounting database as per the assignment of 24.11.2021.",
            "Develop and execute LINQ to SQL queries using extension methods.",
            "Display the query results in DataGridView in separate tabs. One query per tab.",
            "Use a menu, toolbar, and window for displaying information about the application and developer.",
            "If necessary, use auxiliary classes to display query results related to linked tables.",
            "",
            "Database \"Wholesale Store. Sales Accounting\"",
            "1. Parameterized query ",
            "\tSelects information about products from the PRODUCTS table where the unit of measurement is \"pcs\" " +
                "(pieces) and the purchase price is less than 200 rubles.",
            "",
            "2. Parameterized query ",
            "\tSelects information about products from the PRODUCTS table where the purchase price per unit is more than 500 rubles.",
            "",
            "3. Parameterized query\t",
            "\tSelects information about products from the PRODUCTS table with a given name (e.g., \"protective cover\"),",
            "\twhere the purchase price is less than 1800 rubles.",
            "",
            "4. Parameterized query\t",
            "\tSelects information about sellers from the SELLERS table with a given commission percentage value.",
            " ",
            "5. Parameterized query\t",
            "\tSelects information from the PRODUCTS, SELLERS, and SALES tables about all recorded sales events, ",
            "\tincluding the product name, purchase price, sale price, and sale date, where the sale price ",
            "\tfalls within certain specified limits.",
            "",
            "6. Query with calculated fields\t",
            "\tCalculates profit from sales for each sold product. Includes fields like Sale Date, Product Name, ",
            "\tPurchase Price, Sale Price, Quantity Sold, Profit. Sorted by Product Name.",
            "",
            "7. Final query ",
            "\tPerforms grouping by Product Name. For each product name, calculates the average purchase price ",
            "\tand the number of purchases.",
            "",
            "8. Final query\t",
            "\tPerforms grouping by Seller Code from the SALES table. For each seller, calculates the average ",
            "\tsale price per unit and the number of sales.",
            "",
            "Use LINQ to SQL queries to display all tables in your database."});
            this.textBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBox1.CausesValidation = false;
            this.textBox1.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.textBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.textBox1.Location = new System.Drawing.Point(38, 41);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(598, 404);
            this.textBox1.TabIndex = 0;
            this.textBox1.TabStop = false;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // BtnOk
            // 
            this.BtnOk.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.BtnOk.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnOk.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BtnOk.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.BtnOk.Location = new System.Drawing.Point(465, 460);
            this.BtnOk.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BtnOk.Name = "BtnOk";
            this.BtnOk.Size = new System.Drawing.Size(171, 34);
            this.BtnOk.TabIndex = 1;
            this.BtnOk.Text = "OK";
            this.BtnOk.UseVisualStyleBackColor = false;
            this.BtnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 471);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(420, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Dubina Alisa, group PD011, K.A. Shag, Donetsk, 2021";
            // 
            // GrbAbout
            // 
            this.GrbAbout.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GrbAbout.Location = new System.Drawing.Point(13, 13);
            this.GrbAbout.Name = "GrbAbout";
            this.GrbAbout.Size = new System.Drawing.Size(650, 488);
            this.GrbAbout.TabIndex = 3;
            this.GrbAbout.TabStop = false;
            this.GrbAbout.Text = "About the Program: ";
            // 
            // FormAbout
            // 
            this.AcceptButton = this.BtnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 513);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnOk);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.GrbAbout);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "FormAbout";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About the Program";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button BtnOk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox GrbAbout;
    }
}