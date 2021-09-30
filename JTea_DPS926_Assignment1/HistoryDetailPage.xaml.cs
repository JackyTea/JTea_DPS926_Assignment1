using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JTea_DPS926_Assignment1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HistoryDetailPage : ContentPage
    {
        // historical record object
        public History history { get; private set; }

        // history detail page constructor (1 param required)
        public HistoryDetailPage(History history)
        {
            InitializeComponent();
            this.history = history;
            BindingContext = this;
        }
    }
}