using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionGarage.Models.BO
{
    public class Vehicule
    {
        public int id { get; set; }
        public string code { get; set; }
        public string libelle { get; set; }
        public string marque { get; set; }
    }
}