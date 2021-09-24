﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JTea_DPS926_Assignment1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ManagerPage : ContentPage
    {
        // a type of list that reacts to changes without having to reload
        public ObservableCollection<Product> products { get; private set; }

        public ManagerPage(ObservableCollection<Product> products)
        {
            InitializeComponent();
            this.products = products;
        }

        private void OnHistoryClicked(object sender, EventArgs e)
        {

        }

        private void OnRestockClicked(object sender, EventArgs e)
        {

        }

        private void OnAddNewProductClicked(object sender, EventArgs e)
        {

        }
    }
}