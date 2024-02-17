﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccessLayer.Contracts;
using DataAccessLayer.Repositories;
using DomainModel.Models;

namespace Kai.UI
{
    public partial class IngredientsForm : Form
    {
        readonly IIngredientsRepository _ingredientsRepository;
        public IngredientsForm(IIngredientsRepository ingredientsRepository)
        {
            InitializeComponent();
            _ingredientsRepository = ingredientsRepository;
        }

        private void IngredientsForm_Load(object sender, EventArgs e)
        {
            RefreshGridData();
            CustomiseGridAppearance();
        }

        private void ClearAllFields()
        {
            NameTxt.Text = string.Empty;
            TypeDrop.Text = string.Empty;
            QuantityNum.Value = 1;
            UnitOfMeasurementDrop.Text = string.Empty;
            KcalPer100gNum.Value = 0;
            PricePer100gNum.Value = 0;
            SearchTxt.Text = string.Empty;
        }

        private async void RefreshGridData()
        {
            IngredientsGrid.DataSource = await _ingredientsRepository.GetIngredients(SearchTxt.Text);
        }

        private void CustomiseGridAppearance()
        {
            IngredientsGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            IngredientsGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            IngredientsGrid.AutoGenerateColumns = false;

            DataGridViewColumn[] columns = new DataGridViewColumn[7];
            columns[0] = new DataGridViewTextBoxColumn() { DataPropertyName = "ID", Visible = false };
            columns[1] = new DataGridViewTextBoxColumn() { DataPropertyName = "Name", HeaderText = "Name" };
            columns[2] = new DataGridViewTextBoxColumn() { DataPropertyName = "Type", HeaderText = "Type" };
            columns[3] = new DataGridViewTextBoxColumn() { DataPropertyName = "Quantity", HeaderText = "Quantity" };
            columns[4] = new DataGridViewTextBoxColumn() { DataPropertyName = "UnitOfMeasurement", HeaderText = "Unit" };
            columns[5] = new DataGridViewTextBoxColumn() { DataPropertyName = "PricePer100g", HeaderText = "Price (100g)" };
            columns[6] = new DataGridViewTextBoxColumn() { DataPropertyName = "KcalPer100g", HeaderText = "Kcal (100g)" };

            IngredientsGrid.Columns.Clear();
            IngredientsGrid.Columns.AddRange(columns);
        }

        private async void AddToKeteBtn_Click(object sender, EventArgs e)
        {
            Ingredient ingredient = new Ingredient(NameTxt.Text, TypeDrop.Text, QuantityNum.Value, UnitOfMeasurementDrop.Text, KcalPer100gNum.Value, PricePer100gNum.Value);

            AddToKeteBtn.Enabled = false;
            await _ingredientsRepository.AddIngredient(ingredient);
            AddToKeteBtn.Enabled = true;

            ClearAllFields();
            RefreshGridData();
        }

        private async void SearchTxt_TextChanged(object sender, EventArgs e)
        {
            int lengthBeforePause = SearchTxt.Text.Length;
            await Task.Delay(500);

            if (lengthBeforePause == SearchTxt.Text.Length)
                RefreshGridData();
        }

        private void ClearAllFieldsBtn_Click(object sender, EventArgs e)
        {
            ClearAllFields();
        }
    }
}
