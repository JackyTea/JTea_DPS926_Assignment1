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
    public partial class ManagerPage : ContentPage
    {
        // collection of products available in the store that watches for changes
        public ObservableCollection<Product> products { get; private set; }

        // collection of historical records ready to be viewed and watch for changes
        public ObservableCollection<History> history { get; private set; }

        // constructor for manager page (2 params required)
        public ManagerPage(ObservableCollection<Product> products, ObservableCollection<History> history)
        {
            InitializeComponent();
            this.products = products;
            this.history = history;
        }

        // navigate to history page
        private async void OnHistoryClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HistoryPage(history));
        }

        // navigate to restock page
        private async void OnRestockClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RestockPage(products));
        }

        // navigate to add new product page
        private async void OnAddNewProductClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddNewProductPage(products));
        }
    }
}