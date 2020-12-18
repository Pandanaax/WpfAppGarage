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
    public class ModifierVoiture : ICommand
    {
        private GestionVoiture gestionVoiture;

        public ModifierVoiture(GestionVoiture gestionVoiture)
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
            Voiture voiture = (Voiture)parameter;
            MessageBox.Show("Modif en cours ..." + voiture.Marque);
            // Cette classe est une classe de relaie (Relay Command)
            // La modif est faite par la classe GestionLivre
            gestionVoiture.ModifVoitureBase();
        }
    }
}
