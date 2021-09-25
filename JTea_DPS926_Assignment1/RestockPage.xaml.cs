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
        public ObservableCollection<Product> products { get; private set; }

        public Product currentProduct = null;

        public RestockPage(ObservableCollection<Product> products)
        {
            InitializeComponent();
            this.products = products;
            BindingContext = this;
        }

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

                    // update product in array
                    Product updatedProduct = new Product(
                        products[indexOfProduct].name,
                        products[indexOfProduct].quantity + int.Parse(EntryQuantity.Text),
                        products[indexOfProduct].price
                    );
                    products[indexOfProduct] = updatedProduct;

                    EntryQuantity.Text = "";
                    currentProduct = null;
                }
            }
        }

        private async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private void OnProductSelected(object sender, SelectedItemChangedEventArgs e)
        {
            currentProduct = e.SelectedItem as Product;
        }

        private void OnProductTapped(object sender, ItemTappedEventArgs e)
        {
            currentProduct = e.Item as Product;
        }
    }
}