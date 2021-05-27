using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace clientCliente
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class newAccount : ContentPage
    {
        double width;
        Entry entry;
        List<State> states;
        List<Port> ports;
        public newAccount()
        {
            InitializeComponent();
            width = Application.Current.MainPage.Width;
            Task<string> task = RestService.get("/stateList");

            states = JsonConvert.DeserializeObject<List<State>>(task.Result);
            List<string> l = new List<string>();
            foreach ( State S in states)
                l.Add(S.stato);
            state.ItemsSource = l;
        }

        private void newAccountTapped(object sender, EventArgs e)
        {
            string app;
            if (user.SelectedIndex == 0)
            {
                if (String.IsNullOrWhiteSpace(nome.Text) || String.IsNullOrWhiteSpace(password.Text))
                {
                    displayError.Margin = new Thickness((width - 300) / 2, 70, (width - 300) / 2, 0);
                    displayError.Text = "Compilare i campi";
                    displayError.IsVisible = true;
                }
                else
                {
                    app = "{\"name\":\"" + nome.Text + "\",\"password\":\"" + password.Text + "\"}";
                    Task<string> task = RestService.post("/singup?type=fornitore" ,app);
                    displayError.Margin = new Thickness((width - 300) / 2, 70, (width - 300) / 2, 0);
                    displayError.TextColor = Color.DodgerBlue;
                    displayError.Text = "Fornitore aggiunto";
                    displayError.IsVisible = true;
                    nome.Text = "";
                }
            }

            if (user.SelectedIndex == 1)
            {
                if(String.IsNullOrWhiteSpace(nome.Text) || String.IsNullOrWhiteSpace(password.Text) || state.SelectedIndex < 0 || city.SelectedIndex < 0)
                {
                    displayError.Margin = new Thickness((width - 300) / 2, 70, (width - 300) / 2, 0);
                    displayError.Text = "Compilare i campi";
                    displayError.IsVisible = true;
                }
                else
                {
                    app = "{\"name\":\"" + nome.Text + "\",\"surname\":\"" + cognome.Text + "\",\"password\":\"" + password.Text + "\",\"idP\":"+ ports[city.SelectedIndex].idP + "}";
                    Task<string> task = RestService.post("/signup?type=operatore", app);
                    displayError.Margin = new Thickness((width - 300) / 2, 70, (width - 300) / 2, 0);
                    displayError.TextColor = Color.DodgerBlue;
                    displayError.Text = "Operatore aggiunto";
                    displayError.IsVisible = true;
                    nome.Text = "";
                }
            }
            else
            {
                if(String.IsNullOrWhiteSpace(nome.Text) || String.IsNullOrWhiteSpace(cognome.Text) || String.IsNullOrWhiteSpace(password.Text))
                {
                    displayError.Margin = new Thickness((width - 300) / 2, 70, (width - 300) / 2, 0);
                    displayError.Text = "Compilare i campi";
                    displayError.IsVisible = true;
                }
                else
                {
                    app = "{\"name\":\"" + nome.Text + "\",\"surname\":\"" + cognome.Text + "\",\"password\":\"" + password.Text + "\"}";
                    Task<string> task = RestService.post("/singup?type=autista", app);
                    displayError.Margin = new Thickness((width - 300) / 2, 70, (width - 300) / 2, 0);
                    displayError.TextColor = Color.DodgerBlue;
                    displayError.Text = "Autotraportatore aggiunto";
                    displayError.IsVisible = true;
                    nome.Text = "";
                }
            }
        }

        private void userChanged(object sender, EventArgs e)
        {
            if (user.SelectedIndex == 0)
            {
                Cognome.IsVisible = false;
                cognome.IsVisible = false;
                state.IsVisible = false;
                city.IsVisible = false;
            }
            else if(user.SelectedIndex == 1)
            {
                Cognome.IsVisible = true;
                cognome.IsVisible = true;
                state.IsVisible = true;
                city.IsVisible = true;
            }
            else
            {
                Cognome.IsVisible = true;
                cognome.IsVisible = true;
                state.IsVisible = false;
                city.IsVisible = false;
            }
        }

        private void stateChanged(object sender, EventArgs e)
        {
            Task<string> task = RestService.get("/portListByState?state=" + state.Items[state.SelectedIndex]);
            ports = JsonConvert.DeserializeObject<List<Port>>(task.Result);
            List<string> l = new List<string>();
            foreach (Port S in ports)
                l.Add(S.citta);
            city.ItemsSource = l;
        }
    }
}