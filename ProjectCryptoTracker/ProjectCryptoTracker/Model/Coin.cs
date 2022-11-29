using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectCryptoTracker.Model
{
    internal class Coin
    {
        public string id_icon { get; set; }
        public string Name { get; set; }
        public string Asset_id { get; set; }
        public float Price_usd { get; set; }

        public string Icon_Url { get; set; }
    }
}
