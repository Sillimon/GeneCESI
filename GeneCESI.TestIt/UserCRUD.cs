using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using GeneCESI.Lib.Objects;
using GeneCESI.Lib.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GeneCESI.TestIt
{
    [TestClass]
    public class UserCRUD
    {
        static IRepository<User> _userRepo = new UserRepository(new SqlConnection(@"Data Source = (LocalDb)\MSSQLLocalDB;  Integrated Security=SSPI;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False; AttachDbFilename=" +
           Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
           @"\GeneCESI_BDD.mdf;"));

        [TestMethod]
        public bool UserAdd()
        {
            var newUser = new User("Einaudi", "Ludovico", true, "ludo.einaudi@gmail.com", "somePassword");

            try { _userRepo.Insert(newUser); } catch { return false; }

            return true;
        }

        [TestMethod]
        public bool UserDelete()
        {
            var user = new User();
            user.Id = 1;
            try { _userRepo.Delete(user); } catch { return false; }

            return true;
        }

        [TestMethod]
        public bool UserGetById()
        {
            var user = new User();

            try { user = _userRepo.GetById(1); } catch { return false; }

            return true;
        }

        [TestMethod]
        public bool UserGetAll()
        {
            var users = new List<User>();

            try { users = _userRepo.GetAll().ToList<User>(); } catch { return false; }

            foreach (var u in users)
                Console.WriteLine(u.ToString());

            return true;
        }
    }
}
