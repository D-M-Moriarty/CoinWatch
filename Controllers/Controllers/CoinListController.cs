using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using CoinWatch;

namespace Controllers
{
    public class CoinListController : ObservableObject
    {
        /// <summary>
        /// Attributes
        /// </summary>
        private readonly Timer _myTimer = new Timer();
        private ObservableCollection<CNameCPrice> _cNameCPrices;
        public ObservableCollection<CNameCPrice> CNameCPrices
        {
            get => _cNameCPrices;
            set
            {
                _cNameCPrices = value;
                OnPropertyChanged("CNameCPrices");

            }
        }
        // the item of the list that is double clicked
        public CNameCPrice SelectedItem { get; set; }
        // The api object
        private FetchCoinValsAPI _api;

        /// <summary>
        /// This class is a custom class
        /// designed to populate the listview
        /// on the UI
        /// </summary>
        public class CNameCPrice
        {
            public string CoinName { get; set; }
            public decimal? CoinValue { get; set; }
            public byte[] CoinImage { get; set; }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public CoinListController()
        {
            CNameCPrices = GetCNameCPrices();

            // Uncomment/comment these next two lines to start
            // fetching the coin prices from the web api
            // and updating the prices in the listview
            //_api = new FetchCoinValsAPI();
            //Time();
        }

        /// <summary>
        /// This method retrieves all 
        /// the coins from the coin table
        /// and all the coin values 
        /// and inserts them into a new object 
        /// for displaying them in a list on the UI
        /// </summary>
        /// <returns></returns>
        private ObservableCollection<CNameCPrice> GetCNameCPrices()
        {
            // the collection that will be returned
            ObservableCollection<CNameCPrice> coinList = new ObservableCollection<CNameCPrice>();

            using (var db = new CoinWatchEntities())
            {
               // the query
                var query = from coin in db.COINs
                    join coinVal in db.COIN_VALUE
                    on coin.COIN_ID equals coinVal.COIN_ID   
                    orderby coinVal.DATETIME
                    select new {coin.COIN_NAME, coinVal.COIN_VALUE1, coinVal.DATETIME, coin.IMAGE};

                // loop through the query and extract the required information
                // and place in the custom object for the listview
                foreach (var item in query)
                {
                    CNameCPrice cNameCPrice = new CNameCPrice()
                    {
                        CoinName = item.COIN_NAME,
                        CoinValue = item.COIN_VALUE1,
                        CoinImage = item.IMAGE
                    };

                    coinList.Add(cNameCPrice);
                }
            }

            // creating a list from the result set and retieving the most recent distinct items
            List<CNameCPrice> result = coinList.GroupBy(test => test.CoinName)
                .Select(grp => grp.Last())
                .ToList();
            // converting the list to the returned collection type
            ObservableCollection<CNameCPrice> myCollection = new ObservableCollection<CNameCPrice>(result);

            return myCollection;
        }
        
        /// <summary>
        /// this method refreshes the listviews contents every 5 seconds
        /// </summary>
        private void Time()
        {
            _myTimer.Elapsed += new ElapsedEventHandler(DisplayTimeEvent);
            _myTimer.Interval = 5000; // 1000 ms is one second
            _myTimer.Start();
        }

        /// <summary>
        /// updates the contents of the list for the listview
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        public void DisplayTimeEvent(object source, ElapsedEventArgs e)
        {
            CNameCPrices = GetCNameCPrices();
        }


    }
}
