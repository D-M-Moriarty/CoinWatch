using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using CoinWatch;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using static Controllers.CoinListController;

namespace Controllers.Controllers
{
    public class CoinProfileController : ObservableObject
    {
        /// <summary>
        /// Attributes
        /// </summary>

        // coin object to be diplayed on the UI
        private COIN _coin;
        public COIN Coin
        {
            get => _coin;
            set
            {
                if (_coin != value)
                {
                    _coin = value;
                    OnPropertyChanged("Coin");
                }
            }
        }

        public PRICE_ALERT PriceAlert { get; set; }

        private bool _isGreaterThan;
        public bool IsGreaterThan
        {
            get => _isGreaterThan;
            set
            {
                if (_isGreaterThan != value)
                {
                    _isGreaterThan = value;
                    IsGreaterThanString = "";
                    OnPropertyChanged("IsGreaterThan");
                }
            }
        }

        public string IsGreaterThanString
        {
            get => IsGreaterThan ? "Greater than" : "Less than";
            set => OnPropertyChanged("IsGreaterThanString");
        }

        public string PriceAlertSet
        {
            get => CheckIfPriceAlertExists() ? "Change price" : "Set Price Alert";
            set => OnPropertyChanged("PriceAlertSet");
        }

        // a new post to be written
        private POST _post;
        public POST Post
        {
            get => _post;
            set
            {
                if (_post != value)
                {
                    _post = value;
                    OnPropertyChanged("Post");
                }
            }
        }

        // the list of posts in the listview
        private ObservableCollection<POST> _posts;
        public ObservableCollection<POST> Posts
        {
            get => _posts;
            set
            {
                _posts = value;
                OnPropertyChanged("Posts");
            }
        }

        // the string that is displayed on the button
        // dependent on whether the user is following the
        // coin or not
        public string FollowString
        {
            get => IsFollowed ? "- Unfollow" : "+ Follow";
            set => OnPropertyChanged("FollowString");
        }

        // signifies whether the user is following the coin or not
        private bool _isFollowed;
        public bool IsFollowed
        {
            get => _isFollowed;
            set
            {
                if (_isFollowed != value)
                {
                    _isFollowed = value;
                    OnPropertyChanged("IsFollowed");
                    FollowString = "";
                }
            }
        }

        // object to follow a coin
        private COIN_FOLLOW _coinFollow;
        public COIN_FOLLOW CoinFollow
        {
            get => _coinFollow;
            set
            {
                if (_coinFollow != value)
                {
                    _coinFollow = value;
                    OnPropertyChanged("CoinFollow");
                }
            }
        }

        // the displayed value for the coin
        public COIN_VALUE CoinValue { get; set; }
        // a decimal array of values of the selected
        // coin from the database
        public decimal?[] LineValues { get; set; }

        /// <summary>
        /// Constructor
        /// this intitialises the class
        /// </summary>
        /// <param name="coinName"></param>
        public CoinProfileController(string coinName)
        {
            Coin = RetrieveCoinInfo(coinName);
            CoinValue = GetCoinValue();
            OhclExample();
            Post = new POST();
            CoinFollow = new COIN_FOLLOW();
            PriceAlert = new PRICE_ALERT();
            IsGreaterThan = true;
            Posts = GetPosts();
            IsFollowed = CheckIfFollowed();
        }

        /// <summary>
        /// This method retrieves the current value 
        /// for the selected coin and also
        /// populates the list of values needed for the line chart
        /// </summary>
        /// <returns></returns>
        private COIN_VALUE GetCoinValue()
        {
            // the list that needs to be populted from the query
            List<COIN_VALUE> coinList = new List<COIN_VALUE>();
            // list for line chart
            List<decimal?> decimals = new List<decimal?>();

            using (var db = new CoinWatchEntities())
            {
                // get all the values for selected coin
                var query = from value in db.COIN_VALUE
                    where value.COIN_ID == Coin.COIN_ID
                    orderby value.DATETIME 
                    select value;

                foreach (var VARIABLE in query)
                {
                    coinList.Add(VARIABLE);
                    decimals.Add(VARIABLE.COIN_VALUE1);
                }
                
                // set the line chart list
                LineValues = decimals.ToArray();
                // return the current value
                return coinList.Last();
            }
        }

