using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_WPF.Data.Models
{
    public class MusicAlbumn
    {
        public string name { get; set; }
        public string author { get; set; }
        public int year { get; set; }
        [PrimaryKey]
        public int userID { get; set; }

        public MusicAlbumn() { }

        public MusicAlbumn(string name, string author, int year, int userID)
        {
            this.name = name;
            this.author = author;
            this.year = year;
            this.userID = userID;
        }
    }
}