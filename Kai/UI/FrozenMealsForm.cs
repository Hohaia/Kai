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
        private readonly IFrozenMealsTypesRepository _frozenMealsTypesRepository;

        //private int _frozenMealToEditID;
        private bool _errorOccured = false;
        //private string _sortOrder = "ASC";
        //private int _lastClickedColumnIndex = 0;

        public FrozenMealsForm(IServiceProvider serviceProvider, IFrozenMealsRepository frozenMealsRepository, IFrozenMealsTypesRepository frozenMealsTypesRepository)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _frozenMealsRepository = frozenMealsRepository;
            _frozenMealsTypesRepository = frozenMealsTypesRepository;

            _frozenMealsRepository.OnError += OnErrorOccured;
            _frozenMealsTypesRepository.OnError += OnErrorOccured;
        }

        private void FrozenMealsForm_Load(object sender, EventArgs e)
        {

        }

        // BACKGROUND METHODS //
        private void OnErrorOccured(string errorMessage)
        {
            _errorOccured = true;
            if (errorMessage == "That frozen meal already exists in the database!")
                SearchTxt.Text = NameTxt.Text;
            MessageBox.Show(errorMessage);
        }
    }
}
