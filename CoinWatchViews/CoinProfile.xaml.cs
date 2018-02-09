using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CoinWatch;
using Controllers;
using Controllers.Controllers;

namespace CoinWatchViews
{
    /// <summary>
    /// Interaction logic for CoinProfile.xaml
    /// </summary>
    public partial class CoinProfile : UserControl
    {
        private readonly CoinProfileController _coinProfile;

        public CoinProfile(string coinName)
        {
            InitializeComponent();
            _coinProfile = new CoinProfileController(coinName);
            DataContext = _coinProfile;
        }

        private void Follow_Button_Click(object sender, RoutedEventArgs e)
        {
            if (_coinProfile.IsFollowed)
                MessageBox.Show("You are no longer following " + _coinProfile.Coin.COIN_NAME);
            else
                MessageBox.Show("You are now following " + _coinProfile.Coin.COIN_NAME);

            _coinProfile.FollowCoin();
        }

        private void Toggle(object sender, MouseEventArgs e)
        {
            // if the coin id being followed by the current user
            // when the button is hovered over it will toggle
            // unfollow on the button

        }


        private void UpdateAllOnClick(object sender, RoutedEventArgs e)
        {
            _coinProfile.UpdateAllOnClick(sender, e);
        }

        private void Submit_Post_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _coinProfile.SavePost();
            }
            catch (DbEntityValidationException eX)
            {
                foreach (var eve in eX.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Value: \"{1}\", Error: \"{2}\"",
                            ve.PropertyName,
                            eve.Entry.CurrentValues.GetValue<object>(ve.PropertyName),
                            ve.ErrorMessage);

                        MessageBox.Show(ve.ErrorMessage, ve.PropertyName, MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            
        }

        private void Delete_Post(object sender, RoutedEventArgs e)
        {
            _coinProfile.DeletePost();
        }

        private void Update_Post(object sender, RoutedEventArgs e)
        {
            string newMessage = Microsoft.VisualBasic.Interaction.InputBox
                (
                    "Change Message", 
                    "Your Post", 
                    _coinProfile.SelectedItem.MESSAGE

                );
            _coinProfile.UpdatePost(newMessage);

        }

        private void PostList_OnGotFocus(object sender, RoutedEventArgs e)
        {
            _coinProfile.SelectedItem = CoinWatchUtils.List_OnGotFocus<POST>(LbPostList, e);
        }

        private void ChangeCondition_Click(object sender, RoutedEventArgs e)
        {
            _coinProfile.IsGreaterThan = _coinProfile.IsGreaterThan == false;
        }

        private void SavePriceAlert_Click(object sender, RoutedEventArgs e)
        {
            _coinProfile.SavePriceAlert();
        }
    }
}
