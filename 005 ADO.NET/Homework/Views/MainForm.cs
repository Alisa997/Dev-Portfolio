using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Homework.Controllers;
using Homework.Helpers;
using Homework.Models;

namespace Homework.Views
{
    public partial class MainForm : Form
    {
        QueriesController _queriesController;
        public MainForm() {
            InitializeComponent();
             _queriesController = new QueriesController();

            LblMain.Text = "Goods Table:"; // Translated "Таблица товаров:" to "Goods Table:"
            DgvGoods.Visible = true;
            DgvGoods.DataSource = _queriesController.GetGoods();
        } // MainForm

        // Persons table
        private void ShowPersons_Command(object sender, EventArgs e) {
            LblMain.Text = "Persons Table:"; // Translated "Таблица персон:" to "Persons Table:"
            DgvGoods.Visible = DgvUnits.Visible = DgvSellers.Visible = DgvPurchases.Visible = DgvSales.Visible = false;
            DgvPersons.Visible = true;
            DgvPersons.DataSource = _queriesController.GetPersons();
            TbcMain.SelectedTab = TbpMain;
        } // ShowPersons_Command

        // Goods table
        private void ShowGoods_Command(object sender, EventArgs e) {
            LblMain.Text = "Goods Table:"; // Translated "Таблица товаров:" to "Goods Table:"
            DgvPersons.Visible = DgvUnits.Visible = DgvSellers.Visible = DgvPurchases.Visible = DgvSales.Visible = false;
            DgvGoods.Visible = true;
            DgvGoods.DataSource = _queriesController.GetGoods();
            TbcMain.SelectedTab = TbpMain;
        } // ShowGoods_Command

        // Units of measurement table
        private void ShowUnits_Command(object sender, EventArgs e) {
            LblMain.Text = "Units of Measurement Table:"; // Translated "Таблица единиц измерения:" to "Units of Measurement Table:"
            DgvPersons.Visible = DgvGoods.Visible = DgvSellers.Visible = DgvPurchases.Visible = DgvSales.Visible = false;
            DgvUnits.Visible = true;
            DgvUnits.DataSource = _queriesController.GetUnits();
            TbcMain.SelectedTab = TbpMain;
        } // ShowUnits_Command

        // Sellers table
        private void ShowSellers_Command(object sender, EventArgs e) {
            LblMain.Text = "Sellers Table:"; // Translated "Таблица продавцов:" to "Sellers Table:"
            DgvPersons.Visible = DgvGoods.Visible = DgvUnits.Visible = DgvPurchases.Visible = DgvSales.Visible = false;
            DgvSellers.Visible = true;
            DgvSellers.DataSource = _queriesController.GetSellers();
            TbcMain.SelectedTab = TbpMain;
        } // ShowSellers_Command

        // Purchases table
        private void ShowPurchases_Command(object sender, EventArgs e) {
            LblMain.Text = "Purchases Table:"; // Translated "Таблица закупок:" to "Purchases Table:"
            DgvPersons.Visible = DgvGoods.Visible = DgvUnits.Visible = DgvSellers.Visible = DgvSales.Visible = false;
            DgvPurchases.Visible = true;
            DgvPurchases.DataSource = _queriesController.GetPurchases();
            TbcMain.SelectedTab = TbpMain;
        } // ShowPurchases_Command

        // Sales table
        private void ShowSales_Command(object sender, EventArgs e) {
            LblMain.Text = "Sales Table:"; // Translated "Таблица продаж:" to "Sales Table:"
            DgvPersons.Visible = DgvGoods.Visible = DgvUnits.Visible = DgvSellers.Visible = DgvPurchases.Visible = false;
            DgvSales.Visible = true;
            DgvSales.DataSource = _queriesController.GetSales();
            TbcMain.SelectedTab = TbpMain;
        } // ShowSales_Command

        private void Query01_Command(object sender, EventArgs e) {
            DateTime from = new DateTime(2021, 11, 1);
            DateTime to = new DateTime(2021, 11, 30);
            LblQuery01.Text = $"Number and amounts of sales by sellers from {from:d} to {to:d}"; // Translated to English

            DgvQuery01.DataSource = _queriesController.Query01(from, to);
            TbcMain.SelectedTab = TbpQuery01;
        } // Query01_Command

        private void Query02_Command(object sender, EventArgs e) {
            DgvQuery02.DataSource = _queriesController.Query02();
            TbcMain.SelectedTab = TbpQuery02;
        } // Query02_Command

        private void Exit_Command(object sender, EventArgs e) => Application.Exit();

        private void About_Command(object sender, EventArgs e)  {
            FormAbout formAbout = new FormAbout();
            formAbout.ShowDialog();
        } // About_Command

        private void AddGoods_Command(object sender, EventArgs e) {
            GoodsForm goodsForm = new GoodsForm();
            if(goodsForm.ShowDialog() != DialogResult.OK) return;

            _queriesController.AddGoods(goodsForm.Item);
            ShowGoods_Command(sender, e);
            DgvGoods.Rows[DgvGoods.RowCount - 1].Selected = true;
        } // AddGoods_Command

        private void EditGoods_Command(object sender, EventArgs e) {
            if(DgvGoods.SelectedRows[0].Index < 0) return;
            int index = DgvGoods.SelectedRows[0].Index;

            GoodsForm goodsForm = new GoodsForm() { Item = _queriesController.GetGoods()[index].Item};
            if (goodsForm.ShowDialog() != DialogResult.OK) return;

            _queriesController.EditGoods(index, goodsForm.Item);
            ShowGoods_Command(sender, e);
        } // EditGoods_Command
    }
}