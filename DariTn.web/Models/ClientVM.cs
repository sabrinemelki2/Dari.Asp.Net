using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DariTn.web.Models
{
    public class ClientVM
    {
        public int IdClient { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Tel { get; set; }
        public string Mail { get; set; }
        
    }
}