using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JTea_DPS926_Assignment1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RestockPage : ContentPage
    {
        // collection of products currently in the store watching for changes
        public ObservableCollection<Product> products { get; private set; }

        // initial null instance of product
        public Product currentProduct = null;

        // constructor for restock page (1 param required)
        public RestockPage(ObservableCollection<Product> products)
        {
            InitializeComponent();
            this.products = products;
            BindingContext = this;
        }

        // handle restocking a product (updates quantity)
        private void OnRestockClicked(object sender, EventArgs e)
        {
            if (EntryQuantity.Text.Equals(""))
            {
                DisplayAlert("Error", "You have to enter an amount you want to restock.", "Ok");
            }
            else
            {
                if (currentProduct == null)
                {
                    DisplayAlert("Error", "You have to choose a product you want to restock.", "Ok");
                }
                else {
                    int indexOfProduct = 0;
                    foreach (Product p in products)
                    {
                        if (p.name.Equals(currentProduct.name))
                        {
                            break;
                        }
                        indexOfProduct++;
                    }

                    products[indexOfProduct].quantity += int.Parse(EntryQuantity.Text);

                    EntryQuantity.Text = "";
                    currentProduct = null;
                }
            }
        }

        // handle canceling a restock and going back
        private async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        // sets the product instance on select event
        private void OnProductSelected(object sender, SelectedItemChangedEventArgs e)
        {
            currentProduct = e.SelectedItem as Product;
        }

        // sets the product instance on tap event
        private void OnProductTapped(object sender, ItemTappedEventArgs e)
        {
            currentProduct = e.Item as Product;
        }
    }
}