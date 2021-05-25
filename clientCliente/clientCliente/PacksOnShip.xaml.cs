using Newtonsoft.Json;
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
    public partial class PacksOnShip : ContentPage
    {
        int idShip;
        int idRoute;
        string direttrice;
        double width;
        List<idPack> PacksInPort;
        public PacksOnShip(int idShip, int idRoute, string direttrice)
        {
            InitializeComponent();
            this.idShip = idShip;
            this.idRoute = idRoute;
            this.direttrice = direttrice;
            width = Application.Current.MainPage.Width;
            PacksInPort = new List<idPack>();
            Console.WriteLine("idShip = " + idShip);
            Console.WriteLine("idRoute = " + idRoute);
            Console.WriteLine("direttrice = " + direttrice);
            //TODO new Viaggio
            string app = "/packsInPort?idP=" + Operator.idPorto;
            Task<string> task = RestService.get(app);
            PacksInPort = JsonConvert.DeserializeObject<List<idPack>>(task.Result);
        }

        private void AggiungiPaccoTapped(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(idPacco.Text))
            {
                displayError.Margin = new Thickness((width - 300) / 2, 70, (width - 300) / 2, 0);
                displayError.TextColor = Color.OrangeRed;
                displayError.Text = "Compilare i campi";
                displayError.IsVisible = true;
            }
            else
            {
                displayError.IsVisible = false;
                int i;
                bool flag = false;
                for(i = 0; i < PacksInPort.Count; i++)
                {
                    if(PacksInPort[i].idpacco == Convert.ToInt32(idPacco.Text))
                    {
                        flag = true;
                    }
                }
                if (flag == false)
                {
                    displayError.Margin = new Thickness((width - 300) / 2, 70, (width - 300) / 2, 0);
                    displayError.TextColor = Color.OrangeRed;
                    displayError.Text = "Pacco non in porto";
                    displayError.IsVisible = true;
                }
                else
                {
                    string app;
                    //app = "{\"idTrip\":" + idVC + ",\"idPack\":" + idPacco.Text + "}";
                    //TODO new pacco_viaggio
                    displayError.Margin = new Thickness((width - 300) / 2, 70, (width - 300) / 2, 0);
                    displayError.TextColor = Color.DodgerBlue;
                    displayError.Text = "Pacco aggiunto";
                    displayError.IsVisible = true;
                    idPacco.Text = "";
                }
                


            }
        }
    }
}