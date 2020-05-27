using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dari.Domain.Entities
{
    public enum Etat { neuf, ancien }
    public enum Disponibilite { dispo, indispo }
    public enum Livraison { oui, non }
    public class Meuble
    {
        [Key]
        public int IdMeuble { get; set; }
        [Required]
        public string Titre { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public double Prix { get; set; }
        public Livraison Livraison { get; set; }
        public Etat Etat { get; set; }

        public Disponibilite Disponibilite { get; set; }

        public DateTime dateAnn { get; set; }
        public int? IdClient { get; set; }
        [ForeignKey("IdClient")]
        public virtual Client Client { get; set; }
        public int? CategoryMeubId { get; set; }

        [ForeignKey("CategoryMeubId")]
        public virtual CategorieMeub MyCategory { get; set; }

    }
}
