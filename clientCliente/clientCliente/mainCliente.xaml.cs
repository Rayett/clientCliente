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
    public partial class mainCliente : ContentPage
    {
        double width;
        List<Good> Goods;
        List<Button> buttons;
        public mainCliente()
        {
            int i = 0;
            Goods = new List<Good>();
            buttons = new List<Button>();
            width = Application.Current.MainPage.Width;

            InitializeComponent();
            Create();

        }

        public void Create()
        {
            int i = 0;
            string app = "/goods";
            Task<string> task = RestService.get(app);
            Goods = JsonConvert.DeserializeObject<List<Good>>(task.Result);
            Label label;
            Button button;
            RowDefinition rowDef = new RowDefinition();
            foreach (Good item in Goods)
            {
                mainGridLayout.RowDefinitions.Add(rowDef);
                label = new Label
                {
                    Text = Goods[i].tipo + "       " + Goods[i].costo + "$",
                    Margin = new Thickness(20, 10, 0, 0),
                    TextColor = Color.White,
                    FontSize = 20,
                    VerticalTextAlignment = TextAlignment.Center,
                    HorizontalTextAlignment = TextAlignment.Start,
                };
                button = new Button
                {
                    Text = "ACQUISTA",
                    Margin = new Thickness(0, 10, 20, 0),
                    TextColor = Color.White,
                    BackgroundColor = Color.FromHex("#FF6262"),
                    BorderColor = Color.Black,
                    CornerRadius = 10,
                    FontSize = 15,
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.End,
                    HeightRequest = 37,
                };
                buttons.Add(button);
                button.Clicked += suff;
                mainGridLayout.Children.Add(label, 0, i);
                mainGridLayout.Children.Add(button, 1, i);
                i++;
            }
        }

        private void suff(object sender, EventArgs e)
        {
            Navigation.PushAsync(new buyGood(Goods[buttons.IndexOf((Button)sender)].idMerce));
        }

        private void myOrderstapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new myOrders());
        }
    }
}