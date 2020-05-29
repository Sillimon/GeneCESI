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
    public class SignUpController : Controller
    {
        UserRepository repoUser = new UserRepository(new SqliteConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" +
            Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()))) +
            @"\GeneCESI_BDD.mdf;Integrated Security=True;Connect Timeout=30"));

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register(string Name, string Firstname, bool Roles, string Email, string Password)
        {
            foreach (User singleUser in repoUser.GetAll())
            {
                if (singleUser.Email == Email)
                {
                    return Redirect("error");
                }
            }
            repoUser.Insert(new User(Name, Firstname, Roles, Email, Password));
            return RedirectToAction("Index", "SignIn", new { area = "" });
        }

        public ActionResult error()
        {
            return View();
        }
    }
}