﻿using GeneCESI.Lib.Objects;
using GeneCESI.Lib.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GeneCESI.Controllers
{
    public class SignUpController : Controller
    {
        UserRepository repoUser = new UserRepository(new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=genecesi1;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"));

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
            return RedirectToAction("Index", "LogIn", new { area = "" });
        }

        public ActionResult error()
        {
            return View();
        }
    }
}