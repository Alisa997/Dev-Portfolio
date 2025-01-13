using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework.Views
{
    public partial class GoodsForm : Form
    {
        private string _item;
        public string Item {
            get => _item;
            set {
                _item = value;
                TbxItem.Text = _item;
                BtnOk.Text = "Save"; // Changed "Coхранить" to "Save"
                Text = "Edit Product"; // Changed "Редактирование товара" to "Edit Product"
            } // set
        }
        public GoodsForm() {
            InitializeComponent();
        }

        private void BtnOk_Click(object sender, EventArgs e) {
            if (TbxItem.Text == "") { ErpItem.SetError(TbxItem, "Empty input field!"); return; } // Changed "Пустое поле ввода!" to "Empty input field!"
            _item = TbxItem.Text;
            DialogResult = DialogResult.OK;
            Close();
        } // BtnOk_Click
    }
}
