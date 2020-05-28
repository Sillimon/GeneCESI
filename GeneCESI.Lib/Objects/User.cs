using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GeneCESI.Lib.Objects
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Firstname { get; set; }
        public bool Roles { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public User() { }
        public User(string name, string firstname, bool roles, string email, string password, int id = 0)
            => (this.Id, this.Name, this.Firstname, this.Roles, this.Email, this.Password) = (id, name, firstname, roles, email, password);

        public bool isAdmin => this.Roles;
    }
}
