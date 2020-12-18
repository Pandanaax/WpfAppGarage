using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfAppGarage.ViewModel;

namespace WpfAppGarage.Commandes
{
    public class AjouterVoiture : ICommand
    {
        public GestionVoiture gestionVoiture;

       public AjouterVoiture()
        {

        }
        public AjouterVoiture(GestionVoiture gestionVoiture)
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
            bool _ok = false;
            if (parameter != null)
            {
                _ok = gestionVoiture.IsUniqueVoitureModel();
                Voiture voiture = (Voiture)parameter;

                _ok = voiture.Marque.Length > 2;
            }

            return _ok;
        }
        public void Execute(object parameter)
        {
            gestionVoiture.AjouterVoitureBase();
        }
    }
}
