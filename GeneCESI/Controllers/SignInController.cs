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
        UserRepository repoUser = new UserRepository(new SqlConnection(@"Data Source = (LocalDb)\MSSQLLocalDB;  Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False; AttachDbFilename=" +
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
           @"\GeneCESI_BDD.mdf;"));

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ToLogin(string Email, string Password)
        {
                if (repoUser.UserLoggin(Email,Password)!=null)
                {
                    Session["Id"] = repoUser.UserLoggin(Email, Password).Id;
                    Session["Firstname"] = repoUser.UserLoggin(Email, Password).Firstname;
                    Session["Email"] = repoUser.UserLoggin(Email, Password).Email;
                    Session["Roles"] = repoUser.UserLoggin(Email, Password).Roles;

                return RedirectToAction("Index", "Home", new { area = "" });
                }
                else
                {
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
