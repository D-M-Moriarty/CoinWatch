using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoinWatch;

namespace Controllers.Controllers
{
    public class AddCoinController : ObservableObject
    {
        // Coin object that is being saved
        private COIN _coin;
        public COIN Coin
        {
            get { return _coin; }
            set
            {
                if (value != _coin)
                {
                    _coin = value;
                    OnPropertyChanged("Coin");
                }
            }
        }

        // the path to file on the local machine
        private string _filename;
        public string FileName
        {
            get { return _filename; }
            set
            {
                if (value != _filename)
                {
                    _filename = value;
                    OnPropertyChanged("FileName");
                }
            }
        }

        // constructor making an instance of the coin
        public AddCoinController()
        {
            Coin = new COIN();
        }

        // method to save the coin to the database
        public void AddNewCoin()
        {
            using (var db = new CoinWatchEntities())
            {
                // converting the image path to a byte array
                byte[] byteImage = File.ReadAllBytes(FileName);
                Coin.IMAGE = byteImage;
                db.COINs.Add(Coin);
                db.SaveChanges();
            }
        }
    }
}
