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
    public partial class pendingPacks : ContentPage
    {
        double width;
        List<PendingPack> PPacks;
        List<Button> buttons;
        public pendingPacks()
        {
            int i = 0;
            PPacks = new List<PendingPack>();
            buttons = new List<Button>();
            width = Application.Current.MainPage.Width;

            InitializeComponent();
            Create();

        }

        public void Create()
        {
            int i = 0;
            string app = "/pendingPacks?id=" + Misc.id;
            Task<string> task = RestService.get(app);
            PPacks = JsonConvert.DeserializeObject<List<PendingPack>>(task.Result);
            Label label;
            Button button;
            RowDefinition rowDef = new RowDefinition();
            foreach (PendingPack item in PPacks)
            {
                mainGridLayout.RowDefinitions.Add(rowDef);
                label = new Label
                {
                    Text = PPacks[i].tipo + " x " + PPacks[i].peso,
                    Margin = new Thickness(20, 10, 0, 0),
                    TextColor = Color.White,
                    FontSize = 20,
                    VerticalTextAlignment = TextAlignment.Center,
                    HorizontalTextAlignment = TextAlignment.Start,
                };
                button = new Button
                {
                    Text = "CONFERMA",
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
            Navigation.PushAsync(new packStart(PPacks[buttons.IndexOf((Button)sender)].idpacco, PPacks[buttons.IndexOf((Button)sender)].stato, PPacks[buttons.IndexOf((Button)sender)].citta));
            mainGridLayout.Children.Clear();
            PPacks.Remove(PPacks[buttons.IndexOf((Button)sender)]);
            buttons.Remove(buttons[buttons.IndexOf((Button)sender)]);
            CreateALreadyExisting();
        }

        private void CreateALreadyExisting()
        {
            int i=0;
            Label label;
            Button button;
            RowDefinition rowDef = new RowDefinition();
            foreach (PendingPack item in PPacks)
            {
                mainGridLayout.RowDefinitions.Add(rowDef);
                label = new Label
                {
                    Text = PPacks[i].tipo + " x " + PPacks[i].peso,
                    Margin = new Thickness(20, 10, 0, 0),
                    TextColor = Color.White,
                    FontSize = 20,
                    VerticalTextAlignment = TextAlignment.Center,
                    HorizontalTextAlignment = TextAlignment.Start,
                };
                button = new Button
                {
                    Text = "CONFERMA",
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
    }
}