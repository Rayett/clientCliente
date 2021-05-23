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
    public partial class signUp : ContentPage
    {
        double width;
        public signUp()
        {
            InitializeComponent();
            width = Application.Current.MainPage.Width;
        }

        private void signUpTapped(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(nome.Text) || String.IsNullOrWhiteSpace(password.Text) || String.IsNullOrWhiteSpace(cognome.Text) || String.IsNullOrWhiteSpace(RipPassword.Text))
            {
                displayError.Margin = new Thickness((width - 300) / 2, 10, (width - 300) / 2, 0);
                displayError.Text = "Compilare i campi";
                displayError.IsVisible = true;
            }
            else
            {
                string app;
                displayError.IsVisible = false;
                if (password.Text == RipPassword.Text)
                {
                    app = "{\"name\":\"" + nome.Text + "\",\"surname\":\"" + cognome.Text + "\",\"password\":\"" + password.Text + "\"}";
                    Task<string> task = RestService.post("/signup?type=cliente", app);
                    Console.WriteLine("\n\nbased " + task.Result);
                    if (task.Result == "err 204")
                    {
                        displayError.Margin = new Thickness((width - 300) / 2, 10, (width - 300) / 2, 0);
                        displayError.Text = "Utente già esistente";
                        displayError.IsVisible = true;
                    }
                    else
                    {
                        task = RestService.get("/login?type=cliente&name=" + nome.Text + "&surname=" + cognome.Text + "&password=" + password.Text);

                        Misc.id = Convert.ToInt32(task.Result);
                        Console.WriteLine("id = " + Misc.id);
                        Navigation.PushAsync(new mainCliente());
                    }
                }
                else
                {
                    displayError.Margin = new Thickness((width - 300) / 2, 10, (width - 300) / 2, 0);
                    displayError.Text = "Campi password diversi";
                    displayError.IsVisible = true;
                }

            }
        }
    }
}