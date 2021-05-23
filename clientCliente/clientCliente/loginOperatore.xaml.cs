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
    public partial class loginOperatore : ContentPage
    {
        double width;
        public loginOperatore()
        {
            InitializeComponent();
            width = Application.Current.MainPage.Width;
        }

        private void logInTapped(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(nome.Text) || String.IsNullOrWhiteSpace(password.Text) || String.IsNullOrWhiteSpace(cognome.Text))
            {
                displayError.Margin = new Thickness((width - 200) / 2, 10, (width - 200) / 2, 0);
                displayError.Text = "Compilare i campi";
                displayError.IsVisible = true;
            }
            else
            {
                string app;
                displayError.IsVisible = false;
                Task<string> task = RestService.get("/login?type=operatore&name=" + nome.Text + "&surname=" + cognome.Text + "&password=" + password.Text);
                Console.WriteLine("\n\nbased " + task.Result);
                if (task.Result == "err 204")
                {
                    displayError.Margin = new Thickness((width - 200) / 2, 10, (width - 200) / 2, 0);
                    displayError.Text = "Credenziali sbagliate";
                    displayError.IsVisible = true;
                }
                else
                {
                    Misc.id = Convert.ToInt32(task.Result);
                    Console.WriteLine("id = " + Misc.id);
                    Navigation.PushAsync(new mainOperatore());
                }

            }
        }
    }
}