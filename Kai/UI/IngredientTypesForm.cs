using DataAccessLayer.Contracts;
using DataAccessLayer.Repositories;
using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kai.UI
{
    public partial class IngredientTypesForm : Form
    {
        private readonly IIngredientTypesRepository _ingredientTypesRepository;

        public IngredientTypesForm(IIngredientTypesRepository ingredientTypesRepository)
        {
            InitializeComponent();
            _ingredientTypesRepository = ingredientTypesRepository;
            _ingredientTypesRepository.OnError += (errorMessage) => MessageBox.Show(errorMessage);
        }

        private void IngredientTypesForm_Load(object sender, EventArgs e)
        {
            RefreshIngredientTypesList();
        }

        // BACKGROUND METHODS //
        private async void RefreshIngredientTypesList()
        {
            TypesLbx.DataSource = await _ingredientTypesRepository.GetIngredientTypes();
            TypesLbx.DisplayMember = "Name";
        }

        private bool IsValid()
        {
            bool isValid = true;
            string message = "";

            if (string.IsNullOrEmpty(NewTypeTxt.Text))
            {
                isValid = false;
                message += "'Name' is required\n\n";
            }

            if (!isValid)
                MessageBox.Show(message, "Invalid input");

            return isValid;
        }

        private void ClearInputFields()
        {
            NewTypeTxt.Text = string.Empty;
        }

        // UI METHODS //
        private async void AddTypeBtn_Click(object sender, EventArgs e)
        {
            if (!IsValid())
                return;

            IngredientType ingredientType = new IngredientType(NewTypeTxt.Text);

            AddTypeBtn.Enabled = false;
            await _ingredientTypesRepository.AddIngredientType(ingredientType);
            AddTypeBtn.Enabled = true;

            ClearInputFields();
            RefreshIngredientTypesList();
        }

    }
}
