using DataAccessLayer.Contracts;
using DataAccessLayer.Repositories;
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
    public partial class FrozenMealsForm : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IFrozenMealsRepository _frozenMealsRepository;
        private readonly IFrozenMealTypesRepository _frozenMealTypesRepository;

        //private int _frozenMealToEditID;
        private bool _errorOccured = false;
        //private string _sortOrder = "ASC";
        //private int _lastClickedColumnIndex = 0;

        public FrozenMealsForm(IServiceProvider serviceProvider, IFrozenMealsRepository frozenMealsRepository, IFrozenMealTypesRepository frozenMealTypesRepository)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _frozenMealsRepository = frozenMealsRepository;
            _frozenMealTypesRepository = frozenMealTypesRepository;

            _frozenMealsRepository.OnError += OnErrorOccured;
            _frozenMealTypesRepository.OnError += OnErrorOccured;
        }

        private void FrozenMealsForm_Load(object sender, EventArgs e)
        {
            RefreshFrozenMealTypes();
        }

        // BACKGROUND METHODS //
        private void OnErrorOccured(string errorMessage)
        {
            _errorOccured = true;
            if (errorMessage == "That frozen meal already exists in the database!")
                SearchTxt.Text = NameTxt.Text;
            MessageBox.Show(errorMessage);
        }
        private async void RefreshFrozenMealTypes()
        {
            TypeDrop.DataSource = await _frozenMealTypesRepository.GetFrozenMealTypes();
            TypeDrop.DisplayMember = "Name";
            TypeDrop.SelectedItem = null;
        }
    }
}
