using GeneCESI.Lib.Objects;
using GeneCESI.Lib.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GeneCESI.Controllers
{
    public class SignInController : Controller
    {
        UserRepository repoUser = new UserRepository(new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=genecesi1;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"));

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ToLogin(string Email, string Password)
        {
            foreach (User singleUser in repoUser.GetAll())
            {
                if (singleUser.Email == Email && singleUser.Password == Password)
                {
                    return RedirectToAction("Index", "Home", new { area = "" });
                    
                }
            }
            return Redirect("error");
        }

        public ActionResult error()
        {
            return View();
        }
    }
}
