namespace Homework.Views
{
    partial class GoodsForm
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
            this.components = new System.ComponentModel.Container();
            this.LblItem = new System.Windows.Forms.Label();
            this.TbxItem = new System.Windows.Forms.TextBox();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnOk = new System.Windows.Forms.Button();
            this.ErpItem = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ErpItem)).BeginInit();
            this.SuspendLayout();
            // 
            // LblItem
            // 
            this.LblItem.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LblItem.Location = new System.Drawing.Point(23, 33);
            this.LblItem.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblItem.Name = "LblItem";
            this.LblItem.Size = new System.Drawing.Size(250, 32);
            this.LblItem.TabIndex = 0;
            this.LblItem.Text = "Product Name:"; // Translated "Наименование товара:" to "Product Name:"
            // 
            // TbxItem
            // 
            this.TbxItem.Location = new System.Drawing.Point(29, 68);
            this.TbxItem.Name = "TbxItem";
            this.TbxItem.Size = new System.Drawing.Size(378, 29);
            this.TbxItem.TabIndex = 1;
            this.TbxItem.Text = "protective case"; // Translated "чехол защитный" to "protective case"
            // 
            // BtnCancel
            // 
            this.BtnCancel.BackColor = System.Drawing.Color.DarkRed;
            this.BtnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnCancel.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BtnCancel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.BtnCancel.Location = new System.Drawing.Point(287, 118);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(120, 32);
            this.BtnCancel.TabIndex = 2;
            this.BtnCancel.Text = "Cancel"; // Translated "Отменить" to "Cancel"
            this.BtnCancel.UseVisualStyleBackColor = false;
            // 
            // BtnOk
            // 
            this.BtnOk.BackColor = System.Drawing.Color.Navy;
            this.BtnOk.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnOk.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BtnOk.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.BtnOk.Location = new System.Drawing.Point(147, 118);
            this.BtnOk.Name = "BtnOk";
            this.BtnOk.Size = new System.Drawing.Size(120, 32);
            this.BtnOk.TabIndex = 3;
            this.BtnOk.Text = "Add"; // Translated "Добавить" to "Add"
            this.BtnOk.UseVisualStyleBackColor = false;
            this.BtnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // ErpItem
            // 
            this.ErpItem.ContainerControl = this;
            // 
            // GoodsForm
            // 
            this.AcceptButton = this.BtnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnCancel;
            this.ClientSize = new System.Drawing.Size(444, 172);
            this.Controls.Add(this.BtnOk);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.TbxItem);
            this.Controls.Add(this.LblItem);
            this.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "GoodsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Product"; // Translated "Добавление товара" to "Add Product"
            ((System.ComponentModel.ISupportInitialize)(this.ErpItem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblItem;
        private System.Windows.Forms.TextBox TbxItem;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnOk;
        private System.Windows.Forms.ErrorProvider ErpItem;
    }
}