using DataAccessLayer.Contracts;
using Microsoft.Extensions.DependencyInjection;
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
    public partial class RecipesForm : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IRecipeTypesRepository _recipeTypesRepository;

        public RecipesForm(IServiceProvider serviceProvider, IRecipeTypesRepository recipeTypesRepository)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _recipeTypesRepository = recipeTypesRepository;
            _recipeTypesRepository.OnError += (errorMessage) => MessageBox.Show(errorMessage);
        }

        private void RecipesForm_Load(object sender, EventArgs e)
        {
            RefreshRecipeTypes();
        }

        // BACKGROUND METHODS //
        private async void RefreshRecipeTypes()
        {
            TypeDrop.DataSource = await _recipeTypesRepository.GetRecipeTypes();
            TypeDrop.DisplayMember = "Name";
        }

        // UI METHODS //
        private void AddTypeBtn_Click(object sender, EventArgs e)
        {
            RecipeTypesForm form = _serviceProvider.GetRequiredService<RecipeTypesForm>();
            form.FormClosed += (sender, e) => RefreshRecipeTypes();
            form.ShowDialog();
        }
    }
}
