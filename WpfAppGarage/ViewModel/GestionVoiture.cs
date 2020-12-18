using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using WpfAppGarage.ViewModel;

namespace WpfAppGarage.Commandes
{
    public class GestionVoiture : IDisposable, INotifyPropertyChanged
    {
        private EFVoiture db = new EFVoiture();

        private string pathImage;

        public event PropertyChangedEventHandler PropertyChanged;

        public string PathImage
        {
            get { return pathImage; }
            set
            {
                pathImage = value;
                // Alors modifer titre -récupére le substring apres le dernier backslash et affiche
                VoitureVM.Modele = pathImage.Substring(pathImage.LastIndexOf("\\") + 1);
                VoitureVM.Marque = VoitureVM.Modele.Substring(0, VoitureVM.Modele.IndexOf("."));

                VoitureVM.Photo = pathImage;
                // si le titre a changé, il faut que le XAML soit au courant de ce changement 
                // et pour celà il faut pathImage notifie le XMAL (annonce son changement)
                //
                //MessageBox.Show(LivreVM.Titre);
                JaiChange("VoitureVM");// cette méthode est souvent appelée : OnPropertyChanged
            }
        }

        private void JaiChange(string v)
        {
            // puisque c'est une notification, il faut vérifier qu'il y des subscribers
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(v));
            }
        }
        public Voiture VoitureVm { get; set; }
        public AjouterVoiture ajouterVoiture { get; set; }

        public SupprimerVoiture supprimerVoiture { get; set; }

        public MettreAJourTest MettreAJourTest { get; set; }

        public ModifierVoiture modifierVoiture { get; set; }

        public ObservableCollection<Voiture> ListeVoiture { get; set; }


        public Voiture VoitureVM { get; set; }


        public GestionVoiture()
        {
            supprimerVoiture = new SupprimerVoiture();
            modifierVoiture = new ModifierVoiture(this); 
            VoitureVm = new Voiture(); 
            VoitureVm.Modele = "titre ";
            VoitureVm.Marque = "Honda";
            ajouterVoiture = new AjouterVoiture(this); 
            MettreAJourTest = new MettreAJourTest(this);
            if (ListeVoiture == null)
                ListeVoiture = new ObservableCollection<Voiture>(db.Voiture.ToList());

        }


        // internal : c'est à l'interieur du même projet
        public bool IsUniqueVoitureModel()
        {

            return true;
        }

        public void AjouterVoitureBase()
        {


            Voiture _v = new Voiture()
            {
                Modele = VoitureVm.Modele,
                Marque = VoitureVm.Marque,
                Photo = VoitureVm.Photo
            };
            // Automaper 
            db.Voiture.Add(VoitureVm);
            // sauvegarde 
            if (db.SaveChanges() > 0)
            {
                _v.Id = VoitureVm.Id;
                ListeVoiture.Add(VoitureVm);
            }
        }
        public void SupprimerVoitureBase()
        {

            MessageBox.Show("Supression voiture en base");
        }
        public void ModifVoitureBase()
        {

            MessageBox.Show("Modification voiture en base");
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}
