using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_WPF.Data.Models
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }

        public string login { get; set; }
        public string password { get; set; }

        public User() {}

        public User(string login, string password, int id) {
            this.id = id;
            this.login = login;
            this.password = password;
        }
    }
}