using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DariTn.web.Models
{
    public class AnnonceVM
    {
        public int AnnonceId { get; set; }
        
        public string Description { get; set; }
        public string address { get; set; }
        public float surface { get; set; }
        public int chambres { get; set; }

        public string images { get; set; }
    }
}