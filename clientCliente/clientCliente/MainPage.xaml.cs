using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace clientCliente
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            RestService.CreateUrl();
            //main();
        }

        private void clienteTapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new loginCliente());
        }

        private void fornitoreTapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new loginFornitore());
        }

        private void operatoreTapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new loginOperatore());
        }

        private void autotrasportatoreTapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new loginAutotrasportatore());
        }
    }
}
