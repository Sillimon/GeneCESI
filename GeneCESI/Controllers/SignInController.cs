using GeneCESI.Lib.Objects;
using GeneCESI.Lib.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GeneCESI.Controllers
{
    public class SignInController : Controller
    {
        //Accès à la base de données
        UserRepository repoUser = new UserRepository(new SqlConnection(@"Data Source = (LocalDb)\MSSQLLocalDB;  Integrated Security=SSPI;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False; AttachDbFilename=" +
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
           @"\GeneCESI_BDD.mdf;"));

        public ActionResult Index()
        {
            return View();
        }
        //Authentification de l'utilisateur
        public ActionResult ToLogin(string Email, string Password)
        {
            //Vérification des information entrée dans le formulaire de connexion
            //Note: - La restriction d'accès à certaines page n'a pas été implémenté dû
            //        aux difficultés techniques rencontrées avec la création de la base de données
            //      - Par la suite les actions liées à la création des examens auraient nécessité l'appel
            //        de la fonction vériant si l'utilisateur est un admin ou non
            User user = repoUser.UserLoggin(Email, Password);
            if (user != null)
            {
                Session["Id"] = user.Id;
                Session["Firstname"] = user.Firstname;
                Session["Email"] = user.Email;
                Session["Roles"] = user.Roles;
                //Retour à la page d'acceuil
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            else
            {
                //Renvoi vers une page d'érreur
                return Redirect("error");
            }
        }

        public ActionResult ToLogout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home", new { area = "" });
        }

        public ActionResult error()
        {
            return View();
        }
    }
}
