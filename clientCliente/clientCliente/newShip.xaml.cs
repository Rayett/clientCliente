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
    public partial class newShip : ContentPage
    {
        double width;
        public newShip()
        {
            InitializeComponent();
            width = Application.Current.MainPage.Width;
        }

        private void newShipTapped(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(name.Text) || String.IsNullOrWhiteSpace(v.Text))
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
                DateTime dateTime = DateTime.UtcNow;
                string data = dateTime.Year.ToString() + '-' + dateTime.Month.ToString() + '-' + dateTime.Day.ToString();
                app = "{\"name\":\"" + name.Text + "\",\"v\":" + v.Text + ",\"date\":\"" + data + "\"}";
                Console.WriteLine(app);
                Task<string> task = RestService.post("/ship", app);
                Console.WriteLine("\n\nbased " + task.Result);
                if(task.Result == "204")
                {
                    displayError.Margin = new Thickness((width - 300) / 2, 70, (width - 300) / 2, 0);
                    displayError.TextColor = Color.OrangeRed;
                    displayError.Text = "Errore";
                    displayError.IsVisible = true;
                }
                else
                {
                    displayError.Margin = new Thickness((width - 300) / 2, 70, (width - 300) / 2, 0);
                    displayError.TextColor = Color.DodgerBlue;
                    displayError.Text = "ID = " + name.Text + "#" + task.Result;
                    displayError.IsVisible = true;
                }
                    
            }
        }
    }
}