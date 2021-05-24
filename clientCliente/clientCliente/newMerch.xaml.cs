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
    public partial class newMerch : ContentPage
    {
        int idVC;
        double width;
        public newMerch()
        {
            InitializeComponent();
            width = Application.Current.MainPage.Width;
        }

        private void newGoodTapped(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(name.Text) || String.IsNullOrWhiteSpace(cost.Text))
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
                app = "{\"type\":\"" + name.Text + "\",\"cost\":" + cost.Text + "}";
                Task<string> task = RestService.post("/good?id=" + Misc.id, app);
                if (task.Result == "204")
                {
                    displayError.Margin = new Thickness((width - 300) / 2, 70, (width - 300) / 2, 0);
                    displayError.TextColor = Color.OrangeRed;
                    displayError.Text = "Campi non validi";
                    displayError.IsVisible = true;
                }
                else
                {
                    displayError.Margin = new Thickness((width - 300) / 2, 70, (width - 300) / 2, 0);
                    displayError.TextColor = Color.DodgerBlue;
                    displayError.Text = "Merce aggiunta";
                    displayError.IsVisible = true;
                    name.Text = "";
                    cost.Text = "";
                }


            }
        }
    }
}