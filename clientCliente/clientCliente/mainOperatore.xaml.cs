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
    public partial class mainOperatore : ContentPage
    {
        public mainOperatore()
        {
            InitializeComponent();
            Task<string> task = RestService.get("/portoByOp?idpacco=" + Misc.id);
            Operator.idPorto = Convert.ToInt32(task.Result);
        }

        private void shipDockedTapped(object sender, EventArgs e)
        {
            Navigation.PushAsync( new shipDocked());
        }

        private void newViaggioTapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new newShipTrip());
        }

        private void NewuserTapped(object sender, EventArgs e)
        {
            //Navigation.PushAsync();
        }

        private void NewShipTapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new newShip());
        }

        private void RetireShipTapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RetireShip());
        }

        private void DelAccount(object sender, EventArgs e)
        {
            Navigation.PushAsync(new delAccount());
        }
    }
}