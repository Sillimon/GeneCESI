using GeneCESI.Lib.Objects;
using GeneCESI.Lib.Repositories;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GeneCESI.Controllers
{
    public class SignInController : Controller
    {
        UserRepository repoUser = new UserRepository(new SqliteConnection(@"Data Source=" +
           Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()))) +
           @"\GeneCESI_DB.db;"));

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
