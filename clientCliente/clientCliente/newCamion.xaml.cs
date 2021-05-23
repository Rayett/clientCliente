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
    public partial class newCamion : ContentPage
    {
        double width;
        public newCamion()
        {
            InitializeComponent();
            width = Application.Current.MainPage.Width;
        }

        private void newCamionTapped(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(targa.Text) || String.IsNullOrWhiteSpace(marca.Text) || String.IsNullOrWhiteSpace(modello.Text))
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
                app = "{\"plate\":\"" + targa.Text + "\",\"brand\":\"" + marca.Text + "\",\"model\":\"" + modello.Text + "\"}";
                Console.WriteLine(app);
                Task<string> task = RestService.post("/camion", app);
                Console.WriteLine("\n\nbased " + task.Result);
                displayError.Margin = new Thickness((width - 300) / 2, 70, (width - 300) / 2, 0);
                displayError.TextColor = Color.DodgerBlue;
                displayError.Text = "Camion registrato";
                displayError.IsVisible = true;
                

            }
        }
    }
}