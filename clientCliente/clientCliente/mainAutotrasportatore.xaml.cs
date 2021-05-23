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
    public partial class mainAutotrasportatore : ContentPage
    {
        double height;
        public mainAutotrasportatore()
        {
            InitializeComponent();
            height = Application.Current.MainPage.Height;
            viaggioB.Margin = new Thickness(45, (height - 230) / 2, 45, 0);
        }

        private void viaggioTapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new newViaggio());
        }

        private void camionTapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new newCamion());
        }
    }
}