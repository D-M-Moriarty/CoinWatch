using System;
using System.Collections.Generic;
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
using Controllers;

namespace CoinWatchViews
{
    /// <summary>
    /// Interaction logic for CoinListView.xaml
    /// </summary>
    public partial class CoinListView : UserControl
    {
        private readonly CoinListController _coinList = new CoinListController();
        private readonly Window _window;
        public CoinListView(Window window)
        {
            InitializeComponent();
            DataContext = _coinList;
            _window = window;
        }

        private void CoinList_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            _coinList.SelectedItem = CoinWatchUtils.List_OnGotFocus<CoinListController.CNameCPrice>(CoinList, e);
            string coinName = _coinList.SelectedItem.CoinName;
            _window.DataContext = new CoinProfile(coinName);
        }
    }
}
