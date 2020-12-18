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
using WpfAppGarage.Commandes;

namespace WpfAppGarage.View
{
    /// <summary>
    /// Interaction logic for NewPage.xaml
    /// </summary>
    public partial class NewPage : Page
    {
        public NewPage()
        {
            InitializeComponent();
            ChargerListeVoitureExterne();
            GestionVoiture gestionVoiture = new GestionVoiture();
            DataContext = gestionVoiture;

        }

        private void ChargerListeVoitureExterne()
        {

            cbbListeVoitureSource.ItemsSource = Helper.Utils.GetListCar();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}