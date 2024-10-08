﻿using DataAccessLayer.Contracts;
using DataAccessLayer.Repositories;
using DomainModel.Models;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Data.SqlClient;

namespace Kai.UI
{
    public partial class RecipesForm : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IRecipesRepository _recipesRepository;
        private readonly IRecipeTypesRepository _recipeTypesRepository;

        private string _sortOrder = "ASC";
        private int _lastClickedColumnIndex = 0;

        public RecipesForm(IServiceProvider serviceProvider, IRecipesRepository recipesRepository, IRecipeTypesRepository recipeTypesRepository)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _recipesRepository = recipesRepository;
            _recipeTypesRepository = recipeTypesRepository;

            _recipesRepository.OnError += (errorMessage) => MessageBox.Show(errorMessage);
            _recipeTypesRepository.OnError += (errorMessage) => MessageBox.Show(errorMessage);
        }

        private void RecipesForm_Load(object sender, EventArgs e)
        {
            RefreshGridData();
            CustomiseGridAppearance();
            RefreshRecipeTypes();
        }

        // BACKGROUND METHODS //
        private async void RefreshGridData(string? sortBy = "", string? sortOrder = "")
        {
            RecipesGrid.DataSource = await _recipesRepository.GetRecipes(sortBy, sortOrder);
        }

        private async void RefreshRecipeTypes()
        {
            TypeDrop.DataSource = await _recipeTypesRepository.GetRecipeTypes();
            TypeDrop.DisplayMember = "Name";
            TypeDrop.SelectedItem = null;
        }

        private void CustomiseGridAppearance()
        {
            RecipesGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            RecipesGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            RecipesGrid.AutoGenerateColumns = false;

            DataGridViewColumn[] columns = new DataGridViewColumn[6];
            columns[0] = new DataGridViewTextBoxColumn() { DataPropertyName = "Id", Visible = false };
            columns[1] = new DataGridViewTextBoxColumn() { DataPropertyName = "Name", HeaderText = "Name" };
            columns[2] = new DataGridViewTextBoxColumn() { DataPropertyName = "Type", HeaderText = "Type" };
            columns[3] = new DataGridViewTextBoxColumn() { DataPropertyName = "Description", HeaderText = "Description" };
            columns[4] = new DataGridViewButtonColumn() { Text = "Delete", Name = "DeleteBtn", HeaderText = "", UseColumnTextForButtonValue = true };
            columns[5] = new DataGridViewButtonColumn() { Text = "Edit", Name = "EditBtn", HeaderText = "", UseColumnTextForButtonValue = true };

            RecipesGrid.Columns.Clear();
            RecipesGrid.Columns.AddRange(columns);
        }

        private bool IsValid()
        {
            bool isValid = true;
            string message = "";

            if (string.IsNullOrEmpty(NameTxt.Text))
            {
                isValid = false;
                message += "'Name' is required.\n\n";
            }
            if (string.IsNullOrEmpty(TypeDrop.Text))
            {
                isValid = false;
                message += "'Type' is required.\n\n";
            }
            if (string.IsNullOrEmpty(DescriptionTxt.Text))
            {
                isValid = false;
                message += "'Description' is required.\n\n";
            }

            if (!isValid)
                MessageBox.Show(message, "Invalid input");

            return isValid;
        }

        private void ClearAllFields()
        {
            NameTxt.Text = string.Empty;
            TypeDrop.SelectedItem = null;
            DescriptionTxt.Text = string.Empty;
        }

        // UI METHODS //
        private async void AddRecipeBtn_Click(object sender, EventArgs e)
        {
            if (!IsValid())
                return;

            byte[] image = null;
            int recipeTypeId = ((RecipeType)TypeDrop.SelectedItem).Id;
            Recipe newRecipe = new Recipe(NameTxt.Text, DescriptionTxt.Text, image, recipeTypeId);

            AddRecipeBtn.Enabled = false;
            await _recipesRepository.AddRecipe(newRecipe);
            AddRecipeBtn.Enabled = true;

            RefreshGridData();
            ClearAllFields();
        }

        private void AddTypeBtn_Click(object sender, EventArgs e)
        {
            RecipeTypesForm form = _serviceProvider.GetRequiredService<RecipeTypesForm>();
            form.FormClosed += (sender, e) => RefreshRecipeTypes();
            form.ShowDialog();
        }

        private void ClearAllFieldsBtn_Click(object sender, EventArgs e)
        {
            ClearAllFields();
        }

        private void RecipesGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string sortBy = "";

            if (_lastClickedColumnIndex == e.ColumnIndex && _sortOrder == "ASC")
                _sortOrder = "DESC";
            else
                _sortOrder = "ASC";

            if (e.ColumnIndex == 1)
                sortBy = "Name";
            if (e.ColumnIndex == 2)
                sortBy = "Type";

            RefreshGridData(sortBy, _sortOrder);
            _lastClickedColumnIndex = e.ColumnIndex;
        }
    }
}
