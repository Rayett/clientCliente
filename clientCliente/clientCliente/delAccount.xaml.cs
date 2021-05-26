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
    public partial class delAccount : ContentPage
    {
        double width;
        Entry entry;
        public delAccount()
        {
            InitializeComponent();
            width = Application.Current.MainPage.Width;
        }

        private void delAccountTapped(object sender, EventArgs e)
         {
            if(user.SelectedIndex == 0 )
            { 
                if (String.IsNullOrWhiteSpace(nome.Text))
                {
                    displayError.Margin = new Thickness((width - 300) / 2, 70, (width - 300) / 2, 0);
                    displayError.Text = "Compilare i campi";
                    displayError.IsVisible = true;
                }
                else
                {
                    string app = "/account?type=fornitore&name="+ nome.Text;
                    Task<string> task = RestService.delete(app);
                    displayError.Margin = new Thickness((width - 300) / 2, 70, (width - 300) / 2, 0);
                    displayError.TextColor = Color.DodgerBlue;
                    displayError.Text = "Fornitore eliminato";
                    displayError.IsVisible = true;
                    nome.Text = "";
                }
            }

            if (user.SelectedIndex == 1)
            {
                if (String.IsNullOrWhiteSpace(nome.Text) || String.IsNullOrWhiteSpace(entry.Text))
                {
                    displayError.Margin = new Thickness((width - 300) / 2, 70, (width - 300) / 2, 0);
                    displayError.Text = "Compilare i campi";
                    displayError.IsVisible = true;
                }
                else
                {
                    string app = "/account?type=operatore&name=" + nome.Text + "&surname="+entry.Text;
                    Task<string> task = RestService.delete(app);
                    displayError.Margin = new Thickness((width - 300) / 2, 70, (width - 300) / 2, 0);
                    displayError.TextColor = Color.DodgerBlue;
                    displayError.Text = "Operatore eliminato";
                    displayError.IsVisible = true;
                    nome.Text = "";
                }
            }
        }

        private void userChanged(object sender, EventArgs e)
        {
            if (user.SelectedIndex == 0)
            {
                opSurname.Children.Clear();
            }
            else
            {
                Label label = new Label
                {
                    Text ="Cognome",
                    Margin = new Thickness(80, 20, 0, 0),
                    TextColor = Color.White,
                    FontSize = 20,
                    VerticalTextAlignment = TextAlignment.Center,
                    HorizontalTextAlignment = TextAlignment.Start,
                };
                entry = new Entry
                {
                    Placeholder = "Cognome",
                    Margin = new Thickness(80, 10, 80, 0),
                };
                opSurname.Children.Add(label);
                opSurname.Children.Add(entry);
            }
        }
    }
}