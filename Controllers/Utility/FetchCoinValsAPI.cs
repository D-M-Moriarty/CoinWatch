using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Timers;
using CoinWatch;

namespace Controllers
{
    public class FetchCoinValsAPI
    {
        /// <summary>
        /// this class is used to start a new thread for handling the timer
        /// </summary>
        public class TimeCall
        {
            public Timer myTimer = new Timer();

            public void Time()
            {
                // this calls the web api every 5 seconds
                myTimer.Elapsed += DisplayTimeEvent;
                myTimer.Interval = 5000; // 1000 ms is one second
                myTimer.Start();
            }
            public void DisplayTimeEvent(object source, ElapsedEventArgs e)
            {
                // call the api
                CallWebAPIAsync().Wait();
            }
        }

        public FetchCoinValsAPI()
        {
            TimeCall t = new TimeCall();
            t.Time();
            Console.ReadLine();
        }

        /// <summary>
        /// this methid retrieves a list of names of the cion currently in the database
        /// </summary>
        /// <returns></returns>
        public static List<COIN> GetCoins()
        {
            List<COIN> coinValues = new List<COIN>();

            using (var db = new CoinWatchEntities())
            {
                var query = from coin in db.COINs
                    select coin;

                foreach (var valCoin in query)
                {

                    coinValues.Add(valCoin);
                }
            }

            return coinValues;
        }

        /// <summary>
        /// this method retrieves the prices for the coins in the database
        /// </summary>
        /// <returns></returns>
        public static async Task CallWebAPIAsync()
        {

            List<COIN> coinList = GetCoins();
            int[] coinIds = new int[coinList.Count];
            string cListString = null;

            for (int i = 0; i < coinList.Count; i++)
            {
                // this appends the names of the coins to the string to be passed to the api call
                cListString += coinList[i].COIN_NAME + ",";
                // creates an array of CoinIds
                coinIds[i] = coinList[i].COIN_ID;
            }
            // removes the last comma from the api string
            String withoutLast = cListString.Substring(0, (cListString.Length - 1));

            using (var client = new HttpClient())
            {
                // this is the address for web api call
                client.BaseAddress = new Uri("https://min-api.cryptocompare.com/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //GET Method  
                // the api call
                HttpResponseMessage response = await client.GetAsync("data/pricemulti?fsyms=" + withoutLast + "&tsyms=EUR");

                // if there was a response and wa successfull
                if (response.IsSuccessStatusCode)
                {
                    // the string response
                    string s = await response.Content.ReadAsStringAsync();
                    // list for the coin prices
                    List<decimal> prices = new List<decimal>();
                    // regex to match the prices from the json string response
                    foreach (Match m in Regex.Matches(s, @"[0-9]+\.[0-9]+"))
                    {
                        // adding the prices to the list
                        prices.Add(Convert.ToDecimal(m.Value));
                    }

                    // loop through all the prices
                    for (int i = 0; i < prices.Count; i++)
                    {
                        // create a coin value object
                        COIN_VALUE coinValue = new COIN_VALUE()
                        {
                            COIN_ID = coinIds[i],
                            DATETIME = DateTime.Now,
                            COIN_VALUE1 = prices[i]
                        };

                        // save the new value to the database
                        using (var db = new CoinWatchEntities())
                        {
                            db.COIN_VALUE.Add(coinValue);
                            db.SaveChanges();
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Internal server Error");
                }
            }
        }
    }
}
