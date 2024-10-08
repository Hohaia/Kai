﻿using DataAccessLayer.Contracts;
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
    public partial class FrozenMealTypesForm : Form
    {
        private readonly IFrozenMealTypesRepository _frozenMealTypesRepository;

        public FrozenMealTypesForm(IFrozenMealTypesRepository frozenMealTypesRepository)
        {
            InitializeComponent();
            _frozenMealTypesRepository = frozenMealTypesRepository;
            _frozenMealTypesRepository.OnError += (errorMessage) => MessageBox.Show(errorMessage);
        }
    }
}
