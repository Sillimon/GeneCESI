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
        UserRepository repoUser = new UserRepository(new SqlConnection(@"Data Source = (LocalDb)\MSSQLLocalDB;  Integrated Security=SSPI;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False; AttachDbFilename=" +
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
           @"\GeneCESI_BDD.mdf;"));

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ToLogin(string Email, string Password)
        {
            User user = repoUser.UserLoggin(Email, Password);
            if (user != null)
            {
                Session["Id"] = user.Id;
                Session["Firstname"] = user.Firstname;
                Session["Email"] = user.Email;
                Session["Roles"] = user.Roles;

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
