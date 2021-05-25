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
    public partial class newShipTrip : ContentPage
    {
        double width;
        List<Ship> Ships;
        List<Button> buttons;
        public newShipTrip()
        {
            int i = 0;
            Ships = new List<Ship>();
            buttons = new List<Button>();
            width = Application.Current.MainPage.Width;

            InitializeComponent();
            Create();

        }

        public void Create()
        {
            int i = 0;
            string app = "/shipInPort?idP=" + Operator.idPorto;
            Task<string> task = RestService.get(app);
            Ships = JsonConvert.DeserializeObject<List<Ship>>(task.Result);
            Button button;
            foreach (Ship item in Ships)
            {
                button = new Button
                {
                    Text = Ships[i].nome + "#" + Ships[i].idnave,
                    WidthRequest = 230,
                    Margin = new Thickness(100, 20, 100, 0),
                    TextColor = Color.White,
                    BackgroundColor = Color.FromHex("#FF6262"),
                    BorderColor = Color.Black,
                    CornerRadius = 23,
                    FontSize = 20,
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center,
                    HeightRequest = 60,
                };
                buttons.Add(button);
                button.Clicked += suff;
                ShipsInPort.Children.Add(button);
                i++;
            }
        }

        private void suff(object sender, EventArgs e)
        {
            Navigation.PushAsync(new infoShipTrip(Ships[buttons.IndexOf((Button)sender)].idnave));
            ShipsInPort.Children.Clear();
            Ships.Remove(Ships[buttons.IndexOf((Button)sender)]);
            buttons.Remove(buttons[buttons.IndexOf((Button)sender)]);
            CreateALreadyExisting();
        }

        private void CreateALreadyExisting()
        {
            int i = 0;
            Button button;
            foreach (Ship item in Ships)
            {
                button = new Button
                {
                    Text = Ships[i].nome + "#" + Ships[i].idnave,
                    Margin = new Thickness(45, 20, 45, 0),
                    TextColor = Color.White,
                    BackgroundColor = Color.FromHex("#FF6262"),
                    BorderColor = Color.Black,
                    CornerRadius = 23,
                    FontSize = 15,
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center,
                    HeightRequest = 30,
                };
                button.Clicked += suff;
                ShipsInPort.Children.Add(button);
                i++;
            }
        }
    }
}