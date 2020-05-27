using Dari.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DariTn.web.Models
{
    public enum Etat { neuf, ancien }
    public enum Disponibilite { dispo, indispo }
    public enum Livraison { oui, non }
    public class MeubleVM
    {
        public int IdMeuble { get; set; }
        public string Titre { get; set; }
        public int CategoryMeubId { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public double Prix { get; set; }
        public Livraison Livraison { get; set; }
        public Etat Etat { get; set; }

        public Disponibilite Disponibilite { get; set; }
        [DataType(DataType.Date)]
        public DateTime dateAnn { get; set; }
        public int? IdClient { get; set; }

      
    }
}