        /// <summary>
        /// This method will search the database for 
        /// the relevant coin information
        /// </summary>
        /// <param name="coinName"></param>
        /// <returns></returns>
        public COIN RetrieveCoinInfo(string coinName)
        {
            using (var db = new CoinWatchEntities())
            {
                var query = from coin in db.COINs
                            where coin.COIN_NAME == coinName
                    select coin;

                foreach (var VARIABLE in query)
                {
                    return VARIABLE;
                }

            }
            return null;
        }

        /// <summary>
        /// Graph code
        /// </summary>
        private string[] _labels;
        public void OhclExample()
        {

            ChartValues<double> values = new ChartValues<double>();

            foreach (var VARIABLE in LineValues)
            {
                values.Add((double)VARIABLE);
            }

            SeriesCollection = new SeriesCollection
            {
//                new OhlcSeries()
//                {
//                    Values = new ChartValues<OhlcPoint>
//                    {
//                        new OhlcPoint(32, 35, 30, 32),
//                        new OhlcPoint(33, 38, 31, 37),
//                        new OhlcPoint(35, 42, 30, 40),
//                        new OhlcPoint(37, 40, 35, 38),
//                        new OhlcPoint(35, 38, 32, 33)
//                    }
//                },
                new LineSeries
                {
                    Values = values,
                    Fill = Brushes.Transparent
                }
            };

            //based on https://github.com/beto-rodriguez/Live-Charts/issues/166 
            //The Ohcl point X property is zero based indexed.
            //this means the first point is 0, second 1, third 2.... and so on
            //then you can use the Axis.Labels properties to map the chart X with a label in the array.
            //for more info see (mapped labels section) 
            //http://lvcharts.net/#/examples/v1/labels-wpf?path=WPF-Components-Labels

            Labels = new[]
            {
                DateTime.Now.ToString("dd MMM"),
                DateTime.Now.AddDays(1).ToString("dd MMM"),
                DateTime.Now.AddDays(2).ToString("dd MMM"),
                DateTime.Now.AddDays(3).ToString("dd MMM"),
                DateTime.Now.AddDays(4).ToString("dd MMM"),
            };
        }

        public SeriesCollection SeriesCollection { get; set; }

        public string[] Labels
        {
            get { return _labels; }
            set
            {
                _labels = value;
                OnPropertyChanged("Labels");
            }
        }
        /// <summary>
        /// end charts
        /// </summary>

        // this is the highlighted post in the listview
        public POST SelectedItem { get; set; }

        public void UpdateAllOnClick(object sender, RoutedEventArgs e)
        {
            var r = new Random();

            foreach (var point in SeriesCollection[0].Values.Cast<OhlcPoint>())
            {
                point.Open = r.Next((int)point.Low, (int)point.High);
                point.Close = r.Next((int)point.Low, (int)point.High);
            }
        }

        /// <summary>
        /// saves a new post to the database and updates the list of posts
        /// </summary>
        public void SavePost()
        {
            using (var db = new CoinWatchEntities())
            {
                Post.COIN_ID = Coin.COIN_ID;
                Post.USER_ID = 2;// change to current user
                db.POSTs.Add(Post);
                try
                {
                    db.SaveChanges();
                    Posts.Add(Post);
                    Post = new POST();
                    Posts = GetPosts();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.InnerException.InnerException.Message, ex.Message, MessageBoxButton.OK, MessageBoxImage.Error);
                }
                
            }
        }

        /// <summary>
        /// retrieves all the posts for this coin for the database
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<POST> GetPosts()
        {
            ObservableCollection<POST> posts = new ObservableCollection<POST>();

            using (var db = new CoinWatchEntities())
            {
                var query = from postQ in db.POSTs
                            where postQ.COIN_ID == Coin.COIN_ID
                            orderby postQ.DATETIME  
                    select postQ;

                foreach (var itemPost in query)
                {
                    posts.Add(itemPost);
                }
            }

            return posts;
        }

