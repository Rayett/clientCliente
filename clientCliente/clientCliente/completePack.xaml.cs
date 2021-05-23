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
    public partial class completePack : ContentPage
    {
        int idVC;
        double width;
        public completePack(int idVC)
        {
            InitializeComponent();
            this.idVC = idVC;
            width = Application.Current.MainPage.Width;
        }

        private void ritiraPaccoTapped(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(idPacco.Text))
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
                Task<string> task = RestService.get("/packExist?idpacco="+ idPacco.Text);
                if (task.Result == "err 204")
                {
                    displayError.Margin = new Thickness((width - 300) / 2, 70, (width - 300) / 2, 0);
                    displayError.TextColor = Color.OrangeRed;
                    displayError.Text = "Pacco non valido";
                    displayError.IsVisible = true;
                }
                else
                {
                    app = "{\"idTrip\":" + idVC + ",\"idPack\":" + idPacco.Text + "}";
                    task = RestService.post("/completePack",app);
                    displayError.Margin = new Thickness((width - 300) / 2, 70, (width - 300) / 2, 0);
                    displayError.TextColor = Color.DodgerBlue;
                    displayError.Text = "Pacco aggiornato";
                    displayError.IsVisible = true;
                    idPacco.Text = "";
                }


            }
        }
    }
}