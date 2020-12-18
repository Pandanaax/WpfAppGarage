using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfAppGarage.ViewModel;

namespace WpfAppGarage.Commandes
{
    public class MettreAJourTest : ICommand
    {
        private GestionVoiture gestionVoiture;
      

        public MettreAJourTest(GestionVoiture gestionVoiture)
        {
            this.gestionVoiture = gestionVoiture;
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }

            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            // Binding de commande avec Injection de dépendance - Inversion de controle
            // et utilisation de l'interface ICommand
            // Au lieu des évènements click, utiliser le Binding de command
            MessageBox.Show("Misa a joure en cours ....");
            gestionVoiture.ModifVoitureBase();
        }
    }
}