        /// <summary>
        /// deletes the selected post from the post list
        /// </summary>
        public void DeletePost()
        {

            POST itemToDelete;
            //1. Get Account from DB
            using (var db = new CoinWatchEntities())
            {
                itemToDelete =
                    db.POSTs.FirstOrDefault(s => s.POST_ID == SelectedItem.POST_ID);
            }

            //Create new context for disconnected scenario
            using (var db = new CoinWatchEntities())
            {
                db.Entry(itemToDelete).State = System.Data.Entity.EntityState.Deleted;

                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    // TODO review this exception
                    Console.WriteLine(ex);
                    MessageBox.Show("Cannot delete this item");
                }

            }

            Posts.Remove(itemToDelete);
            Posts = GetPosts();

        }

        /// <summary>
        /// updates the selected post from the list of posts
        /// </summary>
        /// <param name="newMessage"></param>
        public void UpdatePost(string newMessage)
        {
            using (var db = new CoinWatchEntities())
            {
                var result = db.POSTs.SingleOrDefault(b => b.POST_ID == SelectedItem.POST_ID);
                if (result != null && newMessage != null)
                {
                    result.MESSAGE = newMessage;
                    db.SaveChanges();
                }
            }

            Posts = GetPosts();
        }

        /// <summary>
        /// allows the current user to follow the coin
        /// </summary>
        public void FollowCoin()
        {

            if (IsFollowed)
            {
                UnfollowCoin();
            }
            else
            {
                using (var db = new CoinWatchEntities())
                {
                    CoinFollow.COIN_ID = Coin.COIN_ID;
                    CoinFollow.USER_ID = 2;
                    db.COIN_FOLLOW.Add(CoinFollow);
                    db.SaveChanges();
                }

                IsFollowed = true;
            }
        }

        /// <summary>
        /// this method determines whether the coin is being followed by the user
        /// </summary>
        /// <returns></returns>
        private bool CheckIfFollowed()
        {
            using (var db = new CoinWatchEntities())
            {
                var query = from fol in db.COIN_FOLLOW
                    where fol.COIN_ID == Coin.COIN_ID && fol.USER_ID == 2
                    select fol;

                return query.Any();
            }
            
        }

        /// <summary>
        /// this is used when the user wants to unfollow the coin theyre following
        /// </summary>
        private void UnfollowCoin()
        {
            // remove entry from table
            COIN_FOLLOW itemToDelete;
            //1. Get Account from DB
            using (var db = new CoinWatchEntities())
            {
                itemToDelete =
                    db.COIN_FOLLOW.FirstOrDefault(s => s.COIN_ID == Coin.COIN_ID && s.USER_ID == 2);
            }

            //Create new context for disconnected scenario
            using (var db = new CoinWatchEntities())
            {
                db.Entry(itemToDelete).State = System.Data.Entity.EntityState.Deleted;

                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    // TODO review this exception
                    Console.WriteLine(ex);
                    MessageBox.Show("Cannot delete this item");
                }

            }

            IsFollowed = false;

        }

        public void SavePriceAlert()
        {

            if (CheckIfPriceAlertExists())
            {
                UpdatePriceAlert();
            }
            else
            {
                // this determines the value to insert into database
                string check = IsGreaterThan ? "Y" : "N";

                using (var db = new CoinWatchEntities())
                {
                    PriceAlert.COIN_ID = Coin.COIN_ID;
                    PriceAlert.USER_ID = 2;
                    PriceAlert.IS_GREATER_THAN = check;
                    PriceAlert.PRICE = (decimal)CoinValue.COIN_VALUE1;
                    db.PRICE_ALERT.Add(PriceAlert);
                    db.SaveChanges();
                    PriceAlertSet = "";
                }
            }
            
        }

        private void UpdatePriceAlert()
        {
            // this determines the value to insert into database
            string check = IsGreaterThan ? "Y" : "N";

            using (var db = new CoinWatchEntities())
            {
                var result = db.PRICE_ALERT.SingleOrDefault(b => b.COIN_ID == Coin.COIN_ID && b.USER_ID == 2);
                if (result != null)
                {
                    result.PRICE = (decimal) CoinValue.COIN_VALUE1;
                    PriceAlert.IS_GREATER_THAN = check;
                    db.SaveChanges();
                }
            }
        }

        private bool CheckIfPriceAlertExists()
        {
            using (var db = new CoinWatchEntities())
            {
                var query = from price in db.PRICE_ALERT
                    where price.COIN_ID == Coin.COIN_ID && price.USER_ID == 2
                    select price;

                return query.Any();
            }
        }
    }
}
