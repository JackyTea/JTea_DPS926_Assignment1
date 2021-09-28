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
    public partial class HistoryPage : ContentPage
    {
        public ObservableCollection<History> history { get; private set; }
        public HistoryPage(ObservableCollection<History> history)
        {
            InitializeComponent();
            this.history = history;
            BindingContext = this;
        }

        private async void OnHistoryTapped(object sender, ItemTappedEventArgs e)
        {
            History h = e.Item as History;
            await Navigation.PushAsync(new HistoryDetailPage(h));
        }
    }
}