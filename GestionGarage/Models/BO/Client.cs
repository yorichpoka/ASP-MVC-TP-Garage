using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionGarage.Models.BO
{
    public class Client
    {
        public int id { get; set; }
        public string code { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
    }
}