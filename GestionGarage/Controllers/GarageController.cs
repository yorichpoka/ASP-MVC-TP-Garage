using GestionGarage.Models.BO;
using GestionGarage.Models.DAO;
using GestionGarage.Models.Static;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionGarage.Controllers
{
    public class GarageController : Controller
    {
        public ClientDAO clientDAO = new ClientDAO();
        public VehiculeDAO vehiculeDAO = new VehiculeDAO();

        [HttpGet]
        public ActionResult Vehicules()
        {
            // -- Charger les données de la page -- //
            Charger_Donnees_Page("Vehicules");

            return View();
        }

        [HttpGet]
        public ActionResult Clients()
        {
            // -- Charger les données de la page -- //
            Charger_Donnees_Page("Clients");

            return View();
        }
        
        public void Charger_Donnees_Page(string page)
        {
            // -- Paramètres à envoyer à la page -- //
            this.ViewBag.donnee = new System.Dynamic.ExpandoObject();
            // -- Variables -- //
            this.ViewBag.donnee.page_vehicules = null;
            this.ViewBag.donnee.page_clients = null;
            this.ViewBag.donnee.bouton_vehicules = null;
            this.ViewBag.donnee.bouton_clients = null;

            #region Vehicules
            if (page == "Vehicules")
            {
                this.ViewBag.donnee.titre = "Gestion des véhicules";
                this.ViewBag.donnee.page_vehicules = "show active";
                this.ViewBag.donnee.bouton_vehicules = "active";
                this.ViewBag.donnee.vehicules = vehiculeDAO.Lister<Vehicule>();
            }
            #endregion

            #region Clients
            else if (page == "Clients")
            {
                this.ViewBag.donnee.titre = "Gestion des clients";
                this.ViewBag.donnee.page_clients = "show active";
                this.ViewBag.donnee.bouton_clients = "active";
                this.ViewBag.donnee.clients = clientDAO.Lister<Client>();
            }
            #endregion
        }

        [HttpPost]
        public ActionResult Ajouter_Enregistrement(string page, string obj)
        {
            try
            {
                // -- Selectionner en fonction du menu - //
                #region Clients
                if (page == "Clients")
                {
                    // -- Service d'enregistrement -- //
                    clientDAO.Ajouter(GGConvert.JSON_To<Client>(obj));
                }
                #endregion

                #region Vehicules
                else if (page == "Vehicules")
                {
                    // -- Service d'enregistrement -- //
                    vehiculeDAO.Ajouter(GGConvert.JSON_To<Vehicule>(obj));
                }
                #endregion

                // -- Notificication -- //
                this.ViewBag.exception = null;
            }
            #region Catch
            catch (Exception ex)
            {
                // -- Notificication -- //
                this.ViewBag.exception = ex.Message;
            }
            #endregion

            // -- Retoure le résultat en objet JSON -- //
            return Json(
                GGConvert.To_Object(this.ViewBag)
            );
        }

        [HttpPost]
        public ActionResult Modifier_Enregistrement(string obj, string page)
        {
            try
            {
                // -- Selectionner en fonction du menu - //
                #region Clients
                if (page == "Clients")
                {
                    // -- Service de modification -- //
                    clientDAO.Modifier<Client>(GGConvert.JSON_To<Client>(obj));
                }
                #endregion

                #region Vehicules
                else if (page == "Vehicules")
                {
                    // -- Service de modification -- //
                    vehiculeDAO.Modifier<Vehicule>(GGConvert.JSON_To<Vehicule>(obj));
                }
                #endregion

                // -- Notificication -- //
                this.ViewBag.exception = null;
            }
            #region Catch
            catch (Exception ex)
            {
                // -- Notificication -- //
                this.ViewBag.exception = ex.Message;
            }
            #endregion

            // -- Retoure le résultat en objet JSON -- //
            return Json(
                GGConvert.To_Object(this.ViewBag)
            );
        }

        [HttpPost]
        public ActionResult Supprimer_Enregistrement(int id, string page)
        {
            try
            {
                // -- Selectionner en fonction du menu - //
                #region Clients
                if (page == "Clients")
                {
                    // -- Service de suppression -- //
                    clientDAO.Supprimer(id);
                }
                #endregion

                #region Vehicules
                else if (page == "Vehicules")
                {
                    // -- Service de suppression -- //
                    vehiculeDAO.Supprimer(id);
                }
                #endregion

                // -- Notificication -- //
                this.ViewBag.exception = null;
            }
            #region Catch
            catch (Exception ex)
            {
                // -- Notificication -- //
                this.ViewBag.exception = ex.Message;
            }
            #endregion

            // -- Retoure le résultat en objet JSON -- //
            return Json(
                GGConvert.To_Object(this.ViewBag)
            );
        }

        [HttpGet]
        public ActionResult Charger_Table(string page)
        {
            // -- Selectionner en fonction du menu - //
            #region Clients
            if (page == "Clients")
            {
                return PartialView("Clients/_Table", clientDAO.Lister<Client>());
            }
            #endregion

            #region Vehicules
            else if (page == "Vehicules")
            {
                return PartialView("Vehicules/_Table", vehiculeDAO.Lister<Vehicule>());
            }
            #endregion

            else
                return null;
        }

        [HttpPost]
        public ActionResult Selection_Enregistrement(int id, string page)
        {
            try
            {
                // -- Selectionner en fonction du menu - //
                #region Clients
                if (page == "Clients")
                {
                    // -- Service de selection -- //
                    Client donnee = clientDAO.Lister<Client>(id);

                    if (donnee == null)
                    {
                        throw new Exception("Aucune données n'a été trouvée!");
                    }

                    this.ViewBag.donnee = donnee;
                }
                #endregion

                #region Vehicules
                else if (page == "Vehicules")
                {
                    // -- Service de selection -- //
                    Vehicule donnee = vehiculeDAO.Lister<Vehicule>(id);

                    if (donnee == null)
                    {
                        throw new Exception("Aucune données n'a été trouvée!");
                    }

                    this.ViewBag.donnee = donnee;
                }
                #endregion

                // -- Notificication -- //
                this.ViewBag.exception = null;
            }
            #region Catch
            catch (Exception ex)
            {
                // -- Notificication -- //
                this.ViewBag.exception = ex.Message;
            }
            #endregion

            // -- Retoure le résultat en objet JSON -- //
            return Json(
                GGConvert.To_Object(this.ViewBag)
            );
        }
    }
}