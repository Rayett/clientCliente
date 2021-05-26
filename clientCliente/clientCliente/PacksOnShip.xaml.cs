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
        public int idShip;
        public int idRoute;
        public int idViaggio;
        public string direttrice;
        public double width;
        List<idPack> PacksInPort;
        public PacksOnShip(int idShip, int idRoute, string direttrice)
        {
            string app;
            InitializeComponent();
            this.idShip = idShip;
            this.idRoute = idRoute;
            this.direttrice = direttrice;
            width = Application.Current.MainPage.Width;
            PacksInPort = new List<idPack>();
            DateTime dateTime = DateTime.UtcNow;
            Task<string> task = RestService.get("/packsInPort?idP=" + Operator.idPorto);
            PacksInPort = JsonConvert.DeserializeObject<List<idPack>>(task.Result);
            string data = dateTime.Year.ToString() + '-' + dateTime.Month.ToString() + '-' + dateTime.Day.ToString() + ' ' + dateTime.Hour.ToString() + ':' + dateTime.Minute.ToString() + ':' + dateTime.Second.ToString();
            app = "{\"idShip\":" + idShip + ",\"idRoute\":" + idRoute + ",\"direttrice\":\"" + direttrice + "\",\"date\":\"" + data + "\"}";
            Console.WriteLine(app);
            task = RestService.post("/viaggio", app);
            idViaggio = Convert.ToInt32(task.Result);
            Console.WriteLine("idViaggio = " + idViaggio);
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
                    app = "{\"idTrip\":" + idViaggio + ",\"idPack\":" + idPacco.Text + "}";
                    Task<string> task = RestService.post("/viaggio_pacco", app);
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