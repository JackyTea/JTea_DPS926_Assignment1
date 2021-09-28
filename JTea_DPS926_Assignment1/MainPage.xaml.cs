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
        // a type of list that reacts to changes without having to reload
        public ObservableCollection<Product> products { get; private set; }

        public ObservableCollection<History> history { get; private set; }

        public MainPage()
        {
            // initial setup
            InitializeComponent();
            InitializeProducts();
            InitializeHistory();

            // set the binding context to current page
            BindingContext = this;
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

        private void InitializeHistory()
        {
            // initialize history
            history = new ObservableCollection<History>();
        }

        private void ClearCalculatorInputs()
        {
            ProductName.Text = "Type";
            QuantityField.Text = "Quantity";
            Total.Text = "Total";
        }

        private void ClearCalculator(object sender, EventArgs e)
        {
            //clear fields
            ClearCalculatorInputs();
        }

        private void OnProductSelected(object sender, SelectedItemChangedEventArgs e)
        {
            // get current product
            Product p = e.SelectedItem as Product;
            ProductName.Text = p.name;

            // calculate and display total price
            if (!QuantityField.Text.Equals("Quantity") && int.Parse(QuantityField.Text) != 0)
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
            if (!QuantityField.Text.Equals("Quantity") && int.Parse(QuantityField.Text) != 0)
            {
                Total.Text = (p.price * int.Parse(QuantityField.Text)).ToString();
            }
        }

        private void OnNumberClicked(object sender, EventArgs e)
        {
            // change quantity amount
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

            // calculate total with quantity
            foreach (Product p in products)
            {
                if (p.name.Equals(ProductName.Text))
                {
                    Total.Text = (int.Parse(QuantityField.Text) * p.price).ToString();
                }
            }
        }

        private void OnBuyClicked(object sender, EventArgs e)
        {
            // find product to buy
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

            // check stock of products
            if (indexOfProduct >= 0 && indexOfProduct < products.Count)
            {
                if (products[indexOfProduct].quantity >= currentQuantity)
                {
                    // update product in array
                    /*
                    Product updatedProduct = new Product(
                        products[indexOfProduct].name,
                        products[indexOfProduct].quantity - currentQuantity,
                        products[indexOfProduct].price
                    );
                    */
                    products[indexOfProduct].quantity -= currentQuantity;

                    history.Add(new History(
                        products[indexOfProduct].name,
                        currentQuantity,
                        products[indexOfProduct].price * currentQuantity,
                        DateTime.Now
                    ));

                    // clear fields
                    ClearCalculatorInputs();
                }
                else
                {
                    // show error message
                    ProductName.Text = products[indexOfProduct].name + " are out of stock! Try again!";
                    QuantityField.Text = "Quantity";
                    Total.Text = "Total";
                }
            }

        }

        private async void OnManagerClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ManagerPage(products, history));
        }
    }
}