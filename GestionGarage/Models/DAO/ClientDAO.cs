using GestionGarage.Models.BO;
using GestionGarage.Models.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionGarage.Models.DAO
{
    public class ClientDAO : GGDAO
    {
        public void Ajouter<T>(T obj)
        {
            // -- Vérification du code -- //
            if (Program.db.clients.Exists(l => l.code == (obj as Client).code))
            {
                throw new Exception("Ce code existe déjà !");
            }

            // -- Mise à jour de l'id -- //
            (obj as Client).id = Program.db.clients.Count + 1;

            Program.db.clients.Add(obj as Client);
        }

        public T Lister<T>(int id)
        {
            return
                (T)Convert.ChangeType(
                    Program.db.clients.FirstOrDefault(l => l.id == id), 
                    typeof(T)
                );
        }

        public List<T> Lister<T>()
        {
            return
                Program.db.clients.ToList().Cast<T>().ToList();
        }

        public void Modifier<T>(T nouveau)
        {
            // -- Vérification du code -- //
            if (Program.db.clients.Exists(l => l.id != (nouveau as Client).id && l.code == (nouveau as Client).code))
            {
                throw new Exception("Ce code existe déjà !");
            }

            // -- Mise à jour de la données -- //
            Program.db.clients.Where(l => l.id == (nouveau as Client).id).ToList().ForEach(l =>
            {
                l.code = (nouveau as Client).code;
                l.nom = (nouveau as Client).nom;
                l.prenom = (nouveau as Client).prenom;
            });
        }

        public void Supprimer(int id)
        {
            Program.db.clients.RemoveAll(l => l.id == id);
        }
    }
}