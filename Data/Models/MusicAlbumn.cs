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
        public uint year { get; set; }
        public uint userID { get; set; }

        public MusicAlbumn() { }

        public MusicAlbumn(string name, string author, uint year, uint userID)
        {
            this.name = name;
            this.author = author;
            this.year = year;
            this.userID = userID;
        }
    }
}