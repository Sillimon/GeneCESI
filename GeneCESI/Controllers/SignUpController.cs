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
    public class SignUpController : Controller
    {
        //accès à la base de données
        UserRepository repoUser = new UserRepository(new SqlConnection(@"Data Source = (LocalDb)\MSSQLLocalDB;  Integrated Security=SSPI;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False; AttachDbFilename=" +
           Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
           @"\GeneCESI_BDD.mdf;"));

        public ActionResult Index()
        {
            return View();
        }
        //Inscription de l'utilisateur
        public ActionResult Register(string Name, string Firstname, bool Roles, string Email, string Password)
        {
            //Vérification de la présence de l'identifiant dans la base de données
            foreach (User singleUser in repoUser.GetAll())
            {
                if (singleUser.Email == Email)
                {
                    //Renvoi vers une page d'érreur
                    return Redirect("error");
                }
            }
            //Ajout de l'utilisateur à la base de données
            repoUser.Insert(new User(Name, Firstname, Roles, Email, Password));
            //Renvoi vers la page de connexion
            return RedirectToAction("Index", "SignIn", new { area = "" });
        }

        public ActionResult error()
        {
            return View();
        }
    }
}