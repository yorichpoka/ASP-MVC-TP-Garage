using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace GestionGarage.Models.Static
{
    public static class GGConvert
    {
        /// <summary>Conevrti er retourne un objet dynamicjson en Objetc </summary>
        public static object To_Object(dynamic dObject)
        {
            return
                new JavaScriptSerializer().Deserialize(
                    JsonConvert.SerializeObject(dObject),
                    typeof(object)
                );
        }

        /// <summary>COnverti un fichier JSON en type_predefini </summary>
        public static T JSON_To<T>(string objet)
        {
            return
                JsonConvert.DeserializeObject<T>(objet);
        }
    }
}