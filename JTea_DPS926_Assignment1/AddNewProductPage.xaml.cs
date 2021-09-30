using System;
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
    public partial class AddNewProductPage : ContentPage
    {
        // collection of products that watches for changes
        public ObservableCollection<Product> products { get; private set; }
        
        // constructor for add new products (1 param required)
        public AddNewProductPage(ObservableCollection<Product> products)
        {
            InitializeComponent();
            this.products = products;
        }

        // handling toolbar "save" button clicked
        private async void OnToolbarSaveClicked(object sender, EventArgs e)
        {
            if (AddProductName.Text.Equals("") && AddProductPrice.Text.Equals("") && AddProductQuantity.Text.Equals(""))
            {
                await DisplayAlert("Error", "Please fill out all form fields", "Ok");
            }
            else
            {
                Product newProduct = new Product(
                    AddProductName.Text,
                    int.Parse(AddProductQuantity.Text),
                    double.Parse(AddProductPrice.Text)
                );

                products.Add(newProduct);
                await Navigation.PopAsync();
                await DisplayAlert("Done!", "New product added successfully!", "Ok");
            }
        }

        // handling toolbar "cancel" button clicked
        private async void OnToolbarCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}