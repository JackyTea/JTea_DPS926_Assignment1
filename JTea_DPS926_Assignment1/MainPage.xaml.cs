﻿using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace JTea_DPS926_Assignment1
{
    public partial class MainPage : ContentPage
    {
        // a type of list that reacts to changes without having to reload
        public ObservableCollection<Product> products { get; private set; }

        public MainPage()
        {
            // initial setup
            InitializeComponent();
            InitializeProducts();

            // set the binding context to current page
            BindingContext = this;

            // set quantity label 
            QuantityField.Text = "0";
        }

        private void InitializeProducts()
        {
            // initialize products available to store
            products = new ObservableCollection<Product>();
            products.Add(new Product("Pants", 20, 7.99));
            products.Add(new Product("Shoes", 50, 45.99));
            products.Add(new Product("Hats", 10, 3.99));
            products.Add(new Product("T-shirt", 10, 5.99));
            products.Add(new Product("Dress", 24, 100.99));
        }

        private void OnProductSelected(object sender, SelectedItemChangedEventArgs e)
        {
            // get current product
            Product p = e.SelectedItem as Product;
            ProductName.Text = p.name;

            // calculate and display total price
            if (int.Parse(QuantityField.Text) != 0)
            {
                Total.Text = (p.price * int.Parse(QuantityField.Text)).ToString();
            }
        }

        private void OnProductTapped(object sender, ItemTappedEventArgs e)
        {
            // get current product
            Product p = e.Item as Product;
            ProductName.Text = p.name;

            // calculate and display total price
            if (int.Parse(QuantityField.Text) != 0)
            {
                Total.Text = (p.price * int.Parse(QuantityField.Text)).ToString();
            }
        }

        private void OnNumberClicked(object sender, EventArgs e)
        {
            // change quantity amount
            Button btn = sender as Button;
            if (int.Parse(QuantityField.Text) != 0)
            {
                QuantityField.Text += btn.Text;
            }
            else
            {
                QuantityField.Text = btn.Text;
            }

            // calculate total with quantity
            foreach (Product p in products)
            {
                if (p.name.Equals(ProductName.Text))
                {
                    Total.Text = (int.Parse(QuantityField.Text) * p.price).ToString();
                }
            }
        }

        private void Buy(object sender, EventArgs e)
        {
            // find product to buy
            int currentQuantity = int.Parse(QuantityField.Text);
            int indexOfProduct = 0;
            foreach (Product p in products)
            {
                if (p.name.Equals(ProductName.Text))
                {
                    break;
                }
                indexOfProduct++;
            }

            // check stock of products
            if (indexOfProduct >= 0 && indexOfProduct < products.Count)
            {
                if (products[indexOfProduct].quantity >= currentQuantity)
                {
                    Product updatedProduct = new Product(
                        products[indexOfProduct].name,
                        products[indexOfProduct].quantity - currentQuantity,
                        products[indexOfProduct].price
                    );
                    products[indexOfProduct] = updatedProduct;

                    QuantityField.Text = "0";
                    Total.Text = "Total";
                }
                else
                {
                    ProductName.Text = products[indexOfProduct].name + " are out of stock! Try again!";
                }
            }

        }

        private void ClearCalculator(object sender, EventArgs e)
        {
            // reset fields
            ProductName.Text = "Select an item";
            QuantityField.Text = "0";
            Total.Text = "Total";
        }
    }
}