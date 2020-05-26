using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneCESI.Lib.Repositories
{
    public class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Firstname { get; set; }
        public bool Roles { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public static void CreateUser(Users user)
        {

        }

        public static void UpdateUser(Users user)
        {

        }

        public static Users GetUser(string name, string firstName)
        {

        }

        public static void DeleteUser(int id)
        {

        }
    }
}
