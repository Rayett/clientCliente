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
    public partial class RetireShip : ContentPage
    {
        int idVC;
        double width;
        public RetireShip()
        {
            InitializeComponent();
            width = Application.Current.MainPage.Width;
        }

        private void ritiraNaveTapped(object sender, EventArgs e)
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
                string app;
                displayError.IsVisible = false;
                app = idNave.Text;
                app = app.Substring(app.IndexOf("#")+1);
                Task<string> task = RestService.delete("/ship?idShip=" + app);
                if (task.Result == "err 204")
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
                    displayError.Text = "Nave ritirata";
                    displayError.IsVisible = true;
                    idNave.Text = "";
                }


            }
        }
    }
}