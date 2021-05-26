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
    public partial class infoShipTrip : ContentPage
    {
        double width;
        int idShip;
        public infoShipTrip(int idShip)
        {
            InitializeComponent();
            width = Application.Current.MainPage.Width;
            this.idShip = idShip;
        }

        private void newShipTriptapped(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(state.Text) || String.IsNullOrWhiteSpace(city.Text) || String.IsNullOrWhiteSpace(direttrice.Text))
            {
                displayError.Margin = new Thickness((width - 300) / 2, 70, (width - 300) / 2, 0);
                displayError.Text = "Compilare i campi";
                displayError.IsVisible = true;
            }
            else
            {
                string app;
                displayError.IsVisible = false;
                Task<string> task = RestService.get("/route?idStart="+ Operator.idPorto +"&state="+ state.Text +"&city="+ city.Text);
                if (task.Result == "err 204")
                {
                    displayError.Margin = new Thickness((width - 300) / 2, 70, (width - 300) / 2, 0);
                    displayError.Text = "Porto non esistente";
                    displayError.IsVisible = true;
                }
                else
                {
                    Navigation.PushAsync(new PacksOnShip(idShip, Convert.ToInt32(task.Result), direttrice.Text));
                }


            }
        }
    }
}