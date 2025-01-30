using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;
using GeckoTerminalGraph;

namespace MainCode
{
    public static class Program
    {
        private static readonly HttpClient client = new HttpClient();

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
            Console.WriteLine(GetPriceAsync().Result);
            Console.ReadLine();
        }
        public static async Task<decimal> GetPriceAsync()
        {
            string url = "https://api.geckoterminal.com/api/v2/simple/networks/ton/token_price/EQBlWgKnh_qbFYTXfKgGAQPxkxFsArDOSr9nlARSzydpNPwA";

            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();
            JObject jsonResponse = JObject.Parse(responseBody);

            decimal price = jsonResponse["data"]["attributes"]["token_prices"]["EQBlWgKnh_qbFYTXfKgGAQPxkxFsArDOSr9nlARSzydpNPwA"].Value<decimal>();
            var newprice = Math.Round(price, 2);

            return newprice;
        }

            public static async Task<decimal> GetPriceAsync2()
        {
            string url2 = "https://api.geckoterminal.com/api/v2/simple/networks/ton/token_price/EQBlWgKnh_qbFYTXfKgGAQPxkxFsArDOSr9nlARSzydpNPwA";

            HttpResponseMessage response2 = await client.GetAsync(url2);
            response2.EnsureSuccessStatusCode();

            string responseBody2 = await response2.Content.ReadAsStringAsync();
            JObject jsonResponse2 = JObject.Parse(responseBody2);

            decimal price2 = jsonResponse2["data"]["attributes"]["token_prices"]["EQBlWgKnh_qbFYTXfKgGAQPxkxFsArDOSr9nlARSzydpNPwA"].Value<decimal>();
            var newprice2 = Math.Round(price2, 2);
            return newprice2;
        }
    }
}