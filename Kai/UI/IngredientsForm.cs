using System;
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
        private int _ingredientToEditID;
        private bool _errorOccured = false;
        private string _sortOrder = "asc";
        private int _lastClickedColumnIndex = 0;

        public IngredientsForm(IIngredientsRepository ingredientsRepository)
        {
            InitializeComponent();
            _ingredientsRepository = ingredientsRepository;
            _ingredientsRepository.OnError += OnErrorOccured;
        }

        private void IngredientsForm_Load(object sender, EventArgs e)
        {
            RefreshGridData();
            CustomiseGridAppearance();

            AddToKeteBtn.Visible = true;
            EditIngredientBtn.Visible = false;
        }

        // BACKGROUND METHODS //
        private void OnErrorOccured(string errorMessage)
        {
            _errorOccured = true;
            if (errorMessage == "That ingredient already exists in the database!")
                SearchTxt.Text = NameTxt.Text;
            MessageBox.Show(errorMessage);
        }

        private void ClearInputFields()
        {
            NameTxt.Text = string.Empty;
            TypeDrop.SelectedItem = null;
            QuantityNum.Value = 1;
            UnitOfMeasurementDrop.SelectedItem = null;
            KcalPer100gNum.Value = 0;
            PricePer100gNum.Value = 0;

            AddToKeteBtn.Visible = true;
            EditIngredientBtn.Visible = false;
            _ingredientToEditID = 0;
        }

        private void ClearSearchField()
        {
            SearchTxt.Text = string.Empty;
        }

        private void ClearAllFields()
        {
            ClearInputFields();
            ClearSearchField();
        }

        private async void RefreshGridData(string? sortBy = "", string? sortOrder = "")
        {
            IngredientsGrid.DataSource = await _ingredientsRepository.GetIngredients(SearchTxt.Text, sortBy, sortOrder);
        }

        private void CustomiseGridAppearance()
        {
            IngredientsGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            IngredientsGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            IngredientsGrid.AutoGenerateColumns = false;

            DataGridViewColumn[] columns = new DataGridViewColumn[9];
            columns[0] = new DataGridViewTextBoxColumn() { DataPropertyName = "ID", Visible = false };
            columns[1] = new DataGridViewTextBoxColumn() { DataPropertyName = "Name", HeaderText = "Name" };
            columns[2] = new DataGridViewTextBoxColumn() { DataPropertyName = "Type", HeaderText = "Type" };
            columns[3] = new DataGridViewTextBoxColumn() { DataPropertyName = "Quantity", HeaderText = "Quantity" };
            columns[4] = new DataGridViewTextBoxColumn() { DataPropertyName = "UnitOfMeasurement", HeaderText = "Unit" };
            columns[5] = new DataGridViewTextBoxColumn() { DataPropertyName = "PricePer100g", HeaderText = "Price (100g)" };
            columns[6] = new DataGridViewTextBoxColumn() { DataPropertyName = "KcalPer100g", HeaderText = "Kcal (100g)" };
            columns[7] = new DataGridViewButtonColumn() { Text = "Delete", Name = "DeleteBtn", HeaderText = "", UseColumnTextForButtonValue = true };
            columns[8] = new DataGridViewButtonColumn() { Text = "Edit", Name = "EditBtn", HeaderText = "", UseColumnTextForButtonValue = true };

            IngredientsGrid.Columns.Clear();
            IngredientsGrid.Columns.AddRange(columns);
        }

        private bool IsValid()
        {
            bool isValid = true;
            string message = "";

            if (string.IsNullOrEmpty(NameTxt.Text))
            {
                isValid = false;
                message += "'Name' is required\n\n";
            }
            if (string.IsNullOrEmpty(TypeDrop.Text))
            {
                isValid = false;
                message += "'Type' is required\n\n";
            }
            if (QuantityNum.Value <= 0)
            {
                isValid = false;
                message += "'Quantity' is required\n\n";
            }
            if (string.IsNullOrEmpty(UnitOfMeasurementDrop.Text))
            {
                isValid = false;
                message += "'Unit of Measurement' is required\n\n";
            }
            if (KcalPer100gNum.Value < 0)
            {
                isValid = false;
                message += "'Kcal per 100g' cannot be less than 0\n\n";
            }
            if (PricePer100gNum.Value < 0)
            {
                isValid = false;
                message += "'Price' cannot be less than 0\n\n";
            }

            if (!isValid)
                MessageBox.Show(message, "Invalid input");

            return isValid;
        }

        private void FillFormForEdit(Ingredient clickedIngredient)
        {
            _ingredientToEditID = clickedIngredient.Id;

            NameTxt.Text = clickedIngredient.Name;
            TypeDrop.Text = clickedIngredient.Type;
            QuantityNum.Value = clickedIngredient.Quantity;
            UnitOfMeasurementDrop.Text = clickedIngredient.UnitOfMeasurement;
            KcalPer100gNum.Value = clickedIngredient.KcalPer100g;
            PricePer100gNum.Value = clickedIngredient.PricePer100g;

            AddToKeteBtn.Visible = false;
            EditIngredientBtn.Visible = true;
        }

        // UI METHODS //
        private async void AddToKeteBtn_Click(object sender, EventArgs e)
        {
            _errorOccured = false;
            if (!IsValid())
                return;

            Ingredient ingredient = new Ingredient(NameTxt.Text, TypeDrop.Text, QuantityNum.Value, UnitOfMeasurementDrop.Text, KcalPer100gNum.Value, PricePer100gNum.Value);

            AddToKeteBtn.Enabled = false;
            await _ingredientsRepository.AddIngredient(ingredient);
            AddToKeteBtn.Enabled = true;

            if (!_errorOccured)
                ClearAllFields();
            else ClearInputFields();
            RefreshGridData();
        }

        private async void EditIngredientBtn_Click(object sender, EventArgs e)
        {
            if (!IsValid())
                return;

            Ingredient ingredient = new Ingredient(NameTxt.Text, TypeDrop.Text, QuantityNum.Value, UnitOfMeasurementDrop.Text, KcalPer100gNum.Value, PricePer100gNum.Value, _ingredientToEditID);

            await _ingredientsRepository.EditIngredient(ingredient);
            ClearInputFields();
            RefreshGridData();
        }

        private void addTypeBtn_Click(object sender, EventArgs e) //TODO:
        {
            //TODO: implement button to add an ingredient 'type' to the drop ingredientsList
        }

        private void ClearAllFieldsBtn_Click(object sender, EventArgs e)
        {
            ClearAllFields();
        }

        private async void SearchTxt_TextChanged(object sender, EventArgs e)
        {
            int lengthBeforePause = SearchTxt.Text.Length;
            await Task.Delay(500);

            if (lengthBeforePause == SearchTxt.Text.Length)
                RefreshGridData();
        }

        private async void IngredientsGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && IngredientsGrid.CurrentCell is DataGridViewButtonCell)
            {
                Ingredient clickedIngredient = (Ingredient)IngredientsGrid.Rows[e.RowIndex].DataBoundItem;

                if (IngredientsGrid.CurrentCell.OwningColumn.Name == "DeleteBtn")
                {
                    await _ingredientsRepository.DeleteIngredient(clickedIngredient);
                    ClearAllFields();
                }
                else if (IngredientsGrid.CurrentCell.OwningColumn.Name == "EditBtn")
                {
                    FillFormForEdit(clickedIngredient);
                }
                RefreshGridData();
            }
        }

        private void IngredientsGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string sortBy = "";

            if (_lastClickedColumnIndex == e.ColumnIndex && _sortOrder == "asc")
                _sortOrder = "desc";
            else
                _sortOrder = "asc";

            if (e.ColumnIndex == 1)
                sortBy = "Name";
            if (e.ColumnIndex == 2)
                sortBy = "Type";
            if (e.ColumnIndex == 3)
                sortBy = "Quantity";
            if (e.ColumnIndex == 4)
                sortBy = "UnitOfMeasurement";
            if (e.ColumnIndex == 5)
                sortBy = "PricePer100g";
            if (e.ColumnIndex == 6)
                sortBy = "KcalPer100g";

            _lastClickedColumnIndex = e.ColumnIndex;
            RefreshGridData(sortBy, _sortOrder);
        }

    }
}
