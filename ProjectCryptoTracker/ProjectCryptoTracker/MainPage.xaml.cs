using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ProjectCryptoTracker.Model;
using RestSharp;
using Newtonsoft.Json;
using System.Net.Http;
using System.Drawing;


namespace ProjectCryptoTracker
{
    public partial class MainPage : ContentPage
    {
        private string apikey = "D528184F-A844-4220-87A9-23F34FE71282";
        private string baseIconUrl = "https://s3.eu-central-1.amazonaws.com/bbxt-static-icons/type-id/png_64/";
        
        public MainPage()
        {
            InitializeComponent();
            CryptoListView.ItemsSource = GetCoins();

        }

        private void RefreshButton_Clicked(object sender, EventArgs e)
        {
            CryptoListView.ItemsSource = GetCoins();
        }

        private List<Coin> GetCoins()
        {
            List<Coin> coins;

            var client = new RestClient("http://rest.coinapi.io/v1/assets/BTC;ETH;XMR;LTC;XRP");
            var request = new RestRequest();
            request.AddHeader("X-CoinAPI-Key", apikey);

            var response = client.Execute<List<Coin>>(request);
            coins = JsonConvert.DeserializeObject<List<Coin>>(response.Content);

            foreach (var c in coins)
            {
                c.Icon_Url = baseIconUrl + c.id_icon.Replace("-", "") + ".png";
            }

            return coins;
        }
    }
}
