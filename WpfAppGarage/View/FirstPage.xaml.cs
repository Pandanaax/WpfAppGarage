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

namespace WpfAppGarage.View
{
    /// <summary>
    /// Interaction logic for FirstPage.xaml
    /// </summary>
    public partial class FirstPage : Page
    {
        public FirstPage()
        {
            InitializeComponent();
            ChargerListeLivreExterne();
        }

        private void ChargerListeLivreExterne()
        {
            //string _rep = ConfigurationManager.AppSettings["repFileExterne"];

            //var _listFic = Directory.GetFiles(_rep, "*.jpg", SearchOption.TopDirectoryOnly);

            //lstLivreExterne.ItemsSource = _listFic;

            lstVoitureExterne.ItemsSource = Helper.Utils.GetListCar();
        }
    }
}
