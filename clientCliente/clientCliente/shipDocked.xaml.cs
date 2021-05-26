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
    public partial class shipDocked : ContentPage
    {
        double width;
        public shipDocked()
        {
            InitializeComponent();
            width = Application.Current.MainPage.Width;
        }

        private void completeTripTapped(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(idNave.Text))
            {
                displayError.Margin = new Thickness((width - 300) / 2, 70, (width - 300) / 2, 0);
                displayError.TextColor = Color.OrangeRed;
                displayError.Text = "Compilare i campi";
                displayError.IsVisible = true;
            }
            else
            {
                displayError.IsVisible = false;
                string app;
                string idShip;
                idShip = idNave.Text.Substring(idNave.Text.IndexOf("#") + 1);
                DateTime dateTime = DateTime.UtcNow;
                string data = dateTime.Year.ToString() + '-' + dateTime.Month.ToString() + '-' + dateTime.Day.ToString() + ' ' + dateTime.Hour.ToString() + ':' + dateTime.Minute.ToString() + ':' + dateTime.Second.ToString();
                app = "{\"idP\":" + Operator.idPorto + ",\"idShip\":" + idShip + ",\"date\":\"" + data + "\"}";
                Task<string> task = RestService.post("/completeViaggio", app);
                if(task.Result == "err 204")
                {
                    displayError.Margin = new Thickness((width - 300) / 2, 70, (width - 300) / 2, 0);
                    displayError.TextColor = Color.OrangeRed;
                    displayError.Text = "Nave non valida";
                    displayError.IsVisible = true;
                }
                else
                {
                    displayError.Margin = new Thickness((width - 300) / 2, 70, (width - 300) / 2, 0);
                    displayError.TextColor = Color.DodgerBlue;
                    displayError.Text = "Viaggio aggiornato";
                    displayError.IsVisible = true;
                    idNave.Text = "";
                }



            }
        }
    }
}