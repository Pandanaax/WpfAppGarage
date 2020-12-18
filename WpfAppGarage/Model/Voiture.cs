using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppGarage.ViewModel
{
    public class Voiture
    {
        [Key]
        public int Id { get; set; }

        public string Marque { get; set; }
        public string Modele { get; set; }

        public string Photo { get; set; }
        public virtual ICollection<Voiture> Voitures { get; set; }

    }
}
