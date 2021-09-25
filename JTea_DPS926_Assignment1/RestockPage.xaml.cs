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

        public RestockPage(ObservableCollection<Product> products)
        {
            InitializeComponent();
            this.products = products;
        }
    }
}