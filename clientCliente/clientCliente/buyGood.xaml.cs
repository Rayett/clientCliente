using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;

namespace clientCliente
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class buyGood : ContentPage
    {
        double width;
        int idGood;
        List<State> states;
        List<Port> ports;
        public buyGood(int idGood)
        {
            InitializeComponent();
            this.idGood = idGood;
            width = Application.Current.MainPage.Width;
            Task<string> task = RestService.get("/stateList");

            states = JsonConvert.DeserializeObject<List<State>>(task.Result);
            List<string> l = new List<string>();
            foreach (State S in states)
                l.Add(S.stato);
            state.ItemsSource = l;
        }

        private void newPackTapped(object sender, EventArgs e)
        {
            string app;
            if (state.SelectedIndex < 0 || city.SelectedIndex < 0)
            {
                displayError.Margin = new Thickness((width - 300) / 2, 70, (width - 300) / 2, 0);
                displayError.Text = "Compilare i campi";
                displayError.IsVisible = true;
            }
            else
            {
                app = "{\"idGood\":" + idGood + ",\"quantity\":" + quantity.Text + ",\"idP\":" + ports[city.SelectedIndex].idP + "}";
                Task<string> task = RestService.post("/pack?id="+ Misc.id, app);
                Navigation.PopAsync();
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