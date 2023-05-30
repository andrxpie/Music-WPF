using Music_WPF.Data.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Music_WPF
{
    /// <summary>
    /// Interaction logic for MusicListWindow.xaml
    /// </summary>
    public partial class MusicListWindow : Window
    {
        public List<MusicAlbumn> musicAlbumns;

        public MusicListWindow(int id)
        {
            InitializeComponent();
            GetMusicAlbumns();
        }

        public void GetMusicAlbumns()
        {
            using(SQLiteConnection connection = new SQLiteConnection(App.dbPath))
            {
                connection.CreateTable<MusicAlbumn>();

                try
                {
                    musicAlbumns = connection.Table<MusicAlbumn>().ToList();
                    albumnsListBox.ItemsSource = musicAlbumns;
                }
                catch
                {
                    MessageBox.Show("No albumns found", "Message", MessageBoxButton.OK);
                }
            }
        }
    }
}
