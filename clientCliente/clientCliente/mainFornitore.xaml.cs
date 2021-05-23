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
    public partial class mainFornitore : ContentPage
    {
        double width;
        List<Good> myGoods;
        public mainFornitore()
        {
            int i = 0;
            string app = "/myGoods?id=" + Misc.id;
            Console.WriteLine(app);
            myGoods = new List<Good>();
            Task<string> task = RestService.get(app);
            Console.WriteLine("task = " + task.Result);
            width = Application.Current.MainPage.Width;

            InitializeComponent();
            Console.WriteLine("poggers");
            myGoods = JsonConvert.DeserializeObject<List<Good>>(task.Result);
            Console.WriteLine("good = " + myGoods[0].tipo);
            Label label;
            Button button;
            RowDefinition rowDef = new RowDefinition();
            foreach (Good item in myGoods)
            {
                mainGridLayout.RowDefinitions.Add(rowDef);
                label = new Label
                { 
                    Text = myGoods[i].tipo + "    " + myGoods[i].costo + "$",
                    Margin = new Thickness(20, 10, 0, 0),
                    TextColor = Color.White,
                    FontSize = 20,
                    VerticalTextAlignment = TextAlignment.Center,
                    HorizontalTextAlignment = TextAlignment.Start,
                };
                button = new Button
                {
                    Text = "RIMUOVI",
                    Margin = new Thickness(0, 10, 20, 0),
                    TextColor = Color.White,
                    BackgroundColor = Color.FromHex("#FF6262"),
                    BorderColor = Color.Black,
                    CornerRadius = 23,
                    FontSize = 15,
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.End,
                    HeightRequest = 20,
                };
                mainGridLayout.Children.Add(label, 0, i);
                mainGridLayout.Children.Add(button, 1, i);
                i++;
            }
        }
        /*Margin="80,10,0,0 "
                TextColor="White" 
                FontSize="20"
                VerticalTextAlignment="Center"
                HorizontalTextAlignment="Start"/>
        */

        /* {
             if (String.IsNullOrWhiteSpace(nome.Text) || String.IsNullOrWhiteSpace(password.Text) || String.IsNullOrWhiteSpace(cognome.Text))
             {
                 displayError.Margin = new Thickness((width - 200) / 2, 10, (width - 200) / 2, 0);
                 displayError.Text = "Compilare i campi";
                 displayError.IsVisible = true;
             }
             else
             {
                 string app;
                 displayError.IsVisible = false;
                 Task<string> task = RestService.get("/login?type=operatore&name=" + nome.Text + "&surname=" + cognome.Text + "&password=" + password.Text);
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
                     Navigation.PushAsync(new mainOperatore());
                 }

             }
         }*/
    }
}