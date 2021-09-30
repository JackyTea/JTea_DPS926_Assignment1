using System;
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

        // collection of products available to buy that watches for changes
        public ObservableCollection<Product> products { get; private set; }

        // collection of historical records to be updated when a product is bought
        public ObservableCollection<History> history { get; private set; }

        // constructor for main page (0 params)
        public MainPage()
        {
            InitializeComponent();
            InitializeProducts();
            InitializeHistory();
            BindingContext = this;
        }

        // helper function to put in products for sale
        private void InitializeProducts()
        {
            products = new ObservableCollection<Product>();
            products.Add(new Product("Pants", 20, 7.99));
            products.Add(new Product("Shoes", 50, 45.99));
            products.Add(new Product("Hats", 10, 3.99));
            products.Add(new Product("T-shirt", 10, 5.99));
            products.Add(new Product("Dress", 24, 100.99));
        }

        // helper function to set history collection
        private void InitializeHistory()
        {
            history = new ObservableCollection<History>();
        }

        // helper function to clear calculator fields
        private void ClearCalculatorInputs()
        {
            ProductName.Text = "Type";
            QuantityField.Text = "Quantity";
            Total.Text = "Total";
        }

        // helper function to clear calculator
        private void ClearCalculator(object sender, EventArgs e)
        {
            ClearCalculatorInputs();
        }

        // handle user selecting a product in the listview
        private void OnProductSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Product p = e.SelectedItem as Product;
            ProductName.Text = p.name;

            if (!QuantityField.Text.Equals("Quantity") && int.Parse(QuantityField.Text) != 0)
            {
                Total.Text = (p.price * int.Parse(QuantityField.Text)).ToString();
            }
        }

        // handle user tapping a product in the listview
        private void OnProductTapped(object sender, ItemTappedEventArgs e)
        {
            Product p = e.Item as Product;
            ProductName.Text = p.name;

            if (!QuantityField.Text.Equals("Quantity") && int.Parse(QuantityField.Text) != 0)
            {
                Total.Text = (p.price * int.Parse(QuantityField.Text)).ToString();
            }
        }

        // handle user clicking on a button on the calculator number grid
        private void OnNumberClicked(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            if (QuantityField.Text.Equals("Quantity"))
            {
                QuantityField.Text = "0";
            }

            if (int.Parse(QuantityField.Text) != 0)
            {
                QuantityField.Text += btn.Text;
            }
            else
            {
                QuantityField.Text = btn.Text;
            }

            foreach (Product p in products)
            {
                if (p.name.Equals(ProductName.Text))
                {
                    Total.Text = (int.Parse(QuantityField.Text) * p.price).ToString();
                }
            }
        }

        // handle a product being bought 
        private void OnBuyClicked(object sender, EventArgs e)
        {
            int currentQuantity = 0;

            if (!QuantityField.Text.Equals("Quantity"))
            {
                currentQuantity = int.Parse(QuantityField.Text);
            }

            int indexOfProduct = 0;

            foreach (Product p in products)
            {
                if (p.name.Equals(ProductName.Text))
                {
                    break;
                }
                indexOfProduct++;
            }

            if (indexOfProduct >= 0 && indexOfProduct < products.Count)
            {
                if (products[indexOfProduct].quantity >= currentQuantity)
                {
                    products[indexOfProduct].quantity -= currentQuantity;

                    history.Add(new History(
                        products[indexOfProduct].name,
                        currentQuantity,
                        products[indexOfProduct].price * currentQuantity,
                        DateTime.Now
                    ));

                    ClearCalculatorInputs();
                }
                else
                {
                    ProductName.Text = products[indexOfProduct].name + " are out of stock! Try again!";
                    QuantityField.Text = "Quantity";
                    Total.Text = "Total";
                }
            }

        }

        // navigates to manager panel 
        private async void OnManagerClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ManagerPage(products, history));
        }
    }
}