using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Music_WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static string dbName = "Database.db";
        public static string folder = Directory.GetCurrentDirectory();
        public static string dbPath = Path.Combine(folder, dbName); 
    }
}
