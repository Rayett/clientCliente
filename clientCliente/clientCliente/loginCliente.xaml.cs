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
    public partial class loginCliente : ContentPage
    {
        double width;
        public loginCliente()
        {
            InitializeComponent();
            width = Application.Current.MainPage.Width;
        }

        private void logInTapped(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(nome.Text) || String.IsNullOrWhiteSpace(password.Text))
            {
                displayError.Margin = new Thickness((width - 200) / 2, 10, (width - 200) / 2, 0);
                displayError.Text = "Compilare i campi";
                displayError.IsVisible = true;
            }
            else
            {
                string app;
                displayError.IsVisible = false;
                Task<string> task = RestService.get("/login?type=cliente&name=" + nome.Text + "&surname=" + cognome.Text + "&password=" + password.Text);
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
                    Navigation.PushAsync(new mainCliente());
                }

            }
        }

        private void signUpTapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new signUp());
        }
    }
}