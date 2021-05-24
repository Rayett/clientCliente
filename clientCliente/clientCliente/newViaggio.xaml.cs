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
    public partial class newViaggio : ContentPage
    {
        double width;
        public newViaggio()
        {
            InitializeComponent();
            width = Application.Current.MainPage.Width;
        }

        private void newCamionTapped(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(targa.Text) || String.IsNullOrWhiteSpace(marca.Text) || String.IsNullOrWhiteSpace(modello.Text))
            {
                displayError.Margin = new Thickness((width - 300) / 2, 70, (width - 300) / 2, 0);
                displayError.Text = "Compilare i campi";
                displayError.IsVisible = true;
            }
            else
            {
                string app;
                displayError.IsVisible = false;
                DateTime dateTime = DateTime.UtcNow;
                string data = dateTime.Year.ToString() + '-' + dateTime.Month.ToString() + '-' + dateTime.Day.ToString() + ' ' + dateTime.Hour.ToString() + ':' + dateTime.Minute.ToString() + ':' + dateTime.Second.ToString();
                app = "{\"plate\":\"" + targa.Text + "\",\"brand\":\"" + marca.Text + "\",\"model\":\"" + modello.Text + "\",\"idDriver\":" + Misc.id + ",\"date\":\"" + data + "\"}";
                Console.WriteLine(app);
                Task<string> task = RestService.post("/viaggio_camion", app);
                if(task.Result == "err 204")
                {
                    displayError.Margin = new Thickness((width - 300) / 2, 70, (width - 300) / 2, 0);
                    displayError.Text = "Camion non registrato";
                    displayError.IsVisible = true;
                }
                else
                {
                    Navigation.PushAsync(new completePack(Convert.ToInt32(task.Result)));
                }
                

            }
        }
    }
}