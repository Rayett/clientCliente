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
    public partial class packStart : ContentPage
    {
        public int idpacco;
        string stato;
        string citta;
        double width;
        public packStart(int idpacco, string stato, string citta)
        {
            this.idpacco = idpacco;
            this.stato = stato;
            this.citta = citta;
            Label label;
            width = Application.Current.MainPage.Width;
            label = new Label
            {
                Text = "Destinazione:  " + stato + ", " + citta,
                Margin = new Thickness(20, 25, 0, 0),
                TextColor = Color.White,
                FontSize = 20,
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center,
            };
            InitializeComponent();
            infoDestination.Children.Add(label);
            
        }

        private void setDestinationTapped(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(state.Text) || String.IsNullOrWhiteSpace(city.Text))
            {
                displayError.Margin = new Thickness((width - 300) / 2, 70, (width - 300) / 2, 0);
                displayError.TextColor = Color.OrangeRed;
                displayError.Text = "Compilare i campi";
                displayError.IsVisible = true;
            }
            else
            {
                string app;
                displayError.IsVisible = false;
                app = "{\"state\":\"" + state.Text + "\",\"city\":\"" + city.Text + "\"}";
                Task<string> task = RestService.post("/setPackStart?id=" + idpacco, app);
                if (task.Result == "err 204")
                {
                    displayError.Margin = new Thickness((width - 300) / 2, 70, (width - 300) / 2, 0);
                    displayError.TextColor = Color.OrangeRed;
                    displayError.Text = "Porto non valido";
                    displayError.IsVisible = true;
                }
                else
                {
                    Navigation.PopAsync();
                }


            }
        }
    }

    
}