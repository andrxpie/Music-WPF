using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_WPF.Data.Models
{
    public class User
    {
        public int id { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public static int userCount { get; set; } = 0;

        public User() {
            id = ++userCount;
        }

        public User(string login, string password) {
            id = ++userCount;
            this.login = login;
            this.password = password;
        }
    }
}