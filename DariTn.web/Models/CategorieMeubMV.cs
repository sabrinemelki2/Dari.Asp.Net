using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DariTn.web.Models
{
    public class CategorieMeubMV
    { 
        [Key]
        public int CategoryMeubId { get; set; }
        public string Name { get; set; }
    }
}