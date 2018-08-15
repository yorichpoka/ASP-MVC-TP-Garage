using GestionGarage.Models.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionGarage.Models.Test
{
    public class BD
    {
        public List<Client> clients { get; set; }
        public List<Vehicule> vehicules { get; set; }

        public BD()
        {
            this.clients = new List<Client>();
            this.vehicules = new List<Vehicule>();
        }
    }
}