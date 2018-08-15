using GestionGarage.Models.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GestionGarage.Models.BO;

namespace GestionGarage.Models.DAO
{
    public class VehiculeDAO : GGDAO
    {
        public void Ajouter<T>(T obj)
        {
            // -- Vérification du code -- //
            if (Program.db.vehicules.Exists(l => l.code == (obj as Vehicule).code))
            {
                throw new Exception("Ce code existe déjà !");
            }

            // -- Mise à jour de l'id -- //
            (obj as Vehicule).id = Program.db.vehicules.Count + 1;

            Program.db.vehicules.Add(obj as Vehicule);
        }

        public T Lister<T>(int id)
        {
            return
                (T)Convert.ChangeType(
                    Program.db.vehicules.FirstOrDefault(l => l.id == id),
                    typeof(T)
                );
        }

        public List<T> Lister<T>()
        {                
            return
                Program.db.vehicules.ToList().Cast<T>().ToList();
        }

        public void Modifier<T>(T nouveau)
        {
            // -- Vérification du code -- //
            if (Program.db.vehicules.Exists(l => l.id != (nouveau as Vehicule).id && l.code == (nouveau as Vehicule).code))
            {
                throw new Exception("Ce code existe déjà !");
            }

            // -- Mise à jour de la données -- //
            Program.db.vehicules.Where(l => l.id == (nouveau as Vehicule).id).ToList().ForEach(l => 
            {
                l.code = (nouveau as Vehicule).code;
                l.libelle = (nouveau as Vehicule).libelle;
                l.marque = (nouveau as Vehicule).marque;
            });
        }

        public void Supprimer(int id)
        {
            Program.db.vehicules.RemoveAll(l => l.id == id);
        }
    }
}