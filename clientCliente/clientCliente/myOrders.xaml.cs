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
    public partial class myOrders : ContentPage
    {
        double width;
        List<Order> orders;
        public myOrders()
        {
            int i = 0;
            orders = new List<Order>();
            width = Application.Current.MainPage.Width;

            InitializeComponent();
            Create();

        }

        public void Create()
        {
            int i = 0;
            string app = "/notSentPacks?id="+ Misc.id;
            Task<string> task = RestService.get(app);
            orders = JsonConvert.DeserializeObject<List<Order>>(task.Result);

            app = "/sentPacks?id="+ Misc.id;
            task = RestService.get(app);
            Console.WriteLine(task);
            orders.AddRange(JsonConvert.DeserializeObject<List<Order>>(task.Result));

            app = "/ritiredPacks?id=" + Misc.id;
            task = RestService.get(app);
            orders.AddRange(JsonConvert.DeserializeObject<List<Order>>(task.Result));
            Label l1, l2, l3, l4;
            RowDefinition rowDef = new RowDefinition();
            foreach (Order item in orders)
            {
                mainGridLayout.RowDefinitions.Add(rowDef);
                l1 = new Label
                {
                    Text = item.tipo + " x " + item.peso,
                    Margin = new Thickness(20, 20, 0, 0),
                    TextColor = Color.White,
                    FontSize = 20,
                    VerticalTextAlignment = TextAlignment.Center,
                    HorizontalTextAlignment = TextAlignment.Start,
                };
                if(item.FKPortoStart == -1)
                {
                    l2 = new Label
                    {
                        Text = "In attesa",
                        Margin = new Thickness(40, 20, 0, 0),
                        TextColor = Color.Red,
                        FontSize = 20,
                        VerticalTextAlignment = TextAlignment.Center,
                        HorizontalTextAlignment = TextAlignment.Start,
                    };
                }else if(item.FKViaggioCamion == -1)
                {
                    l2 = new Label
                    {
                        Text = "In transito",
                        Margin = new Thickness(40, 20, 0, 0),
                        TextColor = Color.Orange,
                        FontSize = 20,
                        VerticalTextAlignment = TextAlignment.Center,
                        HorizontalTextAlignment = TextAlignment.Start,
                    };
                }
                else
                {
                    l2 = new Label
                    {
                        Text = "Ritirato",
                        Margin = new Thickness(40, 20, 0, 0),
                        TextColor = Color.LightGreen,
                        FontSize = 20,
                        VerticalTextAlignment = TextAlignment.Center,
                        HorizontalTextAlignment = TextAlignment.Start,
                    };
                }         
                mainGridLayout.Children.Add(l1, 0, i);
                mainGridLayout.Children.Add(l2, 1, i);
                i++;


                mainGridLayout.RowDefinitions.Add(rowDef);
                if (item.FKPortoStart == -1)
                {
                    var d = DateTime.Parse(item.dataAcq);
                    l3 = new Label
                    {
                        Text = "Acquistato: " + d.ToString("dd-MM-yy"),
                        Margin = new Thickness(40, -10, 0, 0),
                        TextColor = Color.White,
                        FontSize = 18,
                        VerticalTextAlignment = TextAlignment.Center,
                        HorizontalTextAlignment = TextAlignment.Start,
                    };
                }
                else if (item.FKViaggioCamion == -1)
                {
                    var d = DateTime.Parse(item.dataAcq);
                    int temp = (int) Math.Ceiling((double)item.tempoSt / 24);
                    d = d.AddDays(temp);
                    l3 = new Label
                    {
                        Text = "Stimato: " + d.ToString("dd-MM-yy"),
                        Margin = new Thickness(40, -10, 0, 0),
                        TextColor = Color.White,
                        FontSize = 18,
                        VerticalTextAlignment = TextAlignment.Center,
                        HorizontalTextAlignment = TextAlignment.Start,
                    };
                }
                else
                {
                    var d = DateTime.Parse(item.data);
                    l3 = new Label
                    {
                        Text = "Ritirato: "+ d.ToString("dd-MM-yy"),
                        Margin = new Thickness(40, -10, 0, 0),
                        TextColor = Color.White,
                        FontSize = 18,
                        VerticalTextAlignment = TextAlignment.Center,
                        HorizontalTextAlignment = TextAlignment.Start,
                    };
                }        
                mainGridLayout.Children.Add(l3, 1, i);
                if (item.stato != null)
                {
                    l4 = new Label
                    {
                        Text = "Da: " + item.stato + ", " + item.citta,
                        Margin = new Thickness(20, -10, 0, 0),
                        TextColor = Color.White,
                        FontSize = 18,
                        VerticalTextAlignment = TextAlignment.Center,
                        HorizontalTextAlignment = TextAlignment.Start,
                    };
                    mainGridLayout.Children.Add(l4, 0, i);
                }

                
                
                i++;
            }
        }
    }
}