using System;
using System.Collections.Generic;
using System.IO;
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
using Controllers.Controllers;
using Oracle.ManagedDataAccess.Client;
using Path = System.IO.Path;

namespace CoinWatchViews
{
    /// <summary>
    /// Interaction logic for AddCoinView.xaml
    /// </summary>
    public partial class AddCoinView : UserControl
    {
        private readonly Window _window;
        private readonly AddCoinController _addCoinView = new AddCoinController();
        public AddCoinView(Window window)
        {
            _window = window;
            InitializeComponent();
            DataContext = _addCoinView;
        }

        private void Add_Coin_Click(object sender, RoutedEventArgs e)
        {
            _addCoinView.AddNewCoin();
            _window.DataContext = new AddCoinView(_window);
        }

        private void UploadImage_Click(object sender, RoutedEventArgs e)
        {
            // Configure open file dialog box
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            // Show open file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                // Open document
                _addCoinView.FileName = dlg.FileName;
            }

        }
    }
}
