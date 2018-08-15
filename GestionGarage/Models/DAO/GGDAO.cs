using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionGarage.Models.DAO
{
    public interface GGDAO
    {
        void Ajouter<T>(T obj);
        void Modifier<T>(T nouveau);
        void Supprimer(int id);
        List<T> Lister<T>();
        T Lister<T>(int id);
    }
}