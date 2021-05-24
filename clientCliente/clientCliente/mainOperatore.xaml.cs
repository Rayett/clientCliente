using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace clientCliente
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class mainOperatore : ContentPage
    {
        public mainOperatore()
        {
            InitializeComponent();
        }

        private void shipDockedTapped(object sender, EventArgs e)
        {
            //Navigation.PushAsync();
        }

        private void newViaggioTapped(object sender, EventArgs e)
        {
            //Navigation.PushAsync();
        }

        private void NewuserTapped(object sender, EventArgs e)
        {
            //Navigation.PushAsync();
        }

        private void NewShipTapped(object sender, EventArgs e)
        {
            //Navigation.PushAsync();
        }
    }
}